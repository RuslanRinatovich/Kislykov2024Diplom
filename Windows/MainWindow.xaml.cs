using RetrospektivaApp.Entities;
using RetrospektivaApp.Pages;
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

namespace RetrospektivaApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new CataloguePage());
            Manager.CurrentUser = null;
            Manager.MainFrame = MainFrame;
        }

        private void WindowClosed(object sender, EventArgs e)
        {

            App.Current.Shutdown();
        }
        //событие попытки закрытия окна,
        // если пользователь выберет Cancel, то форму не закроем
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult x = MessageBox.Show("Вы действительно хотите выйти?",
                "Выйти", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (x == MessageBoxResult.Cancel)
                e.Cancel = true;
        }
        // Кнопка назад
        private void BtnBackClick(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
        // Кнопка навигации

        // Событие отрисовки страницы
        // Скрываем или показываем кнопку Назад 
        // Скрываем или показываем кнопки Для перехода к остальным страницам
        private void MainFrameContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
                BtnEnter.Visibility = Visibility.Collapsed;
                BtnBooking.Visibility = Visibility.Collapsed;
                BtnQuests.Visibility = Visibility.Collapsed;
                BtnServices.Visibility = Visibility.Collapsed;
                BtnMyAccount.Visibility = Visibility.Collapsed;
                BtnUsers.Visibility = Visibility.Collapsed;
                BtnMyBooking.Visibility = Visibility.Collapsed;
                TextBlockUser.Text = "";
                //if (Manager.CurrentUser is null)
                //    return;
                //if (Manager.CurrentUser.RoleId == 1)
                //{
                //    BtnBooking.Visibility = Visibility.Collapsed;
                //    BtnQuests.Visibility = Visibility.Collapsed;
                //}
                //else
                //{
                //    BtnMyAccount.Visibility = Visibility.Collapsed;
                //    BtnMyOrders.Visibility = Visibility.Collapsed;
                //}

            }
            else
            {
                BtnBack.Visibility = Visibility.Collapsed;
                BtnEnter.Visibility = Visibility.Visible;

                if (Manager.CurrentUser is null)
                    return;

                if (Manager.CurrentUser.RoleId == 1)
                {
                    BtnBooking.Visibility = Visibility.Visible;
                    BtnQuests.Visibility = Visibility.Visible;
                    BtnServices.Visibility = Visibility.Visible;
                    BtnMyAccount.Visibility = Visibility.Visible;
                    BtnMyBooking.Visibility = Visibility.Collapsed;
                    BtnUsers.Visibility = Visibility.Visible;
                }
                else
                {
                    BtnBooking.Visibility = Visibility.Collapsed;
                    BtnQuests.Visibility = Visibility.Collapsed;
                    BtnServices.Visibility = Visibility.Collapsed;
                    BtnUsers.Visibility = Visibility.Collapsed;
                    BtnMyAccount.Visibility = Visibility.Visible;
                    BtnMyBooking.Visibility = Visibility.Visible;
                }
                IconBtnKey.Kind = MaterialDesignThemes.Wpf.PackIconKind.Logout;
                BtnEnter.ToolTip = "Выйти";
                TextBlockUser.Text = $"{Manager.CurrentUser.Username}";
            }
        }

        private void BtnEditDev_Click(object sender, RoutedEventArgs e)
        {
        }



        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (Manager.CurrentUser != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show($"Выйти из системы??? ", "Выход", MessageBoxButton.OKCancel,
MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    IconBtnKey.Kind = MaterialDesignThemes.Wpf.PackIconKind.Login;
                    BtnEnter.ToolTip = "Войти";
                    Manager.CurrentUser = null;
                    BtnBack.Visibility = Visibility.Collapsed;
                    BtnBooking.Visibility = Visibility.Collapsed;
                    BtnQuests.Visibility = Visibility.Collapsed;
                    BtnServices.Visibility = Visibility.Collapsed;
                    BtnMyAccount.Visibility = Visibility.Collapsed;
                    BtnMyBooking.Visibility = Visibility.Collapsed;
                    BtnUsers.Visibility = Visibility.Collapsed;
                    TextBlockUser.Text = "";
                    MainFrame.NavigationService.Refresh();
                    return;
                }

            }

            LoginWindow window = new LoginWindow();
            if (window.ShowDialog() == true)
            {

                if (Manager.CurrentUser.RoleId == 1)
                {
                    BtnBooking.Visibility = Visibility.Visible;
                    BtnQuests.Visibility = Visibility.Visible;
                    BtnServices.Visibility = Visibility.Visible;
                    BtnMyAccount.Visibility = Visibility.Visible;
                    BtnUsers.Visibility = Visibility.Visible;
                    BtnMyBooking.Visibility = Visibility.Collapsed;
                }
                else
                {
                    BtnBooking.Visibility = Visibility.Collapsed;
                    BtnQuests.Visibility = Visibility.Collapsed;
                    BtnServices.Visibility = Visibility.Collapsed;
                    BtnUsers.Visibility = Visibility.Collapsed;
                    BtnMyAccount.Visibility = Visibility.Visible;
                    BtnMyBooking.Visibility = Visibility.Visible;
                }
                IconBtnKey.Kind = MaterialDesignThemes.Wpf.PackIconKind.Logout;
                BtnEnter.ToolTip = "Выйти";
                TextBlockUser.Text = $"{Manager.CurrentUser.Username}";
            }
            MainFrame.NavigationService.Refresh();


        }





        private void BtnMyAccount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MyAccountWindow window = new MyAccountWindow();

                if (window.ShowDialog() == true)
                {

                    MessageBox.Show("Запись изменена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }


        private void BtnMyOrders_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MyBookingPage());
        }



        private void BtnQuests_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductsPage());
        }

        private void BtnBooking_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BookingPage());
        }



        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UsersPage());
        }

      


        private void BtnServices_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ServicesPage());
        }
    }
}
