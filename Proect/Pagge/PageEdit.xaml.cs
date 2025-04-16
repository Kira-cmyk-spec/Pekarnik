using Proect.ADDO;
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
using Proect.Pagge;
using Proect.ADDO;
using Proect.classApp;
using Proect.Properties;
using System.Collections.ObjectModel;


namespace Proect.Pagge
{
    /// <summary>
    /// Логика взаимодействия для PageEdit.xaml
    /// </summary>
    public partial class PageEdit : Page
    {
        public static List<goods_Salesman> animals0 { get; set; }
        public ObservableCollection<goods_Salesman> receptions1 { get; set; }
        public static List<Goods> animals { get; set; }
        public static List<Salesman> animals1 { get; set; }
        public List<goods_Salesman> Cheque { get; set; }
        public PageEdit()
        {
            InitializeComponent();
            Cheque = new List<goods_Salesman>(BDConnection.Magazins.goods_Salesman).ToList();
            this.DataContext = this;
       
            animals = new List<Goods>(BDConnection.Magazins.Goods.Where(i => i.id <= 5).ToList());
            animals1 = new List<Salesman>(BDConnection.Magazins.Salesman.Where(i => i.id <= 5).ToList());
            animals0 = new List<goods_Salesman>(BDConnection.Magazins.goods_Salesman.Where(i => i.id <= 5).ToList());
            //this.DataContext = App.Connection.goods_Salesman.Where(z => z.id == Class_User.CorrUsers.id).FirstOrDefault();
        }

        private void CliventSave(object sender, RoutedEventArgs e)
        {
            App.Connection.SaveChanges();
            MessageBox.Show("Изменение произошло успешно ");
            NavigationService.Navigate(new Pagge.PageOnly());

        }
    }
}
