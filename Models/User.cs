using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using УчетСИЗ.Interfaces;

namespace УчетСИЗ.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Role { get; set; }
        public string Rolename { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string FullName => $"{Surname} {Firstname} {Lastname}".Trim();

        public void LoadUsers(DataGrid dataGrid, string filter = "")
        {
            try
            {
                string connectionString = DatabaseHelper.GetConnectionString();
                string sql = @"
            SELECT 
                u.id_Пользователя,
                u.Логин,
                u.Пароль,
                u.Фамилия_сотрудника,
                u.Имя_сотрудника,
                u.Отчество_сотрудника,
                r.Наименование AS Rolename,
                u.id_роли,
                u.Дата_создания,
                u.Дата_изменения,
                u.Дата_последнего_входа
            FROM Пользователи u
            JOIN Роль r ON u.id_роли = r.id_Роли";

                if (!string.IsNullOrEmpty(filter))
                {
                    sql += @"
                WHERE u.Фамилия_сотрудника LIKE @filter 
                   OR u.Имя_сотрудника LIKE @filter 
                   OR u.Отчество_сотрудника LIKE @filter 
                   OR u.Логин LIKE @filter";
                }

                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(sql, connection))
                {
                    if (!string.IsNullOrEmpty(filter))
                    {
                        command.Parameters.AddWithValue("@filter", $"%{filter}%");
                    }

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var users = new List<User>();

                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                Id = reader.GetInt32(0),
                                Login = reader.GetString(1),
                                Password = reader.GetString(2),
                                Surname = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Firstname = reader.IsDBNull(4) ? null : reader.GetString(4),
                                Lastname = reader.IsDBNull(5) ? null : reader.GetString(5),
                                Rolename = reader.GetString(6),
                                Role = reader.GetInt32(7),
                                CreatedDate = reader.IsDBNull(8) ? (DateTime?)null : reader.GetDateTime(8),
                                UpdateDate = reader.IsDBNull(9) ? (DateTime?)null : reader.GetDateTime(9),
                                LastLoginDate = reader.IsDBNull(10) ? (DateTime?)null : reader.GetDateTime(10)
                            });
                        }

                        dataGrid.ItemsSource = users;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке пользователей: {ex.Message}");
            }
        }

        public static int AddUser(User user)
        {
            var connectionString = DatabaseHelper.GetConnectionString();
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("sp_ДобавитьПользователя", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Логин", user.Login);
                command.Parameters.AddWithValue("@Пароль", user.Password);
                command.Parameters.AddWithValue("@id_роли", user.Role);
                command.Parameters.AddWithValue("@Фамилия_сотрудника", (object)user.Surname ?? DBNull.Value);
                command.Parameters.AddWithValue("@Имя_сотрудника", (object)user.Firstname ?? DBNull.Value);
                command.Parameters.AddWithValue("@Отчество_сотрудника", (object)user.Lastname ?? DBNull.Value);

                connection.Open();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }
}
