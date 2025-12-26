using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tyuiu.DevyatovEV.Sprint7.Project.V7.Lib;

namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    public partial class FormMain_DEV : Form
    {
        private readonly DataService_DEV dataService_DEV = new DataService_DEV();
        private DataTable table_DEV;
        private DataView view_DEV;

        private const string CsvPath = @"C:\Users\Egor\source\repos\Tyuiu.DevyatovEV.Sprint7\Data\HousingManagement.csv";

        public FormMain_DEV()
        {
            InitializeComponent();
            LoadData_DEV();
            ConfigureDataGridViewForEditing();
        }

        private void LoadData_DEV()
        {
            try
            {
                string directory = Path.GetDirectoryName(CsvPath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                if (!File.Exists(CsvPath))
                {
                    File.WriteAllText(CsvPath,
                        "НомерПодъезда,НомерКвартиры,ОбщаяПлощадь,ЖилаяПлощадь,КоличествоКомнат,Фамилия,ДатаРегистрации,ЧленовСемьи,КоличествоДетей,НаличиеДолга,Примечание\n",
                        Encoding.UTF8);
                }

                table_DEV = dataService_DEV.LoadFromCsv_DEV(CsvPath);
                view_DEV = new DataView(table_DEV);
                dataGridViewBase_DEV.DataSource = view_DEV;
                SetColumnHeaders_DEV();

                UpdateFilterInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridViewForEditing()
        {
            dataGridViewBase_DEV.ReadOnly = false;
            dataGridViewBase_DEV.AllowUserToAddRows = false;
            dataGridViewBase_DEV.AllowUserToDeleteRows = true;
            dataGridViewBase_DEV.EditMode = DataGridViewEditMode.EditOnEnter;

            foreach (DataGridViewColumn column in dataGridViewBase_DEV.Columns)
            {
                column.ReadOnly = false;
            }

            dataGridViewBase_DEV.CellEndEdit += DataGridViewBase_DEV_CellEndEdit;
        }

        private void SetColumnHeaders_DEV()
        {
            if (dataGridViewBase_DEV.Columns.Contains("EntranceNumber"))
                dataGridViewBase_DEV.Columns["EntranceNumber"].HeaderText = "Подъезд";
            if (dataGridViewBase_DEV.Columns.Contains("ApartmentNumber"))
                dataGridViewBase_DEV.Columns["ApartmentNumber"].HeaderText = "Квартира";
            if (dataGridViewBase_DEV.Columns.Contains("TotalArea"))
                dataGridViewBase_DEV.Columns["TotalArea"].HeaderText = "Общая площадь";
            if (dataGridViewBase_DEV.Columns.Contains("LivingArea"))
                dataGridViewBase_DEV.Columns["LivingArea"].HeaderText = "Жилая площадь";
            if (dataGridViewBase_DEV.Columns.Contains("RoomsCount"))
                dataGridViewBase_DEV.Columns["RoomsCount"].HeaderText = "Комнаты";
            if (dataGridViewBase_DEV.Columns.Contains("TenantLastName"))
                dataGridViewBase_DEV.Columns["TenantLastName"].HeaderText = "Фамилия";
            if (dataGridViewBase_DEV.Columns.Contains("RegistrationDate"))
                dataGridViewBase_DEV.Columns["RegistrationDate"].HeaderText = "Дата";
            if (dataGridViewBase_DEV.Columns.Contains("FamilyMembers"))
                dataGridViewBase_DEV.Columns["FamilyMembers"].HeaderText = "Семья";
            if (dataGridViewBase_DEV.Columns.Contains("ChildrenCount"))
                dataGridViewBase_DEV.Columns["ChildrenCount"].HeaderText = "Дети";
            if (dataGridViewBase_DEV.Columns.Contains("HasDebt"))
                dataGridViewBase_DEV.Columns["HasDebt"].HeaderText = "Долг";
            if (dataGridViewBase_DEV.Columns.Contains("Note"))
                dataGridViewBase_DEV.Columns["Note"].HeaderText = "Примечание";
        }

        private void DataGridViewBase_DEV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                var cell = dataGridViewBase_DEV.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DataRowView rowView = (DataRowView)dataGridViewBase_DEV.Rows[e.RowIndex].DataBoundItem;
                DataRow row = rowView.Row;

                string columnName = dataGridViewBase_DEV.Columns[e.ColumnIndex].DataPropertyName;
                row[columnName] = cell.Value ?? DBNull.Value;

                dataService_DEV.SaveToCsv_DEV(CsvPath, table_DEV);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_DEV_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow newRow = table_DEV.NewRow();

                newRow["EntranceNumber"] = 1;
                newRow["ApartmentNumber"] = 1;
                newRow["TotalArea"] = 0;
                newRow["LivingArea"] = 0;
                newRow["RoomsCount"] = 1;
                newRow["TenantLastName"] = "";
                newRow["RegistrationDate"] = DateTime.Today.ToString("yyyy-MM-dd");
                newRow["FamilyMembers"] = 1;
                newRow["ChildrenCount"] = 0;
                newRow["HasDebt"] = "нет";
                newRow["Note"] = "";

                table_DEV.Rows.Add(newRow);
                dataService_DEV.SaveToCsv_DEV(CsvPath, table_DEV);

                view_DEV = new DataView(table_DEV);
                dataGridViewBase_DEV.DataSource = view_DEV;
                ConfigureDataGridViewForEditing();

                if (dataGridViewBase_DEV.RowCount > 0)
                {
                    int lastRowIndex = dataGridViewBase_DEV.RowCount - 1;
                    dataGridViewBase_DEV.FirstDisplayedScrollingRowIndex = lastRowIndex;
                    dataGridViewBase_DEV.ClearSelection();
                    dataGridViewBase_DEV.Rows[lastRowIndex].Selected = true;
                    dataGridViewBase_DEV.CurrentCell = dataGridViewBase_DEV.Rows[lastRowIndex].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении строки: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_DEV_Click(object sender, EventArgs e)
        {
            if (dataGridViewBase_DEV.CurrentRow == null)
            {
                MessageBox.Show("Выберите запись для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Удалить выбранную запись?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                DataRow row = ((DataRowView)dataGridViewBase_DEV.CurrentRow.DataBoundItem).Row;
                table_DEV.Rows.Remove(row);
                dataService_DEV.SaveToCsv_DEV(CsvPath, table_DEV);

                view_DEV = new DataView(table_DEV);
                dataGridViewBase_DEV.DataSource = view_DEV;
                ConfigureDataGridViewForEditing();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== СТАТИСТИКА (без многодетной семьи) =====
        private void Statistics_DEV_Click(object sender, EventArgs e)
        {
            if (view_DEV.Count == 0)
            {
                MessageBox.Show("Нет данных для анализа", "Статистика",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var areas = view_DEV.Cast<DataRowView>()
                    .Select(r => Convert.ToDouble(r["TotalArea"]))
                    .ToList();

                double maxArea = areas.Max();
                double minArea = areas.Min();
                double avgArea = areas.Average();

                string statText = $@"СТАТИСТИКА ПО ТЕКУЩЕЙ ТАБЛИЦЕ

Количество записей: {view_DEV.Count}

ОБЩАЯ ПЛОЩАДЬ:
Максимальная: {maxArea} м²
Минимальная: {minArea} м²
Средняя: {avgArea:F2} м²
";

                if (MessageBox.Show(statText + "\nСохранить статистику в файл?", "Статистика",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using SaveFileDialog sfd = new SaveFileDialog
                    {
                        Filter = "TXT файлы (*.txt)|*.txt",
                        FileName = $"статистика_{DateTime.Now:yyyy-MM-dd}.txt"
                    };

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, statText, Encoding.UTF8);
                        MessageBox.Show("Статистика сохранена",
                            "Готово",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчете статистики: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Export_DEV_Click(object sender, EventArgs e)
        {
            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "CSV файлы (*.csv)|*.csv",
                FileName = $"таблица_домоуправление_{DateTime.Now:yyyy-MM-dd}.csv"
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < view_DEV.Table.Columns.Count; i++)
                {
                    sb.Append(view_DEV.Table.Columns[i].ColumnName);
                    if (i < view_DEV.Table.Columns.Count - 1)
                        sb.Append(",");
                }
                sb.AppendLine();

                foreach (DataRowView row in view_DEV)
                {
                    for (int i = 0; i < view_DEV.Table.Columns.Count; i++)
                    {
                        sb.Append(row[i]);
                        if (i < view_DEV.Table.Columns.Count - 1)
                            sb.Append(",");
                    }
                    sb.AppendLine();
                }

                File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                MessageBox.Show("Экспорт завершён", "Готово",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Add_File_DEV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.Title = "Выберите CSV файл для добавления данных";
                openFileDialog.CheckFileExists = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string selectedFilePath = openFileDialog.FileName;
                        DataTable newDataTable = dataService_DEV.LoadFromCsv_DEV(selectedFilePath);

                        int recordsToAdd = newDataTable.Rows.Count;
                        int currentRecords = table_DEV.Rows.Count;

                        DialogResult confirmResult = MessageBox.Show(
                            $"Вы хотите добавить {recordsToAdd} записей из файла:\n" +
                            $"{Path.GetFileName(selectedFilePath)}\n\n" +
                            $"Текущее количество записей: {currentRecords}\n" +
                            $"После добавления будет: {currentRecords + recordsToAdd}",
                            "Подтверждение добавления данных",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (confirmResult == DialogResult.Yes)
                        {
                            foreach (DataRow row in newDataTable.Rows)
                            {
                                table_DEV.ImportRow(row);
                            }

                            dataService_DEV.SaveToCsv_DEV(CsvPath, table_DEV);
                            view_DEV = new DataView(table_DEV);
                            dataGridViewBase_DEV.DataSource = view_DEV;
                            ConfigureDataGridViewForEditing();

                            MessageBox.Show(
                                $"Успешно добавлено {recordsToAdd} записей из файла!\n" +
                                $"Общее количество записей: {table_DEV.Rows.Count}",
                                "Успех",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при добавлении данных из файла:\n{ex.Message}",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Filter_DEV_Click(object sender, EventArgs e)
        {
            using (FormFilter_DEV filterForm = new FormFilter_DEV())
            {
                if (filterForm.ShowDialog() == DialogResult.OK)
                {
                    string filter = filterForm.ResultFilter;

                    if (!string.IsNullOrEmpty(filter))
                    {
                        view_DEV.RowFilter = filter;
                        UpdateFilterInfo();

                        MessageBox.Show($"Применен фильтр. Отображается {view_DEV.Count} записей.",
                            "Фильтр",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        view_DEV.RowFilter = "";
                        UpdateFilterInfo();

                        MessageBox.Show("Фильтр сброшен.",
                            "Фильтр",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void UpdateFilterInfo()
        {
            if (toolTip1 == null || Filter_DEV == null) return;

            try
            {
                if (!string.IsNullOrEmpty(view_DEV.RowFilter))
                {
                    toolTip1.SetToolTip(Filter_DEV, $"Фильтр активен\nОтображается {view_DEV.Count} записей");
                    Filter_DEV.BackColor = Color.LightGreen;
                }
                else
                {
                    toolTip1.SetToolTip(Filter_DEV, "Фильтр");
                    Filter_DEV.BackColor = SystemColors.Control;
                }
            }
            catch
            {
                // Игнорируем ошибки с ToolTip
            }
        }

        private void TextSearch_DEV_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxSearch_DEV.Text.Trim();

            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            text = text.Replace("'", "''");

            string searchFilter = $"TenantLastName LIKE '%{text}%' OR Note LIKE '%{text}%'";

            if (!string.IsNullOrEmpty(view_DEV.RowFilter))
            {
                view_DEV.RowFilter = $"({view_DEV.RowFilter}) AND ({searchFilter})";
            }
            else
            {
                view_DEV.RowFilter = searchFilter;
            }
        }

        private void BtnResetSearch_DEV_Click(object sender, EventArgs e)
        {
            textBoxSearch_DEV.Text = "";
            view_DEV.RowFilter = "";
            UpdateFilterInfo();

            MessageBox.Show("Поиск и фильтры сброшены.",
                "Сброс",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void buttonGraph_DEV_Click(object sender, EventArgs e)
        {
            new FormChart_DEV(table_DEV).ShowDialog();
        }

        private void buttonGuide_DEV_Click(object sender, EventArgs e)
        {
            new FormHelp_DEV().ShowDialog();
        }

        private void buttonAbout_DEV_Click(object sender, EventArgs e)
        {
            new FormAbout_DEV().ShowDialog();
        }
    }
}