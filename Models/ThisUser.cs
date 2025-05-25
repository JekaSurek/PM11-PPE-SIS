using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

                // Получаем IP-адрес
                string ipAddress = GetLocalIPAddress();
                // Получаем информацию о системе
                string systemInfo = Environment.OSVersion.ToString();

                if (user != null)
                {
                    try
                    {
                        // Обновляем дату последнего входа
                        user.Дата_последнего_входа = DateTime.Now;
                        db.SaveChanges();

                        // Записываем успешный вход в историю
                        var loginHistory = new ИсторияВхода
                        {
                            id_пользователя = user.id_Пользователя,
                            Время_входа_в_систему = DateTime.Now,
                            Система = systemInfo,
                            IP_adress = ipAddress,
                            Успех = true,
                            Причина_отказа = null
                        };
                        db.ИсторияВхода.Add(loginHistory);
                        db.SaveChanges();

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
                        else if (user.id_роли == 6)
                        {
                            AccountantWindow accountantWindow = new AccountantWindow();
                            accountantWindow.Show();
                            window.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении данных входа: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    try
                    {
                        var failedLogin = new ИсторияВхода
                        {
                            Время_входа_в_систему = DateTime.Now,
                            Система = systemInfo,
                            IP_adress = ipAddress,
                            Успех = false,
                            Причина_отказа = "Неверный логин или пароль"
                        };
                        db.ИсторияВхода.Add(failedLogin);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Ошибка при записи неудачного входа: {ex.Message}");
                    }

                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        // Метод для получения локального IP-адреса
        private string GetLocalIPAddress()
        {
            try
            {
                string hostName = Dns.GetHostName();
                IPAddress[] addresses = Dns.GetHostAddresses(hostName);

                foreach (IPAddress address in addresses)
                {
                    if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        return address.ToString();
                    }
                }
                return "127.0.0.1";
            }
            catch
            {
                return "Unknown";
            }
        }

        public void ClearDat()
        {
            ThisUser.ClearCurrentUser();
        }
    }
}