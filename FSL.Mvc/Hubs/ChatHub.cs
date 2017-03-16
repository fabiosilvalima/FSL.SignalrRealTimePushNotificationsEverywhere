using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading;

namespace FSL.Mvc.Hubs
{
    public class ChatHub : Hub
    {
        public static int ConnectionCount = 0;
        public void SendMessage(string name, string message)
        {
            Clients.All.receiveMessage(name + ": " + message);
        }

        public void SendDateTimeServer()
        {
            Clients.All.getDateTimeServer(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            Interlocked.Increment(ref ConnectionCount);
            Clients.All.reportConnections(ConnectionCount);
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            Interlocked.Decrement(ref ConnectionCount);
            Clients.All.reportConnections(ConnectionCount);
            return base.OnDisconnected(stopCalled);
        }
    }
}