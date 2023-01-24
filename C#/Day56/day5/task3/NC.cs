using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class NC
    {
        public string nic { get; init; }="00:00:00:00";
        public string Manufacture { get; init; }="NVI";
        public string MAC_Address { get; init; }="0.0.0.0";
        public Type t { get; init; }=Type.Ethernet;

        public static NC oneobj { get; }=new NC();
        private NC() { }
       
    }

    enum Type { Ethernet=1 , tokenring=2 }
}
