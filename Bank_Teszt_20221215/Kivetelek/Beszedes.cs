using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelek
{
    public class Beszedes
    {
        string szolgaltatoNeve;
        string ugyfelNeve;
        int terhelendoOsszeg;

        public Beszedes(string szolgaltatoNeve, string ugyfelNeve, int terhelendoOsszeg)
        {
            this.szolgaltatoNeve = szolgaltatoNeve;
            this.ugyfelNeve = ugyfelNeve;
            this.terhelendoOsszeg = terhelendoOsszeg;
        }
        public string SzolgaltatoNeve { get => szolgaltatoNeve; set => szolgaltatoNeve = value; }
        public string UgyfelNeve { get => ugyfelNeve; set => ugyfelNeve = value; }
        public int TerhelendoOsszeg { get => terhelendoOsszeg; set => terhelendoOsszeg = value; }
    }
}
