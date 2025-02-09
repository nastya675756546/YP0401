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
    /// Логика взаимодействия для CarSalePage.xaml
    /// </summary>
    public partial class CarSalePage : Page
    {
        public CarSalePage()
        {
            InitializeComponent();
            CarSaleDG.ItemsSource = AppData.Connect.context.CarSale.ToList();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.GoBack();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.Navigate(new AddEditCarSalePage(null));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.Navigate(new AddEditCarSalePage((sender as Button).DataContext as CarSale)); AppData.Nav.MainFrame.Navigate(new AddEditCarSalePage((sender as Button).DataContext as CarSale));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CarSaleDG.ItemsSource = AppData.Connect.context.CarSale.ToList();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delCarsSale = CarSaleDG.SelectedItems.Cast<CarSale>().ToList();
            
            if (MessageBox.Show($"Удалить {delCarsSale.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.Connect.context.CarSale.RemoveRange(delCarsSale);
            }
            try
            {
                AppData.Connect.context.SaveChanges();
                CarSaleDG.ItemsSource = AppData.Connect.context.CarSale.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void UpdBtn_Click(object sender, RoutedEventArgs e)
        {
            CarSaleDG.ItemsSource = AppData.Connect.context.CarSale.ToList();
        }

        private void findBtn_Click(object sender, RoutedEventArgs e)
        {
            var find = AppData.Connect.context.CarSale
                .Where(x => x.nameCar.Contains(findtext.Text)).ToList();
            CarSaleDG.ItemsSource = find;
        }
    }
}
