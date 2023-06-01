using System.Text;

namespace _20230201_jackie
{
    internal class Program
    {
        public static List<JackieDatas> racerdata = new List<JackieDatas>();
        static void Main(string[] args)
        {
            StreamReader read = new StreamReader("jackie.txt", Encoding.UTF8);
            string fejlec = read.ReadLine();
            while (!read.EndOfStream)
            {
                racerdata.Add(new JackieDatas(read.ReadLine()));
            }

            //3. feladat
            Console.WriteLine($"3. feladat: {racerdata.Count}");

            //4. feladat
            int max_races = 0;
            int max_index = 0;
            for (int i = 0; i < racerdata.Count; i++)
            {
                if (racerdata[i].Races > max_races)
                {
                    max_races = racerdata[i].Races;
                    max_index = i;
                }
            }
            Console.WriteLine($"4. feladat: {racerdata[max_index].Year}");

            //5. feladat
            int hatvanas = 0;
            int hetvenes = 0;            
            Console.WriteLine("5. feladat: ");
            for (int i = 0; i < racerdata.Count; i++)
            {
                if (racerdata[i].Year >= 1960 && racerdata[i].Year < 1970)
                {
                    hatvanas += racerdata[i].Wins;
                }

                if (racerdata[i].Year >= 1970 && racerdata[i].Year < 1980)
                {
                    hetvenes += racerdata[i].Wins;
                }
            }
            Console.WriteLine($"\t70-es évek: {hetvenes} megnyert verseny");
            Console.WriteLine($"\t60-es évek: {hatvanas} megnyert verseny");
            
            //6. feladat
            Console.WriteLine("6. feladat: jackie.html");
            FileStream filename = new FileStream("jackie.html", FileMode.Create);
            StreamWriter toHtml = new StreamWriter(filename, Encoding.UTF8);
            toHtml.Write("<!DOCTYPE html>");
            toHtml.Write("<html>");
            toHtml.Write("<head>");
            toHtml.Write("</head>");
            toHtml.Write("<style>td {border:1px solid black;}</style>");
            toHtml.Write("<body>");
            toHtml.Write("<h1>Jackie Stewart</h1>");
            toHtml.Write("<table>");
            for (int i = 0; i < racerdata.Count; i++)
            {
                toHtml.WriteLine($"<tr><td>{racerdata[i].Year}</td><td>{racerdata[i].Races}</td><td>{racerdata[i].Wins}</td></tr>");
            }
            toHtml.Write("</table>");
            toHtml.Write("</body>");
            toHtml.Write("</html>");
            toHtml.Close();
            filename.Close();
            Console.ReadLine();
        }
    }
}