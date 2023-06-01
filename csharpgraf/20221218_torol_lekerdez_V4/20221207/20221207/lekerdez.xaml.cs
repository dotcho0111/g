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
        }

        private void btn_lekerdez_Click(object sender, RoutedEventArgs e)
        {

            if (cb_lista.SelectedIndex == -1)
            {
                MessageBox.Show("Nem választottál ki semmit");
            }
            else
            {
                howmany_text.Clear();
                int ajdiii = cb_lista.SelectedIndex;
                string connentionString2 = "datasource=127.0.0.1;port=3306;username=root;password=;database=konyvtarak;";
                MySqlConnection databaseConnection2 = new MySqlConnection(connentionString2);
                databaseConnection2.Open();
                MySqlCommand adat = databaseConnection2.CreateCommand();
                adat.CommandText = "SELECT megyek.megyeNev, COUNT(telepulesek.irsz) FROM megyek INNER JOIN telepulesek ON telepulesek.megyeId = megyek.id WHERE megyek.id = '" + ajdiii + "'; ";
                MessageBox.Show(adat.CommandText);
                MySqlDataReader myReader = adat.ExecuteReader();
                while (myReader.Read())
                {
                    howmany_text.Text = myReader.GetInt32("COUNT(telepulesek.irsz)").ToString();
                }
                databaseConnection2.Close();
            }
        }
    }
}
