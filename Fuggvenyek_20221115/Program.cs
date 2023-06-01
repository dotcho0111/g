namespace Fuggveny_20221115
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hány szóból áll a mondat: {SzavakSzamaaMondatban("Ez egy ot szavas mondat")}");
            Console.WriteLine($"\nHányszor szerepel a karakter: {karakterSzam('e', "ezegyhosszuszo")}");
            Console.WriteLine($"\nSzó fordítva: {inverse("ezegyhosszuszo")}");
            Console.WriteLine($"\nKör terulete: {korT(10)}");
            Console.WriteLine($"\nHány jegyű: {hanyjegy(999)}");
            //Console.WriteLine(Szamjegy(89999));
            Console.WriteLine("\nPáros számok:");
            parosszamok(10, 20);
            Console.WriteLine("\nPrímszám-e");
            Console.WriteLine(primszame(299));
            Console.WriteLine(primszame(199));
            Console.WriteLine($"\nHáromszög trülete: {Terulet(6, 6, 8.485)}");

        }

        static int SzavakSzamaaMondatban(string mon)
        {
            return mon.Split().Length;
        }//feldarabolja a mondatot a space-ek mentén és megszámolja

        static int karakterSzam(char ca, string ch)
        {
            int darab = 0;
            foreach (char item in ch) //végigmegy minden elemén a ch-nak
            {
                if (item == ca)
                {
                    darab++; //ha ch item-je egyenlő ca-val, akkor darab++
                }
            }
            return darab;
        }

        static string inverse(string ch)
        {
            string visszafele = ""; //üres string
            foreach (char item in ch) //végigmegy a ch elemein
            {
                visszafele = item + visszafele;
            }
            return visszafele;
        }

        static double korT(double r)
        {
            return Math.Pow(r, 2) * Math.PI;
        }

        static int hanyjegy(int szam) //10-zel kell osztani a számokat
        {
            int ennyijegyu = 0;
            if (szam == 0)
            {
                return 1;
            }
            while (szam != 0)
            {
                szam = szam / 10; //pl: 100 -> szam = 100 / 10 [10] -> szamjegy++; -> 10(szam) = 10 / 10 [1]
                ennyijegyu++;
            }
            return ennyijegyu;
        }
        
        /*Másik megoldás a hány számjegyre:
        static int Szamjegy(int szam2)
        {
            string str = szam2.ToString();
            return str.Count();
        }
        */

        static void parosszamok(int elso, int masodik)
        {
            for (int i = elso + 1; i < masodik; i++) //for ciklus az első szám + 1-től, a második szam előttig
            {
                if (i % 2 == 0) //ha osztható kettővel (páros)
                {
                    Console.WriteLine(i); //írja ki
                }
            }
        }

        static bool primszame(int szam) //prím: csak 1-gyel és önmagával osztható
        {
            for (int i = 2; i < szam; i++) //for ciklus kettőtől (mert 1-gyel minden osztható)
            {
                if (szam % i == 0) //ha maradék nélkül osztható 2 és a "szam" között -> false, mert biztosan nem prím
                {
                    return false;
                }
            }
            return true;
        }
        
        static double Terulet(double a, double b, double c)
        {
            if ((a > 0 && b > 0 && c > 0 && ((a + b) > c) && ((a + c) > b) && ((b + c) > a))) //0 kizárva, szerkeszthetőség ellenőrizve
            {
                double Kerulet = a + b + c;
                double s = Kerulet / 2;
                return Math.Sqrt(s * (s - a) * (s - b) * (s - c)); //Heron képlet
            }
            else { return 0; } //ha nem szerkeszthető akkor return 0
        }
    }
}
