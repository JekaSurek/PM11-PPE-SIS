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
        //Статическое свойство для хранения текущего пользователя
        public static ThisUser CurrentUser { get; private set; }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string MiddleName { get; set; }
        public string FullName { get; set; }

        public static void SetCurrentUser(Пользователи user)
        {
            if (user != null)
            {
                CurrentUser = new ThisUser
                {
                    Id = user.id_Пользователя,
                    Login = user.Логин,
                    Password = user.Пароль,
                    Surname = user.Фамилия_сотрудника,
                    Firstname = user.Имя_сотрудника,
                    MiddleName = user.Отчество_сотрудника,
                    FullName = $"{user.Фамилия_сотрудника} {user.Имя_сотрудника} {user.Отчество_сотрудника}".Trim()
                };
            }
        }

        public static void ClearCurrentUser()
        {
            CurrentUser = null;
        }
    }

    public class ThisUsers
    {
        public void GetThisUser(string login, string password, Window window)
        {
            using (var db = new БелкаФаворитСпичечнаяФабрикаБазаДанныхEntities())
            {
                var user = db.Пользователи.FirstOrDefault(u => u.Логин == login && u.Пароль == password);
                if (user != null)
                {
                    user.Дата_последнего_входа = System.DateTime.Now;
                    db.SaveChanges();

                    //Устанавливаем текущего пользователя
                    ThisUser.SetCurrentUser(user);

                    if (user.id_роли == 1)
                    {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        window.Close();
                    }
                    else if (user.id_роли == 2)
                    {
                        ManagerWindow managerWindow = new ManagerWindow();
                        managerWindow.Show();
                        window.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public void ClearDat()
        {
            ThisUser.ClearCurrentUser();
        }
    }
}