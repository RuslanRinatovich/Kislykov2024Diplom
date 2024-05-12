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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RetrospektivaApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        int _itemcount = 0;
        public ProductsPage()
        {

            InitializeComponent();
            LoadComboBoxItems();
            LoadDataGrid();
        }

        void LoadDataGrid()
        {
            List<Product> goods = DataEntities.GetContext().Products.OrderBy(p => p.Title).ToList();
            DataGridGood.ItemsSource = goods;
            _itemcount = goods.Count;
            TextBlockCount.Text = $" Результат запроса: {goods.Count} записей из {goods.Count}";
        }

        void LoadComboBoxItems()
        {
            var categories = DataEntities.GetContext().Categories.OrderBy(p => p.Title).ToList();
            categories.Insert(0, new Category
            {
                Title = "Все виды"
            }
            );
            ComboCategory.ItemsSource = categories;
            ComboCategory.SelectedIndex = 0;


        }

        private void BtnCategories_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CategoriesPage());
        }

        private void BtnAges_Click(object sender, RoutedEventArgs e)
        {
            //  Manager.MainFrame.Navigate(new AgesPage());
        }

        private void BtnOrganizers_Click(object sender, RoutedEventArgs e)
        {
            // Manager.MainFrame.Navigate(new OrganizersPage());
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddProductPage(null));
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddProductPage((sender as Button).DataContext as Product));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //событие отображения данного Page
            // обновляем данные каждый раз когда активируется этот Page
            if (Visibility == Visibility.Visible)
            {
                DataEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DataGridGood.ItemsSource = null;

                LoadDataGrid();
            }
        }


        /// <summary>
        /// Метод для фильтрации и сортировки данных
        /// </summary>
        private void UpdateData()
        {
            // получаем текущие данные из бд
            //var currentGoods = DataBDEntities.GetContext().Abonements.OrderBy(p => p.CategoryTrainer.Trainer.LastName).ToList();

            var currentData = DataEntities.GetContext().Products.OrderBy(p => p.Title).ToList();
            // выбор только тех товаров, которые принадлежат данному производителю

            if (ComboCategory.SelectedIndex > 0)
                currentData = currentData.Where(p => p.CategoryId == (ComboCategory.SelectedItem as Category).Id).ToList();



            // выбор тех товаров, в названии которых есть поисковая строка
            currentData = currentData.Where(p => p.Title.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();


            if (ComboSort.SelectedIndex >= 0)
            {
                // сортировка по возрастанию цены
                if (ComboSort.SelectedIndex == 0)
                    currentData = currentData.OrderBy(p => p.Title).ToList();
                if (ComboSort.SelectedIndex == 1)
                    currentData = currentData.OrderByDescending(p => p.Title).ToList();
                if (ComboSort.SelectedIndex == 2)
                    currentData = currentData.OrderBy(p => p.Price).ToList();
                if (ComboSort.SelectedIndex == 3)
                    currentData = currentData.OrderByDescending(p => p.Price).ToList();
                // сортировка по убыванию цены
            }
            // В качестве источника данных присваиваем список данных
            DataGridGood.ItemsSource = currentData;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {currentData.Count} записей из {_itemcount}";
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void ComboOrganizer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void ComboCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void ComboAge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void ComboSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

     

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Product room = (sender as Button).DataContext as Product;
            room.SetPrevPhoto = 1;
            //MessageBox.Show(room.GetCurrentPhoto);
            Image image = (sender as Button).Tag as Image;
            image.Source = new BitmapImage(new Uri(room.GetCurrentPhoto));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Product room = (sender as Button).DataContext as Product;
            room.SetNextPhoto = 1;
            // MessageBox.Show(room.GetCurrentPhoto);
            Image image = (sender as Button).Tag as Image;
            image.Source = new BitmapImage(new Uri(room.GetCurrentPhoto));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            // удаление выбранного товара из таблицы
            //получаем все выделенные товары
            Product selected = (sender as Button).DataContext as Product;
            // вывод сообщения с вопросом Удалить запись?
            MessageBoxResult messageBoxResult = MessageBox.Show($"Удалить информацию о зале, фотографии и ???",
                "Удаление", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            //если пользователь нажал ОК пытаемся удалить запись
            if (messageBoxResult == MessageBoxResult.OK)
            {
                try
                {

                    //// проверка, есть ли у товара в таблице о продажах связанные записи
                    //// если да, то выбрасывается исключение и удаление прерывается
                    if (selected.OrderProducts.Count > 0 )
                        throw new Exception("Есть зависимые записи о залах");

                    DataEntities.GetContext().Photos.RemoveRange(selected.Photos);
                    DataEntities.GetContext().Products.Remove(selected);
                    //сохраняем изменения
                    DataEntities.GetContext().SaveChanges();
                    MessageBox.Show("Записи удалены");
                    LoadDataGrid();
                    UpdateData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

