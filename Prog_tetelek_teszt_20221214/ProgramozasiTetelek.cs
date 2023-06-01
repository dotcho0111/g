namespace ProgtetelekTesztelese
{
    public class ProgramozasiTetelek
    {
        public int[] szamoktomb = new int[5];

        public void Feltolt()
        {
            Random randNum = new Random();
            for (int i = 0; i < szamoktomb.Length; i++)
            {
                szamoktomb[i] = randNum.Next(1, 10);
            }
        }

        public static bool VanE(int[] tomb, int keresettszam)
        {
            bool vane = false;
            foreach (int item in tomb)
            {
                if (item == keresettszam)
                {
                    vane = true;
                }
            }
            return vane;
        }


        public static int Osszegzes(int[] tomb)
        {
            int osszeg = 0;
            foreach (int item in tomb)
            {
                osszeg += item;
            }
            return osszeg;
        }

        public static int Kivalasztas(int[] tomb, int keresettszam)
        {
            int index = 0;
            while (index < tomb.Length && !(tomb[index] == keresettszam))
            {
                index++;
            }
            if (index < tomb.Length)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }

        public static int Megszamlalas(int[] tomb)
        {
            int darab = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] % 2 == 0)
                {
                    darab++;
                }
            }
            return darab;
        }


        public static int Maxindex(int[] tomb)
        {
            int max = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[max] < tomb[i])
                {
                    max = i;
                }
            }
            return max;
        }

        public static int Minindex(int[] tomb)
        {
            int min = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[min] > tomb[i])
                {
                    min = i;
                }
            }
            return min;
        }

        public static int[] Kivalagotas(int[] tomb)
        {
            int[] kivalogatott = new int[tomb.Length];
            int j = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] < 20)
                {
                    kivalogatott[j] = tomb[i];
                    j++;
                }
            }
            return kivalogatott;
        }



        public static int[] Buborek(int[] tomb)
        {
            int n = tomb.Length;
            for (int i = n - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (tomb[j] > tomb[j + 1])
                    {
                        int tmp = tomb[j + 1];
                        tomb[j + 1] = tomb[j];
                        tomb[j] = tmp;
                    }
                }
            }
            return tomb;
        }
    }
}
