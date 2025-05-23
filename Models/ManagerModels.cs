using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace УчетСИЗ.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Vydacha
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int SIZId { get; set; }
        public string SIZName { get; set; }
        public DateTime IssueDate { get; set; }
        public int Quantity { get; set; }
        public DateTime? WearPeriod { get; set; }
        public int CreatedBy { get; set; }
    }

    public class Dermatolog : BaseEntity
    {
        public int ProfessionId { get; set; }
        public string ProfessionName { get; set; }
        public string Norm { get; set; }
    }

    public class Infrastructure : BaseEntity
    {
        public string Description { get; set; }
    }

    public class NormaVydachi
    {
        public int Id { get; set; }
        public int ProfessionId { get; set; }
        public string ProfessionName { get; set; }
        public int SIZId { get; set; }
        public string SIZName { get; set; }
        public string Norm { get; set; }
        public string Period { get; set; }
        public int SeasonId { get; set; }
        public string SeasonName { get; set; }
        public string Basis { get; set; }
    }

    public class Profession : BaseEntity
    {
        public string Code { get; set; }
        public int InfrastructureId { get; set; }
        public string InfrastructureName { get; set; }
    }

    public class Season : BaseEntity { }

    public class SIZ : BaseEntity
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string Unit { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int ProfessionId { get; set; }
        public string ProfessionName { get; set; }
        public string FullName => $"{LastName} {FirstName} {MiddleName}".Trim();
    }

    public class SIZType : BaseEntity
    {
        public string Description { get; set; }
    }

    public static class DataManager
    {
        private static readonly string ConnectionString = DatabaseHelper.GetConnectionString();

        public static void LoadData<T>(DataGrid grid, string procedureName, Func<SqlDataReader, T> createObject, string filter = "")
        {
            var items = new List<T>();
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var command = new SqlCommand(procedureName, connection) { CommandType = CommandType.StoredProcedure };
                    if (!string.IsNullOrEmpty(filter))
                    {
                        command.Parameters.AddWithValue("@filter", filter);
                    }
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(createObject(reader));
                        }
                    }
                }
                grid.ItemsSource = items;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static bool ExecuteCommand(string procedureName, List<SqlParameter> parameters)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var command = new SqlCommand(procedureName, connection) { CommandType = CommandType.StoredProcedure };
                    command.Parameters.AddRange(parameters.ToArray());
                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения команды: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public static void DeleteData(string procedureName, int id, string parameterName)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter(parameterName, id)
            };
            ExecuteCommand(procedureName, parameters);
        }

        public static void LoadReferenceData(ComboBox comboBox, string query, string displayMember, string valueMember)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    var adapter = new SqlDataAdapter(query, connection);
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    comboBox.ItemsSource = dt.DefaultView;
                    comboBox.DisplayMemberPath = displayMember;
                    comboBox.SelectedValuePath = valueMember;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочника: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
