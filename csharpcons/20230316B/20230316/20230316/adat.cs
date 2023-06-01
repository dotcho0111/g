using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230316
{
    public class adat
    {
        char nem;
        string szdatum;
        string sorszam;
        int k;

        public adat(string sor)
        {
            string[] darabolt = sor.Split('-');
            nem = darabolt[0][0]; //[0] - elso blokk [0] - elso karaktere
            //nem = Convert.ToChar(darabolt[0]);
            szdatum = darabolt[1];
            sorszam = darabolt[2][0].ToString() + darabolt[2][1] + darabolt[2][2];
            sorszam = darabolt[2].Substring(0,3); //hányadik karaktertől hány karaktert
            k = int.Parse(darabolt[2].Substring(3)); //3. karaktertől végégig
        }

        public int Nem { get { return int.Parse(nem.ToString()); } }
        public string Nem_string { get { return nem.ToString(); } }
        public string Szdatum {  get { return szdatum; } }
        public string Sorszam { get {  return sorszam; } }
        public int K { get { return k; } }
    }
}
