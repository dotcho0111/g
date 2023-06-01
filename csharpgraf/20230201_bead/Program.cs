using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Jackie
{
    class Jackieadatatok
    {
        public Jackieadatatok(string sor)
        {
            string[] sorelemek = sor.Split('\t');
            this.Ev = Convert.ToInt32(sorelemek[0]);
            this.Ind = Convert.ToInt32(sorelemek[1]);
            this.Nyert = Convert.ToInt32(sorelemek[2]);
            this.Dobogos = Convert.ToInt32(sorelemek[3]);
            this.Elso = Convert.ToInt32(sorelemek[4]);
            this.Gyorskor = Convert.ToInt32(sorelemek[5]);
        }
        
    public int Ev { get; set; }
        public int Ind { get; set; }
        public int Nyert { get; set; }
        public int Dobogos { get; set; }
        public int Elso { get; set; }
        public int Gyorskor { get; set; }
    }
    class Program
    {
        public static List<Jackieadatatok> versenyzoadatok = new List<Jackieadatatok>();
        static void Main(string[] args)
        {
            // olvassa be a jackie. txt állomiíny sorait
            StreamReader olvas = new StreamReader("jackie.txt", Encoding.UTF8);
            string fejlec = olvas.ReadLine();//ha van fejléc
            while (!olvas.EndOfStream)//ciklus amíg nincs vége a fájlnak
            {
                versenyzoadatok.Add(new Jackieadatatok(olvas.ReadLine()));
            }
            //adatok kiíratása (nem volt feladat)
            int i, adatokdb = versenyzoadatok.Count;
            Console.WriteLine(fejlec);
            for (i = 0; i < adatokdb; i++)
            {
                Console.WriteLine("{0,-10}{1,-5}{2,-5}{3,-5}{4,-5}{5,-5}",
                versenyzoadatok[i].Ev, versenyzoadatok[i].Ind, versenyzoadatok[i].Nyert,
                versenyzoadatok[i].Dobogos, versenyzoadatok[i].Elso,
                versenyzoadatok[i].Gyorskor);
            }
            // Határozza meg és irja ki a képernyőre a minta szerint'
            //hogy az állomány hány adatsort tartalmaz!
            Console.WriteLine("3. feladat: {0}", adatokdb);
            /*4. Hatéttozza meg és írja ki a minta szerint,
            * hogy Jackie Stewart melyik évben indult el a legtöbb versenyen!
            * Feltételezheti, hogy nincs a versenyek számábanholtverseny.*/
            int max = versenyzoadatok[0].Ind;//első adat
            int maxi = 0;//sorszám
            for (i = 1; i < adatokdb; i++)
            {
                if (versenyzoadatok[i].Ind > max)
                {
                    max = versenyzoadatok[i].Ind;
                    maxi = i;
                }
            }
            Console.WriteLine("4. feladat: {0}", versenyzoadatok[maxi].Ev);
            /*5. Határozza meg és í{a ki a minta szerint, hogy Jackie Stewart számára
            * melyik évtized mennyire volt sikeres a megnyert versenyek száma alapjan!
            * Az é*izeó alatt az évek tízes csoportját erjük) azaz például a
            * 70-es évek a|att az I9,70.I979.ig terjedő tartományt. */
            int evtized;// 6: 1960-1969
                        //összegzés tétele
            Console.WriteLine("5. feladat:");
            versenyzoadatok.GroupBy(x => x.Ev / 10 - (x.Ev / 100) * 10, x =>
            x.Nyert).ToList().ForEach(x =>
            Console.WriteLine("\t{0}0-es évek: {1} megnyert verseny", x.Key, x.Sum()));
            /*Hozzon létre jackie.html néven UTF-8 kódolású szöveges állomanyt! Az állomány
            szabvrányos HTML5 formátumú legyen, azzal a kitétellel, hogy a head elem tartalma
            üresen hagyható! Az állomanybantáblázatos formában jelenjen meg a versenyzés éve, a
            versenyek és a gyózelmek száma! A táblázat felett első szintű címsorral jelenjen meg
            Jackie Stewart neve! oldja meg, hogy a táb|ázat cellái egy képpont vastag folytonos
            fekete vonallal legyenek keretezve!*/
            //jackie.html
            Console.WriteLine("6. feladat: jackie.html");
            FileStream fnev = new FileStream("jackie.html", FileMode.Create);
            StreamWriter fajlbairo = new StreamWriter(fnev, Encoding.UTF8);
            fajlbairo.Write("<!DOCTYPE html>");
            fajlbairo.Write("<html>");
            fajlbairo.Write("<head>");
            fajlbairo.Write("</head>");
            fajlbairo.Write("<style>td {border:1px solid black;}</style>");
            fajlbairo.Write("<body>");
            fajlbairo.Write("<h1>Jackie Stewart</h1>");
            fajlbairo.Write("<table>");
            for (i = 0; i < adatokdb; i++)
            {
                fajlbairo.WriteLine("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>",
                versenyzoadatok[i].Ev, versenyzoadatok[i].Ind, versenyzoadatok[i].Nyert);
            }
            fajlbairo.Write("</table>");
            fajlbairo.Write("</body>");
            fajlbairo.Write("</html>");
            fajlbairo.Close();
            fnev.Close();
            Console.ReadLine();
        }
    }
}