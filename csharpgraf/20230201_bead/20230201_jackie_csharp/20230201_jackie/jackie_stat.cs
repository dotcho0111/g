using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230201_jackie
{
    class JackieDatas
    {
        public JackieDatas(string line)
        {
            string[] data = line.Split('\t');
            this.Year = Convert.ToInt32(data[0]);
            this.Races = Convert.ToInt32(data[1]);
            this.Wins = Convert.ToInt32(data[2]);
            this.Podiums = Convert.ToInt32(data[3]);
            this.Poles = Convert.ToInt32(data[4]);
            this.Fastest = Convert.ToInt32(data[5]);
        }

        public int Year { get; set; }
        public int Races { get; set; }
        public int Wins { get; set; }
        public int Podiums { get; set; }
        public int Poles { get; set; }
        public int Fastest { get; set; }
    }
}

