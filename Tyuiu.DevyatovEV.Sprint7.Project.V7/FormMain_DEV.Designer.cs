namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    partial class FormMain_DEV
    {
        private MenuStrip menuStripMain_DEV;
        private DataGridView dataGridViewBase_DEV;
        private Panel panelSearch_DEV;
        private Label labelSearch_DEV;
        private TextBox textBoxSearch_DEV;
        private Button btnResetSearch_DEV;


        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Button Add_DEV;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain_DEV));
            Button Delete_DEV;
            Button Graph_DEV;
            Button About_DEV;
            Button Guide_DEV;
            Button Statistics_DEV;
            Button Export_DEV;
            menuStripMain_DEV = new MenuStrip();
            dataGridViewBase_DEV = new DataGridView();
            panelSearch_DEV = new Panel();
            labelSearch_DEV = new Label();
            textBoxSearch_DEV = new TextBox();
            btnResetSearch_DEV = new Button();
            toolTip1 = new ToolTip(components);
            Add_DEV = new Button();
            Delete_DEV = new Button();
            Graph_DEV = new Button();
            About_DEV = new Button();
            Guide_DEV = new Button();
            Statistics_DEV = new Button();
            Export_DEV = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBase_DEV).BeginInit();
            panelSearch_DEV.SuspendLayout();
            SuspendLayout();
            // 
            // Add_DEV
            // 
            Add_DEV.BackgroundImage = (Image)resources.GetObject("Add_DEV.BackgroundImage");
            Add_DEV.BackgroundImageLayout = ImageLayout.Center;
            Add_DEV.ForeColor = SystemColors.ActiveCaption;
            Add_DEV.Location = new Point(9, 8);
            Add_DEV.Name = "Add_DEV";
            Add_DEV.Size = new Size(60, 60);
            Add_DEV.TabIndex = 3;
            toolTip1.SetToolTip(Add_DEV, "Добавить");
            Add_DEV.UseVisualStyleBackColor = true;
            Add_DEV.Click += buttonAdd_DEV_Click;
            // 
            // Delete_DEV
            // 
            Delete_DEV.BackgroundImage = (Image)resources.GetObject("Delete_DEV.BackgroundImage");
            Delete_DEV.BackgroundImageLayout = ImageLayout.Center;
            Delete_DEV.ForeColor = SystemColors.ActiveCaption;
            Delete_DEV.Location = new Point(73, 8);
            Delete_DEV.Name = "Delete_DEV";
            Delete_DEV.Size = new Size(60, 60);
            Delete_DEV.TabIndex = 4;
            toolTip1.SetToolTip(Delete_DEV, "Удалить");
            Delete_DEV.UseVisualStyleBackColor = true;
            Delete_DEV.Click += buttonDelete_DEV_Click;
            // 
            // Graph_DEV
            // 
            Graph_DEV.BackgroundImage = (Image)resources.GetObject("Graph_DEV.BackgroundImage");
            Graph_DEV.BackgroundImageLayout = ImageLayout.Center;
            Graph_DEV.ForeColor = SystemColors.ActiveCaption;
            Graph_DEV.Location = new Point(139, 8);
            Graph_DEV.Name = "Graph_DEV";
            Graph_DEV.Size = new Size(60, 60);
            Graph_DEV.TabIndex = 5;
            toolTip1.SetToolTip(Graph_DEV, "Вывести граф");
            Graph_DEV.UseVisualStyleBackColor = true;
            Graph_DEV.Click += buttonGraph_DEV_Click;
            // 
            // About_DEV
            // 
            About_DEV.BackgroundImage = (Image)resources.GetObject("About_DEV.BackgroundImage");
            About_DEV.BackgroundImageLayout = ImageLayout.Center;
            About_DEV.ForeColor = SystemColors.ActiveCaption;
            About_DEV.Location = new Point(205, 8);
            About_DEV.Name = "About_DEV";
            About_DEV.Size = new Size(60, 60);
            About_DEV.TabIndex = 6;
            toolTip1.SetToolTip(About_DEV, "О программе");
            About_DEV.UseVisualStyleBackColor = true;
            About_DEV.Click += buttonAbout_DEV_Click;
            // 
            // Guide_DEV
            // 
            Guide_DEV.BackgroundImage = (Image)resources.GetObject("Guide_DEV.BackgroundImage");
            Guide_DEV.BackgroundImageLayout = ImageLayout.Center;
            Guide_DEV.ForeColor = SystemColors.ActiveCaption;
            Guide_DEV.Location = new Point(271, 8);
            Guide_DEV.Name = "Guide_DEV";
            Guide_DEV.Size = new Size(60, 60);
            Guide_DEV.TabIndex = 7;
            toolTip1.SetToolTip(Guide_DEV, "Руководство пользователя");
            Guide_DEV.UseVisualStyleBackColor = true;
            Guide_DEV.Click += buttonGuide_DEV_Click;
            // 
            // Statistics_DEV
            // 
            Statistics_DEV.BackgroundImage = (Image)resources.GetObject("Statistics_DEV.BackgroundImage");
            Statistics_DEV.BackgroundImageLayout = ImageLayout.Center;
            Statistics_DEV.ForeColor = SystemColors.ActiveCaption;
            Statistics_DEV.Location = new Point(337, 8);
            Statistics_DEV.Name = "Statistics_DEV";
            Statistics_DEV.Size = new Size(60, 60);
            Statistics_DEV.TabIndex = 8;
            toolTip1.SetToolTip(Statistics_DEV, "Статистика");
            Statistics_DEV.UseVisualStyleBackColor = true;
            Statistics_DEV.Click += Statistics_DEV_Click;
            // 
            // Export_DEV
            // 
            Export_DEV.BackgroundImage = (Image)resources.GetObject("Export_DEV.BackgroundImage");
            Export_DEV.BackgroundImageLayout = ImageLayout.Center;
            Export_DEV.ForeColor = SystemColors.ActiveCaption;
            Export_DEV.Location = new Point(403, 8);
            Export_DEV.Name = "Export_DEV";
            Export_DEV.Size = new Size(60, 60);
            Export_DEV.TabIndex = 9;
            toolTip1.SetToolTip(Export_DEV, "Экспорт");
            Export_DEV.UseVisualStyleBackColor = true;
            Export_DEV.Click += Export_DEV_Click;
            // 
            // menuStripMain_DEV
            // 
            menuStripMain_DEV.ImageScalingSize = new Size(20, 20);
            menuStripMain_DEV.Location = new Point(0, 0);
            menuStripMain_DEV.Name = "menuStripMain_DEV";
            menuStripMain_DEV.Size = new Size(1024, 24);
            menuStripMain_DEV.TabIndex = 2;
            menuStripMain_DEV.ItemClicked += menuStripMain_DEV_ItemClicked;
            // 
            // dataGridViewBase_DEV
            // 
            dataGridViewBase_DEV.AllowUserToAddRows = false;
            dataGridViewBase_DEV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBase_DEV.ColumnHeadersHeight = 29;
            dataGridViewBase_DEV.Dock = DockStyle.Fill;
            dataGridViewBase_DEV.Location = new Point(0, 103);
            dataGridViewBase_DEV.Name = "dataGridViewBase_DEV";
            dataGridViewBase_DEV.ReadOnly = true;
            dataGridViewBase_DEV.RowHeadersWidth = 51;
            dataGridViewBase_DEV.Size = new Size(1024, 487);
            dataGridViewBase_DEV.TabIndex = 0;
            // 
            // panelSearch_DEV
            // 
            panelSearch_DEV.BackColor = Color.FromArgb(240, 240, 255);
            panelSearch_DEV.Controls.Add(Export_DEV);
            panelSearch_DEV.Controls.Add(Statistics_DEV);
            panelSearch_DEV.Controls.Add(Guide_DEV);
            panelSearch_DEV.Controls.Add(About_DEV);
            panelSearch_DEV.Controls.Add(Graph_DEV);
            panelSearch_DEV.Controls.Add(Delete_DEV);
            panelSearch_DEV.Controls.Add(Add_DEV);
            panelSearch_DEV.Controls.Add(labelSearch_DEV);
            panelSearch_DEV.Controls.Add(textBoxSearch_DEV);
            panelSearch_DEV.Controls.Add(btnResetSearch_DEV);
            panelSearch_DEV.Dock = DockStyle.Top;
            panelSearch_DEV.Location = new Point(0, 24);
            panelSearch_DEV.Name = "panelSearch_DEV";
            panelSearch_DEV.Size = new Size(1024, 79);
            panelSearch_DEV.TabIndex = 1;
            panelSearch_DEV.Paint += panelSearch_DEV_Paint;
            // 
            // labelSearch_DEV
            // 
            labelSearch_DEV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelSearch_DEV.AutoSize = true;
            labelSearch_DEV.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelSearch_DEV.Location = new Point(567, 34);
            labelSearch_DEV.Name = "labelSearch_DEV";
            labelSearch_DEV.Size = new Size(57, 19);
            labelSearch_DEV.TabIndex = 0;
            labelSearch_DEV.Text = "Поиск:";
            labelSearch_DEV.Click += labelSearch_DEV_Click;
            // 
            // textBoxSearch_DEV
            // 
            textBoxSearch_DEV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxSearch_DEV.Location = new Point(630, 31);
            textBoxSearch_DEV.Name = "textBoxSearch_DEV";
            textBoxSearch_DEV.Size = new Size(300, 23);
            textBoxSearch_DEV.TabIndex = 1;
            textBoxSearch_DEV.TextChanged += TextSearch_DEV_TextChanged;
            // 
            // btnResetSearch_DEV
            // 
            btnResetSearch_DEV.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnResetSearch_DEV.Location = new Point(936, 32);
            btnResetSearch_DEV.Name = "btnResetSearch_DEV";
            btnResetSearch_DEV.Size = new Size(75, 23);
            btnResetSearch_DEV.TabIndex = 2;
            btnResetSearch_DEV.Text = "Сбросить";
            btnResetSearch_DEV.Click += BtnResetSearch_DEV_Click;
            // 
            // FormMain_DEV
            // 
            ClientSize = new Size(1024, 590);
            Controls.Add(dataGridViewBase_DEV);
            Controls.Add(panelSearch_DEV);
            Controls.Add(menuStripMain_DEV);
            Name = "FormMain_DEV";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Домоуправление | Девятов Егор Владимирович | Истнб-25-1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewBase_DEV).EndInit();
            panelSearch_DEV.ResumeLayout(false);
            panelSearch_DEV.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private ToolTip toolTip1;
        private System.ComponentModel.IContainer components;
    }
}