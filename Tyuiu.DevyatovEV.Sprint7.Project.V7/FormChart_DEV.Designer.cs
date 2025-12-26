namespace Tyuiu.DevyatovEV.Sprint7.Project.V7
{
    partial class FormChart_DEV
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // FormChart_DEV
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 700);
            DoubleBuffered = true;
            MinimumSize = new Size(600, 400);
            Name = "FormChart_DEV";
            StartPosition = FormStartPosition.CenterScreen;
            Load += FormChart_DEV_Load;
            ResumeLayout(false);
        }
    }
}