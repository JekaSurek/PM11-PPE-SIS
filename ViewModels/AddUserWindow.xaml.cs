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
using УчетСИЗ.Models;

namespace УчетСИЗ.ViewModels
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void LoadRoles()
        {
            using (var db = new БелкаФаворитСпичечнаяФабрикаБазаДанныхEntities())
            {
                RoleComboBox.ItemsSource = db.Роль.ToList();
                RoleComboBox.DisplayMemberPath = "Наименование";
                RoleComboBox.SelectedValuePath = "id_Роли";
                User user = new User(0);
                if (User != null && User.Role > 0)
                {
                    RoleComboBox.SelectedValue = User.Role;
                }
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new БелкаФаворитСпичечнаяФабрикаБазаДанныхEntities())
                {
                    // Создаем новый объект пользователя
                    var newUser = new Пользователи
                    {
                        Логин = LoginTextBox.Text,
                        Пароль = PasswordTextBox.Text,
                        Фамилия_сотрудника = SurnameTextBox.Text,
                        Имя_сотрудника = FirstnameTextBox.Text,
                        Отчество_сотрудника = LastnameTextBox.Text,
                        id_роли = (int)ComboBox.item, 
                        Дата_создания = DateTime.Now,
                        Дата_изменения = DateTime.Now
                    };

                    // Добавляем в контекст
                    db.Пользователи.Add(newUser);

                    // Сохраняем изменения
                    db.SaveChanges();

                    MessageBox.Show("Пользователь успешно добавлен!", "Успех",
                                  MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении пользователя: {ex.Message}",
                               "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
