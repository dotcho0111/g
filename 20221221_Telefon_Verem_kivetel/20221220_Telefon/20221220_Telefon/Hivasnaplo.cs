namespace _20221220_Telefon
{
    public class Hivasnaplo
    {
        long _telefonszamnaplo;
        DateTime _kapcsolasiido;
        bool _kimeno;

        public long Telefonszam { get { return _telefonszamnaplo; } }
        public DateTime Kapcsolasiido { get { return _kapcsolasiido; } }
        public bool Kimeno { get; set; }
        public Hivasnaplo(long telefonszamnaplo, bool kimeno)
        {
            _telefonszamnaplo = telefonszamnaplo;
            _kapcsolasiido = DateTime.Now;
            _kimeno = kimeno;
        }
        public override string ToString()
        {
            if (_kimeno == false)
            {
                return $"A bejövő hívást a következő telefonszámról: {Telefonszam}  {Kapcsolasiido} időpontban fogadtak.";
            }
            return $"A kimenő hívást a következő telefonszámra: {Telefonszam}  {Kapcsolasiido} időpontban kezdeményeztek.";
        }
    }
}
