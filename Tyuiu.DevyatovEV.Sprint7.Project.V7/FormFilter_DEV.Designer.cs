namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    partial class FormFilter_DEV
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxEntrance_DEV;
        private System.Windows.Forms.ComboBox comboBoxDebt_DEV;
        private System.Windows.Forms.Button buttonApply_DEV;
        private System.Windows.Forms.Button buttonReset_DEV;
        private System.Windows.Forms.Button buttonCancel_DEV;
        private System.Windows.Forms.Label labelEntrance_DEV;
        private System.Windows.Forms.Label labelDebt_DEV;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            textBoxEntrance_DEV = new System.Windows.Forms.TextBox();
            comboBoxDebt_DEV = new System.Windows.Forms.ComboBox();
            buttonApply_DEV = new System.Windows.Forms.Button();
            buttonReset_DEV = new System.Windows.Forms.Button();
            buttonCancel_DEV = new System.Windows.Forms.Button();
            labelEntrance_DEV = new System.Windows.Forms.Label();
            labelDebt_DEV = new System.Windows.Forms.Label();

            SuspendLayout();

            // labelEntrance_DEV
            labelEntrance_DEV.AutoSize = true;
            labelEntrance_DEV.Location = new System.Drawing.Point(20, 20);
            labelEntrance_DEV.Name = "labelEntrance_DEV";
            labelEntrance_DEV.Size = new System.Drawing.Size(95, 15);
            labelEntrance_DEV.TabIndex = 0;
            labelEntrance_DEV.Text = "Номер подъезда:";

            // textBoxEntrance_DEV
            textBoxEntrance_DEV.Location = new System.Drawing.Point(125, 17);
            textBoxEntrance_DEV.Name = "textBoxEntrance_DEV";
            textBoxEntrance_DEV.Size = new System.Drawing.Size(150, 23);
            textBoxEntrance_DEV.TabIndex = 1;

            // labelDebt_DEV
            labelDebt_DEV.AutoSize = true;
            labelDebt_DEV.Location = new System.Drawing.Point(20, 60);
            labelDebt_DEV.Name = "labelDebt_DEV";
            labelDebt_DEV.Size = new System.Drawing.Size(94, 15);
            labelDebt_DEV.TabIndex = 2;
            labelDebt_DEV.Text = "Наличие долга:";

            // comboBoxDebt_DEV
            comboBoxDebt_DEV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxDebt_DEV.FormattingEnabled = true;
            comboBoxDebt_DEV.Location = new System.Drawing.Point(125, 57);
            comboBoxDebt_DEV.Name = "comboBoxDebt_DEV";
            comboBoxDebt_DEV.Size = new System.Drawing.Size(150, 23);
            comboBoxDebt_DEV.TabIndex = 3;

            // buttonApply_DEV
            buttonApply_DEV.Location = new System.Drawing.Point(20, 100);
            buttonApply_DEV.Name = "buttonApply_DEV";
            buttonApply_DEV.Size = new System.Drawing.Size(80, 35);
            buttonApply_DEV.TabIndex = 4;
            buttonApply_DEV.Text = "Применить";
            buttonApply_DEV.UseVisualStyleBackColor = true;
            buttonApply_DEV.Click += new System.EventHandler(this.buttonApply_DEV_Click);

            // buttonReset_DEV
            buttonReset_DEV.Location = new System.Drawing.Point(110, 100);
            buttonReset_DEV.Name = "buttonReset_DEV";
            buttonReset_DEV.Size = new System.Drawing.Size(80, 35);
            buttonReset_DEV.TabIndex = 5;
            buttonReset_DEV.Text = "Сбросить";
            buttonReset_DEV.UseVisualStyleBackColor = true;
            buttonReset_DEV.Click += new System.EventHandler(this.buttonReset_DEV_Click);

            // buttonCancel_DEV
            buttonCancel_DEV.Location = new System.Drawing.Point(200, 100);
            buttonCancel_DEV.Name = "buttonCancel_DEV";
            buttonCancel_DEV.Size = new System.Drawing.Size(80, 35);
            buttonCancel_DEV.TabIndex = 6;
            buttonCancel_DEV.Text = "Отмена";
            buttonCancel_DEV.UseVisualStyleBackColor = true;
            buttonCancel_DEV.Click += new System.EventHandler(this.buttonCancel_DEV_Click);

            // FormFilter_DEV
            ClientSize = new System.Drawing.Size(300, 150);
            Controls.Add(buttonCancel_DEV);
            Controls.Add(buttonReset_DEV);
            Controls.Add(buttonApply_DEV);
            Controls.Add(comboBoxDebt_DEV);
            Controls.Add(labelDebt_DEV);
            Controls.Add(textBoxEntrance_DEV);
            Controls.Add(labelEntrance_DEV);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormFilter_DEV";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Фильтр данных";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}