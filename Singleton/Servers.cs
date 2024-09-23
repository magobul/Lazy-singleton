using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Servers
    {
        private static readonly Lazy<Servers> singleton = new Lazy<Servers>(() => new Servers());
        private readonly HashSet<string> serverList;

        private Servers()
        {
            serverList = new HashSet<string>();
        }

        public static Servers Singleton = singleton.Value;

        public bool AddServer(string serverAddress)
        {
            if (string.IsNullOrWhiteSpace(serverAddress) || (!serverAddress.StartsWith("http://") && !serverAddress.StartsWith("https://")) || !serverList.Add(serverAddress))
            {
                return false; 
            }

            return true; 
        }

        public List<string> GetHttpServers()
        {
            var httpServers = new List<string>();
            foreach (var server in serverList)
            {
                if (server.StartsWith("http://"))
                {
                    httpServers.Add(server);
                }
            }
            return httpServers;
        }

        public List<string> GetHttpsServers()
        {
            var httpsServers = new List<string>();
            foreach (var server in serverList)
            {
                if (server.StartsWith("https://"))
                {
                    httpsServers.Add(server);
                }
            }
            return httpsServers;
        }
    }
}
