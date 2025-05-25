using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using УчетСИЗ.Models;
using System.Linq;

namespace УчетСИЗ.ViewModels
{
    /// <summary>
    /// Логика взаимодействия для AccountantWindow.xaml
    /// </summary>
    public partial class AccountantWindow : Window
    {
        private AccountantModel _model = new AccountantModel();

        public AccountantWindow()
        {
            InitializeComponent();
            Loaded += AccountantWindow_Loaded;
        }

        private void AccountantWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var norms = _model.GetNormsData();
            NormsGrid.ItemsSource = norms;
        }

        private void RefreshData_Click(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void ExportToExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var norms = _model.GetNormsData();
                if (norms == null || norms.Count == 0)
                {
                    MessageBox.Show("Нет данных для экспорта", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                //Группировка по инфраструктуре
                var groupedData = norms.GroupBy(n => n.Infrastructure);

                //Создаем Excel приложение
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;
                Excel.Workbook workbook = excelApp.Workbooks.Add();

                //Настройки документа
                excelApp.DisplayAlerts = false;

                //Создаем лист
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "Нормы выдачи СИЗ";

                //Заголовок
                worksheet.Cells[1, 1] = "Нормы выдачи средств индивидуальной защиты";
                Excel.Range headerRange = worksheet.Range["A1:I1"];
                headerRange.Merge();
                headerRange.Font.Bold = true;
                headerRange.Font.Size = 14;
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                int currentRow = 3;

                foreach (var infrastructureGroup in groupedData)
                {
                    //Записываем инфраструктуру
                    worksheet.Cells[currentRow, 1] = infrastructureGroup.Key;
                    Excel.Range infraRange = worksheet.Range[$"A{currentRow}:I{currentRow}"];
                    infraRange.Merge();
                    infraRange.Font.Bold = true;
                    infraRange.Font.Size = 12;
                    infraRange.Interior.Color = Excel.XlRgbColor.rgbLightGray;
                    currentRow++;

                    //Группируем профессии внутри инфраструктуры
                    var professionGroups = infrastructureGroup.GroupBy(n => n.Profession);

                    foreach (var professionGroup in professionGroups)
                    {
                        //Записываем профессию
                        worksheet.Cells[currentRow, 1] = professionGroup.Key;
                        Excel.Range professionRange = worksheet.Range[$"A{currentRow}:I{currentRow}"];
                        professionRange.Merge();
                        professionRange.Font.Bold = true;
                        professionRange.Font.Italic = true;
                        currentRow++;

                        //Заголовки таблицы СИЗ
                        worksheet.Cells[currentRow, 1] = "СИЗ";
                        worksheet.Cells[currentRow, 2] = "Тип";
                        worksheet.Cells[currentRow, 3] = "Ед. изм.";
                        worksheet.Cells[currentRow, 4] = "Норма";
                        worksheet.Cells[currentRow, 5] = "Период";
                        worksheet.Cells[currentRow, 6] = "Сезон";
                        worksheet.Cells[currentRow, 7] = "Основание";

                        //Форматируем заголовки
                        Excel.Range headersRange = worksheet.Range[$"A{currentRow}:G{currentRow}"];
                        headersRange.Font.Bold = true;
                        headersRange.Interior.Color = Excel.XlRgbColor.rgbLightBlue;
                        currentRow++;

                        //Записываем СИЗ для профессии
                        foreach (var norm in professionGroup)
                        {
                            worksheet.Cells[currentRow, 1] = norm.SIZ;
                            worksheet.Cells[currentRow, 2] = norm.SIZType;
                            worksheet.Cells[currentRow, 3] = norm.Unit;
                            worksheet.Cells[currentRow, 4] = norm.Norm;
                            worksheet.Cells[currentRow, 5] = norm.Period;
                            worksheet.Cells[currentRow, 6] = norm.Season;
                            worksheet.Cells[currentRow, 7] = norm.Basis;
                            currentRow++;
                        }

                        //Пустая строка между профессиями
                        currentRow++;
                    }

                    //Пустая строка между инфраструктурами
                    currentRow++;
                }

                //Автонастройка ширины столбцов
                worksheet.Columns.AutoFit();

                //Сохраняем файл
                string fileName = $"Нормы_выдачи_СИЗ_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

                workbook.SaveAs(filePath);
                MessageBox.Show($"Данные успешно экспортированы в файл:\n{filePath}", "Экспорт завершен", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте в Excel: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            ThisUsers thisUsers = new ThisUsers();
            thisUsers.ClearDat();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}