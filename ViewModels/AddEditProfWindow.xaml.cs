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
    /// Логика взаимодействия для AddEditProfWindow.xaml
    /// </summary>
    public partial class AddEditProfWindow : Window
    {
        private readonly Profession _currentProf;
        private readonly bool _isEditMode;

        public AddEditProfWindow(Profession prof)
        {
            InitializeComponent();
            LoadInfraComboBox();
            _currentProf = prof;
            _isEditMode = prof != null;

            if (_isEditMode)
            {
                this.Title = "Редактировать профессию";
                NameTextBox.Text = _currentProf.Name;
                CodeTextBox.Text = _currentProf.Code;
                InfraComboBox.SelectedValue = _currentProf.InfrastructureId;
            }
            else
            {
                this.Title = "Добавить профессию";
            }
        }

        private void LoadInfraComboBox()
        {
            DataManager.LoadReferenceData(InfraComboBox, "SELECT id_Инфраструктуры, Наименование FROM Инфраструктура ORDER BY Наименование", "Наименование", "id_Инфраструктуры");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || InfraComboBox.SelectedValue == null)
            {
                MessageBox.Show("Заполните 'Наименование' и выберите 'Инфраструктуру'.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string procedure = _isEditMode ? "sp_UpdateПрофессия" : "sp_AddПрофессия";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Наименование", NameTextBox.Text),
                new SqlParameter("@Код_по_нормативу", (object)CodeTextBox.Text ?? System.DBNull.Value),
                new SqlParameter("@id_инфраструктуры_или_отдела", (int)InfraComboBox.SelectedValue)
            };

            if (_isEditMode)
            {
                parameters.Add(new SqlParameter("@id_Профессии_или_должности", _currentProf.Id));
            }

            if (DataManager.ExecuteCommand(procedure, parameters))
            {
                this.DialogResult = true;
            }
        }
    }
}
