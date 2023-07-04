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

        BooksManager booksManager;
        private void GoSuche(object sender, RoutedEventArgs e)
        {
            booksManager = new BooksManager(new GoogleApiSource(), tb1.Text);

            myGrid.ItemsSource = booksManager.GetBooks();
        }

        private void CalcPageSum(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"{booksManager.CountPages()} pages");
        }
    }
}
