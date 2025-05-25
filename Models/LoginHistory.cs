using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace УчетСИЗ.Models
{
    public class LoginHistory
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Login { get; set; }
        public string FullName { get; set; }
        public DateTime LoginTime { get; set; }
        public string SystemInfo { get; set; }
        public string IpAddress { get; set; }
        public bool Success { get; set; }
        public string FailureReason { get; set; }

        public void LoadHistory(DataGrid dataGrid, string loginFilter = "", DateTime? dateFrom = null, DateTime? dateTo = null)
        {
            try
            {
                string connectionString = DatabaseHelper.GetConnectionString();
                string sql = @"
                SELECT 
                    h.id_Записи,
                    h.id_пользователя,
                    u.Логин,
                    ISNULL(u.Фамилия_сотрудника, '') + ' ' + ISNULL(u.Имя_сотрудника, '') + ' ' + ISNULL(u.Отчество_сотрудника, '') AS FullName,
                    h.Время_входа_в_систему,
                    h.Система,
                    h.IP_adress,
                    h.Успех,
                    h.Причина_отказа
                FROM ИсторияВхода h
                LEFT JOIN Пользователи u ON h.id_пользователя = u.id_Пользователя
                WHERE 1=1";

                var parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(loginFilter))
                {
                    sql += " AND u.Логин LIKE @loginFilter";
                    parameters.Add(new SqlParameter("@loginFilter", $"%{loginFilter}%"));
                }

                if (dateFrom.HasValue)
                {
                    sql += " AND h.Время_входа_в_систему >= @dateFrom";
                    parameters.Add(new SqlParameter("@dateFrom", dateFrom.Value));
                }

                if (dateTo.HasValue)
                {
                    sql += " AND h.Время_входа_в_систему <= @dateTo";
                    parameters.Add(new SqlParameter("@dateTo", dateTo.Value.AddDays(1))); // Чтобы включить весь день
                }

                sql += " ORDER BY h.Время_входа_в_систему DESC";

                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var history = new List<LoginHistory>();

                        while (reader.Read())
                        {
                            history.Add(new LoginHistory
                            {
                                Id = reader.GetInt32(0),
                                UserId = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                                Login = reader.IsDBNull(2) ? "Неизвестно" : reader.GetString(2),
                                FullName = reader.IsDBNull(3) ? "Неизвестно" : reader.GetString(3).Trim(),
                                LoginTime = reader.GetDateTime(4),
                                SystemInfo = reader.IsDBNull(5) ? null : reader.GetString(5),
                                IpAddress = reader.GetString(6),
                                Success = reader.GetBoolean(7),
                                FailureReason = reader.IsDBNull(8) ? null : reader.GetString(8)
                            });
                        }

                        dataGrid.ItemsSource = history;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке истории входа: {ex.Message}");
            }
        }
    }
}
