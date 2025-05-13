using KolosGrupaA.Model;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

namespace KolosGrupaA
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
            listSamochody.Items.Clear();
            using (var db = new DbKomisy())
            {
                var samochody = db.Samochody;
                foreach(var item in samochody)
                {
                    listSamochody.Items.Add(item);
                }
                int suma = samochody.Sum(s => s.Przebieg);
                lblSamochody.Content = $"Suma przebiegu samochodów = {suma}";
            }
        }

        void Dodaj(string marka, string model, int rok, int przebieg)
        {
            var nowy = new Samochod
            {
                Marka = marka,
                Model = model,
                RokProdukcji = rok,
                Przebieg = przebieg
            };

            using (var db = new DbKomisy())
            {
                db.Samochody.Add(nowy);
                db.SaveChanges();
            }
            
        }

        private void bntDodaj_Click(object sender, RoutedEventArgs e)
        {
            Dodaj("Fiat", "Panda", 2015, 220000);
            Dodaj("Ford", "Mustang", 2019, 57000);
        }
    }
}