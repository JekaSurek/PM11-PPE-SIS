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
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public User User { get; private set; }

        public EditUserWindow()
        {
            InitializeComponent();
            User = new User();
            DataContext = User;
        }

        public EditUserWindow(User user) : this()
        {
            InitializeComponent();
            LoadDate(user);
        }

        private void LoadDate(User user)
        {
            LoginTextBox.Text = User.Login;
            PasswordTextBox.Text = User.Password;
            SurnameTextBox.Text = User.Surname;
            FirstnameTextBox.Text = User.Firstname;
            LastnameTextBox.Text = User.Lastname;

        }
        private void LoadRoles()
        {
            using (var db = new БелкаФаворитСпичечнаяФабрикаБазаДанныхEntities())
            {
                RoleComboBox.ItemsSource = db.Роль.ToList();
                RoleComboBox.DisplayMemberPath = "Наименование";
                RoleComboBox.SelectedValuePath = "id_Роли";

                if (User != null && User.Role > 0)
                {
                    RoleComboBox.SelectedValue = User.Role;
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
