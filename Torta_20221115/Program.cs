namespace Torta_20221115
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Torta t1 = new Torta("Eper", 1, true);
            Torta t2 = new Torta("Málna", 3, false);
            Console.WriteLine("Eper torta " + t1.mennyiKaloria());
            Console.WriteLine("Málna torta " + t2.mennyiKaloria());
            t2.UjEmelet();
            Console.WriteLine("Málna torta plusz emlettel " + t2.mennyiKaloria());
            Console.WriteLine();
            Console.WriteLine("Krémmel kenés után:");
            t1.kremmelMegken();
            t2.kremmelMegken();
            Console.WriteLine("Eper torta " + t1.mennyiKaloria());
            Console.WriteLine("Málna torta " + t2.mennyiKaloria());
        }        
    }

    class Torta
    {
        string neve;
        int emeletszam;
        bool kenveE;

        public Torta(string neve, int emeletszam, bool kenveE)
        {
            this.neve = neve;
            this.emeletszam = emeletszam;
            this.kenveE = kenveE;
        }

        public void UjEmelet()
        {
            emeletszam++;
        }

        public bool kremmelMegken()
        {
            if (kenveE == false)
            {
                kenveE = true;
                return true;
            }
            return false;
        }

        public int mennyiKaloria()
        {
            int kal = emeletszam * 1000;
            if (kenveE == true)
            {
                kal = kal * 2;
            }
            return kal;
        }
    }
}