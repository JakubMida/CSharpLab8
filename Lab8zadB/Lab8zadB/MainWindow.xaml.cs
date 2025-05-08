using Lab8zadB.Model;
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

namespace Lab8zadB
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
            listStudenci.Items.Clear();
            using(var db = new DbUczelnia())
            {
                var studenci = db.Studenci.OrderBy(s => s.Nazwisko).ToList();
                foreach (var student in studenci)
                {
                    listStudenci.Items.Add(student);
                }

                var srednia = studenci.Average(s => s.Ocena);
                lblSrednia.Content = $"Srednia ocen = {srednia:f2}";
            }

           
        }
    }
}