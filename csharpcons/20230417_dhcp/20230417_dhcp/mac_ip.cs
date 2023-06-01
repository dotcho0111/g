using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230417_dhcp
{
    internal class mac_ip
    {
        string mac, ip;
        public mac_ip(string sor)
        {
            mac = sor.Split(";")[0];
            ip = sor.Split(";")[1];
        }
        public string Mac { get { return mac; } }
        public string Ip { get { return ip; } }
    }
}
