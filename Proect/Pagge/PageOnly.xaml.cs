using Proect.ADDO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
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
using Proect.Pagge;
using Proect.Properties;

namespace Proect.Pagge
{
    /// <summary>
    /// Логика взаимодействия для PageOnly.xaml
    /// </summary>
    public partial class PageOnly : Page
    {
        public static List<goods_Salesman> receptions { get; set; }
        public ObservableCollection<goods_Salesman> receptions1 { get; set; }
        public static List<Goods> goods { get; set; }
        public ICollectionView animalView { get; set; }
        public List<goods_Salesman> Cheque { get; set; }
        private const int id_seller = 1;
        public PageOnly()
        {
            InitializeComponent();
            Listanimals.ItemsSource = App.Connection.goods_Salesman.ToList();
            receptions = new List<goods_Salesman>(BDConnection.Magazins.goods_Salesman.Where(i => i.IsDelete == true).ToList());
            goods = new List<Goods>((BDConnection.Magazins.Goods.ToList()));
            this.DataContext = this;
            Cheque = new List<goods_Salesman>(BDConnection.Magazins.goods_Salesman).ToList();
            this.DataContext = this;
            FilterChequesBySellerId();
        }





        private void edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pagge.PageEdit());
        }


        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var ser = (sender as Button).DataContext as goods_Salesman;
            MessageBox.Show("Точно хотите удалить?");
            ser.IsDelete = false;
            BDConnection.Magazins.SaveChanges();
            Listanimals.ItemsSource = new List<goods_Salesman>(BDConnection.Magazins.goods_Salesman.Where(i => i.IsDelete == true).ToList());
            
            
        }

       
    
    private void FilterChequesBySellerId()
    {
        var sellerCheques = Cheque.Where(c => c.id_Salesman == id_seller).ToList();
            Listanimals.ItemsSource = sellerCheques;
        if (!sellerCheques.Any())
        {
            MessageBox.Show("Нет чеков для данного продавца.");
        }
    }

    private void Group_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = Group_TextBox.Text.ToLower();
            var filteredProducts = receptions.Where(p => p.id_Goods.ToString().Contains(filterText)).ToList();
            Listanimals.ItemsSource = new ObservableCollection<goods_Salesman>(filteredProducts);
        }

        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pagge.AddPage());
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

            Listanimals.ItemsSource = filteredCheques.ToList();

            // Проверка на пустые результаты
            if (!filteredCheques.Any())
            {
                MessageBox.Show("Нет чеков за указанный период для данного продавца.");
            }
        }
    }
}

