using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using УчетСИЗ.Models;
using УчетСИЗ.ViewModels;

namespace УчетСИЗ
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private БелкаФаворитСпичечнаяФабрикаБазаДанныхEntities db;
        private List<User> users;
        private User selectedUser;
        User _user = new User();
        private LoginHistory _loginHistory = new LoginHistory();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            DateFromPicker.SelectedDate = DateTime.Now.AddDays(-7);
            DateToPicker.SelectedDate = DateTime.Now;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db = new БелкаФаворитСпичечнаяФабрикаБазаДанныхEntities();
            _user.LoadUsers(UsersGrid);
            _loginHistory.LoadHistory(HistoryGrid);
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _user.LoadUsers(UsersGrid, FilterTextBox.Text);
        }

        private void ResetFilter_Click(object sender, RoutedEventArgs e)
        {
            FilterTextBox.Text = "";
            _user.LoadUsers(UsersGrid);
        }

        private void UsersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedUser = UsersGrid.SelectedItem as User;
            EditButton.IsEnabled = selectedUser != null;
            DeleteButton.IsEnabled = selectedUser != null;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddUserWindow addUserWindow = new AddUserWindow();
                if (addUserWindow.ShowDialog() == true) 
                {
                    _user.LoadUsers(UsersGrid);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка\n" + ex, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser == null) return;

            var editWindow = new EditUserWindow(selectedUser);
            if (editWindow.ShowDialog() == true)
            {
                var updatedUser = editWindow.User;
                var dbUser = db.Пользователи.Find(updatedUser.Id);

                if (dbUser != null)
                {
                    dbUser.Логин = updatedUser.Login;
                    dbUser.Пароль = updatedUser.Password;
                    dbUser.Фамилия_сотрудника = updatedUser.Surname;
                    dbUser.Имя_сотрудника = updatedUser.Firstname;
                    dbUser.Отчество_сотрудника = updatedUser.Lastname;
                    dbUser.id_роли = updatedUser.Role;

                    db.SaveChanges();
                    _user.LoadUsers(UsersGrid);
                }
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (selectedUser == null) return;

            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить пользователя {selectedUser.FullName}?",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var dbUser = db.Пользователи.Find(selectedUser.Id);
                if (dbUser != null)
                {
                    db.Пользователи.Remove(dbUser);
                    db.SaveChanges();
                    _user.LoadUsers(UsersGrid);
                }
            }
        }

        private void OutButton_Click(object sender, RoutedEventArgs e)
        {
            ThisUsers thisUsers = new ThisUsers();
            thisUsers.ClearDat();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
        private void ApplyHistoryFilter_Click(object sender, RoutedEventArgs e)
        {
            DateTime? dateFrom = DateFromPicker.SelectedDate;
            DateTime? dateTo = DateToPicker.SelectedDate;

            // Проверка, чтобы дата "С" не была больше даты "По"
            if (dateFrom.HasValue && dateTo.HasValue && dateFrom > dateTo)
            {
                MessageBox.Show("Дата 'С' не может быть больше даты 'По'", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _loginHistory.LoadHistory(
                HistoryGrid,
                LoginFilterTextBox.Text,
                dateFrom,
                dateTo
            );
        }

        private void ResetHistoryFilter_Click(object sender, RoutedEventArgs e)
        {
            LoginFilterTextBox.Text = "";
            DateFromPicker.SelectedDate = null;
            DateToPicker.SelectedDate = null;
            _loginHistory.LoadHistory(HistoryGrid);
        }
    }
}
