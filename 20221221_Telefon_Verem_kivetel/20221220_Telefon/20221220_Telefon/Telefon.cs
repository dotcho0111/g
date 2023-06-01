namespace _20221220_Telefon
{
    public interface ITelefon
    {
        void EgyenlegFeltoltes(int osszeg);
        void HivasKezdemenyez(long telszam, Telefon telefon);
        void HivasFogadas(long telszam, Telefon telefon);
    }
    public class Telefon : ITelefon
    {
        long _telefonszam;
        int _egyenleg;
        List<Hivasnaplo> hivasok;

        public long Telefonszam { get { return _telefonszam; } }
        public int Egyenleg { get { return _egyenleg; } }
        public List<Hivasnaplo> Hivasok { get { return hivasok; } }

        public Telefon(long telefonszam)
        {
            _telefonszam = telefonszam;
            hivasok = new List<Hivasnaplo>();
        }

        public void EgyenlegFeltoltes(int osszeg)
        {
            _egyenleg = _egyenleg + osszeg;
        }

        public override string ToString()
        {
            return $"A követekző telefonszámhoz: {Telefonszam} tartozó egyenleg: {Egyenleg} Ft.";
        }

        public void HivasKezdemenyez(long telszam, Telefon telefon)
        {
            _egyenleg = _egyenleg - 50;
            Hivasnaplo bejegyzes = new Hivasnaplo(telszam, true);
            hivasok.Add(bejegyzes);            

            string filepath = "naplo.txt";
            StreamWriter kiiras = new StreamWriter(filepath, true);
            kiiras.WriteLine($"Hívásindítás. Telefonszám: {telszam}, Időpont: {DateTime.Now}");
            kiiras.Close();

            long inditoszam = Telefonszam;
            HivasFogadas(inditoszam, telefon);
        }

        public void HivasFogadas(long forrastelszam, Telefon telefon)
        {            
            Hivasnaplo bejegyzes = new Hivasnaplo(forrastelszam, false);
            telefon.hivasok.Add(bejegyzes);            

            string filepath = "naplo.txt";
            StreamWriter kiiras = new StreamWriter(filepath, true);
            kiiras.WriteLine($"Hívásfogadás. Telefonszám: {forrastelszam}, Időpont: {DateTime.Now}");
            kiiras.Close();
        }
    }
}
