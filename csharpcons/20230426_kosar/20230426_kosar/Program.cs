using MySql.Data.MySqlClient;
namespace _20230426_kosar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<adat> Lista = new List<adat>();

            string[] sorok = File.ReadAllLines("eredmenyek.csv");
            foreach (var sor in sorok.Skip(1))
            {
                Lista.Add(new adat(sor));
            }
            /*
            Console.WriteLine(Lista.Count);
            foreach (var item in Lista)
            {
                Console.WriteLine(item.Haz_pont);
            }
            */


            //3. feladat Real Madrid hány mérkőzést játszott hazaiként és idegenként
            int real_hazai = 0;
            int real_idegen = 0;
            foreach (var item in Lista)
            {
                if (item.Haz_team == "Real Madrid")
                {
                    real_hazai++;
                }
                else if (item.Ideg_team == "Real Madrid")
                {
                    real_idegen++;

                }
            }
            Console.WriteLine($"3. feladat: Real Madrid: Hazai:{real_hazai} Idegen:{real_idegen}");

            //4. feladat:
            bool vane = false;
            foreach (var item in Lista)
            {
                if (item.Haz_pont == item.Ideg_pont)
                {
                    vane = true;
                }
            }
            if (vane)
            {
                Console.WriteLine($"4. feladat: Volt döntetlen?  igen");
            }
            else
            {
                Console.WriteLine($"4. feladat: Volt döntetlen?  nem");
            }

            //5.feladat: barceloniai csapat neve
            foreach (var item in Lista)
            {
                if (item.Haz_team.Contains("Barcelona"))
                {
                    Console.WriteLine("5. feladat: barceloniai csapat neve: " + item.Haz_team);
                    break;
                }
            }

            //6.feladat
            Console.WriteLine("6. feladat:");
            foreach (var item in Lista)
            {
                if (item.Datum == "2004-11-21")
                {
                    Console.WriteLine("\t" + item.Haz_team + "-" + item.Ideg_team + "(" + item.Haz_pont + ":" + item.Ideg_pont + ")");
                }
            }

            //7.feladat
            Console.WriteLine("7. feladat:");
            Dictionary<string, int> stadion = new Dictionary<string, int>();
            for (int i = 0; i < Lista.Count; i++)
            {
                if (stadion.ContainsKey(Lista[i].Hely))
                {
                    stadion[Lista[i].Hely] += 1;
                }
                else
                {
                    stadion.Add(Lista[i].Hely, 1);
                }
            }
            foreach (var item in stadion)
            {
                if (item.Value > 20)
                {
                    Console.WriteLine($"\t{item.Key}: {item.Value}");
                }
            }

            //Adatbázis
            string connentionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=20230426;";
            MySqlConnection databaseConnection = new MySqlConnection(connentionString);
            databaseConnection.Open();
            MySqlCommand adat = databaseConnection.CreateCommand();

            foreach (var item in Lista)
            {
                adat.CommandText = "INSERT INTO `eredmenyek`(`hazai`, `idegen`, `hazai_pont`, `idegen_pont`, `helyszin`, `idopont`) VALUES ('" + item.Haz_team + "','" + item.Ideg_team + "'," + item.Haz_pont.ToString() + "," + item.Ideg_pont.ToString() + ",'" + item.Hely + "','" + item.Datum.ToString() + "')";
                adat.ExecuteNonQuery();
            }
            databaseConnection.Close();
        }
    }
}