using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;

namespace Lab8ZadA
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

        private void btnWczytaj_Click(object sender, RoutedEventArgs e)
        {
            using (var polaczenia = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sklep2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            {
                SqlCommand zapytanie = new SqlCommand("SELECT Nazwa FROM Towary", polaczenia);
                SqlCommand sredniaCen = new SqlCommand("Select AVG(Cena) FROM Towary", polaczenia);
                polaczenia.Open();
                listTowary.Items.Clear();
                int ilosc = 0;

                SqlDataReader czytnik = zapytanie.ExecuteReader();
                while (czytnik.Read())
                {

                    //decimal cena = czytnik.GetDecimal(czytnik.GetOrdinal("Cena"));
                    //ilosc = czytnik.GetInt32(czytnik.GetOrdinal("Ilość"));

                    //listTowary.Items.Add($"{nazwa}, cena: {cena}zł, ilość = {ilosc}");
                    listTowary.Items.Add(czytnik["Nazwa"]);

                }
                czytnik.Close();
                polaczenia.Close();
            }
        }
    }
}