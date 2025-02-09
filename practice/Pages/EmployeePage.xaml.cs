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
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
            EmployeeDG.ItemsSource = AppData.Connect.context.Employee.ToList();

        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.GoBack();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.Navigate(new AddEditEmployeePage(null));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeDG.ItemsSource = AppData.Connect.context.Employee.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.Navigate(new AddEditEmployeePage((sender as Button).DataContext as Employee)); AppData.Nav.MainFrame.Navigate(new AddEditEmployeePage((sender as Button).DataContext as Employee));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var delEmployees = EmployeeDG.SelectedItems.Cast<Employee>().ToList();
            foreach (var delEmployee in delEmployees)
            {
                if (AppData.Connect.context.CarSale.Any(x => x.fiiNameEmployee == delEmployee.fillNameEmployee)
                    || AppData.Connect.context.TheArrivalOfCars.Any(x => x.fillNameEmployee == delEmployee.fillNameEmployee))
                {
                    MessageBox.Show("Данные используются в главной таблице", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            if (MessageBox.Show($"Удалить {delEmployees.Count} записей", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                AppData.Connect.context.Employee.RemoveRange(delEmployees);
            }
            try
            {
                AppData.Connect.context.SaveChanges();
                EmployeeDG.ItemsSource = AppData.Connect.context.Employee.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void UpdBtn_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDG.ItemsSource = AppData.Connect.context.Employee.ToList();
        }
    }
}
