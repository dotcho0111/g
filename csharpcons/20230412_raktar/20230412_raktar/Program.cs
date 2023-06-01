using MySql.Data.MySqlClient;

namespace _20230412_raktar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<raktar> raktar_keszlet = new List<raktar>();

            StreamReader beolvas = new StreamReader(@"raktar.csv");
            while (!beolvas.EndOfStream)
            {
                string line = beolvas.ReadLine();
                raktar_keszlet.Add(new raktar(line));
            }
            beolvas.Close();


            ///////////////////////////////////////
            List<megrendeles> megrendelesek = new List<megrendeles>();
            List<tetelek> megrendelt_tetelek = new List<tetelek>();

            StreamReader beolvas2 = new StreamReader(@"rendeles.csv");
            while (!beolvas2.EndOfStream)
            {
                string line = beolvas2.ReadLine();
                if (line[0] == 'M')
                {
                    megrendelesek.Add(new megrendeles(line));
                }
                else
                {
                    megrendelt_tetelek.Add(new tetelek(line));
                }
            }
            beolvas2.Close();

            ///////////////////////////////////
            /*
            foreach (var item in raktar_keszlet)
            {
                Console.WriteLine(item.Cikkszam + "\t" + item.Megnevezes + "\t" + item.Mennyiseg);
            }
            Console.WriteLine();
            Console.WriteLine("//////////////////////////////////////////////////////////");
            Console.WriteLine();
            foreach (var item in megrendelesek)
            {
                Console.WriteLine(item.Datum + "\t" + item.Rendeles_szama + "\t" + item.Email);
            }
            */
            ///////////////////////////////////

            //3-4. feladat
            Dictionary<string, int> hiany = new Dictionary<string, int>();
            StreamWriter ki = new StreamWriter("levelek.csv", false, System.Text.Encoding.UTF8);
            foreach (var vasarlo in megrendelesek)
            {
                bool rendelheto = true;
                int ar = 0;
                foreach (var egy_termek in megrendelt_tetelek)
                {
                    if (egy_termek.Rendeles_szama == vasarlo.Rendeles_szama)
                    {
                        int i = 0;
                        while (i < raktar_keszlet.Count && raktar_keszlet[i].Cikkszam != egy_termek.Cikszam)
                        {
                            i++;
                        }
                        if (raktar_keszlet[i].Mennyiseg < egy_termek.Mennyiseg)
                        {
                            rendelheto = false;
                            if (hiany.ContainsKey(egy_termek.Cikszam))
                            {
                                hiany[egy_termek.Cikszam] += egy_termek.Mennyiseg - raktar_keszlet[i].Mennyiseg;
                            }
                            else
                            {
                                hiany.Add(egy_termek.Cikszam, egy_termek.Mennyiseg - raktar_keszlet[i].Mennyiseg);
                            }
                        }
                        else
                        {
                            ar += egy_termek.Mennyiseg * raktar_keszlet[i].Ar;                           
                        }
                    }
                }
                if (rendelheto == true)
                {

                    Console.WriteLine($"A rendelését két napon belül szállítjuk. A rendelés értéke: {ar} Ft");
                    ki.WriteLine($"A rendelését két napon belül szállítjuk. A rendelés értéke: {ar} Ft");
                    foreach (var egy_termek in megrendelt_tetelek)
                    {
                        if (egy_termek.Rendeles_szama == vasarlo.Rendeles_szama)
                        {
                            int i = 0;
                            while (i < raktar_keszlet.Count && raktar_keszlet[i].Cikkszam != egy_termek.Cikszam)
                            {
                                i++;
                            }
                            raktar_keszlet[i].Mennyiseg = raktar_keszlet[i].Mennyiseg - egy_termek.Mennyiseg;
                            /*if (raktar_keszlet[i].Mennyiseg < egy_termek.Mennyiseg)
                            {
                                raktar_keszlet[i].Mennyiseg = raktar_keszlet[i].Mennyiseg - egy_termek.Mennyiseg;
                            }*/
                        }
                    }
                }
                else
                {
                    Console.WriteLine("A rendelése függő állapotba került. Hamarosan értesítjük a szállítás időpontjáról");
                    ki.WriteLine("A rendelése függő állapotba került. Hamarosan értesítjük a szállítás időpontjáról");
                }

            }
            ki.Close();

            //4. feladat
            foreach (var item in hiany)
            {
                Console.WriteLine(item.Key + "\t" + item.Value);
            }



            //adatbázis cucc
            

            string connentionString = "datasource=127.0.0.1;port=3306;" +
               "username=root;password=;database=20230412;";
            Console.WriteLine(connentionString);
            MySqlConnection databaseConnection = new MySqlConnection(connentionString);



            databaseConnection.Open();
            MySqlCommand adat = databaseConnection.CreateCommand();
            foreach (var item in raktar_keszlet)
            {
                adat.CommandText = "INSERT INTO `raktar`(`cikkszam`, `megnevezes`, `ar`,`mennyiseg` ) VALUES ('" +
                    item.Cikkszam + "','" + item.Megnevezes + "'," + item.Ar + ","
                    + item.Mennyiseg + ") ";
                Console.WriteLine(adat.CommandText);
                adat.ExecuteNonQuery();
            }
            databaseConnection.Close();
        }
    }
}