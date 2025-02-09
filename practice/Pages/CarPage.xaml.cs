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
    /// Логика взаимодействия для CarPage.xaml
    /// </summary>
    public partial class CarPage : Page
    {
        public CarPage()
        {
            InitializeComponent();
            CarDG.ItemsSource = AppData.Connect.context.Car.ToList();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.GoBack();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.Navigate(new AddEditCarPage(null));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CarDG.ItemsSource = AppData.Connect.context.Car.ToList();
        }

        private void UpdBtn_Click(object sender, RoutedEventArgs e)
        {
            CarDG.ItemsSource = AppData.Connect.context.Car.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.Navigate(new AddEditCarPage((sender as Button).DataContext as Car));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delCars = CarDG.SelectedItems.Cast<Car>().ToList();
            foreach (var delCar in delCars)
            {
                if (AppData.Connect.context.CarSale.Any(x => x.nameCar == delCar.nameCar)
                    || AppData.Connect.context.TheArrivalOfCars.Any(x => x.nameCar == delCar.nameCar))
                {
                    MessageBox.Show("Данные используются в главной таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (MessageBox.Show($"Удалить {delCars.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.Connect.context.Car.RemoveRange(delCars);
            }
            try
            {
                AppData.Connect.context.SaveChanges();
                CarDG.ItemsSource = AppData.Connect.context.Car.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void filtrBtn_Click(object sender, RoutedEventArgs e)
        {
            var filtr = AppData.Connect.context.Car
                .Where(x => x.color == filtrtext.Text).ToList();
            CarDG.ItemsSource = filtr;
        }
    }
}
