using System.IO;

using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace _20230329_morze
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter htmlbe = new StreamWriter("index.html");
            htmlbe.WriteLine("<!DOCTYPE html >\n"+
                            "<html lang = \"hu\">\n"+
                            "<head>\n"+
                                "<meta charset = \"UTF-8\">\n"+
                                "<meta http - equiv = \"X-UA-Compatible\" content = \"IE=edge\">\n"+
                                "<meta name = \"viewport\" content = \"width=device-width, initial-scale=1.0\">\n"+
                                "<title> Document </title>\n"+
                                "<link rel=\"stylesheet\" href=\"styles.css\">\n" +
                            "</head>\n" +
                            "<body>\n");


            StreamReader beolvas = new StreamReader("morzeabc.txt");
            List<adat> Jelek = new List<adat>();
            beolvas.ReadLine();
            while (!beolvas.EndOfStream)
            {
                Jelek.Add(new adat(beolvas.ReadLine()));
                Console.WriteLine(Jelek[Jelek.Count - 1].Betu);
            }
            beolvas.Close();
            Console.WriteLine("3. feladat: " + Jelek.Count + " db kód van benne");
            htmlbe.WriteLine("<p>3. feladat: " + Jelek.Count + " db kód van benne</p>");


            //4. feladat
            Console.Write("4. feladat: Kérek egykaraktert: ");
            //char karakter = Console.ReadLine().ToUpper()[0];
            char karakter = Console.ReadKey().KeyChar;
            karakter = karakter.ToString().ToUpper()[0];
            //Console.WriteLine(karakter);
            int i = 0;
            while (i < Jelek.Count && Jelek[i].Betu != karakter)
            {
                i++;
            }
            if (i < Jelek.Count)
            {
                Console.WriteLine($"\n\tA {karakter} mórze kódja: {Jelek[i].Kod}");
            }
            else
            {
                Console.WriteLine("\n\tNincs ilyen kód!");
            }

            //5. feladat
            List<adat2> idezetek = new List<adat2>();
            beolvas = new StreamReader("morze.txt");

            while (!beolvas.EndOfStream)
            {
                idezetek.Add(new adat2(beolvas.ReadLine()));
            }
            beolvas.Close();

            //6. feladat
            Console.WriteLine(Morze2Szoveg(idezetek[0].Szerzo));
            string Morze2Szoveg(string szoveg)
            {
                string s = "";
                szoveg = szoveg.Replace("       ", "@");
                string[] szavak = szoveg.Split('@');
                foreach (var szo in szavak)
                {
                    //Console.WriteLine(szo);
                    string szo2 = szo.Replace("   ", "@");
                    string[] betuk = szo2.Split('@');
                    foreach (var betu in betuk)
                    {
                        if (betu != "")
                        {
                            int j = 0;
                            while (Jelek[j].Kod != betu)
                            {
                                j++;
                            }
                            s += Jelek[j].Betu;
                        }                        
                    }
                    s += " ";
                }
                return s;
            }

            //10. feladat            
            StreamWriter kiiras = new StreamWriter("forditas.txt");
            foreach (var idezet in idezetek)
            {
                kiiras.WriteLine(Morze2Szoveg(idezet.Szerzo) + ":" + Morze2Szoveg(idezet.Idezet));
            }
            kiiras.Close();



            //8. feladat
            string[] idez = File.ReadAllLines("forditas.txt");
            for (int j = 0; j < idez.Length; j++)
            {
                idez[j] = idez[j].Replace(" :", "@");
            }
            int maxi = 0;
            string max = idez[0].Split('@')[1];
            for (int j = 0; j < idez.Length; j++)
            {
                if (max.Length < idez[j].Split('@')[1].Length)
                {
                    maxi = j;max = idez[j].Split('@')[1];
                }
            }
            Console.WriteLine(idez[maxi].Replace("@"," :"));


            //9. feladat:
            foreach (var item in idez)
            {
                if (item.Split("@")[0] == "ARISZTOTELÉSZ")
                {
                    Console.WriteLine(item.Split("@")[1]);
                }
            }


            
            htmlbe.WriteLine("</body>\n</html>");
            htmlbe.Close();
        }
    }
}
