namespace _20230329_morze
{
    public class adat2
    {
        string szerzo;
        string idezet;

        public string Szerzo { get { return szerzo; } set { szerzo = value; } }
        public string Idezet { get { return idezet; } set { idezet = value; } }

        public adat2(string sor)
        {
            szerzo = sor.Split(';')[0];
            idezet = sor.Split(';')[1];
        }
    }

}
