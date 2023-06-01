using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230426_kosar
{
    internal class adat
    {
        string haz_team;
        string ideg_team;
        int haz_pont;
        int ideg_pont;
        string hely;
        //DateTime datum;
        string datum;

        public adat(string sor)
        {
            string[] darabolt = sor.Split(';');
            haz_team = darabolt[0];
            ideg_team = darabolt[1];
            haz_pont = int.Parse(darabolt[2]);
            ideg_pont = int.Parse(darabolt[3]);
            hely = darabolt[4];
            datum = darabolt[5];
            //darabolt = darabolt[5].Split('-');
            //datum = new DateTime(int.Parse(darabolt[0]), int.Parse(darabolt[1]), int.Parse(darabolt[2]));
        }

        public string Haz_team { get { return haz_team; } set { haz_team = value; } }
        public string Ideg_team { get { return ideg_team; } set { ideg_team = value; } }
        public int Haz_pont { get { return haz_pont; } set { haz_pont = value; } }
        public int Ideg_pont { get { return ideg_pont; } set { ideg_pont = value; } }
        public string Hely { get { return hely; } set { hely = value; } }
        public string Datum { get { return datum; } }
        //public DateTime Datum { get { return datum; } set { datum = value; } }


    }
}
