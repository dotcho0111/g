using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230404_operator
{
    internal class adat
    {
        int elso, masodik;
        string muvelet;
        public adat(string sor)
        {
            string[] darabol = sor.Split(' ');
            elso = int.Parse(darabol[0]);
            masodik = int.Parse(darabol[2]);
            muvelet = darabol[1];
        }
        public int Elso { get { return elso; } }
        public string Muvelet { get { return muvelet; } }
        public int Masodik { get { return masodik; } }

    }
}
