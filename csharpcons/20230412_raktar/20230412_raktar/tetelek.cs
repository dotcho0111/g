namespace _20230412_raktar
{
    internal class tetelek
    {
        string cikkszam;
        int rendeles_szama;
        int mennyiseg;
        public tetelek(string sor)
        {
            rendeles_szama = int.Parse(sor.Split(';')[1]);
            cikkszam = sor.Split(';')[2];
            mennyiseg = int.Parse(sor.Split(';')[3]);
        }

        public string Cikszam
        {
            get { return cikkszam; }
        }
        public int Rendeles_szama
        {
            get { return rendeles_szama;  }
        }
        public int Mennyiseg
        {
            get { return mennyiseg;  }
        }
    }
}
