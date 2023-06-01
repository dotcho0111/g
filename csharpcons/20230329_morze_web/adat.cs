namespace _20230329_morze
{
    public class adat
    {
        char betu;
        string kod;

        public adat(string sor)
        {
            betu = sor.Split("\t")[0][0];
            kod = sor.Split("\t")[1];
        }
        public char Betu
        {
            get { return betu; }
        }
        public string Kod
        {
            get { return kod; }
        }
    }
}
