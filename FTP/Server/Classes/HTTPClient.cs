using System.Net.Sockets;
using System.Text;
using System;
using System.Net;
using System.IO;
using System.Xml;

namespace FTP
{
    class HTTPClient
    {
        Socket ClientSocket;
        string HttpVersion;
        Session CurrentSession;

        internal HTTPClient(Socket ClientSocket)
        {
            this.ClientSocket = ClientSocket;
        }

        ~HTTPClient()
        {
            if (ClientSocket != null && ClientSocket.Connected) ClientSocket.Close();
            ClientSocket = null;
            CurrentSession = null;
            HttpVersion = null;
        }

        internal void Process()
        {
            byte[] Buffer = new byte[1024];
            int Received = ClientSocket.Receive(Buffer, Buffer.Length, SocketFlags.None);
            string Request = Encoding.ASCII.GetString(Buffer, 0, Received);
            int StartPos = Request.IndexOf("HTTP", 3);
            HttpVersion = Request.Substring(StartPos, 8);

            int CooStart = Request.IndexOf("Cookie:") + 7;
            int CooEndpoint = 0;
            string SessionId = null;
            string tmpRequest = Request.Substring(0, StartPos - 1);
            string[] Commands = tmpRequest.Substring(5).Split('&');
            if (Commands[0].StartsWith("/")) Commands[0] = Commands[0].Remove(0, 1);
            if (Commands.Length == 0)
            {
                Commands = Commands[0].Split('/');
            }
            else
            {
                string[] temp = Commands[0].Split('/');
                string[] temp2 = new string[temp.Length + Commands.Length - 1];
                temp.CopyTo(temp2, 0);

                for (int i = temp.Length, j = 1; i < temp2.Length; i++)
                    temp2[i] = Commands[j++];
                Commands = temp2;
            }

            if (CooStart != 6)
            {
                CooEndpoint = Request.IndexOf("\r\n", CooStart);
                string[] Cookie = Request.Substring(CooStart, CooEndpoint - CooStart).Split('=');
                if (Cookie[0].Trim() == "SessionId") SessionId = Cookie[1].Trim();
                for (int i = 0; i < ApplicationSettings.HttpServer.HTTPSessions.Count; i++)
                    if (((Session)ApplicationSettings.HttpServer.HTTPSessions[i]).ID == SessionId) { CurrentSession = (Session)(ApplicationSettings.HttpServer.HTTPSessions[i]); break; }

                if (CurrentSession == null)
                {
                    CurrentSession = new Session(SessionId, ClientSocket);

                    if (Commands[0] == "Admin" || Commands[0] == "")
                        ApplicationSettings.HttpServer.HTTPSessions.Add(CurrentSession);
                    else
                    {
                        RenderPage_Expired();
                        ClientSocket.Close(); ClientSocket = null;
                        return;
                    }
                }
                else if ((!CurrentSession.IsValid(ClientSocket)) && Commands[0] != "Admin" && Commands[0] != "")
                    Commands[0] = "CURRENT";

                CurrentSession.LastInteraction = DateTime.Now;
            }
            else
            {
                CurrentSession = new Session(ClientSocket);
                if (Commands[0] == "Admin" || Commands[0] == "") { RenderPage(); ApplicationSettings.HttpServer.HTTPSessions.Add(CurrentSession); }
                else
                {
                    RenderPage_Expired();
                    ClientSocket.Close(); ClientSocket = null;
                    return;
                }
            }

        RenderPage:
            if (CurrentSession.IsAuthenticated)
                switch (Commands[0])
                {
                    case "": RenderPage_Admin(); break;
                    case "Admin": RenderPage_Admin(); break;
                    case "LIST": RenderPage_List(Uri.UnescapeDataString(Commands[1])); break;
                    case "OLU": CurrentSession.CurrentCommand = Commands[0]; RenderPage_OLU(); break;
                    case "UA": CurrentSession.CurrentCommand = Commands[0]; RenderPage_UA(); break;
                    case "MODUA": RenderPage_EditUA(Commands[1]); break;
                    case "SAVEUA": RenderPage_SaveUA(Commands[1].ToUpper(), Commands[2].ToUpper(), Uri.UnescapeDataString(Commands[3]), Uri.UnescapeDataString(Commands[4]), Commands[6], Commands[5].Trim() == "1"); break;
                    case "DELEUA": RenderPage_DeleUA(Commands[1]); break;
                    case "HLP": CurrentSession.CurrentCommand = Commands[0]; RenderPage_Help(); break;
                    case "MS": CurrentSession.CurrentCommand = Commands[0]; RenderPage_MS(); break;
                    case "LO": CurrentSession.CurrentCommand = Commands[0]; RenderPage_LO(); break;
                    case "SAVEP": RenderPage_SaveP(Convert.ToInt32(Commands[1].Trim()), Convert.ToInt32(Commands[2].Trim()), Convert.ToInt32(Commands[3].Trim()), Convert.ToInt32(Commands[4].Trim())); break;
                    case "HPCA": RenderPage_ChangeHTTPAccount(Convert.ToInt32(Commands[1].Trim()), Uri.UnescapeDataString(Commands[2]), Uri.UnescapeDataString(Commands[3])); break;
                    case "favicon.ico": SendFavIcon(); break;
                    case "CURRENT": Commands[0] = CurrentSession.CurrentCommand; goto RenderPage;
                }
            else
                switch (Commands[0])
                {
                    case "": RenderPage(); break;
                    case "Admin": RenderPage_Admin(); break;
                    case "SIGNUP": RenderPage_Signup(Commands[1], Uri.UnescapeDataString(Commands[2])); break;
                    case "OLU": CurrentSession.CurrentCommand = Commands[0]; RenderPage_Login("Please Signin"); break;
                    case "UA": CurrentSession.CurrentCommand = Commands[0]; RenderPage_Login("Please Signin"); break;
                    case "MODUA": RenderPage_Login("Please Signin"); break;
                    case "SAVEUA": RenderPage_Login("Please Signin"); break;
                    case "HPCA": RenderPage_Login("Please Signin"); break;
                    case "DELEUA": RenderPage_Login("Please Signin"); break;
                    case "HLP": CurrentSession.CurrentCommand = Commands[0]; RenderPage_Login("Please Signin"); break;
                    case "MS": CurrentSession.CurrentCommand = Commands[0]; RenderPage_Login("Please Signin"); break;
                    case "LO": CurrentSession.CurrentCommand = Commands[0]; RenderPage_Login("Please Signin"); break;
                    case "favicon.ico": SendFavIcon(); break;
                    case "CURRENT": RenderPage_Login("Please Signin"); break;
                }
            ClientSocket.Close(); ClientSocket = null;
        }

        void SendHeader(int TotalBytes, string StatusCode)
        {
            SendHeader(TotalBytes, StatusCode, "text/html");
        }

        void SendHeader(int TotalBytes, string StatusCode, string ContentType)
        {
            string ResponseHeader = HttpVersion + " " + StatusCode + "\r\n";
            ResponseHeader += "Server: FTP/2.5\r\n";
            ResponseHeader += "Date: " + DateTime.Now.ToString("r") + "\r\n";
            ResponseHeader += "Content-Type: " + ContentType + "\r\n";
            ResponseHeader += "Accept-Ranges: bytes\r\n";
            ResponseHeader += "Content-Length: " + TotalBytes + "\r\n\r\n";

            SendData(Encoding.ASCII.GetBytes(ResponseHeader));
        }

        void SendData(byte[] ResponseBody)
        {
            if (ClientSocket.Connected) ClientSocket.Send(ResponseBody, ResponseBody.Length, SocketFlags.None);
        }

        #region Render Methods

        void RenderPage()
        {
            string ResponseText = global::FTP.Properties.Resources.PreRender.Replace("\"+Value+\"", CurrentSession.ID);
            SendHeader(ResponseText.Length, "200 OK");
            SendData(Encoding.ASCII.GetBytes(ResponseText));
        }

        void RenderPage_Admin()
        {
            string ResponseText = global::FTP.Properties.Resources.Main.Replace("<%FTPPort%>", ApplicationSettings.FTPPort.ToString());
            SendHeader(ResponseText.Length, "200 OK");
            SendData(Encoding.ASCII.GetBytes(ResponseText));
        }

        void RenderPage_List(string Path)
        {
            Path = Path.Replace('/', '\\');
            string List = "";

            string ResponseText = global::FTP.Properties.Resources.Browser;

            if (Path.Trim().Length > 1)
            {
                if (Path.Length == 2) Path += "\\";
                try
                {
                    string[] Directories = Directory.GetDirectories(Path);

                    for (int i = 0; i < Directories.Length; i++)
                    {
                        Directories[i] = Directories[i].Substring(Directories[i].LastIndexOf('\\') + 1);
                        List += "<option value=\"" + Directories[i] + "\">" + Directories[i] + "</option>";
                    }
                }
                catch { }
                if (Path.Length < 4)
                    ResponseText = ResponseText.Replace("bakonclick", "onclick=\"RequestAsync('LIST&', '', tdDirectory, 'Loading... Please wait.');\"");
                else
                    ResponseText = ResponseText.Replace("bakonclick", "onclick=\"RequestAsync('LIST&', '" + Path.Substring(0, Path.LastIndexOf('\\')).Replace("\\", "\\\\") + "', tdDirectory, 'Loading... Please wait.');\"");
            }
            else
            {
                DriveInfo[] Drives = ApplicationSettings.Drives;
                for (int i = 0; i < Drives.Length; i++)
                {
                    if (Drives[i].DriveType == DriveType.Fixed)
                        List += "<option value=\"" + Drives[i].Name + "\"><LOCAL DRIVE> " + Drives[i].VolumeLabel + " [" + Drives[i].Name + "]</option>\n";
                }
                ResponseText = ResponseText.Replace("bakonclick", "disabled");
            }
            if (Path.Length > 1 && !Path.EndsWith("\\")) Path += "\\";
            ResponseText = ResponseText.Replace("--SelPath--", Path);
            ResponseText = ResponseText.Replace("<OPTIONS>", List);
            SendHeader(ResponseText.Length, "200 OK");
            SendData(Encoding.ASCII.GetBytes(ResponseText));
        }

        void RenderPage_Login(string Message)
        {
            string ResponseText = global::FTP.Properties.Resources.Login.Replace("-MessageText-", Message);
            SendHeader(ResponseText.Length, "200 OK");
            SendData(Encoding.ASCII.GetBytes(ResponseText));
        }

        void RenderPage_Signup(string LoginID, string Password)
        {
            if (ApplicationSettings.UserName.ToUpper() == LoginID.ToUpper() && ApplicationSettings.Password == Password)
            {
                CurrentSession.IsAuthenticated = true;
                string ResponseText = "<span style=\"position:absolute; left:381px; top:218px\"><font size=4 color=#0000FF>You have been successfully authenticated!<br>Click on the menus to navigate.</font></span>";
                SendHeader(ResponseText.Length, "200 OK");
                SendData(Encoding.ASCII.GetBytes(ResponseText));
            }
            else RenderPage_Login("<font color=red>Invalid Credentials</font>");
        }

        void RenderPage_OLU()
        {
            string ResponseText = string.Empty;
            for (int i = 0; i < ApplicationSettings.FtpServer.FTPClients.Count; i++)
            {
                FTPClient Client = (FTPClient)ApplicationSettings.FtpServer.FTPClients[i];
                if (Client.IsConnected)
                    ResponseText += "<tr style=\"color:Black;background-color:#EEEECC;\"><td>" + (i + 1) + "</td><td>" + Client.EndPoint + "</td><td>" + Client.ConnectedUser.UserName + "</td><td>" + Client.ConnectedUser.StartUpDirectory + Client.ConnectedUser.CurrentWorkingDirectory + "</td><td>" + Client.ConnectedTime.ToString(ApplicationSettings.DateTimeFormat) + "</td><td>" + Client.LastInteraction.ToString(ApplicationSettings.DateTimeFormat) + "</td></tr>";
                else i--;
            }
            ResponseText = global::FTP.Properties.Resources.OnlineUsers.Replace("<ROWS>", ResponseText);
            byte[] Buffer = Encoding.ASCII.GetBytes(ResponseText);
            SendHeader(Buffer.Length, "200 OK");
            SendData(Buffer);
        }

        void RenderPage_UA()
        {
            string ResponseText = "";
            XmlNodeList Users = ApplicationSettings.GetUserList();
            for (int i = 0; i < Users.Count; i++)
            {
                ResponseText += "\n<tr style=\"color:Black;background-color:#EEEECC;\"><td>" + (i + 1) + "</td><td>" + Users[i].Attributes[0].Value + "</td><td>" + Users[i].Attributes[1].Value + "</td><td>" + Users[i].Attributes[2].Value + "</td>"
     + "<td><input type=button value=\"Delete\" style=\"color:#284E98;background-color:White;border-color:#507CD1;border-width:1px;border-style:Solid;font-family:Verdana;font-size:0.8em;\" onclick=\"JavaScript:if(confirm('Deleting user " + Users[i].Attributes[0].Value + " premenantly.'))RequestAsync('DELEUA/', '" + Users[i].Attributes[0].Value + "', div_Render, 'Deleting Account. Please wait...');\"></td>"
     + "<td align=\"center\"><input type=button value=\"Edit\" style=\"color:#284E98;background-color:White;border-color:#507CD1;border-width:1px;border-style:Solid;font-family:Verdana;font-size:0.8em;\" onclick=\"RequestAsync('MODUA/', '" + Users[i].Attributes[0].Value + "', div_Render, 'Preparing. Please wait...');\"></td></tr>";
            }

            ResponseText = global::FTP.Properties.Resources.UserAccount.Replace("<ROWS>", ResponseText);
            SendHeader(ResponseText.Length, "200 OK");
            SendData(Encoding.ASCII.GetBytes(ResponseText));
        }

        void RenderPage_SaveUA(string OldUserName, string UserName, string Password,
            string StartUp, string Permissions, bool Enabled)
        {
            string ResponseText = null;

            if (OldUserName.Length > 2)
            {
                bool Edited = ApplicationSettings.EditUser(OldUserName, UserName, Password, StartUp, Permissions, Enabled);

                if (!Edited) ResponseText = "User " + UserName + " already exist.";
                else ResponseText = "User " + OldUserName + " updated successfully.";
            }
            else
            {
                bool Created = ApplicationSettings.CreateFTPUser(UserName, Password, StartUp, Permissions, Enabled);

                if (!Created) ResponseText = "User with the name " + UserName + " already exists.";
                else ResponseText = "User created successfully.";
            }

            SendHeader(ResponseText.Length, "201 OK");
            SendData(Encoding.ASCII.GetBytes(ResponseText));
        }

        void RenderPage_DeleUA(string UserName)
        {
            ApplicationSettings.DeleteFTPUser(UserName.ToUpper());
            RenderPage_UA();
        }

        void RenderPage_EditUA(string UserName)
        {
            string Password = "", PermissionSet = "", StartupPath = "", RenFiles = "checked", RenFolders = "checked",
                DelFiles = "checked", DelFolders = "checked", AddFiles = "checked", AddFolders = "checked",
                CopyFiles = "checked", ShowHiddenFiles = "checked", ShowHiddenFolders = "checked", EnableUser = "checked";
            bool Enabled = false;

            if (UserName.Length != 0)
            {
                ApplicationSettings.GetUser(UserName, out Password, out StartupPath, out PermissionSet, out Enabled);

                char[] Permissions = PermissionSet.ToCharArray();
                if (Permissions[0] == '0') AddFiles = "";
                if (Permissions[1] == '0') AddFolders = "";
                if (Permissions[2] == '0') RenFiles = "";
                if (Permissions[3] == '0') RenFolders = "";
                if (Permissions[4] == '0') DelFiles = "";
                if (Permissions[5] == '0') DelFolders = "";
                if (Permissions[6] == '0') CopyFiles = "";
                if (Permissions[7] == '0') ShowHiddenFiles = "";
                if (Permissions[8] == '0') ShowHiddenFolders = "";
                if (!Enabled) EnableUser = "";
            }
            else UserName = "\"";
            string ResponseText = global::FTP.Properties.Resources.EditAccount;

            ResponseText = ResponseText.Replace("addfiles", AddFiles).Replace("addfolders", AddFolders);
            ResponseText = ResponseText.Replace("renfiles", RenFiles).Replace("renfolders", RenFolders);
            ResponseText = ResponseText.Replace("delfiles", DelFiles).Replace("delfolders", DelFolders);
            ResponseText = ResponseText.Replace("copyfiles", CopyFiles).Replace("enableuser", EnableUser);
            ResponseText = ResponseText.Replace("viewhiddenfiles", ShowHiddenFiles).Replace("viewhiddenfolders", ShowHiddenFolders);

            ResponseText = ResponseText.Replace("--UName--", UserName).Replace("--PWD--", Password).Replace("--StartUp--", StartupPath);
            SendHeader(ResponseText.Length, "200 OK");
            SendData(Encoding.ASCII.GetBytes(ResponseText));
        }

        void RenderPage_MS()
        {
            string ResponseText = global::FTP.Properties.Resources.ManageServices;
            ResponseText = ResponseText.Replace("--FTPPort--", ApplicationSettings.FTPPort.ToString());
            ResponseText = ResponseText.Replace("--HTTPPort--", ApplicationSettings.HTTPPort.ToString());
            ResponseText = ResponseText.Replace("--RUNSVC--", ApplicationSettings.FtpServer.Status);
            ResponseText = ResponseText.Replace("--MinPasvPort--", ApplicationSettings.MinPassvPort.ToString());
            ResponseText = ResponseText.Replace("--MaxPasvPort--", ApplicationSettings.MaxPassvPort.ToString());
            SendHeader(ResponseText.Length, "200 OK");
            SendData(Encoding.ASCII.GetBytes(ResponseText));
        }

        void RenderPage_LO()
        {
            CurrentSession.IsAuthenticated = false;
            RenderPage_Login("Please Signin");
        }

        void RenderPage_SaveP(int FTPPort, int PASVFrom, int PASVTo, int FTPEnabled)
        {
            int tempFtpPort = ApplicationSettings.FTPPort;
            bool IsFtpPortChanged = false;

            ApplicationSettings.MinPassvPort = PASVFrom;
            ApplicationSettings.MaxPassvPort = PASVTo;

            if (tempFtpPort != FTPPort)
            {
                ApplicationSettings.FtpServer.Stop();
                ApplicationSettings.FTPPort = FTPPort;
                IsFtpPortChanged = ApplicationSettings.FtpServer.Start();

                if (!IsFtpPortChanged)
                {
                    ApplicationSettings.FTPPort = tempFtpPort;
                    ApplicationSettings.FtpServer.Start();
                }
            }

            ApplicationSettings.AutoStartFTP = (FTPEnabled > 0);
            ApplicationSettings.SaveSettings();

            string Message = "";

            if (IsFtpPortChanged) Message = "FTP Port has been successfully changed\n";
            else Message = (tempFtpPort != FTPPort) ? "FTP Port could not be changed either because the specified port is being in use by other application or the specified port is not valid.\n" : "";

            if (Message == string.Empty)
                Message = "Changes Successfully Updated";

            SendHeader(Message.Length, "201");
            SendData(Encoding.ASCII.GetBytes(Message));
        }

        void RenderPage_ChangeHTTPAccount(int HTTPPort, string UserName, string Password)
        {
            int tempHttpPort = ApplicationSettings.HTTPPort;
            bool IsHttpPortChanged = false;

            string Message = null;

            if (tempHttpPort != HTTPPort)
            {
                ApplicationSettings.HttpServer.Stop();
                ApplicationSettings.HTTPPort = HTTPPort;
                IsHttpPortChanged = ApplicationSettings.HttpServer.Start();

                if (!IsHttpPortChanged)
                {
                    ApplicationSettings.HTTPPort = tempHttpPort;
                    ApplicationSettings.HttpServer.Start();
                }
            }

            if (IsHttpPortChanged) Message += "HTTP Port has been successfully changed\n\nNote: Now your session will be expired and use the new port to connect again.\n";
            else Message += (tempHttpPort != HTTPPort) ? "HTTP Port could not be changed either because the specified port is being in use by other application or the specified port is not valid.\n" : "";

            if (UserName.Trim().Length != 0)
            {
                if (UserName.Trim().Length < 4)
                    Message += "Username cannot be lesser than 4 chars.\n";
                else
                {
                    ApplicationSettings.UserName = UserName.Trim();
                    Message += "User Name changed successfully.\n";
                }
            }
            if (Password.Length != 0)
            {
                if (Password.Length < 4)
                    Message += "Password cannot be lesser than 4 chars.\n";
                else
                {
                    ApplicationSettings.Password = Password;
                    Message += "Password changed successfully.\n";
                }
            }
            ApplicationSettings.SaveSettings();

            SendHeader(Message.Length, "201");
            SendData(Encoding.ASCII.GetBytes(Message));
        }

        void RenderPage_Expired()
        {
            string ResponseText = "<script>var date = new Date();\ndate.setTime(date.getTime()-86400000);\ndocument.cookie = \"SessionId=; expires=\"+date.toGMTString()+\"; path=/\";\n</script><p align=center><b><font color=red size=4>This session has been expired. Please refresh to authenticate again.</font></b></p>";
            SendHeader(ResponseText.Length, "200 OK");
            SendData(Encoding.ASCII.GetBytes(ResponseText));
        }

        void SendFavIcon()
        {
            System.Drawing.Icon Icon = (System.Drawing.Icon)global::FTP.Properties.Resources.ResourceManager.GetObject("favicon");
            MemoryStream str = new MemoryStream();
            Icon.Save(str);
            SendHeader((int)str.Length, "200 OK", "image/x-icon");
            SendData(str.GetBuffer());
        }

        void RenderPage_Help()
        {
            string ResponseText = global::FTP.Properties.Resources.Help;
            SendHeader(ResponseText.Length, "200 OK");
            SendData(Encoding.ASCII.GetBytes(ResponseText));
        }
        #endregion
    }
}