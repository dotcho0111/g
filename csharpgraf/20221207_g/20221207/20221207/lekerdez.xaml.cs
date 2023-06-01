using MySql.Data.MySqlClient;
using System.Windows;

namespace _20221207
{
    /// <summary>
    /// Interaction logic for lekerdez.xaml
    /// </summary>
    public partial class lekerdez : Window
    {
        public lekerdez()
        {
            InitializeComponent();
            string connentionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=konyvtarak;";
            MySqlConnection databaseConnection = new MySqlConnection(connentionString);
            databaseConnection.Open();
            string query = "SELECT * FROM megyek;";
            MySqlCommand myadat = new MySqlCommand(query, databaseConnection);
            MySqlDataReader olvas = myadat.ExecuteReader();
            if (olvas.HasRows)
            {
                while (olvas.Read())
                {
                    string seged = olvas.GetString(1);
                    cb_lista.Items.Add(seged);
                }
            }

            databaseConnection.Close();
            olvas.Close();
        }

        private void btn_lekerdez_Click(object sender, RoutedEventArgs e)
        {

            if (cb_lista.SelectedIndex == -1)
            {
                MessageBox.Show("Nem választottál ki semmit");

            }
            else
            {
                int ajdiii = cb_lista.SelectedIndex + 1;
                string connentionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=konyvtarak;";
                MySqlConnection databaseConnection = new MySqlConnection(connentionString);
                databaseConnection.Open();
                MySqlCommand adat = databaseConnection.CreateCommand();
                adat.CommandText = "SELECT megyek.megyeNev, COUNT(telepulesek.irsz) FROM megyek INNER JOIN telepulesek ON telepulesek.megyeId = ' + ajdiii + '; ";
                MessageBox.Show(adat.CommandText);
                adat.ExecuteReader();
                MySqlDataReader myReader = adat.ExecuteReader();
                while (myReader.Read())
                {
                    howmany_text.Text = myReader.GetInt32("COUNT(telepulesek.irsz)").ToString();
                }
                databaseConnection.Close();
                //A kiíratás nem sikerült :(


            }
        }
    }
}
