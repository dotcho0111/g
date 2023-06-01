namespace Kivetelek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* int szam2;
             int szam;
             try
             {
                 Console.Write("Kerek egy szamot: ");
                 szam = Convert.ToInt32(Console.ReadLine());
                 if (szam != 2)
                 {
                     throw new ASzamNemEgyenloKetovelException("A szam nem felelt meg az elvárt értéknek!");
                 }

                 Console.Write("Kerek egy masik szamot: ");
                 szam2 = Convert.ToInt32(Console.ReadLine());

                 Console.WriteLine($"A két szám hanyadosa: {szam/szam2}");
             }
             catch (FormatException)
             {
                 Console.WriteLine("Hibás formátum nem számot adott meg!");
             }catch(OverflowException)
             {
                 Console.WriteLine("Túl nagy vagy túl kicsi értéket adtunk meg!");
             }
             catch (DivideByZeroException)
             {
                 Console.WriteLine("Hiba 0-val nem osztunk!");
             }
             catch(ASzamNemEgyenloKetovelException ex)
             {
                 Console.WriteLine(ex.Message);
             }
             catch(Exception)
             {
                 Console.WriteLine("Ismeretlen hiba!");
             }
             //Rossz megoldás mivel a hibák fent állhatnak megint.
             Console.Write("Kerek egy szamot: ");
             szam = Convert.ToInt32(Console.ReadLine());
             do
             {
                 Console.Write("Kerek egy masik szamot: ");
                 szam2 = Convert.ToInt32(Console.ReadLine());
             } while (szam2 < 0);
             Console.WriteLine($"A két szám hanyadosa: {szam / szam2}");
             Console.WriteLine();*/
            try
            {
                Bank blathyBank = new Bank();
                blathyBank.UjSzamlaNyitasa("Gipsz Jakab", 1000, 1);
                blathyBank.UjSzamlaNyitasa("Minta Janos", 10000, 2);
                blathyBank.UjSzamlaNyitasa("Minta Janos2", 500, 1);
                Beszedes netflix = new Beszedes("Netflix", "Gipsz Jakab", 500);
                Beszedes hbo = new Beszedes("hbo", "Minta Janos", 5000);
                Beszedes hbo2 = new Beszedes("hbo", "Minta Janos2", 5000);
                blathyBank.CsoportosBeszedes(netflix);
                Console.WriteLine(blathyBank.Szamla[0].ToString());
                blathyBank.CsoportosBeszedes(hbo);
                Console.WriteLine(blathyBank.Szamla[1].ToString());
                blathyBank.CsoportosBeszedes(hbo2);
                Console.WriteLine(blathyBank.Szamla[2].ToString());

            }
            catch(SzamlanNincsFedezetException ex)
            {
                Console.WriteLine($"A(z) {ex.Szamla.Aszonosito} Id-vel elatott szamlan " +
                    $"melynek tulajdonosa: {ex.Szamla.SzamlatulajdonosNeve}, " +
                    $"nem sikerult a {ex.Terheles:C0} terheles, mivel a kovetkezo helyzet allt fen: {ex.Message}");
            }
            catch(Exception)
            {
                Console.WriteLine("Ismeretlen hiba!");
            }
            Console.ReadLine();
        }
    }
    public class ASzamNemEgyenloKetovelException: Exception
    {
        public ASzamNemEgyenloKetovelException(string msg):base(msg)
        {
        }
    }
}