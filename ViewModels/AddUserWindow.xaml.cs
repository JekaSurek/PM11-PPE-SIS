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
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private readonly string _connectionString = DatabaseHelper.GetConnectionString();

        public AddUserWindow()
        {
            InitializeComponent();
            LoadRoles();
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке ролей: {ex.Message}");
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTextBox.Text) ||string.IsNullOrWhiteSpace(PasswordTextBox.Text) ||RoleComboBox.SelectedValue == null)
            {
                MessageBox.Show("Заполните обязательные поля: Логин, Пароль и Роль");
                return;
            }

            var newUser = new User
            {
                Login = LoginTextBox.Text,
                Password = PasswordTextBox.Text,
                Surname = SurnameTextBox.Text,
                Firstname = FirstnameTextBox.Text,
                Lastname = LastnameTextBox.Text,
                Role = (int)RoleComboBox.SelectedValue
            };

            try
            {
                int userId = User.AddUser(newUser);
                MessageBox.Show($"Пользователь успешно добавлен с ID: {userId}");
                DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении пользователя: {ex.Message}");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
