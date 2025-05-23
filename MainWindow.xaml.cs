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

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            db = new БелкаФаворитСпичечнаяФабрикаБазаДанныхEntities();
            LoadUsers();
        }

        private void LoadUsers(string filter = "")
        {
            var query = db.Пользователи.AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(u =>u.Фамилия_сотрудника.Contains(filter) ||u.Имя_сотрудника.Contains(filter) || u.Отчество_сотрудника.Contains(filter) || u.Логин.Contains(filter));
            }

            users = query.Select(u => new User
            {
                Id = u.id_Пользователя,
                Login = u.Логин,
                Password = u.Пароль,
                Surname = u.Фамилия_сотрудника,
                Firstname = u.Имя_сотрудника,
                Lastname = u.Отчество_сотрудника,
                Rolename = u.Роль.Наименование,
                Role = u.id_роли,
                LastLoginDate = u.Дата_последнего_входа}).ToList();

            UsersGrid.ItemsSource = users;
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoadUsers(FilterTextBox.Text);
        }

        private void ResetFilter_Click(object sender, RoutedEventArgs e)
        {
            FilterTextBox.Text = "";
            LoadUsers();
        }

        private void UsersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedUser = UsersGrid.SelectedItem as User;
            EditButton.IsEnabled = selectedUser != null;
            DeleteButton.IsEnabled = selectedUser != null;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
            if(addUserWindow.ShowDialog() == true)
            {
                LoadUsers();
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
                    LoadUsers();
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
                    LoadUsers();
                }
            }
        }
    }
}
