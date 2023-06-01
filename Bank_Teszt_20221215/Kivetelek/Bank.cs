using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelek
{
    public  class Bank
    {
        List<BankSzamla> szamlak;
        public Bank()
        {
            this.szamlak = new List<BankSzamla>();
        }
        public List<BankSzamla> Szamla { get => szamlak; }

        public void UjSzamlaNyitasa(string tulaj, int nyitoOsszeg, int ID)
        {
            if (tulaj == null || nyitoOsszeg == 0 || ID == 0)
            {
                throw new NullReferenceException("Hiba ures ertekek vannak!");
            }
            BankSzamla seged = new BankSzamla(ID, tulaj, nyitoOsszeg);
            szamlak.Add(seged);
        }
        public void CsoportosBeszedes(Beszedes beszedes)
        {
            foreach (BankSzamla egySzamla in szamlak)
            {
                if (egySzamla.SzamlatulajdonosNeve == beszedes.UgyfelNeve)
                {
                    egySzamla.Terhel(beszedes.TerhelendoOsszeg);
                }
            }
        }

    }
}
