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
    /// Логика взаимодействия для AddEditSeasonWindow.xaml
    /// </summary>
    public partial class AddEditSeasonWindow : Window
    {
        private readonly Season _currentSeason;
        private readonly bool _isEditMode;

        public AddEditSeasonWindow(Season season)
        {
            InitializeComponent();
            _currentSeason = season;
            _isEditMode = season != null;

            if (_isEditMode)
            {
                this.Title = "Редактировать сезон";
                NameTextBox.Text = _currentSeason.Name;
            }
            else
            {
                this.Title = "Добавить сезон";
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Поле 'Наименование' не может быть пустым.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string procedure = _isEditMode ? "sp_UpdateСезон" : "sp_AddСезон";
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Наименование", NameTextBox.Text)
            };

            if (_isEditMode)
            {
                parameters.Add(new SqlParameter("@id_Сезона", _currentSeason.Id));
            }

            if (DataManager.ExecuteCommand(procedure, parameters))
            {
                this.DialogResult = true;
            }
        }
    }
}
