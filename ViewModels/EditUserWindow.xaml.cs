using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using УчетСИЗ.Models;

namespace УчетСИЗ.ViewModels
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public User User { get; private set; }
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        public EditUserWindow(User user)
        {
            InitializeComponent();
            User = user;
            LoadUserData();
            LoadRoles();
        }

        private void LoadUserData()
        {
            LoginTextBox.Text = User.Login;
            PasswordTextBox.Text = User.Password;
            SurnameTextBox.Text = User.Surname;
            FirstnameTextBox.Text = User.Firstname;
            LastnameTextBox.Text = User.Lastname;
        }

        private void LoadRoles()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = new SqlCommand("SELECT id_Роли, Наименование FROM Роль", connection);
                    var adapter = new SqlDataAdapter(command);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    RoleComboBox.DisplayMemberPath = "Наименование";
                    RoleComboBox.SelectedValuePath = "id_Роли";
                    RoleComboBox.ItemsSource = dt.DefaultView;
                    RoleComboBox.SelectedValue = User.Role;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке ролей: {ex.Message}");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordTextBox.Text) ||
                RoleComboBox.SelectedValue == null)
            {
                MessageBox.Show("Заполните обязательные поля: Логин, Пароль и Роль");
                return;
            }

            try
            {
                //Обновляем данные пользователя
                User.Login = LoginTextBox.Text;
                User.Password = PasswordTextBox.Text;
                User.Surname = SurnameTextBox.Text;
                User.Firstname = FirstnameTextBox.Text;
                User.Lastname = LastnameTextBox.Text;
                User.Role = (int)RoleComboBox.SelectedValue;

                //Обновляем в базе данных
                UpdateUserInDatabase();
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        private void UpdateUserInDatabase()
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand("sp_ОбновитьПользователя", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id_Пользователя", User.Id);
                command.Parameters.AddWithValue("@Логин", User.Login);
                command.Parameters.AddWithValue("@Пароль", User.Password);
                command.Parameters.AddWithValue("@id_роли", User.Role);
                command.Parameters.AddWithValue("@Фамилия_сотрудника", (object)User.Surname ?? DBNull.Value);
                command.Parameters.AddWithValue("@Имя_сотрудника", (object)User.Firstname ?? DBNull.Value);
                command.Parameters.AddWithValue("@Отчество_сотрудника", (object)User.Lastname ?? DBNull.Value);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ThisUsers users = new ThisUsers();

            DialogResult = false;
            Close();
        }
    }
}
