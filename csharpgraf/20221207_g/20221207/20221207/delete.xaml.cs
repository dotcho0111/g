using MySql.Data.MySqlClient;
using System.Windows;

namespace _20221207
{
    /// <summary>
    /// Interaction logic for delete.xaml
    /// </summary>
    public partial class delete : Window
    {
        public delete()
        {
            InitializeComponent();
            string connentionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=konyvtarak;";
            MySqlConnection databaseConnection = new MySqlConnection(connentionString);
            databaseConnection.Open();
            string query = "SELECT * FROM konyvtarak;";
            MySqlCommand myadat = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader = myadat.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string seged = reader.GetString(1);
                    seged += "\t" + reader.GetString(2);
                    seged += "\t" + reader.GetString(3);
                    cb_lista.Items.Add(seged);
                }
            }
            databaseConnection.Close();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
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
                //adat.CommandText = "UPDATE konyvtarak SET konyvtarNev = '" + txt_adat.Text + "' WHERE konyvtarak.id='" + "" + "';";
                adat.CommandText = "DELETE FROM konyvtarak WHERE konyvtarak.id= ' + ajdiii + ';";
                MessageBox.Show(adat.CommandText);
                adat.ExecuteNonQuery();
                databaseConnection.Close();
                MessageBox.Show("Mentés sikerült!");
            }
        }
    }
}
