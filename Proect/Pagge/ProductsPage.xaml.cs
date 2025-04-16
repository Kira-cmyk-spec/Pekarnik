using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Proect.ADDO;

namespace Proect.Pagge
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public List<Goods> Products { get; set; }
        public ObservableCollection<Goods> FilteredProducts { get; set; }
        public ProductsPage()
        {
            InitializeComponent();
            LoadProducts();
            this.DataContext = this;
        }
        private void LoadProducts()
        {
            Products = new List<Goods>(BDConnection.Magazins.Goods).ToList();
            FilteredProducts = new ObservableCollection<Goods>(Products); 
            ServicesLv.ItemsSource = FilteredProducts;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower(); 

            var filtered = Products
                .Where(p => p.Name.ToLower().Contains(searchText))
                .ToList();

            FilteredProducts.Clear(); 
            foreach (var product in filtered)
            {
                FilteredProducts.Add(product); 
            }

            if (!filtered.Any())
            {
                MessageBox.Show("Товары не найдены.");
            }
        }

        private void ExetBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CloseBTN_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

    }
}
