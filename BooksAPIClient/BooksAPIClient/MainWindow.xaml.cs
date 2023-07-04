using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace BooksAPIClient
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

        private async void GoSuche(object sender, RoutedEventArgs e)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={tb1.Text}";

            var http = new HttpClient();
            var json = await http.GetStringAsync(url);

            var result = System.Text.Json.JsonSerializer.Deserialize<BooksResult>(json);

            myGrid.ItemsSource = result.items.Select(x => x.volumeInfo).ToList();

        }

        private async void CalcPageSum(object sender, RoutedEventArgs e)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={tb1.Text}";

            var http = new HttpClient();
            var json = await http.GetStringAsync(url);

            var result = System.Text.Json.JsonSerializer.Deserialize<BooksResult>(json);


            MessageBox.Show($"{result.items.Sum(x => x.volumeInfo.pageCount)} pages");
        }
    }
}
