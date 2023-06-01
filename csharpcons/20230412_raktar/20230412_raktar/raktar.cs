namespace _20230412_raktar
{
    internal class raktar
    {
        string cikkszam;
        string megnevezes;
        int ar, mennyiseg;

        public string Cikkszam { get { return cikkszam; } }
        public int Ar { get { return ar; } }
        public string Megnevezes { get { return megnevezes; } }
        public int Mennyiseg
        {
            get { return mennyiseg; }
            set { mennyiseg = value; }
        }

        public raktar(string sor)
        {
            cikkszam = sor.Split(';')[0];
            megnevezes = sor.Split(';')[1];
            ar = int.Parse(sor.Split(';')[2]);
            mennyiseg = int.Parse(sor.Split(';')[3]);
        }
                    
    }

}
