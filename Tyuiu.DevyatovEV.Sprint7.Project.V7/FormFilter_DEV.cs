using System;
using System.Text;
using System.Windows.Forms;

namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    public partial class FormFilter_DEV : Form
    {
        public string ResultFilter { get; private set; } = "";

        public FormFilter_DEV()
        {
            InitializeComponent();

            comboBoxDebt_DEV.Items.Clear();
            comboBoxDebt_DEV.Items.Add("все");
            comboBoxDebt_DEV.Items.Add("да");
            comboBoxDebt_DEV.Items.Add("нет");
            comboBoxDebt_DEV.SelectedIndex = 0;
        }

        private void buttonApply_DEV_Click(object sender, EventArgs e)
        {
            StringBuilder filter = new StringBuilder();

            // ===== Подъезд =====
            if (!string.IsNullOrWhiteSpace(textBoxEntrance_DEV.Text))
            {
                if (!int.TryParse(textBoxEntrance_DEV.Text, out int entrance))
                {
                    MessageBox.Show("Подъезд должен быть числом", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (filter.Length > 0)
                    filter.Append(" AND ");
                filter.Append($"EntranceNumber = {entrance}");
            }

            // ===== Долг (СТРОКА - используем одинарные кавычки) =====
            if (comboBoxDebt_DEV.SelectedIndex > 0)
            {
                if (filter.Length > 0)
                    filter.Append(" AND ");

                string debtValue = comboBoxDebt_DEV.SelectedItem.ToString();

                // Для строки ОБЯЗАТЕЛЬНО одинарные кавычки
                filter.Append($"HasDebt = '{debtValue}'");
            }

            ResultFilter = filter.ToString();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonReset_DEV_Click(object sender, EventArgs e)
        {
            textBoxEntrance_DEV.Clear();
            comboBoxDebt_DEV.SelectedIndex = 0;
            ResultFilter = "";
        }

        private void buttonCancel_DEV_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}