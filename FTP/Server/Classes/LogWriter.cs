using System;
using System.IO;
using System.Text;
using System.Runtime.CompilerServices;

namespace FTP
{
    internal enum LogSource
    {
        HTTP, FTP
    }

    internal class ApplicationLog
    {
        static FileStream LogStream;
        static StreamWriter Log;
        static string LogFilePath;
        internal static bool EnableLogging = true;

        [MethodImpl(MethodImplOptions.Synchronized)]
        internal static void Write(LogSource Source, Exception Ex)
        {
            if (Ex == null || !EnableLogging) return;
            if (Ex.InnerException != null) Ex = Ex.InnerException;

            try
            {
                if (!Directory.Exists(ApplicationSettings.DataPath + "Logs\\"))
                    Directory.CreateDirectory(ApplicationSettings.DataPath + "Logs\\");

                LogFilePath = ApplicationSettings.DataPath + "Logs\\LOG." + DateTime.Today.ToString("yyyy-MM-dd") + ".EXCEPTION";

                LogStream = new FileStream(LogFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read);
                Log = new StreamWriter(LogStream, Encoding.UTF8);

                StringBuilder SB = new StringBuilder();

                if (LogStream.Length < 21)
                    SB.AppendLine("<ERRORLOG>");
                else
                    LogStream.Position = LogStream.Length - 13;

                SB.AppendLine("  <LOG TIME=\"{0}\" SOURCE=\"{1}\">");
                SB.AppendLine("    <EXCEPTION>{2}</EXCEPTION>");
                SB.AppendLine("    <MESSAGE>{3}</MESSAGE>");
                SB.AppendLine("    <SOURCE>{4}</SOURCE>");
                SB.AppendLine("    <STACK>{5}</STACK>");
                SB.AppendLine("    <TARGETSITE>{6}</TARGETSITE>");
                SB.AppendLine("  </LOG>");

                SB.AppendLine("</ERRORLOG>"); // End the xml file

                Log.Write(
                    string.Format(SB.ToString(),
                    DateTime.Now.ToString("HH:mm:ss"),
                    Source.ToString(),
                    Ex.ToString(),
                    Ex.Message,
                    Ex.Source,
                    Ex.StackTrace,
                    Ex.TargetSite.Name));

                SB = null;
            }
            catch (Exception Exn)
            { }
            finally
            {
                if (Log != null) Log.Close(); Log = null;
                if (LogStream != null) LogStream.Close(); LogStream = null;
            }
        }
    }
}