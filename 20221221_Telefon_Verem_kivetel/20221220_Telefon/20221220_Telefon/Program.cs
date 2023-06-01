namespace _20221220_Telefon
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Telefon telefon1 = new Telefon(201234567);

            Telefon telefon2 = new Telefon(307654321);


            telefon1.EgyenlegFeltoltes(500);
            telefon2.EgyenlegFeltoltes(1000);
            Console.WriteLine(telefon1.ToString());
            Console.WriteLine(telefon2.ToString());

            Console.WriteLine();

            telefon1.HivasKezdemenyez(307654321, telefon2);
            telefon2.HivasKezdemenyez(201234567, telefon1);
            telefon1.HivasKezdemenyez(307654321, telefon2);
            telefon2.HivasKezdemenyez(201234567, telefon1);
            Console.WriteLine(telefon1.Hivasok[0].ToString());
            Console.WriteLine(telefon2.Hivasok[0].ToString());
            Console.WriteLine();
            Console.WriteLine(telefon2.Hivasok[1].ToString());
            Console.WriteLine(telefon1.Hivasok[1].ToString());
            Console.WriteLine();
            Console.WriteLine(telefon1.ToString());            
            Console.WriteLine(telefon2.ToString());            
        }
    }
}