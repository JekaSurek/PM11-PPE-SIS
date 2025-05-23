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
    /// Логика взаимодействия для AddEditInfraWindow.xaml
    /// </summary>
    public partial class AddEditInfraWindow : Window
    {
        private readonly Infrastructure _currentInfra;
        private readonly bool _isEditMode;

        public AddEditInfraWindow(Infrastructure infra)
        {
            InitializeComponent();
            _currentInfra = infra;
            _isEditMode = infra != null;

            if (_isEditMode)
            {
                this.Title = "Редактировать инфраструктуру";
                NameTextBox.Text = _currentInfra.Name;
                DescriptionTextBox.Text = _currentInfra.Description;
            }
            else
            {
                this.Title = "Добавить инфраструктуру";
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Поле 'Наименование' не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string procedure = _isEditMode ? "sp_UpdateИнфраструктура" : "sp_AddИнфраструктура";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Наименование", NameTextBox.Text),
                new SqlParameter("@Описание", (object)DescriptionTextBox.Text ?? System.DBNull.Value)
            };

            if (_isEditMode)
            {
                parameters.Add(new SqlParameter("@id_Инфраструктуры", _currentInfra.Id));
            }

            if (DataManager.ExecuteCommand(procedure, parameters))
            {
                this.DialogResult = true;
            }
        }
    }

}
