using System.Data.SqlTypes;

namespace _20230417_dhcp
{
    internal class test
    {
        string keres, cim;

        public test(string sor)
        {
            keres = sor.Split(';')[0];
            cim = sor.Split(';')[1];
        }
        public bool Keres
        {
            get
            {
                if (keres == "request")
                { return true; }

                else
                { return false; }
            }
        }

        public string Cim { get { return cim; } }
    }
}

