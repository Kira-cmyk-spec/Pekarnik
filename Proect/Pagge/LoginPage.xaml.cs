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

namespace Proect.Pagge
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TBLogin.Text != "" )
            {
                var _employee = App.Connection.Salesman.Where(u => u.Name == TBLogin.Text).FirstOrDefault();
                if (_employee != null)
                {
                    if (_employee.Name != null)
                    {
                        if (_employee.id == 1)
                        {
                            MessageBox.Show("авторизация прошла успешно");
                            NavigationService.Navigate(new Saller1Page());
                            //NavigationService.Navigate(new AddPage());
                        }
                        else if (_employee.id == 2)
                        {
                            MessageBox.Show("авторизация прошла успешно");
                            NavigationService.Navigate(new Saller2Page());
                        }
                        else
                        {
                            MessageBox.Show("отказано в доступе", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("такого пользователя нет", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("не все поля заполнены", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
