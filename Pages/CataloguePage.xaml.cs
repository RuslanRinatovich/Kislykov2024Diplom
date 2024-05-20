using RetrospektivaApp.Entities;
using RetrospektivaApp.Windows;
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
    /// Логика взаимодействия для CataloguePage.xaml
    /// </summary>
    public partial class CataloguePage : Page
    {
        public int _itemcount = 0;
        public int _itemservisescount = 0;
        int _allitemcount = 0;
        int _pagenumber = 0;
        int _pagecount = 0;
        int n = 20;

        List<Service> services;
        public CataloguePage()
        {
            InitializeComponent();
            LoadComboBoxItems();
        }


        // Создание списка страниц
        public void InitializeListBoxPages()
        {
            // очишаем список
            ListBoxPageCount.Items.Clear();
            // узнаем количество страниц нужное для отображения данного количества записей
            _pagecount = _itemservisescount / n;
            if (_itemservisescount % n != 0)
                _pagecount++;
            // добавляем в Листбокс элементы - номера страниц
            for (int i = 1; i <= _pagecount; i++)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = i.ToString();

                ListBoxPageCount.Items.Add(itm);
            }

        }
        void LoadData()
        {

            List<Product> goods = DataEntities.GetContext().Products.Where(p=> p.IsSold == false).OrderBy(p => p.Title).ToList();
            LViewGoods.ItemsSource = goods;
            _itemcount = goods.Count;
            TextBlockCount.Text = $" Результат запроса: {goods.Count} записей из {goods.Count}";

            DataEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            // загрузка данных в listview сортируем по названию

            services = DataEntities.GetContext().Services.OrderBy(p => p.Title).ToList();
            // отображение количества записей
            _allitemcount = services.Count;
            _itemservisescount = _allitemcount;

            _pagenumber = 1;
            InitializeListBoxPages();

            // Метод GetRange позволяет выбрать из списка данных элементы 
            // Создает неполную копию диапазона элементов исходного списка List<T>.
            // GetRange (int index, int count);
            // index -  Отсчитываемый от нуля индекс списка List<T>, с которого начинается диапазон.
            // count -  Число элементов в диапазоне
            // если указать count за размером списка будет ошибка.
            int k = services.Count - (_pagenumber - 1) * n;
            if (k < 10)
                ListBoxProducts.ItemsSource = services.GetRange((_pagenumber - 1) * n, k);
            else
                ListBoxProducts.ItemsSource = services.GetRange((_pagenumber - 1) * n, n);

            TextBlockServicesCount.Text = $" Результат запроса: {_itemservisescount} записей из {_allitemcount}";
        }
        private void UpdateServiceData()
        {
            var currentProducts =
                DataEntities.GetContext().Services.OrderBy(p => p.Title).ToList();
            // выбор только тех агентов, которые принадлежат данному типу
           
            // выбор тех агентов, в названии которых есть поисковая строка
            currentProducts = currentProducts.Where(p => p.Title.ToLower().Contains(TBoxSearchServices.Text.ToLower())).ToList();

            // сортировка
            if (ComboSortServices.SelectedIndex >= 0)
            {
                // сортировка по возрастанию названия
                if (ComboSortServices.SelectedIndex == 0)
                    currentProducts = currentProducts.OrderBy(p => p.Title).ToList();
                // сортировка по убыванию названия
                if (ComboSortServices.SelectedIndex == 1)
                    currentProducts = currentProducts.OrderByDescending(p => p.Title).ToList();
                // сортировка по возрастанию скидки

                // сортировка по возрастанию минимальной стоимости
                if (ComboSortServices.SelectedIndex == 2)
                    currentProducts = currentProducts.OrderBy(p => p.Price).ToList();
                // сортировка по убыванию минимальной стоимости
                if (ComboSortServices.SelectedIndex == 3)
                    currentProducts = currentProducts.OrderByDescending(p => p.Price).ToList();
            }

            // В качестве источника данных присваиваем список данных
            // пересчитываем список страниц
            _pagenumber = 1;
            services = currentProducts;
            ListBoxProducts.ItemsSource = currentProducts;
            _itemservisescount = currentProducts.Count;
            InitializeListBoxPages();
            int k = services.Count - (_pagenumber - 1) * n;
            if (k < 10)
                ListBoxProducts.ItemsSource = services.GetRange((_pagenumber - 1) * n, k);
            else
                ListBoxProducts.ItemsSource = services.GetRange((_pagenumber - 1) * n, n);
            // отображение количества записей
            TextBlockServicesCount.Text = $" Результат запроса: {currentProducts.Count} записей из {_allitemcount}";

        }
        void LoadComboBoxItems()
        {
            var categories = DataEntities.GetContext().Categories.OrderBy(p => p.Title).ToList();
            categories.Insert(0, new Category
            {
                Title = "Все категории"
            }
            );
            ComboCategory.ItemsSource = categories;
            ComboCategory.SelectedIndex = 0;
         

        }

        /// Метод для фильтрации и сортировки данных
        /// </summary>
        private void UpdateData()
        {
            // получаем текущие данные из бд
            //var currentGoods = DataBDEntities.GetContext().Abonements.OrderBy(p => p.CategoryTrainer.Trainer.LastName).ToList();

            var currentData = DataEntities.GetContext().Products.Where(p => p.IsSold == false).OrderBy(p => p.Title).ToList();
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
            LViewGoods.ItemsSource = currentData;
            // отображение количества записей
            TextBlockCount.Text = $" Результат запроса: {currentData.Count} записей из {_itemcount}";
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Product _selectedProduct = (sender as Button).DataContext as Product;
            ProductBasket.AddProductInBasket(_selectedProduct);
            // отображаем кнопку и текстовое поле
            if (ProductBasket.GetCount > 0 || ServiceBasket.GetCount > 0)
            {
                BtnBasket.Visibility = Visibility.Visible;
                TextBlockBasketInfo.Visibility = Visibility.Visible;
                TextBlockBasketInfo.Text = $"В корзине {ProductBasket.GetCount + ServiceBasket.GetCount} товаров";
                BadgeBasketCount.Badge = ProductBasket.GetCount + ServiceBasket.GetCount;
            }
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


        private void PageIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //обновление данных после каждой активации окна
            if (Visibility == Visibility.Visible)
            {
                LoadData();
            }
        }

        private void ListBoxPageCount_SelectionChanged(object sender,
       SelectionChangedEventArgs e)
        {
            if (ListBoxPageCount.SelectedItems.Count == 0)
                return;
            ListBoxItem lbi = (sender as ListBox).SelectedItem as ListBoxItem;

            _pagenumber = Convert.ToInt32(lbi.Content);

            int k = services.Count - (_pagenumber - 1) * n;
            if (k < 10)
                ListBoxProducts.ItemsSource = services.GetRange((_pagenumber - 1) * n, k);
            else
                ListBoxProducts.ItemsSource = services.GetRange((_pagenumber - 1) * n, 10);
            TextBlockServicesCount.Text = $" Результат запроса: {_itemservisescount} записей из {_allitemcount}";
        }
        //кнопки перемещения между страницами
        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (_pagenumber > 1)
                _pagenumber--;
            ListBoxPageCount.SelectedIndex = _pagenumber - 1;
        }
        //кнопки перемещения между страницами
        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (_pagenumber < _pagecount)
                _pagenumber++;
            ListBoxPageCount.SelectedIndex = _pagenumber - 1;
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
        private void BtnBasket_Click(object sender, RoutedEventArgs e)
        {
            // кнопка Корзина
            NewOrderWindow newOrderWindow = new NewOrderWindow();
            newOrderWindow.ShowDialog();
            UpdateData();
            if (ProductBasket.GetCount > 0)
            {
                BtnBasket.Visibility = Visibility.Visible;
                TextBlockBasketInfo.Visibility = Visibility.Visible;
                BadgeBasketCount.Badge = ProductBasket.GetCount + ServiceBasket.GetCount;
            }
            else
            {
                BadgeBasketCount.Badge = "";
                BtnBasket.Visibility = Visibility.Collapsed;
                TextBlockBasketInfo.Visibility = Visibility.Collapsed;
            }

        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            Service _selectedProduct = (sender as Button).DataContext as Service;
            ServiceBasket.AddProductInBasket(_selectedProduct);
            // отображаем кнопку и текстовое поле
            if (ProductBasket.GetCount > 0 || ServiceBasket.GetCount > 0)
            {
                BtnBasket.Visibility = Visibility.Visible;
                TextBlockBasketInfo.Visibility = Visibility.Visible;
                TextBlockBasketInfo.Text = $"В корзине {ProductBasket.GetCount + ServiceBasket.GetCount} товаров";
                BadgeBasketCount.Badge = ProductBasket.GetCount + ServiceBasket.GetCount;
            }
        }

        private void TBoxSearchServices_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateServiceData();
        }

        private void ComboSortServices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServiceData();
        }
        private void ComboTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServiceData();
        }
    }
}
