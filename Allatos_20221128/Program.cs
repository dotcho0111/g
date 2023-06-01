namespace _20221128_allati_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Állatok létrehozása
            Allat allat1a = new Allat("Kormos", true, 20, "kutya");
            Allat allat2a = new Allat("Mici", false, 320, "panda");
            Allat allat3a = new Allat("Kajás", true, 40, "kutya");
            Allat allat4a = new Allat("Killer", true, 3, "kutya");
            Allat allat5a = new Allat("Kaller", true, 5, "kutya");

            Allat allat1b = new Allat("Nori", true, 4, "nyul");
            Allat allat2b = new Allat("Marcsi", false, 320, "panda");
            Allat allat3b = new Allat("Nandi", true, 4, "nyul");

            Allat allat1c = new Allat("Kolbasz", true, 40, "kutya");
            Allat allat2c = new Allat("Kati", false, 13, "kutya");
            Allat allat3c = new Allat("Karesz", true, 15, "kutya");

            Allat allat1d = new Allat("Nindzsa", true, 2, "nyul");
            Allat allat2d = new Allat("Nyami", false, 12, "nyul");
            Allat allat3d = new Allat("Kicsi", false, 10, "kutya");
            Allat allat4d = new Allat("Norbi", true, 5, "nyul");
            Allat allat5d = new Allat("Krumpli", true, 10, "kutya");

            
            //Ketrecek létrehozása
            Ketrec ketrec1 = new Ketrec(5);
            Ketrec ketrec2 = new Ketrec(3);
            Ketrec ketrec3 = new Ketrec(5);
            Ketrec ketrec4 = new Ketrec(5);

            //Állatok ketrecekbe helyezése
            ketrec1.Felvetel(allat1a);
            ketrec1.Felvetel(allat2a);
            ketrec1.Felvetel(allat3a);
            ketrec1.Felvetel(allat4a);
            ketrec1.Felvetel(allat5a);

            ketrec2.Felvetel(allat1b);
            ketrec2.Felvetel(allat2b);
            ketrec2.Felvetel(allat3b);

            ketrec3.Felvetel(allat1c);
            ketrec3.Felvetel(allat2c);
            ketrec3.Felvetel(allat3c);

            ketrec4.Felvetel(allat1d);
            ketrec4.Felvetel(allat2d);
            ketrec4.Felvetel(allat3d);
            ketrec4.Felvetel(allat4d);
            ketrec4.Felvetel(allat5d);

            //4 db. Ketrec objektumot tartalmazó tömb
            Ketrec[] ketrectomb = new Ketrec[] { ketrec1, ketrec2, ketrec3, ketrec4 };
            

            Console.WriteLine($"1. Ennyi megadott fajú állat található a megadott ketrecben: {FajDarab(ketrec4, "kutya")}");
            Console.WriteLine($"2. Van-e megadott fajú és nemű állat a megadott ketrecben: {VaneFajNem(ketrec3, "nyul", true)}");
            Console.Write("3. Megadott ketrecben melyek a megadott fajú állatok: ");
            foreach (Allat allat in FajAllatok(ketrec2, "nyul"))
            {
                Console.Write(allat.Nev + " "); //nem sikerült kiiratni az állat objektum nevét, ezért .Nev-et írattam ki
            }
            Console.WriteLine();
            Console.WriteLine($"4. Ennyi a megadott fajú állatok átlagos tömege a megadott ketrecben: {AtlagFajTomeg(ketrec4, "kutya")}");
            Console.WriteLine($"5. Van-e a megadott ketrecben azonos fajú, de ellenkező nemű állat: {AzonosFajEllenkezoNemVanE(ketrec4)}");
            Console.WriteLine($"6. Melyik ketrecben található a legtöbb állat a megadott fajból: {LegtobbFaj("nyul")}");


            //------------------------------------------------------------------------------------------------------------------
            //1. Megadott ketrecben hány darab megadott fajú állat található?
            int FajDarab(Ketrec ketrecnev, string faj)
            {
                int db = 0;
                for (int i = 0; i < ketrecnev.allatok_tomb.Length; i++)
                {
                    if (ketrecnev.allatok_tomb[i] == null)
                    {
                        continue;
                    }

                    else if (ketrecnev.allatok_tomb[i].Faj == faj)
                    {
                        db++;
                    }
                }
                return db;
            }



            //------------------------------------------------------------------------------------------------------------------
            //2. Megadott ketrecben van - e megadott fajú és nemű állat?
            bool VaneFajNem(Ketrec ketrecnev, string faj, bool nem)
            {
                int db = 0;
                for (int i = 0; i < ketrecnev.allatok_tomb.Length; i++)
                {
                    if (ketrecnev.allatok_tomb[i] == null)
                    {
                        continue;
                    }
                    else if (ketrecnev.allatok_tomb[i].Faj == faj && ketrecnev.allatok_tomb[i].Nem == nem)
                    {
                        db++;
                    }
                }
                if (db > 0)
                {
                    return true;
                }
                return false;
            }



            //------------------------------------------------------------------------------------------------------------------
            //3. Megadott ketrecben melyek a megadott fajú állatok ?
            Allat[] FajAllatok(Ketrec ketrecnev, string faj)
            {
                List<Allat> list = new List<Allat>();
                for (int i = 0; i < ketrecnev.allatok_tomb.Length; i++)
                {
                    if (ketrecnev.allatok_tomb[i] == null)
                    {
                        continue;
                    }
                    else if (ketrecnev.allatok_tomb[i].Faj == faj)
                    {
                        list.Add(ketrecnev.allatok_tomb[i]);

                    }
                }
                Allat[] ezenallatok = list.ToArray();
                return ezenallatok;
            }


            //------------------------------------------------------------------------------------------------------------------
            //4. Megadott ketrecben mennyi a megadott fajú állatok átlagos tömege?
            float AtlagFajTomeg(Ketrec ketrecnev, string faj)
            {
                float sum = 0;
                int db = 0;
                for (int i = 0; i < ketrecnev.allatok_tomb.Length; i++)
                {
                    if (ketrecnev.allatok_tomb[i] == null)
                    {
                        continue;
                    }
                    else if (ketrecnev.allatok_tomb[i].Faj == faj)
                    {
                        sum = sum + ketrecnev.allatok_tomb[i].Suly;
                        db++;
                    }
                }
                return sum / db;
            }



            //------------------------------------------------------------------------------------------------------------------
            //5. Megadott ketrecben van-e legalább egy azonos fajú, de ellenkező nemű egyedekből álló páros?
            bool AzonosFajEllenkezoNemVanE(Ketrec ketrecnev)
            {
                for (int i = 0; i < ketrecnev.allatok_tomb.Length; i++)
                {
                    if (ketrecnev.allatok_tomb[i] == null)
                    {
                        continue;
                    }
                    else
                    {
                        for (int j = 0; j < ketrecnev.allatok_tomb.Length; j++)
                        {
                            if (ketrecnev.allatok_tomb[j].Faj == ketrecnev.allatok_tomb[i].Faj && !ketrecnev.allatok_tomb[j].Nem == ketrecnev.allatok_tomb[i].Nem)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }



            //------------------------------------------------------------------------------------------------------------------
            //6. Melyik ketrecben található a legtöbb megadott fajú állat?
            Ketrec LegtobbFaj(string faj)
            {                
                int sum = 0;
                List<int> ketrecperallat = new List<int>();
                for (int i = 0; i < ketrectomb.Length; i++)
                {
                    sum = 0;
                    if (ketrectomb[i].allatok_tomb[i] == null)
                    {
                        continue;
                    }
                    else 
                    {
                        for (int j = 0; j < ketrectomb[i].allatok_tomb.Length; j++)
                        {
                            if (ketrectomb[i].allatok_tomb[j] == null)
                            {
                                continue;
                            }                            
                            else if (ketrectomb[i].allatok_tomb[j].Faj == faj)
                            {
                                sum++;
                            }

                        }
                        ketrecperallat.Add(sum);
                    }
                }
                int maxindex = ketrecperallat.IndexOf(ketrecperallat.Max());
                return ketrectomb[maxindex]; //nem sikerült kiiratni a ketrec objektum nevét
            }            
        }
    }

    public class Allat
    {
        string _nev;
        bool _nem;
        int _suly;
        string _faj;

        public string Nev { get { return _nev; } }
        public bool Nem { get { return _nem; } }
        public int Suly { get { return _suly; } }
        public string Faj { get { return _faj; } }

        public Allat(string nev, bool nem, int suly, string faj)
        {
            _nev = nev;
            _nem = nem;
            _suly = suly;
            _faj = faj;

        }
    }
    
    public class Ketrec
    {
        public Allat[] allatok_tomb;

        public Ketrec(int size)
        {
            allatok_tomb = new Allat[size];
        }

        public void Felvetel(Allat allatka)
        {
            for (int i = 0; i < allatok_tomb.Length; i++)
            {

                if (allatok_tomb[i] == null)
                {
                    allatok_tomb.SetValue(allatka, i);
                    break;
                }
            }
        }

        public void Torol(Allat allatka)
        {
            for (int i = 0; i < allatok_tomb.Length; i++)
            {
                if (allatok_tomb[i] == allatka)
                {
                    allatok_tomb[i] = null;
                }
            }
        }
    }
}