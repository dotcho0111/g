using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace _20221201_kari
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] nevek;
        public MainWindow()
        {
            InitializeComponent();
            nevek = File.ReadAllLines("nevsor2.txt");
        }

        private void btn_sorsolas_Click(object sender, RoutedEventArgs e)
        {
            lista.Items.Clear();
            List<string> seged = nevek.ToList();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            //MessageBox.Show(seged[0]);
            foreach (var nev in nevek)
            {
                dict.Add(nev, "");
            }
            Random vsz = new Random();
            int i = 0;
            for (i = 0; i < dict.Count; i++)
            {
                int szam = vsz.Next(0, seged.Count);
                if (nevek[i] != seged[szam])
                {
                    dict[nevek[i]] = seged[szam];
                    seged.RemoveAt(szam);
                }
                else
                {
                    i--;
                }
            }
            i = 1;
            foreach (var item in dict)
            {
                lista.Items.Add((i++).ToString() + ": " + item.Key + " | " + item.Value);
            }
        }

        private void nyomtat_Click(object sender, RoutedEventArgs e)
        {
            /*PrintDialog vmi = new PrintDialog();
            if (vmi.ShowDialog() == true)
            {
                //vmi.PrintDocument(DocumentPaginator vmi.);

            }*/
            //PrintDialog printDlg = new PrintDialog();
            //printDlg.PrintVisual(lista, "Listbox Printing.");

            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                FlowDocument flowDoc = new FlowDocument();
                flowDoc.Blocks.Add(new Paragraph(new Run(lista.Items.ToString())));
                //flowDoc.Name = "Print ListBox Content";
                IDocumentPaginatorSource idpSource = flowDoc;
                printDialog.PrintDocument(idpSource.DocumentPaginator, "Print ListBox Content");
            }
        }
    }
}
