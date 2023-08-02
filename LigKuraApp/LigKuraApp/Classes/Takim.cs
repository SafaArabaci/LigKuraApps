using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigKuraApp.Classes
{
    class Takim
    {
        public string TakimAd { get; set; }
        public string Ulke { get; set; }

        public Takim(string takimAd, string ulke)
        {
            TakimAd = takimAd;
            Ulke = ulke;
        }
        public string GetFullName()
        {
            return $"{TakimAd}-{Ulke}";
        }
    }
}
