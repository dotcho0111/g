using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _20230316;
using System.IO;

namespace _20230316_graf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static bool CdvEll(adat x)
        {
            int k11 = x.Nem * 10;
            string seged = x.Szdatum;
            k11 += int.Parse(x.Szdatum[0].ToString()) * 9;
            k11 += int.Parse(x.Szdatum[1].ToString()) * 8;
            k11 += int.Parse(x.Szdatum[2].ToString()) * 7;
            k11 += int.Parse(x.Szdatum[3].ToString()) * 6;
            k11 += int.Parse(x.Szdatum[4].ToString()) * 5;
            k11 += int.Parse(x.Szdatum[5].ToString()) * 4;
            seged = x.Sorszam;
            k11 += int.Parse(x.Sorszam[0].ToString()) * 3;
            k11 += int.Parse(x.Sorszam[1].ToString()) * 2;
            k11 += int.Parse(x.Sorszam[2].ToString()) * 1;

            if (k11 % 11 == x.K)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        List<adat> adatList = new List<adat>();
        public MainWindow()
        {
            InitializeComponent();
            
            StreamReader be = new StreamReader("vas.txt");
            while (!be.EndOfStream)
            {
                adatList.Add(new adat(be.ReadLine()));
            }
            be.Close();

            Console.WriteLine("LIsta elemeinek száma: " + adatList.Count);
            List<adat> adatLista2 = new List<adat>();
            foreach (var item in adatList)
            {
                if (CdvEll(item) == false)
                {
                    Console.WriteLine(item.Nem_string + "-" + item.Szdatum + "-" + item.Sorszam + "-" + item.K);
                    adatLista2.Add(item);
                }
            }
            foreach (var item in adatLista2)
            {
                adatList.Remove(item);
                lista_abrazol.Items.Add(item.Nem_string + "-" + item.Szdatum + "-" + item.Sorszam + "-" + item.K);
            }
            //adatLista2.Clear(); ez most nem kell ide

            //MessageBox.Show(adatList.Count + " elem van benne", "2023.03.16.");
            string[] honapok = new string[] { "Január", "Február", "Március", "Április", "Május", "Június", "Július", "Augusztus", "Szeptember", "Október", "November", "December" };
            cb_honapok.ItemsSource = honapok;
        }

        private void cb_honapok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(cb_honapok.SelectedIndex.ToString());
            int melyik = cb_honapok.SelectedIndex + 1;
            int db = 0;
            foreach (var item in adatList)
            {
                if (int.Parse(item.Szdatum.Substring(2,2)) == melyik)
                {
                    db++;
                }
            }
            MessageBox.Show(db.ToString());
        }
    }
}
