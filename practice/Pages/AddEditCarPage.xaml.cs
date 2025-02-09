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
    /// Логика взаимодействия для AddEditCarPage.xaml
    /// </summary>
    public partial class AddEditCarPage : Page
    {
        Car car;
        bool CheckNew;
        public AddEditCarPage(Car c)
        {
            InitializeComponent();
            if(c == null)
            {
                car = new Car();
                DataContext = car;
                CheckNew = true;
            }
            else
            {
                CheckNew = false;
                DataContext = car = c;
            }
            
        }

        private void AddEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if(CheckNew)
            {
                AppData.Connect.context.Car.Add(car);
            }
            try
            {
                AppData.Connect.context.SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            AppData.Nav.MainFrame.GoBack();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.GoBack();
        }

    }
}
