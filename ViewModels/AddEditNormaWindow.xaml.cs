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
    /// Логика взаимодействия для AddEditNormaWindow.xaml
    /// </summary>
    public partial class AddEditNormaWindow : Window
    {
        private readonly NormaVydachi _currentNorma;
        private readonly bool _isEditMode;

        public AddEditNormaWindow(NormaVydachi norma)
        {
            InitializeComponent();
            LoadComboBoxes();
            _currentNorma = norma;
            _isEditMode = norma != null;

            if (_isEditMode)
            {
                this.Title = "Редактировать норму выдачи";
                ProfessionComboBox.SelectedValue = _currentNorma.ProfessionId;
                SIZComboBox.SelectedValue = _currentNorma.SIZId;
                NormTextBox.Text = _currentNorma.Norm;
                PeriodTextBox.Text = _currentNorma.Period;
                SeasonComboBox.SelectedValue = _currentNorma.SeasonId;
                BasisTextBox.Text = _currentNorma.Basis;
            }
            else
            {
                this.Title = "Добавить норму выдачи";
            }
        }

        private void LoadComboBoxes()
        {
            DataManager.LoadReferenceData(ProfessionComboBox, "SELECT id_Профессии_или_должности, Наименование FROM Профессия ORDER BY Наименование", "Наименование", "id_Профессии_или_должности");
            DataManager.LoadReferenceData(SIZComboBox, "SELECT id_СИЗ, Наименование FROM СИЗ ORDER BY Наименование", "Наименование", "id_СИЗ");
            DataManager.LoadReferenceData(SeasonComboBox, "SELECT id_Сезона, Наименование FROM Сезон ORDER BY Наименование", "Наименование", "id_Сезона");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (ProfessionComboBox.SelectedValue == null || SIZComboBox.SelectedValue == null || SeasonComboBox.SelectedValue == null ||
                string.IsNullOrWhiteSpace(NormTextBox.Text) || string.IsNullOrWhiteSpace(PeriodTextBox.Text) || string.IsNullOrWhiteSpace(BasisTextBox.Text))
            {
                MessageBox.Show("Заполните все обязательные поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string procedure = _isEditMode ? "sp_UpdateНормаВыдачи" : "sp_AddНормаВыдачи";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@id_профессии", (int)ProfessionComboBox.SelectedValue),
                new SqlParameter("@id_сиз", (int)SIZComboBox.SelectedValue),
                new SqlParameter("@Норма_в_единицах_измерения", NormTextBox.Text),
                new SqlParameter("@Период", PeriodTextBox.Text),
                new SqlParameter("@Сезон", (int)SeasonComboBox.SelectedValue),
                new SqlParameter("@Основание_назначения", BasisTextBox.Text)
            };

            if (_isEditMode)
            {
                parameters.Add(new SqlParameter("@id_Нормы", _currentNorma.Id));
            }

            if (DataManager.ExecuteCommand(procedure, parameters))
            {
                this.DialogResult = true;
            }
        }
    }
}
