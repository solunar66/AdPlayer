using System.Net.Sockets;
using System;

namespace FTP
{
    class Session
    {
        internal string ID;
        internal string EndPoint;
        internal string CurrentCommand;
        internal bool IsAuthenticated;
        internal DateTime LastInteraction;

        internal Session(Socket ClientSocket)
        {
            this.ID = "SI" + DateTime.Now.Ticks;
            LastInteraction = DateTime.Now;
            this.EndPoint = ClientSocket.RemoteEndPoint.ToString().Substring(0, ClientSocket.RemoteEndPoint.ToString().IndexOf(':')).ToLower();
        }

        internal Session(string ID, Socket ClientSocket)
        {
            this.ID = ID;
            LastInteraction = DateTime.Now;
            this.EndPoint = ClientSocket.RemoteEndPoint.ToString().Substring(0, ClientSocket.RemoteEndPoint.ToString().IndexOf(':')).ToLower();
        }

        internal bool IsValid(Socket ClientSocket)
        {
            TimeSpan Difference = DateTime.Now - LastInteraction;
            if (this.EndPoint.ToLower() != ClientSocket.LocalEndPoint.ToString().Substring(0, ClientSocket.LocalEndPoint.ToString().IndexOf(':')).ToLower()) return true;
            else if (Difference.Minutes > 10) { IsAuthenticated = false; return false; }
            return true;
        }
    }
}
