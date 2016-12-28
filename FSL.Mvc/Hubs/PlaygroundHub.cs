using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace FSL.Mvc.Hubs
{
    public class PlaygroundHub : Hub
    {
        public PlaygroundHub()
        {

        }

        public void SendMessage(string message)
        {
            Clients.All.sendMessage(message);
        }

        public void ReportMonitor(object monitor)
        {
            Clients.All.reportMonitor(monitor);
        }

        public static async Task SendMessageToAllClients(string message)
        {
            await GlobalHost.ConnectionManager.GetHubContext<PlaygroundHub>().Clients.All.sendMessage(message);
        }

        public static async Task ReportMonitorToAllClients(Monitor monitor)
        {
            await GlobalHost.ConnectionManager.GetHubContext<PlaygroundHub>().Clients.All.reportMonitor(monitor);
        }
    }
}