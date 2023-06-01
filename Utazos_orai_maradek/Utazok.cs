using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20221107Utazas
{
    public class Utazok
    {
        public string allomasok;
        public Utazok()
        {
            this.allomasok = "";
        }
        public Utazok(string elsoAllomasok)
        {
            this.allomasok = elsoAllomasok;
        }
        public void Utazik(string hova) //void: nincs visszatérési értéke
        {
            if (allomasok == "")
            {
                allomasok += hova;
            }
            else
            {
                allomasok += ";" + hova;
            }
        }
        public bool JartE(string hol)
        {
            return allomasok.Contains(hol);
        }

        public int HanyHelyenJart
        {
            get { return allomasok.Split(';').Length; }
        }

        public string HolVoltElobb(string egyik, string masik)
        {
            if (allomasok.IndexOf(egyik) < allomasok.IndexOf(masik))
            {
                return egyik;
            }
            else
            {
                return masik;
            }

        }
        public string[] HelyekIsmetlesNelkul()
        {
            string[] s = allomasok.Split(';'); //allomasok stringet a ; mentén daragolva tömbbé alakítjuk
            string[] q = s.Distinct().ToArray(); //térjen vissza a "q", az "s"-t tömbbé alakítva és kiszedve az ismétlődés
            return q;
        }

        public string[]  HelyekAholTobbszorJart()
        {
            string[] allomtomb = allomasok.Split(';'); //allomasok stringet a ; mentén daragolva tömbbé alakítjuk
            List <string> tobbszor = new List<string>(); //üres string lista a többször járt városoknak
            for (int i = 0; i < allomtomb.Length; i++) //végigmengyünk az allomtombon
            {
                int darab = 1; //1 biztos van minden városból
                for (int j = i + 1; j < allomtomb.Length; j++) //minden allomttomb [i] értékénél újra végigmegyünk az allamtombon és...
                {
                    if (allomtomb[i] == allomtomb[j]) //ha [i] == [í] (valamely allomasnevvel) akkor darab++
                    {
                        darab++;
                    }
                }
                if (darab > 1) //ha a darab több mint egy, mert egynél többször szerepel a városnév akkor...
                {
                    tobbszor.Add(allomtomb[i]); //a tobbszor listához adja hozzá az allamtomb elemét (Városnevét)
                }
            }
            return tobbszor.Distinct().ToArray(); //térjen vissza a "tobbszor", kiszedve az ismétlődés és tömbbé alakítva 
        }
    }
}