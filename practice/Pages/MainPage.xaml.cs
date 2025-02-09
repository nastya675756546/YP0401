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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            if (!AppData.dateRole.isAdmin)
            {
                carBtn.Visibility = Visibility.Collapsed;
                emlBtn.Visibility = Visibility.Collapsed;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.Navigate(new CarPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.Navigate(new EmployeePage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.Navigate(new TheArrivalOfCarsPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.Navigate(new CarSalePage());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.Navigate(new ReportPage());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
