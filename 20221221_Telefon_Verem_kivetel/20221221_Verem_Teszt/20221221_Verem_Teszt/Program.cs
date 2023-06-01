namespace _20221221_Verem_Teszt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Verem verem1 = new Verem(4);
            try
            {
                               
                verem1.Push(1);
                verem1.Push(2);
                verem1.Push(3);
                verem1.Push(4);
                verem1.Push(5);
                
                
            }
            catch (VeremMegteltKivetel ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (VeremUresKivetel ex)
            {
                Console.WriteLine(ex.Message);
            }



            try
            {
                Verem verem2 = new Verem(6);
                verem2.Pop();
            }
            catch (VeremMegteltKivetel ex)
            {
                Console.WriteLine(ex.Message);                
            }
            catch (VeremUresKivetel ex)
            {
                Console.WriteLine(ex.Message);
            }

            verem1.Pop();
        }
    }
}