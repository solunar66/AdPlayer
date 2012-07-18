using System.Net.Sockets;
using System.Collections;
using System.IO;
using System;
using System.Net;

namespace FTP
{
    class HTTPServer
    {
        TcpListener HTTPListener;
        internal ArrayList HTTPSessions = new ArrayList();

        internal bool IsRunning
        {
            get { return HTTPListener != null; }
        }

        internal bool Start()
        {
            try
            {
                HTTPListener = new TcpListener(IPAddress.Any, ApplicationSettings.HTTPPort);
                HTTPListener.Start(10);
                HTTPListener.BeginAcceptSocket(new AsyncCallback(NewHTTPClientArrived), null);
                return true;
            }
            catch (Exception Ex)
            {
                ApplicationLog.Write(LogSource.HTTP, Ex);
            }
            return false;
        }

        internal void Stop()
        {
            if (HTTPListener != null) HTTPListener.Stop(); HTTPListener = null;
        }

        void NewHTTPClientArrived(IAsyncResult arg)
        {
            Socket NewClient = null;
            try
            {
                new HTTPClient(NewClient = HTTPListener.EndAcceptSocket(arg)).Process();
            }
            catch (Exception Ex)
            {
                if (NewClient != null && NewClient.Connected)
                    NewClient.Close();

                ApplicationLog.Write(LogSource.HTTP, Ex);
            }
            NewClient = null;

            try
            {
                // Start accepting the incoming HTTP clients.
                HTTPListener.BeginAcceptSocket(new AsyncCallback(NewHTTPClientArrived), null);
            }
            catch (Exception Ex)
            {
                ApplicationLog.Write(LogSource.HTTP, Ex);
            }
        }
    }
}