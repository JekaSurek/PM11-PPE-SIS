using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для AddEditEmployeeWindow.xaml
    /// </summary>
    public partial class AddEditEmployeeWindow : Window
    {
        private readonly Employee _currentEmployee;
        private readonly bool _isEditMode;

        public AddEditEmployeeWindow(Employee employee)
        {
            InitializeComponent();
            LoadProfessionComboBox();
            _currentEmployee = employee;
            _isEditMode = employee != null;

            if (_isEditMode)
            {
                this.Title = "Редактировать сотрудника";
                LastNameTextBox.Text = _currentEmployee.LastName;
                FirstNameTextBox.Text = _currentEmployee.FirstName;
                MiddleNameTextBox.Text = _currentEmployee.MiddleName;
                ProfessionComboBox.SelectedValue = _currentEmployee.ProfessionId;
            }
            else
            {
                this.Title = "Добавить сотрудника";
            }
        }

        private void LoadProfessionComboBox()
        {
            DataManager.LoadReferenceData(ProfessionComboBox, "SELECT id_Профессии_или_должности, Наименование FROM Профессия ORDER BY Наименование", "Наименование", "id_Профессии_или_должности");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text) || string.IsNullOrWhiteSpace(FirstNameTextBox.Text) || ProfessionComboBox.SelectedValue == null)
            {
                MessageBox.Show("Заполните 'Фамилию', 'Имя' и выберите 'Профессию'.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string procedure = _isEditMode ? "sp_UpdateСотрудник" : "sp_AddСотрудник";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Фамилия", LastNameTextBox.Text),
                new SqlParameter("@Имя", FirstNameTextBox.Text),
                new SqlParameter("@Отчество", (object)MiddleNameTextBox.Text ?? System.DBNull.Value),
                new SqlParameter("@id_профессии", (int)ProfessionComboBox.SelectedValue)
            };

            if (_isEditMode)
            {
                parameters.Add(new SqlParameter("@id_Сотрудника", _currentEmployee.Id));
            }

            if (DataManager.ExecuteCommand(procedure, parameters))
            {
                this.DialogResult = true;
            }
        }
    }
}
