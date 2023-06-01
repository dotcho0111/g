namespace _20221221_Verem_Teszt
{
    public class Verem
    {
        int?[] verem_tomb;
        public int?[] Veremelemek { get { return verem_tomb; } }

        public Verem(int meret)
        {
            verem_tomb = new int?[meret];
        }

        public void Push(int num)
        {
            for (int i = 0; i < verem_tomb.Length; i++)
            {
                if (verem_tomb[i] == null)
                {
                    verem_tomb.SetValue(num, i);
                    break;
                }
                else if (verem_tomb[verem_tomb.Length - 1] != null)
                {
                    throw new VeremMegteltKivetel(num, $"A verem tömbbe nem fér a(z) \"{num}\" szám, mert megtelt.");
                }
            }
        }

        public void Pop()
        {
            for (int i = 0; i < verem_tomb.Length; i++)
            {
                if (verem_tomb[0] == null)
                {
                    throw new VeremUresKivetel("Ez a verem üres.");
                }
                else if (verem_tomb[i] == null)
                {
                    verem_tomb[i - 1] = null;
                    break;
                }
                else if (verem_tomb[verem_tomb.Length - 1] != null)
                {
                    verem_tomb[verem_tomb.Length - 1] = null;
                }
            }
        }
    }

    public class VeremMegteltKivetel : Exception
    {
        public int Beszurelem { get; set; }
        public VeremMegteltKivetel(int beszurelem, string msg) : base(msg)
        {
            Beszurelem = beszurelem;
        }
    }

    public class VeremUresKivetel : Exception
    {
        public VeremUresKivetel(string msg) : base(msg)
        {
        }
    }
}

