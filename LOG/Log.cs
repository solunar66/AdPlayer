using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LOG
{
    public class LogInfo
    {
        /// <summary>
        /// 日志文件大小
        /// </summary>
        private int fileSize = 1024 * 1024;

        /// <summary>
        /// 日志文件的路径
        /// </summary>
        private string fileLogPath = Directory.GetCurrentDirectory() + @"\log";

        /// <summary>
        /// 日志文件的名称
        /// </summary>
        private string logFileName = "log";

        /// <summary>
        /// 所在驱动器的名称
        /// </summary>
        private String logDriver = "";

        private static LogInfo instance;
        private LogInfo() { }
        public static LogInfo GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogInfo();
                }
                return instance;
            }
        }

        /// <summary>
        /// 获取或设置定义日志文件大小
        /// </summary>
        public int FileSize
        {
            set
            {
                fileSize = value;
            }
            get
            {
                return fileSize;
            }
        }

        /// <summary>
        /// 获取或设置日志文件的路径
        /// </summary>
        public string FileLogPath
        {
            set
            {
                this.fileLogPath = value;
            }
            get
            {
                return this.fileLogPath;
            }
        }

        /// <summary>
        /// 获取或设置日志文件的名称
        /// </summary>
        public string LogFileName
        {
            set
            {
                this.logFileName = value;
            }
            get
            {
                return this.logFileName;
            }

        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message">日志内容</param>
        public void WriteLine(string message)
        {
            this.WriteLog(this.logFileName, message);
        }

        /// <summary>
        /// 记录并打印日志（用以Console程序）
        /// </summary>
        /// <param name="message">日志内容</param>
        public void WriteConsoleAndLog(string message)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + message);
            this.WriteLog(this.logFileName, message);
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="message">记录信息</param>
        private void WriteLog(string fileName, string message)
        {
            bool t = LogInfo.HaveAvailableFreeSpace(logDriver, 100 * this.fileSize);
            if (!t)
            {
                //如果当前驱动器空间不够，删除最早的文件夹
                LogInfo.DeleteFileDirectoryByCreateTime(this.fileLogPath, 10);
            }

            //如果日志文件目录不存在,则创建
            DateTime dt = DateTime.Now;
            string sCurDate = dt.ToString("yyyy-MM-dd");
            string trueFilePath = this.fileLogPath + "\\" + sCurDate;
            if (!Directory.Exists(trueFilePath))
            {
                Directory.CreateDirectory(trueFilePath);
            }
            int i = 1;
            string trueLogFileName = fileName + "_" + sCurDate + "_" + i + ".log";
            FileInfo finfo = new FileInfo(trueFilePath + "\\" + trueLogFileName);

            while (1 == 1)
            {
                if (!finfo.Exists || finfo.Length < fileSize)
                {
                    break;
                }
                i++;
                trueLogFileName = fileName + "_" + sCurDate + "_" + i + ".log";
                finfo = new FileInfo(trueFilePath + "\\" + trueLogFileName);
            }

            try
            {
                using (FileStream fs = new FileStream(trueFilePath + "\\" + trueLogFileName, FileMode.Append))
                {
                    StreamWriter strwriter = new StreamWriter(fs);

                    if (String.IsNullOrEmpty(this.logDriver))
                    {
                        this.logDriver = Directory.GetDirectoryRoot(this.fileLogPath);
                    }

                    try
                    {
                        DateTime d = DateTime.Now;
                        strwriter.WriteLine(d.ToString() + " | " + message);
                        strwriter.Flush();
                    }
                    catch (IOException ee)
                    {
                        Console.WriteLine("日志文件写入失败信息:" + ee.ToString());

                        if (!LogInfo.HaveAvailableFreeSpace(this.logDriver, 200 * (long)this.fileSize))
                        {
                            LogInfo.DeleteFileDirectoryByCreateTime(this.fileLogPath, 10);
                        }
                    }
                    finally
                    {
                        strwriter.Close();
                        strwriter = null;
                    }
                }
            }
            catch (IOException ee)
            {
                Console.WriteLine("日志文件没有打开,详细信息如下:" + ee.ToString());

            }
        }

        /// <summary>
        /// 判断日志所在驱动器是否已满
        /// </summary>
        /// <param name="driverName">驱动器名称</param>
        /// <param name="size">文件大小</param>
        /// <returns>是否驱动器driverName有size大小剩余空间</returns>
        private static bool HaveAvailableFreeSpace(String driverName, long size)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                if (d.Name.Equals(driverName))
                {
                    if (d.IsReady == true)
                    {
                        if (d.AvailableFreeSpace <= size) return false;
                        else return true;
                    }
                    break;
                }
            }
            return true;
        }

        /// <summary>
        /// 按创建日期，删除最早的文件夹
        /// </summary>
        /// <param name="targetDirectory">目标文件夹</param>
        /// <param name="num">删除的文件夹数目</param>
        private static void DeleteFileDirectoryByCreateTime(String targetDirectory, int num)
        {
            if (Directory.Exists(targetDirectory))
            {
                try
                {
                    string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                    DateTime[] subdirectoryCreateTime = new DateTime[subdirectoryEntries.Length];
                    int i = 0;
                    foreach (string subdirectory in subdirectoryEntries)//初始化一个记录文件夹创建时间的数组
                    {
                        subdirectoryCreateTime[i] = Directory.GetCreationTime(subdirectory);
                        i++;
                    }
                    subdirectoryEntries = LogInfo.BubbleSort(subdirectoryEntries, subdirectoryCreateTime);
                    if (num >= subdirectoryEntries.Length) num = subdirectoryEntries.Length - 1;
                    for (i = 0; i < num; i++)
                    {
                        if (Directory.Exists(subdirectoryEntries[i]))
                        {
                            try
                            {
                                Directory.Delete(subdirectoryEntries[i], true);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("删除" + subdirectoryEntries[i] + "子目录出错---错误类型---" + e.GetType());
                                Console.WriteLine("删除" + subdirectoryEntries[i] + "子目录出错---错误信息---" + e.ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("获取" + targetDirectory + "子目录出错---错误类型---" + ex.GetType());
                    Console.WriteLine("获取" + targetDirectory + "子目录出错---错误信息---" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// 将文件夹按照创建时间从小到大排序
        /// </summary>
        private static string[] BubbleSort(string[] arr1, DateTime[] arr2)
        {
            int j;
            string temp;
            DateTime tempdate;
            j = 1;
            while ((j < arr2.Length))
            {
                for (int i = 0; i < arr2.Length - j; i++)
                {
                    if (arr2[i].CompareTo(arr2[i + 1]) > 0)
                    {
                        tempdate = arr2[i];
                        arr2[i] = arr2[i + 1];
                        arr2[i + 1] = tempdate;

                        if (!string.IsNullOrEmpty(arr1[i]))
                        {
                            temp = arr1[i];
                            arr1[i] = arr1[i + 1];
                            arr1[i + 1] = temp;
                        }
                    }
                }
                j++;
            }
            return arr1;
        }

        #region 多线程部分

        /// <summary>
        /// 记录线程n的日志
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="n">线程ID</param>
        public void WriteLine(string message, int n)
        {
            this.WriteLog(this.logFileName, message, n);
        }

        /// <summary>
        /// 记录子线程日志
        /// </summary>
        /// <param name="message">日志内容</param>
        /// <param name="mainSn">主线程ID</param>
        /// <param name="subSn">子线程ID</param>
        public void WriteLine(string message, int mainSn, int subSn)
        {
            this.WriteLog(this.logFileName, message, mainSn, subSn);
        }

        /// <summary>
        /// 记录线程n的日志
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="message">记录信息</param>
        /// <param name="n">线程ID</param>
        private void WriteLog(string fileName, string message, int n)
        {
            bool t = LogInfo.HaveAvailableFreeSpace(logDriver, 100 * this.fileSize);
            if (!t)
            {
                LogInfo.DeleteFileDirectoryByCreateTime(this.fileLogPath, 10);
            }
            DateTime dt = DateTime.Now;
            string sCurDate = dt.ToShortDateString();
            string trueFilePath = this.fileLogPath + "\\" + sCurDate + "\\" + n.ToString();
            if (!Directory.Exists(trueFilePath))
            {
                Directory.CreateDirectory(trueFilePath);
            }
            int i = 1;
            string trueLogFileName = fileName + "_" + sCurDate + "_" + i + ".log";
            FileInfo finfo = new FileInfo(trueFilePath + "\\" + trueLogFileName);
            while (1 == 1)
            {
                if (!finfo.Exists || finfo.Length < fileSize)
                {
                    break;
                }
                i++;
                trueLogFileName = fileName + "_" + sCurDate + "_" + i + ".log";
                finfo = new FileInfo(trueFilePath + "\\" + trueLogFileName);
            }
            try
            {
                using (FileStream fs = new FileStream(trueFilePath + "\\" + trueLogFileName, FileMode.Append))
                {
                    StreamWriter strwriter = new StreamWriter(fs);
                    if (String.IsNullOrEmpty(this.logDriver))
                    {
                        this.logDriver = Directory.GetDirectoryRoot(this.fileLogPath);
                    }
                    try
                    {
                        DateTime d = DateTime.Now;
                        strwriter.WriteLine(d.ToString() + message);
                        strwriter.Flush();
                    }
                    catch (IOException ee)
                    {
                        Console.WriteLine("日志文件写入失败信息:" + ee.ToString());
                        if (!LogInfo.HaveAvailableFreeSpace(this.logDriver, 200 * (long)this.fileSize))
                        {
                            LogInfo.DeleteFileDirectoryByCreateTime(this.fileLogPath, 10);
                        }
                    }
                    finally
                    {
                        strwriter.Close();
                        strwriter = null;
                    }
                }
            }
            catch (IOException ee)
            {
                Console.WriteLine("日志文件没有打开,详细信息如下:" + ee.ToString());
            }
        }

        /// <summary>
        /// 记录子线程日志
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="message">记录信息</param>
        /// <param name="mainSn">主线程ID</param>
        /// <param name="subSn">子线程ID</param>
        private void WriteLog(string fileName, string message, int mainSn, int subSn)
        {
            bool t = LogInfo.HaveAvailableFreeSpace(logDriver, 100 * this.fileSize);
            if (!t)
            {
                LogInfo.DeleteFileDirectoryByCreateTime(this.fileLogPath, 10);
            }
            DateTime dt = DateTime.Now;
            string sCurDate = dt.ToShortDateString();
            string trueFilePath = this.fileLogPath + "\\" + sCurDate + "\\" + mainSn.ToString() + "\\" + subSn.ToString();
            if (!Directory.Exists(trueFilePath))
            {
                Directory.CreateDirectory(trueFilePath);
            }
            int i = 1;
            string trueLogFileName = fileName + "_" + sCurDate + "_" + i + ".log";
            FileInfo finfo = new FileInfo(trueFilePath + "\\" + trueLogFileName);
            while (1 == 1)
            {
                if (!finfo.Exists || finfo.Length < fileSize)
                {
                    break;
                }
                i++;
                trueLogFileName = fileName + "_" + sCurDate + "_" + i + ".log";
                finfo = new FileInfo(trueFilePath + "\\" + trueLogFileName);
            }
            try
            {
                using (FileStream fs = new FileStream(trueFilePath + "\\" + trueLogFileName, FileMode.Append))
                {
                    StreamWriter strwriter = new StreamWriter(fs);
                    if (String.IsNullOrEmpty(this.logDriver))
                    {
                        this.logDriver = Directory.GetDirectoryRoot(this.fileLogPath);
                    }
                    try
                    {
                        DateTime d = DateTime.Now;
                        strwriter.WriteLine(d.ToString() + message);
                        strwriter.Flush();
                    }
                    catch (IOException ee)
                    {
                        Console.WriteLine("日志文件写入失败信息:" + ee.ToString());
                        if (!LogInfo.HaveAvailableFreeSpace(this.logDriver, 200 * (long)this.fileSize))
                        {
                            LogInfo.DeleteFileDirectoryByCreateTime(this.fileLogPath, 10);
                        }
                    }
                    finally
                    {
                        strwriter.Close();
                        strwriter = null;
                    }
                }
            }
            catch (IOException ee)
            {
                Console.WriteLine("日志文件没有打开,详细信息如下:" + ee.ToString());
            }
        }
        #endregion 多线程部分
    }
}
