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
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using RetrospektivaApp.Entities;

namespace RetrospektivaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShowOrderPage.xaml
    /// </summary>
    public partial class ShowOrderPage : Page
    {
        Order _currentOrder; // текущий заказ
        User _currentUser;// текущий пользователь
        public ShowOrderPage(Order order)
        {
            InitializeComponent();
            _currentUser = order.User;
            LoadDataAndInit(order);
        }
        // Загрузка и инициализация данных
        void LoadDataAndInit(Order order)
        {
            _currentOrder = order;
            DataGridDoorsOrder.ItemsSource = null;
            DataGridDoorsOrder.ItemsSource = order.OrderProducts;

            DataGridServicesOrder.ItemsSource = null;
            DataGridServicesOrder.ItemsSource = order.OrderServices;


            if (_currentUser != null)
            {
                TextBlockOrderNumber.Text = $"Заказ №{_currentOrder.Id} на имя " +
                    $"{ _currentUser.LastName} {_currentUser.FirstName} оформлен";
            }
            else
            {
                TextBlockOrderNumber.Text = $"Заказ №{_currentOrder.Id}";
            }
            TextBlockTotalCost.Text = $"Итого {_currentOrder.Total:C}";
            TextBlockOrderCreateDate.Text = _currentOrder.DateOrder.ToString("f");


        }



        private void BtnSavePDF_Click(object sender, RoutedEventArgs e)
        {
            PrintInPdf(_currentOrder);
        }

        void PrintInPdf(Order order)
        {
            try
            {
                string path = null;
                // указываем файл для сохранения
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF (.pdf)|*.pdf"; // Filter files by extension
                                                            // если диалог завершился успешно
                if (saveFileDialog.ShowDialog() == true)
                {
                    path = saveFileDialog.FileName;
                    Word.Application application = new Word.Application();
                    Word.Document document = application.Documents.Add();
                    Word.Paragraph paragraph = document.Paragraphs.Add();
                    Word.Range range = paragraph.Range;
                    range.Font.Bold = 1;
                    range.Text = $"Номер заказа: {order.Id}";
                    range.InsertParagraphAfter();

                    range = paragraph.Range;
                    range.Font.Bold = 0;
                    range.Text = $"Дата: {order.DateOrder}\n";
                    range.InsertParagraphAfter();

                    range = paragraph.Range;
                    range.Font.Bold = 0;
                    range.Text = $"Антиквариат";
                    range.InsertParagraphAfter();
                    Word.Paragraph tableParagraph = document.Paragraphs.Add();
                    Word.Range tableRange = tableParagraph.Range;


                    Word.Table table = document.Tables.Add(tableRange, order.OrderProducts.Count + 1, 6);
                    //table.Range.Bold = 0;
                    table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    table.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                    Word.Range cellRange;
                    cellRange = table.Cell(1, 1).Range;
                    cellRange.Text = "№";
                    cellRange = table.Cell(1, 2).Range;
                    cellRange.Text = "Наименование";
                    cellRange = table.Cell(1, 3).Range;
                    cellRange.Text = "Категория";
                    cellRange = table.Cell(1, 4).Range;
                    cellRange.Text = "Количество";
                    cellRange = table.Cell(1, 5).Range;
                    cellRange.Text = "Стоимость";

                    cellRange = table.Cell(1, 6).Range;
                    cellRange.Text = "ИТОГО";
                    table.Rows[1].Range.Bold = 1;
                    table.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    int i = 0;
                    double totalSum = 0;
                    foreach (var item in order.OrderProducts)
                    {
                        cellRange = table.Cell(i + 2, 1).Range;
                        cellRange.Text = (i + 1).ToString();
                        cellRange = table.Cell(i + 2, 2).Range;
                        cellRange.Text = item.Product.Title;
                        cellRange = table.Cell(i + 2, 3).Range;
                        cellRange.Text = item.Product.Category.Title;
                        cellRange = table.Cell(i + 2, 4).Range;
                        cellRange.Text = item.Count.ToString();
                        cellRange = table.Cell(i + 2, 5).Range;
                        cellRange.Text = item.Product.Price.ToString("f2");

                        cellRange = table.Cell(i + 2, 6).Range;
                        cellRange.Text = item.Total.ToString("f2");
                        i++;
                        totalSum += item.Total;
                    }

                    range.InsertParagraphAfter();

                    range = paragraph.Range;
                    range.Font.Bold = 0;
                    range.Text = $"Услуги";
                    range.InsertParagraphAfter();


                    tableParagraph = document.Paragraphs.Add();
                    tableRange = tableParagraph.Range;


                    table = document.Tables.Add(tableRange, order.OrderServices.Count + 1, 5);
                    //table.Range.Bold = 0;
                    table.Borders.InsideLineStyle = table.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                    table.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    cellRange = table.Cell(1, 1).Range;
                    cellRange.Text = "№";
                    cellRange = table.Cell(1, 2).Range;
                    cellRange.Text = "Наименование услуги";
                  
                    cellRange = table.Cell(1, 3).Range;
                    cellRange.Text = "Количество";
                    cellRange = table.Cell(1, 4).Range;
                    cellRange.Text = "Стоимость";

                    cellRange = table.Cell(1, 5).Range;
                    cellRange.Text = "ИТОГО";
                    table.Rows[1].Range.Bold = 1;
                    table.Rows[1].Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    i = 0;
                    foreach (var item in order.OrderServices)
                    {
                        cellRange = table.Cell(i + 2, 1).Range;
                        cellRange.Text = (i + 1).ToString();
                        cellRange = table.Cell(i + 2, 2).Range;
                        cellRange.Text = item.Service.Title;
                        cellRange = table.Cell(i + 2, 3).Range;
                        cellRange.Text = item.Count.ToString();
                        cellRange = table.Cell(i + 2, 4).Range;
                        cellRange.Text = Convert.ToInt32(item.Service.Price).ToString("f2");
                        cellRange = table.Cell(i + 2, 5).Range;
                        cellRange.Text = item.Total.ToString("f2");
                        i++;
                        totalSum += item.Total;
                    }
                    Word.Paragraph generalSumProduct = document.Paragraphs.Add();
                    Word.Range generalRange = generalSumProduct.Range;
                    generalRange.Text = $"\nОбщая сумма заказа: {totalSum:f2} руб.";
                    document.SaveAs2($@"{path}", Word.WdExportFormat.wdExportFormatPDF);
                    MessageBox.Show("Заказ сохранен");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        // отображение номеров строк в DataGrid
        private void DataGridGoodLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OrderProduct orderProduct = (sender as Button).DataContext as OrderProduct;
            orderProduct.Product.SetPrevPhoto = 1;
            //MessageBox.Show(product.GetCurrentPhoto);
            Image image = (sender as Button).Tag as Image;
            image.Source = new BitmapImage(new Uri(orderProduct.Product.GetCurrentPhoto));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OrderProduct orderProduct = (sender as Button).DataContext as OrderProduct;
            orderProduct.Product.SetNextPhoto = 1;
            // MessageBox.Show(product.GetCurrentPhoto);
            Image image = (sender as Button).Tag as Image;
            image.Source = new BitmapImage(new Uri(orderProduct.Product.GetCurrentPhoto));
        }
    }
}