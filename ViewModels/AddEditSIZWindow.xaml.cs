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
    /// Логика взаимодействия для AddEditSIZWindow.xaml
    /// </summary>
    public partial class AddEditSIZWindow : Window
    {
        private readonly SIZ _currentSIZ;
        private readonly bool _isEditMode;

        public AddEditSIZWindow(SIZ siz)
        {
            InitializeComponent();
            LoadSIZTypeComboBox();
            _currentSIZ = siz;
            _isEditMode = siz != null;

            if (_isEditMode)
            {
                this.Title = "Редактировать СИЗ";
                NameTextBox.Text = _currentSIZ.Name;
                UnitTextBox.Text = _currentSIZ.Unit;
                SIZTypeComboBox.SelectedValue = _currentSIZ.TypeId;
            }
            else
            {
                this.Title = "Добавить СИЗ";
            }
        }

        private void LoadSIZTypeComboBox()
        {
            DataManager.LoadReferenceData(SIZTypeComboBox, "SELECT id_Типа, Наименование FROM ТипСИЗ ORDER BY Наименование", "Наименование", "id_Типа");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(UnitTextBox.Text) || SIZTypeComboBox.SelectedValue == null)
            {
                MessageBox.Show("Заполните все обязательные поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string procedure = _isEditMode ? "sp_UpdateСИЗ" : "sp_AddСИЗ";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Наименование", NameTextBox.Text),
                new SqlParameter("@Единица_измерения", UnitTextBox.Text),
                new SqlParameter("@id_типаСИЗ", (int)SIZTypeComboBox.SelectedValue)
            };

            if (_isEditMode)
            {
                parameters.Add(new SqlParameter("@id_СИЗ", _currentSIZ.Id));
            }

            if (DataManager.ExecuteCommand(procedure, parameters))
            {
                this.DialogResult = true;
            }
        }
    }
}
