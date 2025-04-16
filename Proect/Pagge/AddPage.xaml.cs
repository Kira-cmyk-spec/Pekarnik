using Proect.ADDO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using Proect.Pagge;
using Proect.Properties;

namespace Proect.Pagge
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Page
    {
        public static List<goods_Salesman> receptions { get; set; }
        public ObservableCollection<goods_Salesman> receptions1 { get; set; }
        public static List<Goods> animals { get; set; }
        public static List<Salesman> animals1 { get; set; }
        public List<goods_Salesman> Cheque { get; set; }
        public ICollectionView animalView { get; set; }
        public AddPage()
        {
            InitializeComponent();
            animals = new List<Goods>(BDConnection.Magazins.Goods.Where(i => i.id <= 5).ToList());
            animals1 = new List<Salesman>(BDConnection.Magazins.Salesman.Where(i => i.id <= 5).ToList());
            Cheque = new List<goods_Salesman>(BDConnection.Magazins.goods_Salesman).ToList();
            this.DataContext = this;
            //this.DataContext = App.Connection.goods_Salesman.Where(z => z.id == ClassUser.CorrUsers.id).FirstOrDefault();
            //receptions = new List<goods_Salesman>(BDConnection.Magazins.goods_Salesman.Where(i => i.IsDelete == true).ToList());
            //this.DataContext = this;

        }

        private void CLEventAddNewProd(object sender, RoutedEventArgs e)
        {

            try
            {


                goods_Salesman items = new goods_Salesman()
                {
                    id_Goods = (tov.SelectedItem as Goods).id,
                    id_Salesman = (prov.SelectedItem as Salesman).id,
                    Date_1 = DateTime.Now,
                    Kol_goods = Convert.ToInt32(kol.Text),
                    summa = sum.Text,
                    IsDelete = true,


                };
              

                App.Connection.goods_Salesman.Add(items);



                App.Connection.SaveChanges();
                MessageBox.Show("Добавление произошло  успешно ");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}

