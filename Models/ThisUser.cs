using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using УчетСИЗ.Interfaces;
using УчетСИЗ.ViewModels;

namespace УчетСИЗ.Models
{
    public class ThisUser
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }
    }

    public class ThisUsers : IThisUserLogin
    {
        public void GetThisUser(string login, string password, Window window)
        {
            using (var db = new БелкаФаворитСпичечнаяФабрикаБазаДанныхEntities())
            {
                var user = db.Пользователи.FirstOrDefault(u => u.Логин == login && u.Пароль == password);
                if (user != null)
                {
                    user.Дата_последнего_входа = DateTime.Now;
                    db.SaveChanges(); 
                    ThisUser thisUser = new ThisUser();
                    thisUser.Id = user.id_Пользователя;
                    thisUser.Login = login;
                    thisUser.Password = password;
                    thisUser.Surname = user.Фамилия_сотрудника;
                    thisUser.Firstname = user.Имя_сотрудника;
                    MainWindow mainWindow = new MainWindow();
                    if (user.Отчество_сотрудника != null)
                    {
                        thisUser.FullName = $"{user.Фамилия_сотрудника} {user.Имя_сотрудника} {user.Отчество_сотрудника}";
                        mainWindow.Show();
                        window.Close();
                    }
                    else
                    {
                        thisUser.FullName = $"{user.Фамилия_сотрудника} {user.Имя_сотрудника}";
                        mainWindow.Show();
                        window.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }
    }
}