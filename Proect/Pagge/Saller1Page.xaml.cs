using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Saller1Page.xaml
    /// </summary>
    public partial class Saller1Page : Page
    {
        public List<goods_Salesman> Cheque { get; set; }
        private const int id_seller = 1;
        public Saller1Page()
        {
            InitializeComponent();
            Cheque = new List<goods_Salesman>(BDConnection.Magazins.goods_Salesman).ToList();
            this.DataContext = this;

            FilterChequesBySellerId();
        }
        private void FilterChequesBySellerId()
        {
            var sellerCheques = Cheque.Where(c => c.id_Salesman == id_seller).ToList();
            ServicesLv.ItemsSource = sellerCheques;
            if (!sellerCheques.Any())
            {
                MessageBox.Show("Нет чеков для данного продавца.");
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

        private void FiltrBTN_Click(object sender, RoutedEventArgs e)
        {
            DateTime? startDate = StartDatePicker.SelectedDate;
            DateTime? endDate = EndDatePicker.SelectedDate;

            var filteredCheques = Cheque
      .Where(c => c.id_Salesman == id_seller)
      .AsQueryable();

            if (startDate.HasValue)
            {
                filteredCheques = filteredCheques.Where(c => c.Date_1 >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                filteredCheques = filteredCheques.Where(c => c.Date_1 <= endDate.Value);
            }

            ServicesLv.ItemsSource = filteredCheques.ToList();

            // Проверка на пустые результаты
            if (!filteredCheques.Any())
            {
                MessageBox.Show("Нет чеков за указанный период для данного продавца.");
            }
        }

        private void RedBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageEdit());
        }

        private void ProductBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsPage());
        }
        private void DeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            var ser = (sender as Button).DataContext as goods_Salesman;
            MessageBox.Show($"Вы действительно хотите удалить {ser.id_Salesman}?");
            ser.IsDelete = true;
            BDConnection.Magazins.SaveChanges();
            ServicesLv.ItemsSource = new List<goods_Salesman>(BDConnection.Magazins.goods_Salesman.Where(i => i.IsDelete == false).ToList());
        }

        private void ListOnly_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pagge.PageOnly());
        }
    }
}
