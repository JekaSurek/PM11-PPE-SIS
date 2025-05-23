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
    /// Логика взаимодействия для AddEditSIZTypeWindow.xaml
    /// </summary>
    public partial class AddEditSIZTypeWindow : Window
    {
        private readonly SIZType _currentSIZType;
        private readonly bool _isEditMode;

        public AddEditSIZTypeWindow(SIZType sizType)
        {
            InitializeComponent();
            _currentSIZType = sizType;
            _isEditMode = sizType != null;

            if (_isEditMode)
            {
                this.Title = "Редактировать тип СИЗ";
                NameTextBox.Text = _currentSIZType.Name;
                DescriptionTextBox.Text = _currentSIZType.Description;
            }
            else
            {
                this.Title = "Добавить тип СИЗ";
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Поле 'Наименование' не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string procedure = _isEditMode ? "sp_UpdateТипСИЗ" : "sp_AddТипСИЗ";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Наименование", NameTextBox.Text),
                new SqlParameter("@Описание", (object)DescriptionTextBox.Text ?? System.DBNull.Value)
            };

            if (_isEditMode)
            {
                parameters.Add(new SqlParameter("@id_Типа", _currentSIZType.Id));
            }

            if (DataManager.ExecuteCommand(procedure, parameters))
            {
                this.DialogResult = true;
            }
        }
    }
}
