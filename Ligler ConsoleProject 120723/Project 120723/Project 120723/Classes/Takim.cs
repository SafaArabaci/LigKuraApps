using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_120723.Classes
{
    class Takim
    {
        private string Ad { get; set; }
        public int No { get; set; }
        public bool YarıFinal{ get; set; }
        public bool Final { get; set; }
        public bool Sampiyon { get; set; }

        public Takim(string ad)
        {
            Ad = ad;
        }
        public string GetAd()
        {
            return Ad;
        }
    }
}
