using System;
using System.Collections;
using System.Net.Sockets;
using System.Net;

namespace FTP
{
    class FTPServer
    {
        TcpListener FTPListener;

        internal ArrayList FTPClients = new ArrayList();
        
        internal string Status
        {
            get { if (FTPListener == null)return "value=\"0\""; else return "value=\"1\" checked"; }
        }

        internal bool IsRunning
        {
            get { return FTPListener != null; }
        }

        internal bool Start()
        {
            try
            {
                Stop();

                FTPListener = new TcpListener(IPAddress.Any, ApplicationSettings.FTPPort);
                FTPListener.Start(20);

                // Start accepting the incoming clients.
                FTPListener.BeginAcceptSocket(new AsyncCallback(NewFTPClientArrived), null);
                return true;
            }
            catch (Exception Ex)
            {
                ApplicationLog.Write(LogSource.FTP, Ex);
            }
            return false;
        }

        internal void Stop()
        {
            if (FTPListener != null) FTPListener.Stop(); FTPListener = null;
        }

        void NewFTPClientArrived(IAsyncResult arg)
        {
            try
            {
                FTPClients.Add(new FTPClient(FTPListener.EndAcceptSocket(arg)));
            }
            catch (Exception Ex)
            {
                ApplicationLog.Write(LogSource.FTP, Ex);
            }

            try
            {
                // Start accepting the incoming clients.
                FTPListener.BeginAcceptSocket(new AsyncCallback(NewFTPClientArrived), null);
            }
            catch (Exception Ex)
            {
                ApplicationLog.Write(LogSource.FTP, Ex);
            }
        }
    }
}