using RetrospektivaApp.Entities;
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
using System.Windows.Shapes;

namespace RetrospektivaApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для NewOrderWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {
        public struct BuyItem
        {
            public int Count { get; set; }
            public double Total { get; set; }
        }
        Order _currentOrder;
        User _currentUser;
        public NewOrderWindow()
        {
            InitializeComponent();
            LoadDataAndInit();
        }

        /// <summary>
        /// Загрузка и инициализация полей
        /// </summary>
        void LoadDataAndInit()
        {
            // источник данных корзина
            ListBoxOrderProducts.ItemsSource = ProductBasket.GetBasket;

            ListBoxOrderServices.ItemsSource = ServiceBasket.GetBasket;
            // создаем новый заказ
            _currentOrder = CreateNewOrder();
            // текущий пользователь
            _currentUser = Manager.CurrentUser;
            TextBlockOrderNumber.Text = $"Заказ №{_currentOrder.Id} на имя " +
                    $"{ _currentUser.LastName} {_currentUser.FirstName}";


            TextBlockTotalCost.Text = $"Итого {ProductBasket.GetTotalCost + ServiceBasket.GetTotalCost:C}";
            DatePickerDate.SelectedDate = DateTime.Today;
            TimePickerTime.SelectedTime = DateTime.Now;
            //TextBlockOrderCreateDate.Text = _currentOrder.DateOrder.ToLongDateString();

        }

        /// <summary>
        /// Создает новый заказ
        /// </summary>
        /// <returns>новый заказ Order</returns>
        static Order CreateNewOrder()
        {
            Order order = new Order();
            int k = DataEntities.GetContext().Orders.Count();
            order.Id = 1;
            if (k > 0)
                order.Id = DataEntities.GetContext().Orders.Max(p => p.Id) + 1;


            order.DateOrder = DateTime.Now;


            return order;
        }



        private void BtnOkClick(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
        private void BtnDeleteClick(object sender, RoutedEventArgs e)
        {
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить товар из корзины???",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                if (ListBoxOrderProducts.SelectedIndex >= 0)
                {
                    var x = (ListBoxOrderProducts.SelectedValue as Product);
                    ProductBasket.DeleteProductFromBasket(x);
                    ListBoxOrderProducts.Items.Refresh();
                    TextBlockTotalCost.Text = $"Итого {ProductBasket.GetTotalCost:C}";
                }
            }

        }

       

        private void TextBoxService_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) // при нажатии на кнопку Enter
            {
                TextBox textBox = sender as TextBox;
                int k = ListBoxOrderProducts.SelectedIndex;

                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    int x = 0;
                    if (!int.TryParse(textBox.Text, out x))
                    {
                        MessageBox.Show("Количество только число");
                        return;
                    }
                    x = Convert.ToInt32(textBox.Text);
                    if (x < 0)
                    {
                        MessageBox.Show("Количество не может быть отрицательным");
                    }
                    else if (x == 0)
                    {
                        Service product = textBox.Tag as Service;
                        MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить {product.Title} из корзины???",
                            "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                        if (messageBoxResult == MessageBoxResult.OK)
                        {
                            ServiceBasket.DeleteProductFromBasket(product);
                            ListBoxOrderServices.Items.Refresh();
                            ListBoxOrderServices.SelectedIndex = k;
                        }

                    }
                    else
                    {
                        Service product = textBox.Tag as Service;
                        ServiceBasket.SetCount(product, x);
                        ListBoxOrderServices.Items.Refresh();
                        ListBoxOrderServices.SelectedIndex = k;
                    }
                }
            }
            if (e.Key == Key.Escape) // клавиша ESC
            {
                int k = ListBoxOrderServices.SelectedIndex;
                ListBoxOrderServices.Items.Refresh();
                ListBoxOrderServices.SelectedIndex = k;
            }
            TextBlockTotalCost.Text = $"Итого {ProductBasket.GetTotalCost + ServiceBasket.GetTotalCost:C}";

        }

        // В поле количество можно вводить только цифры
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !char.IsDigit(e.Text, 0);
        }

        // кнопка оформить покупку
        private void BtnBuyItem_Click(object sender, RoutedEventArgs e)
        {

            if (ListBoxOrderProducts.Items.Count == 0)
            {
                MessageBox.Show("Корзина пуста");
                return;
            }

            int day = DatePickerDate.SelectedDate.Value.Date.Day;
            int month = DatePickerDate.SelectedDate.Value.Date.Month;
            int year = DatePickerDate.SelectedDate.Value.Date.Year;

            int hours = TimePickerTime.SelectedTime.Value.Hour;
            int minutes = TimePickerTime.SelectedTime.Value.Minute;
            int seconds = TimePickerTime.SelectedTime.Value.Second;
            DateTime date = new DateTime(year, month, day, hours, minutes, seconds);
            _currentOrder.DateOrder = date;
            _currentOrder.DateOrder = date;
            _currentOrder.Username = Manager.CurrentUser.Username;
            _currentOrder.Total = Convert.ToInt32(ProductBasket.GetTotalCost);
            MessageBoxResult messageBoxResult = MessageBox.Show($"Оформить заказ???",
                "Оформление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.OK)
            {

                DataEntities.GetContext().Orders.Add(_currentOrder);
                //формируем данные в OrderProduct (товары заказа)
                foreach (var item in ProductBasket.GetBasket)
                {
                    OrderProduct orderService = new OrderProduct();
                    orderService.OrderId = _currentOrder.Id;
                    orderService.DoorId = item.Key.Id;
                    orderService.Count = item.Value.Count;

                    DataEntities.GetContext().OrderProducts.Add(orderService);
                }
                foreach (var item in ServiceBasket.GetBasket)
                {
                    OrderService orderService = new OrderService();
                    orderService.OrderId = _currentOrder.Id;
                    orderService.ServiceId = item.Key.Id;
                    orderService.Count = item.Value.Count;

                    DataEntities.GetContext().OrderServices.Add(orderService);
                }
                DataEntities.GetContext().SaveChanges();  // Сохраняем изменения в БД
                // показываем талон заказа в новом окне 
                OrderTicketWindow orderTicketWindow = new OrderTicketWindow(_currentOrder);
                orderTicketWindow.ShowDialog();

                // очищаем корзину
                ProductBasket.ClearBasket();
                this.Close();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // удаление выбранного товара из таблицы
            //получаем все выделенные товары

            // вывод сообщения с вопросом Удалить запись?
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить товар из корзины???",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                Button button = sender as Button;

                Product product = button.Tag as Product;

                ProductBasket.DeleteProductFromBasket(product);
                ListBoxOrderProducts.Items.Refresh();
                TextBlockTotalCost.Text = $"Итого {ProductBasket.GetTotalCost:C}";

            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Image image = (sender as Button).Tag as Image;
            Product product = image.Tag as Product;
            product.SetPrevPhoto = 1;
            image.Source = new BitmapImage(new Uri(product.GetCurrentPhoto));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            // MessageBox.Show(product.GetCurrentPhoto);
            Image image = (sender as Button).Tag as Image;
            Product product = image.Tag as Product;
            product.SetNextPhoto = 1;
            image.Source = new BitmapImage(new Uri(product.GetCurrentPhoto));
        }

        private void BtnDeleteService_Click(object sender, RoutedEventArgs e)
        {
            // удаление выбранного товара из таблицы
            //получаем все выделенные товары

            // вывод сообщения с вопросом Удалить запись?
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить услугу из корзины???",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                Button button = sender as Button;

                Service product = button.Tag as Service;

                ServiceBasket.DeleteProductFromBasket(product);
                ListBoxOrderServices.Items.Refresh();
                TextBlockTotalCost.Text = $"Итого {ProductBasket.GetTotalCost + ServiceBasket.GetTotalCost:C}";

            }
        }
    }
}
