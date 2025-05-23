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

namespace УчетСИЗ.ViewModels
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;
            ThisUsers thisUsers = new ThisUsers();
            thisUsers.GetThisUser(login, password, this);
        }
    }
}
