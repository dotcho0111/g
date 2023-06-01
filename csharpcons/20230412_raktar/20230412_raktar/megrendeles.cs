namespace _20230412_raktar
{
    internal class megrendeles
    {
        DateTime datum;
        int rendeles_szama;
        string email;

        public megrendeles(string sor)
        {
            string[] darabolt = sor.Split(';');
            datum = DateTime.Parse(darabolt[1]);
            rendeles_szama = int.Parse(darabolt[2]);
            email = darabolt[3];
        }
        public DateTime Datum
        {
            get { return datum; }
        }
        public int Rendeles_szama { get { return rendeles_szama; } }
        public string Email { get { return email; } }
    }
}
