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
    /// Логика взаимодействия для AddEditDermatologWindow.xaml
    /// </summary>
    public partial class AddEditDermatologWindow : Window
    {
        private readonly Dermatolog _currentDermatolog;
        private readonly bool _isEditMode;

        public AddEditDermatologWindow(Dermatolog dermatolog)
        {
            InitializeComponent();
            LoadProfessionComboBox();
            _currentDermatolog = dermatolog;
            _isEditMode = dermatolog != null;

            if (_isEditMode)
            {
                this.Title = "Редактировать средство";
                NameTextBox.Text = _currentDermatolog.Name;
                NormTextBox.Text = _currentDermatolog.Norm;
                ProfessionComboBox.SelectedValue = _currentDermatolog.ProfessionId;
            }
            else
            {
                this.Title = "Добавить средство";
            }
        }

        private void LoadProfessionComboBox()
        {
            DataManager.LoadReferenceData(ProfessionComboBox, "SELECT id_Профессии_или_должности, Наименование FROM Профессия ORDER BY Наименование", "Наименование", "id_Профессии_или_должности");
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || string.IsNullOrWhiteSpace(NormTextBox.Text) || ProfessionComboBox.SelectedValue == null)
            {
                MessageBox.Show("Заполните все обязательные поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string procedure = _isEditMode ? "sp_UpdateДерматологическоеСредство" : "sp_AddДерматологическоеСредство";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Наименование", NameTextBox.Text),
                new SqlParameter("@Норма", NormTextBox.Text),
                new SqlParameter("@id_профессии", (int)ProfessionComboBox.SelectedValue)
            };

            if (_isEditMode)
            {
                parameters.Add(new SqlParameter("@id_ДерматологическогоСредства", _currentDermatolog.Id));
            }

            if (DataManager.ExecuteCommand(procedure, parameters))
            {
                this.DialogResult = true;
            }
        }
    }
}
