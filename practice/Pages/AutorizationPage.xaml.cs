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

namespace practice.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /* login = Администратор
             * password = admin*/
            var login = loginText.Text;
            var password = passwordText.Text;

            var find = AppData.Connect.context.Employee
                .Where(x => x.fillNameEmployee == login && x.password == password).ToArray();
            if(find.Count() == 1)
            {
                
                if (login == "Администратор")
                    AppData.dateRole.isAdmin = true;
               else
                    AppData.dateRole.isAdmin = false;

            AppData.Nav.MainFrame.Navigate(new MainPage());
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
