using System.Windows;

namespace _20221207
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_hozzaadas_Click(object sender, RoutedEventArgs e)
        {
            hozzaadas ablak = new hozzaadas();
            ablak.ShowDialog();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            update ablak = new update();
            ablak.ShowDialog();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            delete ablak = new delete();
            ablak.ShowDialog();
        }

        private void btn_lekerdez_Click(object sender, RoutedEventArgs e)
        {
            lekerdez ablak = new lekerdez();
            ablak.ShowDialog();
        }
    }
}
