using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
            Loaded += ManagerWindow_Loaded;
        }

        private void ManagerWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadAllData();
        }

        private void LoadAllData()
        {
            LoadVydachaData();
            LoadDermatologData();
            LoadInfraData();
            LoadNormaData();
            LoadProfData();
            LoadSeasonData();
            LoadSIZData();
            LoadEmployeeData();
            LoadSIZTypeData();
        }

        private void OutButton_Click(object sender, RoutedEventArgs e)
        {
            new ThisUsers().ClearDat();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        #region Vydacha (Выдача)

        private void LoadVydachaData(string filter = "") => DataManager.LoadData(VydachaGrid, "sp_GetВыдача", reader => new Vydacha
        {
            Id = reader.GetInt32(0),
            EmployeeId = reader.GetInt32(1),
            EmployeeName = reader.GetString(2),
            SIZId = reader.GetInt32(3),
            SIZName = reader.GetString(4),
            IssueDate = reader.GetDateTime(5),
            Quantity = reader.GetInt32(6),
            WearPeriod = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7)
        }, filter);

        private void VydachaFilterTextBox_TextChanged(object sender, TextChangedEventArgs e) => LoadVydachaData(VydachaFilterTextBox.Text);
        private void VydachaResetFilter_Click(object sender, RoutedEventArgs e) { VydachaFilterTextBox.Text = ""; LoadVydachaData(); }
        private void VydachaGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isSelected = VydachaGrid.SelectedItem != null;
            VydachaEditButton.IsEnabled = isSelected;
            VydachaDeleteButton.IsEnabled = isSelected;
        }
        private void VydachaAdd_Click(object sender, RoutedEventArgs e)
        {
            if (new AddEditVydachaWindow(null).ShowDialog() == true) LoadVydachaData();
        }
        private void VydachaEdit_Click(object sender, RoutedEventArgs e)
        {
            if (VydachaGrid.SelectedItem is Vydacha selected)
            {
                if (new AddEditVydachaWindow(selected).ShowDialog() == true) LoadVydachaData();
            }
        }
        private void VydachaDelete_Click(object sender, RoutedEventArgs e)
        {
            if (VydachaGrid.SelectedItem is Vydacha selected)
            {
                if (MessageBox.Show($"Удалить запись ID: {selected.Id}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DataManager.DeleteData("sp_DeleteВыдача", selected.Id, "@id_Выдачи");
                    LoadVydachaData();
                }
            }
        }

        #endregion

        #region Dermatolog (Дерматологические средства)

        private void LoadDermatologData(string filter = "") => DataManager.LoadData(DermatologGrid, "sp_GetДерматологическоеСредство", reader => new Dermatolog
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Norm = reader.GetString(2),
            ProfessionId = reader.GetInt32(3),
            ProfessionName = reader.GetString(4)
        }, filter);

        private void DermatologFilterTextBox_TextChanged(object sender, TextChangedEventArgs e) => LoadDermatologData(DermatologFilterTextBox.Text);
        private void DermatologResetFilter_Click(object sender, RoutedEventArgs e) { DermatologFilterTextBox.Text = ""; LoadDermatologData(); }
        private void DermatologGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isSelected = DermatologGrid.SelectedItem != null;
            DermatologEditButton.IsEnabled = isSelected;
            DermatologDeleteButton.IsEnabled = isSelected;
        }
        private void DermatologAdd_Click(object sender, RoutedEventArgs e)
        {
            if (new AddEditDermatologWindow(null).ShowDialog() == true) LoadDermatologData();
        }
        private void DermatologEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DermatologGrid.SelectedItem is Dermatolog selected)
            {
                if (new AddEditDermatologWindow(selected).ShowDialog() == true) LoadDermatologData();
            }
        }
        private void DermatologDelete_Click(object sender, RoutedEventArgs e)
        {
            if (DermatologGrid.SelectedItem is Dermatolog selected)
            {
                if (MessageBox.Show($"Удалить '{selected.Name}'?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DataManager.DeleteData("sp_DeleteДерматологическоеСредство", selected.Id, "@id_ДерматологическогоСредства");
                    LoadDermatologData();
                }
            }
        }

        #endregion

        #region Infrastructure (Инфраструктура)

        private void LoadInfraData(string filter = "") => DataManager.LoadData(InfraGrid, "sp_GetИнфраструктура", reader => new Infrastructure
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Description = reader.IsDBNull(2) ? "" : reader.GetString(2)
        }, filter);

        private void InfraFilterTextBox_TextChanged(object sender, TextChangedEventArgs e) => LoadInfraData(InfraFilterTextBox.Text);
        private void InfraResetFilter_Click(object sender, RoutedEventArgs e) { InfraFilterTextBox.Text = ""; LoadInfraData(); }
        private void InfraGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isSelected = InfraGrid.SelectedItem != null;
            InfraEditButton.IsEnabled = isSelected;
            InfraDeleteButton.IsEnabled = isSelected;
        }
        private void InfraAdd_Click(object sender, RoutedEventArgs e)
        {
            if (new AddEditInfraWindow(null).ShowDialog() == true) LoadInfraData();
        }
        private void InfraEdit_Click(object sender, RoutedEventArgs e)
        {
            if (InfraGrid.SelectedItem is Infrastructure selected)
            {
                if (new AddEditInfraWindow(selected).ShowDialog() == true) LoadInfraData();
            }
        }
        private void InfraDelete_Click(object sender, RoutedEventArgs e)
        {
            if (InfraGrid.SelectedItem is Infrastructure selected)
            {
                if (MessageBox.Show($"Удалить '{selected.Name}'?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DataManager.DeleteData("sp_DeleteИнфраструктура", selected.Id, "@id_Инфраструктуры");
                    LoadInfraData();
                }
            }
        }
        #endregion

        #region NormaVydachi (Нормы выдачи)

        private void LoadNormaData(string filter = "") => DataManager.LoadData(NormaGrid, "sp_GetНормаВыдачи", reader => new NormaVydachi
        {
            Id = reader.GetInt32(0),
            ProfessionId = reader.GetInt32(1),
            ProfessionName = reader.GetString(2),
            SIZId = reader.GetInt32(3),
            SIZName = reader.GetString(4),
            Norm = reader.GetString(5),
            Period = reader.GetString(6),
            SeasonId = reader.GetInt32(7),
            SeasonName = reader.GetString(8),
            Basis = reader.GetString(9)
        }, filter);

        private void NormaFilterTextBox_TextChanged(object sender, TextChangedEventArgs e) => LoadNormaData(NormaFilterTextBox.Text);
        private void NormaResetFilter_Click(object sender, RoutedEventArgs e) { NormaFilterTextBox.Text = ""; LoadNormaData(); }
        private void NormaGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isSelected = NormaGrid.SelectedItem != null;
            NormaEditButton.IsEnabled = isSelected;
            NormaDeleteButton.IsEnabled = isSelected;
        }
        private void NormaAdd_Click(object sender, RoutedEventArgs e)
        {
            if (new AddEditNormaWindow(null).ShowDialog() == true) LoadNormaData();
        }
        private void NormaEdit_Click(object sender, RoutedEventArgs e)
        {
            if (NormaGrid.SelectedItem is NormaVydachi selected)
            {
                if (new AddEditNormaWindow(selected).ShowDialog() == true) LoadNormaData();
            }
        }
        private void NormaDelete_Click(object sender, RoutedEventArgs e)
        {
            if (NormaGrid.SelectedItem is NormaVydachi selected)
            {
                if (MessageBox.Show($"Удалить норму ID: {selected.Id}?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DataManager.DeleteData("sp_DeleteНормаВыдачи", selected.Id, "@id_Нормы");
                    LoadNormaData();
                }
            }
        }
        #endregion

        #region Profession (Профессии)

        private void LoadProfData(string filter = "") => DataManager.LoadData(ProfGrid, "sp_GetПрофессия", reader => new Profession
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Code = reader.IsDBNull(2) ? "" : reader.GetString(2),
            InfrastructureId = reader.GetInt32(3),
            InfrastructureName = reader.GetString(4)
        }, filter);

        private void ProfFilterTextBox_TextChanged(object sender, TextChangedEventArgs e) => LoadProfData(ProfFilterTextBox.Text);
        private void ProfResetFilter_Click(object sender, RoutedEventArgs e) { ProfFilterTextBox.Text = ""; LoadProfData(); }
        private void ProfGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isSelected = ProfGrid.SelectedItem != null;
            ProfEditButton.IsEnabled = isSelected;
            ProfDeleteButton.IsEnabled = isSelected;
        }
        private void ProfAdd_Click(object sender, RoutedEventArgs e)
        {
            if (new AddEditProfWindow(null).ShowDialog() == true) LoadProfData();
        }
        private void ProfEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ProfGrid.SelectedItem is Profession selected)
            {
                if (new AddEditProfWindow(selected).ShowDialog() == true) LoadProfData();
            }
        }
        private void ProfDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ProfGrid.SelectedItem is Profession selected)
            {
                if (MessageBox.Show($"Удалить '{selected.Name}'?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DataManager.DeleteData("sp_DeleteПрофессия", selected.Id, "@id_Профессии_или_должности");
                    LoadProfData();
                }
            }
        }
        #endregion

        #region Season (Сезоны)

        private void LoadSeasonData(string filter = "") => DataManager.LoadData(SeasonGrid, "sp_GetСезон", reader => new Season
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1)
        }, filter);

        private void SeasonFilterTextBox_TextChanged(object sender, TextChangedEventArgs e) => LoadSeasonData(SeasonFilterTextBox.Text);
        private void SeasonResetFilter_Click(object sender, RoutedEventArgs e) { SeasonFilterTextBox.Text = ""; LoadSeasonData(); }
        private void SeasonGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isSelected = SeasonGrid.SelectedItem != null;
            SeasonEditButton.IsEnabled = isSelected;
            SeasonDeleteButton.IsEnabled = isSelected;
        }
        private void SeasonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (new AddEditSeasonWindow(null).ShowDialog() == true) LoadSeasonData();
        }
        private void SeasonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SeasonGrid.SelectedItem is Season selected)
            {
                if (new AddEditSeasonWindow(selected).ShowDialog() == true) LoadSeasonData();
            }
        }
        private void SeasonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SeasonGrid.SelectedItem is Season selected)
            {
                if (MessageBox.Show($"Удалить '{selected.Name}'?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DataManager.DeleteData("sp_DeleteСезон", selected.Id, "@id_Сезона");
                    LoadSeasonData();
                }
            }
        }

        #endregion

        #region SIZ (СИЗ)

        private void LoadSIZData(string filter = "") => DataManager.LoadData(SIZGrid, "sp_GetСИЗ", reader => new SIZ
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Unit = reader.GetString(2),
            TypeId = reader.GetInt32(3),
            TypeName = reader.GetString(4)
        }, filter);

        private void SIZFilterTextBox_TextChanged(object sender, TextChangedEventArgs e) => LoadSIZData(SIZFilterTextBox.Text);
        private void SIZResetFilter_Click(object sender, RoutedEventArgs e) { SIZFilterTextBox.Text = ""; LoadSIZData(); }
        private void SIZGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isSelected = SIZGrid.SelectedItem != null;
            SIZEditButton.IsEnabled = isSelected;
            SIZDeleteButton.IsEnabled = isSelected;
        }
        private void SIZAdd_Click(object sender, RoutedEventArgs e)
        {
            if (new AddEditSIZWindow(null).ShowDialog() == true) LoadSIZData();
        }
        private void SIZEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SIZGrid.SelectedItem is SIZ selected)
            {
                if (new AddEditSIZWindow(selected).ShowDialog() == true) LoadSIZData();
            }
        }
        private void SIZDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SIZGrid.SelectedItem is SIZ selected)
            {
                if (MessageBox.Show($"Удалить '{selected.Name}'?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DataManager.DeleteData("sp_DeleteСИЗ", selected.Id, "@id_СИЗ");
                    LoadSIZData();
                }
            }
        }
        #endregion

        #region Employee (Сотрудники)

        private void LoadEmployeeData(string filter = "") => DataManager.LoadData(EmployeeGrid, "sp_GetСотрудник", reader => new Employee
        {
            Id = reader.GetInt32(0),
            LastName = reader.GetString(1),
            FirstName = reader.GetString(2),
            MiddleName = reader.IsDBNull(3) ? "" : reader.GetString(3),
            ProfessionId = reader.GetInt32(4),
            ProfessionName = reader.GetString(5)
        }, filter);

        private void EmployeeFilterTextBox_TextChanged(object sender, TextChangedEventArgs e) => LoadEmployeeData(EmployeeFilterTextBox.Text);
        private void EmployeeResetFilter_Click(object sender, RoutedEventArgs e) { EmployeeFilterTextBox.Text = ""; LoadEmployeeData(); }
        private void EmployeeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isSelected = EmployeeGrid.SelectedItem != null;
            EmployeeEditButton.IsEnabled = isSelected;
            EmployeeDeleteButton.IsEnabled = isSelected;
        }
        private void EmployeeAdd_Click(object sender, RoutedEventArgs e)
        {
            if (new AddEditEmployeeWindow(null).ShowDialog() == true) LoadEmployeeData();
        }
        private void EmployeeEdit_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem is Employee selected)
            {
                if (new AddEditEmployeeWindow(selected).ShowDialog() == true) LoadEmployeeData();
            }
        }
        private void EmployeeDelete_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem is Employee selected)
            {
                if (MessageBox.Show($"Удалить сотрудника '{selected.LastName} {selected.FirstName}'?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DataManager.DeleteData("sp_DeleteСотрудник", selected.Id, "@id_Сотрудника");
                    LoadEmployeeData();
                }
            }
        }
        #endregion

        #region SIZType (Типы СИЗ)

        private void LoadSIZTypeData(string filter = "") => DataManager.LoadData(SIZTypeGrid, "sp_GetТипСИЗ", reader => new SIZType
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Description = reader.IsDBNull(2) ? "" : reader.GetString(2)
        }, filter);

        private void SIZTypeFilterTextBox_TextChanged(object sender, TextChangedEventArgs e) => LoadSIZTypeData(SIZTypeFilterTextBox.Text);
        private void SIZTypeResetFilter_Click(object sender, RoutedEventArgs e) { SIZTypeFilterTextBox.Text = ""; LoadSIZTypeData(); }
        private void SIZTypeGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool isSelected = SIZTypeGrid.SelectedItem != null;
            SIZTypeEditButton.IsEnabled = isSelected;
            SIZTypeDeleteButton.IsEnabled = isSelected;
        }
        private void SIZTypeAdd_Click(object sender, RoutedEventArgs e)
        {
            if (new AddEditSIZTypeWindow(null).ShowDialog() == true) LoadSIZTypeData();
        }
        private void SIZTypeEdit_Click(object sender, RoutedEventArgs e)
        {
            if (SIZTypeGrid.SelectedItem is SIZType selected)
            {
                if (new AddEditSIZTypeWindow(selected).ShowDialog() == true) LoadSIZTypeData();
            }
        }
        private void SIZTypeDelete_Click(object sender, RoutedEventArgs e)
        {
            if (SIZTypeGrid.SelectedItem is SIZType selected)
            {
                if (MessageBox.Show($"Удалить '{selected.Name}'?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DataManager.DeleteData("sp_DeleteТипСИЗ", selected.Id, "@id_Типа");
                    LoadSIZTypeData();
                }
            }
        }
        #endregion
    }
}
