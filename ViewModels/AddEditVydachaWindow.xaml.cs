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
    /// Логика взаимодействия для AddEditVydachaWindow.xaml
    /// </summary>
    public partial class AddEditVydachaWindow : Window
    {
        private readonly Vydacha _currentVydacha;
        private readonly bool _isEditMode;

        public AddEditVydachaWindow(Vydacha vydacha)
        {
            InitializeComponent();
            LoadComboBoxes();
            _currentVydacha = vydacha;
            _isEditMode = vydacha != null;

            if (_isEditMode)
            {
                this.Title = "Редактировать выдачу";
                EmployeeComboBox.SelectedValue = _currentVydacha.EmployeeId;
                SIZComboBox.SelectedValue = _currentVydacha.SIZId;
                QuantityTextBox.Text = _currentVydacha.Quantity.ToString();
                WearPeriodPicker.SelectedDate = _currentVydacha.WearPeriod;
            }
            else
            {
                this.Title = "Добавить выдачу";
            }
        }

        private void LoadComboBoxes()
        {
            DataManager.LoadReferenceData(EmployeeComboBox, "SELECT id_Сотрудника, Фамилия + ' ' + Имя + ' ' + ISNULL(Отчество, '') AS FullName FROM Сотрудник ORDER BY FullName", "FullName", "id_Сотрудника");
            DataManager.LoadReferenceData(SIZComboBox, "SELECT id_СИЗ, Наименование FROM СИЗ ORDER BY Наименование", "Наименование", "id_СИЗ");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeComboBox.SelectedValue == null || SIZComboBox.SelectedValue == null || !int.TryParse(QuantityTextBox.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Выберите сотрудника, СИЗ и укажите корректное количество.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string procedure = _isEditMode ? "sp_UpdateВыдача" : "sp_ДобавитьВыдачу";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@id_сотрудника", (int)EmployeeComboBox.SelectedValue),
                new SqlParameter("@id_сиз", (int)SIZComboBox.SelectedValue),
                new SqlParameter("@количество", quantity),
                new SqlParameter("@Срок_износа", WearPeriodPicker.SelectedDate.HasValue ? (object)WearPeriodPicker.SelectedDate.Value : System.DBNull.Value),
                new SqlParameter("@Кем_создана", ThisUser.CurrentUser?.Id ?? (object)System.DBNull.Value)
            };

            if (_isEditMode)
            {
                parameters.Add(new SqlParameter("@id_Выдачи", _currentVydacha.Id));
            }

            if (DataManager.ExecuteCommand(procedure, parameters))
            {
                this.DialogResult = true;
            }
        }
    }
}
