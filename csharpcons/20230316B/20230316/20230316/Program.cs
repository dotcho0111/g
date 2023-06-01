using System.Runtime.InteropServices;
using System.IO;

namespace _20230316
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<adat> adatList = new List<adat>();
            StreamReader be = new StreamReader("vas.txt");
            while (!be.EndOfStream)
            {
                adatList.Add(new adat(be.ReadLine()));
            }
            be.Close();
            Console.WriteLine("LIsta elemeinek száma: " + adatList.Count);
            List<adat> adatLista2 = new List<adat>();
            foreach (var item in adatList)
            {
                if (CdvEll(item) == false)
                {
                    Console.WriteLine(item.Nem_string + "-" + item.Szdatum + "-" + item.Sorszam + "-" + item.K);
                    adatLista2.Add(item);
                }
            }
            foreach (var item in adatLista2)
            {
                adatList.Remove(item);
            }
            adatLista2.Clear();
            Console.WriteLine("LIsta elemeinek száma: " + adatList.Count);

            //6 feladat
            int db = 0;
            foreach (var item in adatList)
            {
                if (item.Nem == 1 || item.Nem == 3)
                {
                    db++;
                }
            }            
            Console.WriteLine("6. feladat: Fiúk száma: " + db);

            //7. feladat
            int min = int.MaxValue;
            int max = int.MinValue;
            SortedSet <int> halmaz = new SortedSet<int>();
            foreach (var item in adatList)
            {
                string s = "";
                if (item.Nem < 3)
                {
                    s = "19" + item.Szdatum[0] + item.Szdatum[1];
                }
                else
                {
                    s = "20" + item.Szdatum[0] + item.Szdatum[1];
                }
                int d = int.Parse(s);
                if (d < min)
                {
                    min = d;
                }
                if (d > max)
                {
                    max = d;
                }
                halmaz.Add(d);
            }
            Console.WriteLine("7. feladat: Vizsgált időszak: " + min + "-" + max);

            //8. feladat
            int i = 0;
            while (i < adatList.Count && adatList[i].Szdatum.Substring(2,4) == "0224" && int.Parse(adatList[i].Szdatum.Substring(2, 4)) % 4  == 0)
            {
                i++;
            }
            if (i < adatList.Count)
            {
                Console.WriteLine("8. feladat: Szőkőnapon született baba!");
            }
            else
            {
                Console.WriteLine("Nem volt");
            }
            //9. Feladat
            foreach (var elem in halmaz)
            {
                db = 0;
                foreach (var item in adatList)
                {
                    string s = "";
                    if (item.Nem < 3)
                    {
                        s = "19" + item.Szdatum[0] + item.Szdatum[1];
                    }
                    else
                    {
                        s = "20" + item.Szdatum[0] + item.Szdatum[1];
                    }
                    int d = int.Parse(s);
                    if (elem == d)
                    {
                        db++;
                    }
                }
                Console.WriteLine(elem + "-" + db);
            }

            //plusz feladat, születések száma per hónap
            for (int honap = 1; honap <= 12; honap++)
            {
                db = 0;
                foreach (var item in adatList)
                {
                    if (int.Parse(item.Szdatum.Substring(2,2)) == honap)                        
                    {
                        db++;
                    }
                }
                Console.WriteLine(honap + ":" + db);
            }
            
        }

        static bool CdvEll(adat x)
        {
            int k11 = x.Nem * 10;
            string seged = x.Szdatum;
            k11 += int.Parse(x.Szdatum[0].ToString()) * 9;
            k11 += int.Parse(x.Szdatum[1].ToString()) * 8;
            k11 += int.Parse(x.Szdatum[2].ToString()) * 7;
            k11 += int.Parse(x.Szdatum[3].ToString()) * 6;
            k11 += int.Parse(x.Szdatum[4].ToString()) * 5;
            k11 += int.Parse(x.Szdatum[5].ToString()) * 4;
            seged = x.Sorszam;
            k11 += int.Parse(x.Sorszam[0].ToString()) * 3;
            k11 += int.Parse(x.Sorszam[1].ToString()) * 2;
            k11 += int.Parse(x.Sorszam[2].ToString()) * 1;

            if (k11 % 11 == x.K)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}