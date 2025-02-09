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
    /// Логика взаимодействия для AddEditEmployeePage.xaml
    /// </summary>
    public partial class AddEditEmployeePage : Page
    {
        Employee employee;
        bool CheckNew;
        public AddEditEmployeePage(Employee c)
        {
            InitializeComponent();
            if (c == null)
            {
                employee = new Employee();
                DataContext = employee;
                CheckNew = true;
            }
            else
            {
                CheckNew = false;
                DataContext = employee = c;
            }
           
        }

        private void AddEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNew)
            {
                AppData.Connect.context.Employee.Add(employee);
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
