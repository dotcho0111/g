using System.Net.Http.Headers;

namespace _20230417_dhcp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kizarasok = File.ReadAllLines("excluded.csv");
            List<mac_ip> foglaltak = new List<mac_ip>();
            StreamReader beolvas = new StreamReader("reserved.csv");
            while (!beolvas.EndOfStream)
            {
                foglaltak.Add(new mac_ip(beolvas.ReadLine()));
            }
            beolvas.Close();

            List<mac_ip> dhcp = new List<mac_ip>();
            beolvas = new StreamReader("dhcp.csv");
            while (!beolvas.EndOfStream)
            {
                dhcp.Add(new mac_ip(beolvas.ReadLine()));
            }
            beolvas.Close();

            beolvas = new StreamReader("test.csv");
            List<test> teszt = new List<test>();
            while (!beolvas.EndOfStream)
            {
                string sor = beolvas.ReadLine();
                teszt.Add(new test(sor));
            }
            beolvas.Close();

            foreach (var item in teszt)
            {
                if (item.Keres == false)
                {
                    //eldobás
                    int i = 0;
                    while (i < dhcp.Count && dhcp[i].Ip != item.Cim)
                    {
                        i++;
                    }
                    if (i < dhcp.Count) //van benne
                    {
                        Console.WriteLine(item.Cim + " felszabadítva");
                        dhcp.RemoveAt(i);
                    }
                    else
                    {
                        Console.WriteLine("Nincs benne ilyen cím");
                    }
                }
                else
                {
                    int i = 0;
                    while (i < dhcp.Count && dhcp[i].Mac != item.Cim)
                    {
                        i++;
                    }
                    if (i < dhcp.Count)
                    {
                        Console.WriteLine("Benne volt");
                    }
                    else
                    {
                        i = 0;
                        while (i < foglaltak.Count && foglaltak[i].Mac != item.Cim)
                        {
                            i++;
                        }
                        if (i < foglaltak.Count)
                        {
                            if (dhcp.Contains(foglaltak[i]) == false)
                            {
                                string s = foglaltak[i].Mac + ";" + foglaltak[i].Ip;
                                dhcp.Add(new mac_ip(s));
                            }

                            else
                            {
                                int IP = 100;
                                while (IP < 200)
                                {
                                    string IPcim = "192.168.10." + IP.ToString();
                                    i = 0;
                                    while (i < dhcp.Count && dhcp[i].Ip != IPcim)
                                    {
                                        i++;
                                    }
                                    if (i < dhcp.Count) //benn volt
                                    {
                                        IP++;
                                    }
                                    else //nem volt benne
                                    {
                                        if (kizarasok.Contains(IPcim))
                                        {
                                            IP++;
                                        }
                                        else
                                        {
                                            i = 0;
                                            while (i < foglaltak.Count && foglaltak[i].Ip != IPcim)
                                            {
                                                i++;
                                            }
                                            if (i < foglaltak.Count)
                                            {
                                                IP++;
                                            }
                                            else
                                            {
                                                string s = item.Cim + ";" + IPcim;
                                                dhcp.Add(new mac_ip(s));
                                            }
                                        }
                                    }
                                }
                                if (IP == 200)
                                {
                                    Console.WriteLine("Nincs elég cím");
                                }
                            }
                        }
                    }
                }   
            }
            StreamWriter ki = new StreamWriter("dhcp_kesz.csv");
            foreach (var item in dhcp)
            {
                ki.WriteLine(item.Mac + ";" + item.Ip);
            }
            ki.Close();

            //bekérés
            Console.WriteLine("Adj meg IP címet: ");
            string ip = Console.ReadLine();
            foreach (var item in dhcp)
            {
                if (item.Ip == ip)
                {
                    Console.WriteLine("Van benne");
                    break;
                }
                else
                {
                    Console.WriteLine("Nincs benne");
                }
            }
            /*
            bool van = false;
            int j = 0;
            while (dhcp[j].Ip != ip)
            {
                j++;
            }
            if (j > 0)
            {
                Console.WriteLine("Van benne");
            }
            else
            {
                Console.WriteLine("Nincs benne");
            }
            */
        }
    }
}