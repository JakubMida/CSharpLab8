using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kolokwium7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KontoBankowe konto;
        public MainWindow()
        {
            InitializeComponent();
            konto = new KontoBankowe
            {
                NumerKonta = "123456789",
                Saldo = 0,
                HistoriaTransakcji = new List<Transakcja>()
            };
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            konto.NowaTransakcja(new Transakcja { Opis = "Wplata", Kwota = 2000, Data = DateTime.Now });
            konto.NowaTransakcja(new Transakcja { Opis = "Wplata", Kwota = 1500, Data = DateTime.Now });
            konto.NowaTransakcja(new Transakcja { Opis = "Zakupy", Kwota = -500, Data = DateTime.Now });
            

            string json = JsonSerializer.Serialize(konto);
            string plikJson = "kolokwium.json";
            File.WriteAllText(plikJson, json);

        }
    }
}