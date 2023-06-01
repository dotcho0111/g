using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelek
{
    public class BankSzamla
    {
       private int aszonosito;
       private string szamlatulajdonosNeve; 
       private int aktualiEgyenleg;
        public BankSzamla(int aszonosito, string szamlatulajdonosNeve, int aktualiEgyenleg)
        {
            this.aszonosito = aszonosito;
            this.szamlatulajdonosNeve = szamlatulajdonosNeve;
            this.aktualiEgyenleg = aktualiEgyenleg;
        }
        public BankSzamla()
        {
        }
        public int Aszonosito { get => aszonosito; }
        public string SzamlatulajdonosNeve { get => szamlatulajdonosNeve;  }
        public int AktualiEgyenleg { get {return aktualiEgyenleg; } }
        public void Terhel(int osszeg)
        {
            if (aktualiEgyenleg >= osszeg)
            {
                aktualiEgyenleg-= osszeg;
            }
            else
            {
                BankSzamla seged = new BankSzamla()
                {
                    aktualiEgyenleg = this.aktualiEgyenleg,
                    szamlatulajdonosNeve = this.szamlatulajdonosNeve,
                    aszonosito = this.aszonosito
                };
                throw new SzamlanNincsFedezetException(seged, osszeg, "Nincs eleg fedezet a szamlan");
            }
        }
        public override string ToString()
        {
            return $"A(z) {aszonosito} ID-val elattot szamlanak a tulajdonosa: {szamlatulajdonosNeve}" +
                $" aktualis osszege: {aktualiEgyenleg:C0}";
        }
    }
    public class SzamlanNincsFedezetException : Exception
    {
        public BankSzamla Szamla { get; set; }
        public int Terheles { get; set; }
        public SzamlanNincsFedezetException(BankSzamla szamla, int terheles, string msg):base(msg)
        {
            Szamla = szamla;
            Terheles = terheles;
        }
    }
}
