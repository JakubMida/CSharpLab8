using Microsoft.Data.SqlClient;
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

namespace KolosGrupaB
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

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            using(var polaczenie = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Biblioteka;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            {
                polaczenie.Open();

                var cmd = new SqlCommand("INSERT INTO Ksiazki (Tytul, Autor, RokWydania, Gatunek) VALUES (@Tytul, @Autor, @Rok, @Gatunek)", polaczenie);
                cmd.Parameters.AddWithValue("@Tytul", txtTytul.Text);
                cmd.Parameters.AddWithValue("@Autor", txtAutor.Text);
                cmd.Parameters.AddWithValue("@Rok", txtRok.Text);
                cmd.Parameters.AddWithValue(@"Gatunek", txtGatunek.Text);

                cmd.ExecuteNonQuery();
                polaczenie.Close();
            }
            
        }

        private void btnWyswietl_Click(object sender, RoutedEventArgs e)
        {
            using (var poloczenie = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Biblioteka;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Ksiazki", poloczenie);
                poloczenie.Open();
                listKsiazki.Items.Clear();

                SqlDataReader czytnik = cmd.ExecuteReader();
                while (czytnik.Read())
                {
                    string tytul = czytnik["Tytul"].ToString();
                    string autor = czytnik["Autor"].ToString();
                    string rok = czytnik["RokWydania"].ToString();
                    string gatunek = czytnik["Gatunek"].ToString();

                    listKsiazki.Items.Add($"{tytul}, {autor}, {rok}, {gatunek}");
                }
                czytnik.Close();

                var cmdSuma = new SqlCommand("SELECT COUNT(*) FROM Ksiazki", poloczenie);
                int ilosc=  (int)cmdSuma.ExecuteScalar();
                lblSuma.Content = $"ilosc ksiazek = {ilosc}";

                poloczenie.Close();
            }
        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {
            string wybrany = listKsiazki.SelectedItems.ToString();
            int id = int.Parse(wybrany.Split(":")[0]);

            using (var polaczenie = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Biblioteka;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            {
                polaczenie.Open();
                var cmd = new SqlCommand("DELETE FROM Ksiazki WHERE IdKsiazki = @id", polaczenie);
                cmd.Parameters.AddWithValue("@id", id);
                int wynik = cmd.ExecuteNonQuery();

                polaczenie.Close();
            }
            
        }
    }
}