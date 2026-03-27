using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace ConsoleApp4.Ping
{
    
    public  class NetworkSErvice
    {
        public string Send()
        {
            return "Sucess";
        }
        public int Time(int n,int m)
        {
            return n + m;
        }
        public DateTime Pingdate()
        {
            return DateTime.Now;
        }
        public PingOptions PingOptions()
        {
            return new PingOptions()
            {
                Ttl = 1,
                DontFragment = true
            };

        }
        public IEnumerable<PingOptions> Most()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new PingOptions()
            {
                Ttl = 1,
                DontFragment = true
            },
            new PingOptions()
            {
                Ttl = 1,
                DontFragment = true
            },
            new PingOptions()
            {
                Ttl = 1,
                DontFragment = true
            },
            };
            return pingOptions;
        }
    }
}
