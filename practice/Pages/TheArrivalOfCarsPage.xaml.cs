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
    /// Логика взаимодействия для TheArrivalOfCarsPage.xaml
    /// </summary>
    public partial class TheArrivalOfCarsPage : Page
    {
        public TheArrivalOfCarsPage()
        {
            InitializeComponent();
            TheArrivalOfCarsDG.ItemsSource = AppData.Connect.context.TheArrivalOfCars.ToList();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.GoBack();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.Navigate(new AddEditTheArrivalOfCarsPage(null));
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.Navigate(new AddEditTheArrivalOfCarsPage((sender as Button).DataContext as TheArrivalOfCars)); AppData.Nav.MainFrame.Navigate(new AddEditTheArrivalOfCarsPage((sender as Button).DataContext as TheArrivalOfCars));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TheArrivalOfCarsDG.ItemsSource = AppData.Connect.context.TheArrivalOfCars.ToList();
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delTheArrivalOfCars = TheArrivalOfCarsDG.SelectedItems.Cast<TheArrivalOfCars>().ToList();
            foreach (var delTheArrivalOfCar in delTheArrivalOfCars)
            {
                if (AppData.Connect.context.CarSale.Any(x => x.receiptDocument == delTheArrivalOfCar.receiptDocument))
                {
                    MessageBox.Show("Данные используются в главной таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (MessageBox.Show($"Удалить {delTheArrivalOfCars.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.Connect.context.TheArrivalOfCars.RemoveRange(delTheArrivalOfCars);
            }
            try
            {
                AppData.Connect.context.SaveChanges();
                TheArrivalOfCarsDG.ItemsSource = AppData.Connect.context.TheArrivalOfCars.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

        }

        private void UpdBtn_Click(object sender, RoutedEventArgs e)
        {
            TheArrivalOfCarsDG.ItemsSource = AppData.Connect.context.TheArrivalOfCars.ToList();
        }
    }
}
