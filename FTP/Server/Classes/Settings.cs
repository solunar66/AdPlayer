using System;
using System.IO;
using System.Xml;
using System.Net;
using System.Text;
using System.Data;

namespace FTP
{
    enum SettingsKey
    {
        MAX_PASSV_PORT,
        MIN_PASSV_PORT,
        FTP_PORT,
        AUTO_START_FTP,
        ENABLE_FTP_LOGGING,
        HTTP_PORT,
        AUTO_START_HTTP,
        HTTP_LOGIN_ID,
        HTTP_PASSWORD,
        ENABLE_NOTIFY_ICON,
        ENABLE_FTPFOLDER_ICON,
        ENABLE_QUICK_CONFIG_MENU,
        AUTO_SEND_ERROR_REPORT,
        ENABLE_APD,
        MOVE_FILES_TO_RECYCLE_BIN,
        DATE_TIME_FORMAT
    }

    class ApplicationSettings
    {
        #region Declerations
        internal static XmlDocument Settings;
        internal static FTPServer FtpServer;
        internal static HTTPServer HttpServer;
        internal static DriveInfo[] Drives;
        static string _HostName, _DataPath;
        #endregion

        #region Properties

        #region Other Settings
        internal static string DataPath
        {
            get
            {
                return _DataPath;
            }
        }
        internal static bool AutoStartFTP
        {
            get
            {
                return GetSettingsAsBool(SettingsKey.AUTO_START_FTP);
            }
            set
            {
                ChangeSettings(SettingsKey.AUTO_START_FTP, value);
            }
        }
        internal static bool AutoStartHTTP
        {
            get
            {
                return GetSettingsAsBool(SettingsKey.AUTO_START_HTTP);
            }
            set
            {
                ChangeSettings(SettingsKey.AUTO_START_HTTP, value);
            }
        }
        internal static bool EnableFTPLogging
        {
            get
            {
                return GetSettingsAsBool(SettingsKey.ENABLE_FTP_LOGGING);
            }
            set
            {
                ChangeSettings(SettingsKey.ENABLE_FTP_LOGGING, value);
            }
        }
        internal static string HostName
        {
            get
            {
                return _HostName;
            }
        }
        internal static string UserName
        {
            get
            {
                return GetSettingsAsString(SettingsKey.HTTP_LOGIN_ID);
            }
            set
            {
                ChangeSettings(SettingsKey.HTTP_LOGIN_ID, value);
            }
        }
        internal static string Password
        {
            get
            {
                return GetSettingsAsString(SettingsKey.HTTP_PASSWORD);
            }
            set
            {
                ChangeSettings(SettingsKey.HTTP_PASSWORD, value);
            }
        }
        internal static int FTPPort
        {
            get
            {
                return Convert.ToInt32(GetSettingsAsString(SettingsKey.FTP_PORT));
            }
            set
            {
                ChangeSettings(SettingsKey.FTP_PORT, value.ToString());
            }
        }
        internal static int HTTPPort
        {
            get
            {
                return Convert.ToInt32(GetSettingsAsString(SettingsKey.HTTP_PORT));
            }
            set
            {
                ChangeSettings(SettingsKey.HTTP_PORT, value.ToString());
            }
        }
        internal static int MaxPassvPort
        {
            get
            {
                return Convert.ToInt32(GetSettingsAsString(SettingsKey.MAX_PASSV_PORT));
            }
            set
            {
                ChangeSettings(SettingsKey.MAX_PASSV_PORT, value.ToString());
            }
        }
        internal static int MinPassvPort
        {
            get
            {
                return Convert.ToInt32(GetSettingsAsString(SettingsKey.MIN_PASSV_PORT));
            }
            set
            {
                ChangeSettings(SettingsKey.MIN_PASSV_PORT, value.ToString());
            }
        }
        #endregion

        #region General settings
        internal static bool EnableNotifyIcon
        {
            get
            {
                return GetSettingsAsBool(SettingsKey.ENABLE_NOTIFY_ICON);
            }
            set
            {
                ChangeSettings(SettingsKey.ENABLE_NOTIFY_ICON, value);
            }
        }
        internal static bool ChangeFTPFoldersIcon
        {
            get
            {
                return GetSettingsAsBool(SettingsKey.ENABLE_FTPFOLDER_ICON);
            }
            set
            {
                if (GetSettingsAsBool(SettingsKey.ENABLE_FTPFOLDER_ICON))
                {
                    if (!value)
                    {
                        XmlNodeList UserList = GetUserList();

                        foreach (XmlNode User in UserList)
                            RemoveFolderIcon(User.Attributes["Root"].Value);
                    }
                }
                else
                {
                    if (value)
                    {
                        XmlNodeList UserList = GetUserList();

                        foreach (XmlNode User in UserList)
                            SetFolderIcon(User.Attributes["Root"].Value);
                    }
                }
                ChangeSettings(SettingsKey.ENABLE_FTPFOLDER_ICON, value);
            }
        }
        internal static bool EnableQuickConfigMenu
        {
            get
            {
                return GetSettingsAsBool(SettingsKey.ENABLE_QUICK_CONFIG_MENU);
            }
            set
            {
                ChangeSettings(SettingsKey.ENABLE_QUICK_CONFIG_MENU, value);
            }
        }
        internal static bool AutoSendErrorReport
        {
            get
            {
                return GetSettingsAsBool(SettingsKey.AUTO_SEND_ERROR_REPORT);
            }
            set
            {
                ChangeSettings(SettingsKey.AUTO_SEND_ERROR_REPORT, value);
            }
        }
        internal static bool DefineFileAccessPermission
        {
            get
            {
                return GetSettingsAsBool(SettingsKey.ENABLE_APD);
            }
            set
            {
                ChangeSettings(SettingsKey.ENABLE_APD, value);
            }
        }
        internal static bool MoveDeletedFilesToRecycleBin
        {
            get
            {
                return GetSettingsAsBool(SettingsKey.MOVE_FILES_TO_RECYCLE_BIN);
            }
            set
            {
                ChangeSettings(SettingsKey.MOVE_FILES_TO_RECYCLE_BIN, value);
            }
        }
        internal static string DateTimeFormat
        {
            get
            {
                return GetSettingsAsString(SettingsKey.DATE_TIME_FORMAT);
            }
            set
            {
                ChangeSettings(SettingsKey.DATE_TIME_FORMAT, value);
            }
        }
        #endregion

        #endregion

        #region General Methods

        internal static void ReadSettings()
        {
            Drives = DriveInfo.GetDrives();
            _HostName = Dns.GetHostName();
            _DataPath = System.Windows.Forms.Application.StartupPath;
            if (!_DataPath.EndsWith("\\")) _DataPath += "\\";

            Settings = new XmlDocument();

            try
            {
                if (File.Exists(DataPath + "Settings.dat"))
                {
                    FileStream RawStream = new FileStream(DataPath + "Settings.dat", FileMode.Open, FileAccess.Read);

                    byte[] Buffer = new byte[(int)RawStream.Length];
                    RawStream.Read(Buffer, 0, Buffer.Length);
                    RawStream.Close(); RawStream = null;

                    Buffer = Crypt(Buffer);

                    MemoryStream Stream = new MemoryStream(Buffer);
                    TextReader Reader = new StreamReader(Stream, Encoding.UTF8);

                    Settings.Load(Reader);
                    Reader.Close(); Stream.Close();
                    Buffer = null;
                }
                else Settings.LoadXml(global::FTP.Properties.Resources.Settings);
            }
            catch (Exception Ex)
            {
                ApplicationLog.Write(LogSource.FTP, Ex);
            }
        }

        internal static void SaveSettings()
        {
            try
            {
                MemoryStream Stream = new MemoryStream();
                TextWriter TxtWriter = new StreamWriter(Stream, Encoding.UTF8);
                Settings.Save(TxtWriter);
                
                byte[] Buff = Crypt(Stream.GetBuffer());
                FileStream FS = new FileStream(DataPath + "Settings.dat", FileMode.Create, FileAccess.Write);
                FS.Write(Buff, 0, Buff.Length);
                FS.Close(); FS = null;
                TxtWriter.Close(); Stream.Close();
            }
            catch (Exception Ex)
            {
                ApplicationLog.Write(LogSource.FTP, Ex);
            }
        }

        static byte[] Crypt(byte[] Buffer)
        {
            for (int i = 0; i < Buffer.Length; i++)
            {
                Buffer[i] ^= 36;
            }
            return Buffer;
        }

        static void SetFolderIcon(string Path)
        {
            if (!ChangeFTPFoldersIcon) return;
            try
            {
                if (Directory.Exists(Path))
                {
                    // Create Icon information file
                    string IconFileInfo = System.IO.Path.Combine(Path, "Desktop.ini");
                    if (File.Exists(IconFileInfo))
                    {
                        File.SetAttributes(IconFileInfo, FileAttributes.Normal);
                        File.Move(IconFileInfo, "_Desktop.ini");
                    }

                    StreamWriter SW = new StreamWriter(IconFileInfo);
                    SW.WriteLine("[.ShellClassInfo]");
                    SW.WriteLine(@"IconFile=" + System.IO.Path.Combine(_DataPath, "Icons\\Folder.ico"));
                    SW.WriteLine("IconIndex=0");
                    SW.WriteLine("SET_BY_ADVFTPSVR");
                    SW.Close(); SW = null;

                    // Hide the icon informaion file
                    File.SetAttributes(IconFileInfo, FileAttributes.Hidden | FileAttributes.System);
                    File.SetAttributes(System.IO.Path.Combine(Path, "_Desktop.ini"), FileAttributes.Hidden | FileAttributes.System);
                }
            }
            catch { }
        }

        static void RemoveFolderIcon(string Path)
        {
            if (!ChangeFTPFoldersIcon) return;
            try
            {
                if (Directory.Exists(Path))
                {
                    // Create Icon information file
                    string IconFileInfo = System.IO.Path.Combine(Path, "Desktop.ini");
                    bool DeleteFile = true;
                    if (File.Exists(IconFileInfo))
                    {
                        StreamReader SR = new StreamReader(IconFileInfo);
                        DeleteFile = (SR.BaseStream.Length < 1024 && SR.ReadToEnd().IndexOf("SET_BY_ADVFTPSVR") != -1);
                        SR.Close(); SR = null;
                        if (DeleteFile) File.Delete(IconFileInfo);
                    }
                    if (File.Exists(System.IO.Path.Combine(Path, "_Desktop.ini")))
                    {
                        if (DeleteFile)
                        {
                            File.SetAttributes(System.IO.Path.Combine(Path, "_Desktop.ini"), FileAttributes.Normal);
                            File.Move(System.IO.Path.Combine(Path, "_Desktop.ini"), "Desktop.ini");
                        }
                        else File.Delete(System.IO.Path.Combine(Path, "_Desktop.ini"));
                    }

                    // Hide the icon informaion file
                    File.SetAttributes(IconFileInfo, FileAttributes.Hidden | FileAttributes.System);
                }
            }
            catch { }
        }

        static string GetSettingsAsString(SettingsKey Key)
        {
            XmlNodeList SettingsList = Settings.DocumentElement.SelectSingleNode("SETTINGS").ChildNodes;
            string returnValue = string.Empty;

            foreach (XmlNode Setting in SettingsList)
            {
                if (Setting.Attributes["NAME"].Value != Key.ToString()) continue;

                returnValue = Setting.Attributes["VALUE"].Value;
                break;
            }
            return returnValue;
        }

        static bool GetSettingsAsBool(SettingsKey Key)
        {
            return GetSettingsAsString(Key) == "1";
        }

        static void ChangeSettings(SettingsKey Key, string Value)
        {
            XmlNode SettingsNode = Settings.DocumentElement.SelectSingleNode("SETTINGS");

            foreach (XmlNode Setting in SettingsNode.ChildNodes)
            {
                if (Setting.Attributes["NAME"].Value != Key.ToString()) continue;

                Setting.Attributes["VALUE"].Value = Value;
                return;
            }
            XmlNode NewSetting = Settings.CreateElement("KEY");
            XmlAttribute Attrib = Settings.CreateAttribute("NAME");
            Attrib.Value = Key.ToString();
            NewSetting.Attributes.Append(Attrib);

            Attrib = Settings.CreateAttribute("NAME");
            Attrib.Value = Value;
            NewSetting.Attributes.Append(Attrib);

            SettingsNode.AppendChild(NewSetting);
        }

        static void ChangeSettings(SettingsKey Key, bool Value)
        {
            ChangeSettings(Key, (Value) ? "1" : "0");
        }

        internal static DataTable GetExceptionLog(DateTime StartDate, DateTime EndDate,
            DateTime StartTime, DateTime EndTime, bool FtpExceptions, bool HttpExceptions, ref bool CancelSearch)
        {
            string LogPath = Path.Combine(_DataPath, "Logs");

            if (!Directory.Exists(LogPath)) return null;

            DataTable Result = new DataTable();
            Result.Columns.Add("ErrorSource");
            Result.Columns.Add("DateTime", Type.GetType("System.DateTime"));
            Result.Columns.Add("Exception");
            Result.Columns.Add("Message");
            Result.Columns.Add("Source");
            Result.Columns.Add("Stack");
            Result.Columns.Add("TargetSite");

            XmlDocument ErrorDocument = new XmlDocument();

            TimeSpan DateDiff = EndDate - StartDate;
            TimeSpan TimeDiff = EndTime - StartTime;

            string[] LogFileList = new string[(int)DateDiff.TotalDays + 1];
            string[] DateList = new string[(int)DateDiff.TotalDays + 1];

            for (int i = 0; i < LogFileList.Length; i++)
            {
                LogFileList[i] = Path.Combine(LogPath, StartDate.ToString("LOG.yyyy-MM-dd.EXCEPTION"));
                DateList[i] = StartDate.ToString("yyyy-MM-dd");
                StartDate = StartDate.AddDays(1);
            }

            for (int i = 0; i < LogFileList.Length; i++)
            {
                string CurrentFile = LogFileList[i];
                if (!File.Exists(CurrentFile)) continue;

                try
                {
                    ErrorDocument.Load(CurrentFile);

                    XmlNodeList LogList = ErrorDocument.DocumentElement.ChildNodes;

                    foreach (XmlNode Log in LogList)
                    {
                        try
                        {
                            if (!(FtpExceptions && Log.Attributes["SOURCE"].Value == LogSource.FTP.ToString())
                                && !(HttpExceptions && Log.Attributes["SOURCE"].Value == LogSource.HTTP.ToString()))
                                continue;

                            DateTime LogTime = DateTime.ParseExact(Log.Attributes["TIME"].Value, "HH:mm:ss", null);


                            if (LogTime.Hour < StartTime.Hour || LogTime.Hour > EndTime.Hour) continue;
                            if ((LogTime.Hour == StartTime.Hour && LogTime.Minute < StartTime.Minute) ||
                                (LogTime.Hour == EndTime.Hour && LogTime.Minute > EndTime.Minute)) continue;
                            if (LogTime.Minute == EndTime.Minute && LogTime.Second > 0) continue;

                            DataRow Row = Result.NewRow();
                            string strDateTimeString = DateList[i] + " " + Log.Attributes["TIME"].Value;

                            Row["ErrorSource"] = Log.Attributes["SOURCE"].Value;
                            Row["DateTime"] = DateTime.ParseExact(strDateTimeString, "yyyy-MM-dd HH:mm:ss", null);

                            Row["Exception"] = Log.ChildNodes[0].InnerText;
                            Row["Message"] = Log.ChildNodes[1].InnerText;
                            Row["Source"] = Log.ChildNodes[2].InnerText;
                            Row["Stack"] = Log.ChildNodes[3].InnerText;
                            Row["TargetSite"] = Log.ChildNodes[4].InnerText;

                            Result.Rows.Add(Row);
                            if (CancelSearch) return Result;
                        }
                        catch { }
                    }
                }
                catch { continue; }
            }
            return Result;
        }

        #endregion

        #region User Account Methods

        internal static bool CreateFTPUser(string UserName, string Password, string RootPath, string PermissionSet, bool Enabled)
        {
            if (IsUserExists(UserName)) return false;

            XmlNodeList Users = GetUserList();
            XmlNode User = ApplicationSettings.Settings.CreateElement("User");
            User.Attributes.Append(ApplicationSettings.Settings.CreateAttribute("UserName"));
            User.Attributes.Append(ApplicationSettings.Settings.CreateAttribute("Password"));
            User.Attributes.Append(ApplicationSettings.Settings.CreateAttribute("Root"));
            User.Attributes.Append(ApplicationSettings.Settings.CreateAttribute("PermissionSet"));
            User.Attributes.Append(ApplicationSettings.Settings.CreateAttribute("Enabled"));
            Settings.DocumentElement.SelectSingleNode("UserAccount").AppendChild(User);

            User.Attributes[0].Value = UserName.ToUpper();
            User.Attributes[1].Value = Password;
            User.Attributes[2].Value = RootPath;
            User.Attributes[3].Value = PermissionSet;
            User.Attributes[4].Value = (Enabled) ? "1" : "0";
            SaveSettings();
            SetFolderIcon(RootPath);
            return true;
        }

        internal static bool EditUser(string OldUserName, string UserName, string Password, string StartUpPath, string PermissionSet, bool Enabled)
        {
            string OldRootPath = string.Empty;
            XmlNodeList Users = GetUserList();
            XmlNode User = GetUser(OldUserName);

            if (User == null)
                return CreateFTPUser(UserName, Password, StartUpPath, PermissionSet, Enabled);
            else
            {
                if (UserName != OldUserName && IsUserExists(UserName)) return false;
                else
                {
                    if (User.Attributes["Root"].Value.ToLower().Trim() != StartUpPath.ToLower().Trim())
                    {
                        RemoveFolderIcon(User.Attributes["Root"].Value);
                        SetFolderIcon(StartUpPath);
                    }

                    User.Attributes["UserName"].Value = UserName.ToUpper();
                    User.Attributes["Password"].Value = Password;
                    User.Attributes["Root"].Value = StartUpPath;
                    User.Attributes["PermissionSet"].Value = PermissionSet;
                    User.Attributes["Enabled"].Value = (Enabled) ? "1" : "0";
                    SaveSettings();
                    return true;
                }
            }
        }

        internal static bool IsUserExists(string UserName)
        {
            return GetUser(UserName) != null;
        }

        internal static bool GetUser(string UserName, out string Password, out string RootPath, out string PermissionSet, out bool Enabled)
        {
            XmlNode User = GetUser(UserName);
            Password = PermissionSet = RootPath = null;
            Enabled = false;
            if (User == null) return false;

            Password = User.Attributes[1].Value;
            PermissionSet = User.Attributes[3].Value;
            RootPath = User.Attributes[2].Value;
            Enabled = User.Attributes[4].Value == "1";

            return true;
        }

        internal static XmlNode GetUser(string UserName)
        {
            XmlNodeList Users = GetUserList();
            XmlNode User = null;

            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Attributes[0].Value.ToUpper() != UserName) continue;
                User = Users[i]; break;
            }

            return User;
        }

        internal static void DeleteFTPUser(string UserName)
        {
            XmlNode User = GetUser(UserName);
            if (User != null)
            {
                Settings.DocumentElement.SelectSingleNode("UserAccount").RemoveChild(User);
                SaveSettings();
                RemoveFolderIcon(User.Attributes["Root"].Value);
            }
        }

        internal static XmlNodeList GetUserList()
        {
            return Settings.DocumentElement.SelectNodes("UserAccount/User");
        }

        #endregion
    }
}