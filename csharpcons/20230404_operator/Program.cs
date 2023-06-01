using MySql.Data.MySqlClient;

namespace _20230404_operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<adat> lista = new List<adat>();
            StreamReader be = new StreamReader("kifejezesek.txt");

            DateTime kezdes = DateTime.Now;
            int db = 0;
            while (!be.EndOfStream)
            {
                string sor = be.ReadLine();
                lista.Add(new adat(sor));
                if (sor.Contains("mod"))
                {
                    db++;
                }

            }
            be.Close();
            DateTime vege = DateTime.Now;
            Console.WriteLine(vege - kezdes);

            //2. feladat
            Console.WriteLine("2. feladat: Kifejezések száma: " + lista.Count);

            //3. feladat
            Console.WriteLine("3. feladat: Kifejezések maradékos osztással: " + db);

            //3. alternatív
            kezdes = DateTime.Now;
            int dbb = 0;
            foreach (var item in lista)
            {
                if (item.Muvelet == "mod")
                {
                    dbb++;
                }
            }
            Console.WriteLine("3. feladat: Kifejezések maradékos osztással: " + dbb);
            vege = DateTime.Now;
            Console.WriteLine(vege - kezdes);

            //4. feladat
            kezdes = DateTime.Now;
            bool volt = false;
            foreach (var item in lista)
            {
                if (item.Elso % 10 == 0 && item.Masodik % 10 == 0)
                {
                    volt = true;
                    break;
                }
            }
            if (!volt)
            {
                Console.WriteLine("Nem vót");
            }
            else
            {
                Console.WriteLine("volt");
            }
            vege = DateTime.Now;
            Console.WriteLine("4/1: " + (vege - kezdes));
            //4. feladat másik megoldás
            kezdes = DateTime.Now;
            volt = false;
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Elso % 10 == 0 && lista[i].Masodik % 10 == 0)
                {
                    i = lista.Count;
                    volt = true;
                }
            }
            if (!volt)
            {
                Console.WriteLine("Nem vót");
            }
            else
            {
                Console.WriteLine("volt");
            }
            vege = DateTime.Now;
            Console.WriteLine("4/2: " + (vege - kezdes));

            //4. feladat harmadik megoldás
            kezdes = DateTime.Now;
            volt = false;
            int j = 0;
            while (!(lista[j].Elso % 10 == 0 && lista[j].Masodik % 10 == 0))
            {
                j++;
            }
            if (j > 0)
            {
                volt = true;
                Console.WriteLine("Volt");
            }
            else
            {
                Console.WriteLine("Nem vót");
            }
            vege = DateTime.Now;
            Console.WriteLine("4/3: " + (vege - kezdes));

            //5. feladat
            kezdes = DateTime.Now;
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (var item in lista)
            {
                if (dict.ContainsKey(item.Muvelet))
                {
                    dict[item.Muvelet]++;
                }
                else
                {
                    dict.Add(item.Muvelet, 1);
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine("\t" + item.Key + " -> " + item.Value);
            }
            vege = DateTime.Now;
            Console.WriteLine("5/1: " + (vege - kezdes));

            //5. feladat második megoldás
            kezdes = DateTime.Now;
            HashSet<string> halmaz = new HashSet<string>();
            foreach (var item in lista)
            {
                halmaz.Add(item.Muvelet);
            }
            foreach (var item in halmaz)
            {
                db = 0;
                foreach (var item2 in lista)
                {
                    if (item2.Muvelet == item)
                    {
                        db++;
                    }
                }
                Console.WriteLine("\t" + item + " -> " + db);
            }


            Dictionary<string, int> dict2 = new Dictionary<string, int>();
            dict2.Add("+", 0);
            dict2.Add("-", 0);
            dict2.Add("*", 0);
            dict2.Add("/", 0);
            dict2.Add("div", 0);
            dict2.Add("mod", 0);

            foreach (var item in lista)
            {
                if (dict2.ContainsKey(item.Muvelet))
                {
                    dict2[item.Muvelet]++;
                }
            }

            foreach (var item in dict2)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            vege = DateTime.Now;
            Console.WriteLine("5/2: " + (vege - kezdes));

            //6-7-8. feladat

            Console.WriteLine("Kérek egy kifejezést: ");
            string sor2 = Console.ReadLine();
            try
            {
                string[] darabol = sor2.Split(' ');
                int.Parse(darabol[0]);
                int.Parse(darabol[2]);
                adat muv = new adat(sor2);
                Console.WriteLine(fuggveny(muv));
            }
            catch (Exception)
            {

                Console.WriteLine("Hibás adat");
            }



            //Fájlbaírás
            if (File.Exists("eredmenyek.txt"))
            {
                char c = ' ';

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Felül írod? I/N: ");
                    c = Console.ReadKey().KeyChar;
                    c = c.ToString().ToUpper()[0];

                } while (c != 'I' && c != 'N');
                if (c == 'I')
                {
                    StreamWriter ki1 = new StreamWriter("eredmenyek.txt");
                    foreach (var item in lista)
                    {
                        ki1.WriteLine(fuggveny(item));
                    }
                    ki1.Close();
                }
            }
            else
            {

                StreamWriter ki = new StreamWriter("eredmenyek.txt");
                foreach (var item in lista)
                {
                    ki.WriteLine(fuggveny(item));
                }
                ki.Close();
            }
            //Fájlbaírás vége



            string fuggveny(adat valami)
            {
                string vissater = "";
                if (!dict2.ContainsKey(valami.Muvelet))
                {
                    vissater = valami.Elso.ToString() + " " + valami.Muvelet + " " + valami.Masodik.ToString() + " = Hibás operátor";
                }
                else
                {
                    double eredmeny = 0;

                    try
                    {
                        switch (valami.Muvelet)
                        {
                            case "div":
                                eredmeny = valami.Elso / valami.Masodik;
                                break;
                            case "mod":
                                eredmeny = valami.Elso % valami.Masodik;
                                break;
                            case "+":
                                eredmeny = valami.Elso + valami.Masodik;
                                break;
                            case "*":
                                eredmeny = valami.Elso * valami.Masodik;
                                break;
                            case "-":
                                eredmeny = valami.Elso - valami.Masodik;
                                break;
                            case "/":
                                if (valami.Masodik != 0)
                                {
                                    eredmeny = (double)valami.Elso / valami.Masodik;
                                }
                                else
                                {
                                    eredmeny = valami.Elso / valami.Masodik;
                                }
                                break;
                        }
                        vissater = valami.Elso.ToString() + " " + valami.Muvelet + " " + valami.Masodik.ToString() + " = " + eredmeny.ToString();

                    }
                    catch (Exception)
                    {

                        vissater = valami.Elso.ToString() + " " + valami.Muvelet + " " + valami.Masodik.ToString() + " = Hibás adat";
                    }
                }
                return vissater;
            }

            //adatbázis cucc
            string connentionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=20230404;";
            MySqlConnection databaseConnection = new MySqlConnection(connentionString);

            databaseConnection.Open();
            MySqlCommand adat = databaseConnection.CreateCommand();

            foreach (var item in lista)
            {


                adat.CommandText = "INSERT INTO `adat`(`elso`, `masodik`, `muvelet`) VALUES (" + item.Elso.ToString() + "," + item.Masodik.ToString()+",'" + item.Muvelet + "')";
                adat.ExecuteNonQuery();
            }
            databaseConnection.Close();
        }
    }
}