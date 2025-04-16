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
    /// Логика взаимодействия для RedPage.xaml
    /// </summary>
    public partial class RedPage : Page
    {
        public List<goods_Salesman> Cheque { get; set; }
        public RedPage()
        {
            InitializeComponent();
            Cheque = new List<goods_Salesman>(BDConnection.Magazins.goods_Salesman).ToList();
            this.DataContext = this;
            //this.DataContext = App.Connection.goods_Salesman.Where(z => z.id == ClassUser.CorrUsers.id).FirstOrDefault();
        }
        private void ExetBTN_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CloseBTN_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
        private void SaveBTN_Click(object sender, RoutedEventArgs e)
        {
            App.Connection.SaveChanges();
            MessageBox.Show("Изменение произошло успешно ");
        
        }

        private void ProductBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
