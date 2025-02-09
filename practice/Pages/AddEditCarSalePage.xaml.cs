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
    /// Логика взаимодействия для AddEditCarSalePage.xaml
    /// </summary>
    public partial class AddEditCarSalePage : Page
    {
        CarSale carSale;
        bool CheckNew;
        public AddEditCarSalePage(CarSale c)
        {
            InitializeComponent();
            if (c == null)
            {
                carSale = new CarSale();
                DataContext = carSale;
                CheckNew = true;
            }
            else
            {
                CheckNew = false;
                DataContext = carSale = c;
            }
        }

        private void AddEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNew)
            {
                AppData.Connect.context.CarSale.Add(carSale);
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
