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
using Excel = Microsoft.Office.Interop.Excel;

namespace practice.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        Excel.Application app;
        public ReportPage()
        {
            InitializeComponent();
            app = new Excel.Application();
            {
                app.Visible = true;
                app.SheetsInNewWorkbook = 1;
            }
            Excel.Workbook workBook = app.Workbooks.Add(Type.Missing);
            app.DisplayAlerts = false;
            Excel.Worksheet sheet = (Excel.Worksheet)app.Worksheets.get_Item(1);

            sheet.Name = "Отчет";

            sheet.Cells[1, 1] = "Учет продажи автомобилей в автосалоне";
            Excel.Range range = sheet.get_Range("A1", "M1");
            range.Merge(Type.Missing);
            range.HorizontalAlignment = Excel.Constants.xlCenter;

            sheet.Cells[2, 1] = "___________________________________________________________________";
            Excel.Range range1 = sheet.get_Range("A2", "M2");
            range1.Merge(Type.Missing);
            range1.HorizontalAlignment = Excel.Constants.xlCenter;

            sheet.Cells[3, 1] = "Дата продажи";
            sheet.Cells[3, 2] = "Документ продажи";
            sheet.Cells[3, 3] = "Продал";
            sheet.Cells[3, 4] = "Дата поступления";
            sheet.Cells[3, 5] = "Документ поступления";
            sheet.Cells[3, 6] = "Принял";
            sheet.Cells[3, 7] = "Автомобиль";
            sheet.Cells[3, 8] = "Марка";
            sheet.Cells[3, 9] = "Модель";
            sheet.Cells[3, 10] = "Цвет";
            sheet.Cells[3, 11] = "Начальная цена";
            sheet.Cells[3, 12] = "Конечная цена";
            sheet.Cells[3, 13] = "Прибыль";

            var currentRow = 4;
            var CarSaleTable = AppData.Connect.context.CarSale.Select(
                x => new
                {
                    x.dataOfSale,
                    x.salesDocument,
                    x.fiiNameEmployee,
                    x.TheArrivalOfCars.dateOfReceipt,
                    x.receiptDocument,
                    x.TheArrivalOfCars.fillNameEmployee,
                    x.nameCar,
                    x.Car.stamp,
                    x.Car.model,
                    x.Car.color,
                    x.TheArrivalOfCars.initialPrice,
                    x.price,
                    pribl = (x.price - x.TheArrivalOfCars.initialPrice) * 0.8
                }).ToList();

            foreach (var item in CarSaleTable)
            {
                sheet.Cells[currentRow, 1] = item.dataOfSale;
                sheet.Cells[currentRow, 2] = item.salesDocument;
                sheet.Cells[currentRow, 3] = item.fiiNameEmployee;
                sheet.Cells[currentRow, 4] = item.dateOfReceipt;
                sheet.Cells[currentRow, 5] = item.receiptDocument;
                sheet.Cells[currentRow, 6] = item.fillNameEmployee;
                sheet.Cells[currentRow, 7] = item.nameCar;
                sheet.Cells[currentRow, 8] = item.stamp;
                sheet.Cells[currentRow, 9] = item.model;
                sheet.Cells[currentRow, 10] = item.color;
                sheet.Cells[currentRow, 11] = item.initialPrice;
                sheet.Cells[currentRow, 12] = item.price;
                sheet.Cells[currentRow, 13] = item.pribl;
                currentRow++;
            }

            var initialPriceSum = CarSaleTable.Select(
                x => new
                {
                   x.initialPrice
                }).Sum(x => x.initialPrice);

            var priceSum = CarSaleTable.Select(
                x => new
                {
                    x.price
                }).Sum(x => x.price);

            var priblSum = CarSaleTable.Select(
                x => new
                {
                    x.pribl
                }).Sum(x => x.pribl);

            sheet.Cells[currentRow, 1] = "Итого";
            Excel.Range range2 = sheet.get_Range($"A{currentRow}", $"J{currentRow}");
            range2.Merge(Type.Missing);
            range2.HorizontalAlignment = Excel.Constants.xlRight;

            sheet.Cells[currentRow, 11] = initialPriceSum;
            sheet.Cells[currentRow, 12] = priceSum;
            sheet.Cells[currentRow, 13] = priblSum;

            Excel.Range r = sheet.get_Range("A3", $"M{currentRow}");
            Excel.Borders body = r.Borders;
            body.LineStyle = Excel.XlLineStyle.xlContinuous;

            sheet.Columns.AutoFit();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppData.Nav.MainFrame.GoBack();
        }
    }
}
