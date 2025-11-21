namespace MyHwInfo.HWMonitor
{
    partial class HardwareMonitor_view
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            hardwareListView = new ListView();
            Sensor = new ColumnHeader();
            Value = new ColumnHeader();
            Min = new ColumnHeader();
            Max = new ColumnHeader();
            SuspendLayout();
            // 
            // hardwareListView
            // 
            hardwareListView.BackColor = SystemColors.Menu;
            hardwareListView.BackgroundImageTiled = true;
            hardwareListView.Columns.AddRange(new ColumnHeader[] { Sensor , Value , Min , Max });
            hardwareListView.Dock = DockStyle.Fill;
            hardwareListView.Font = new Font("D2Coding" , 9.75F , FontStyle.Regular , GraphicsUnit.Point , 129);
            hardwareListView.FullRowSelect = true;
            hardwareListView.GridLines = true;
            hardwareListView.Location = new Point(0 , 0);
            hardwareListView.MultiSelect = false;
            hardwareListView.Name = "hardwareListView";
            hardwareListView.Size = new Size(634 , 582);
            hardwareListView.TabIndex = 0;
            hardwareListView.UseCompatibleStateImageBehavior = false;
            hardwareListView.View = View.Details;
            // 
            // Sensor
            // 
            Sensor.Text = "Sensor";
            Sensor.Width = 300;
            // 
            // Value
            // 
            Value.Text = "Value";
            Value.Width = 120;
            // 
            // Min
            // 
            Min.Text = "Min";
            Min.Width = 100;
            // 
            // Max
            // 
            Max.Text = "Max";
            Max.Width = 100;
            // 
            // HardwareInfo_view
            // 
            AutoScaleDimensions = new SizeF(7F , 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634 , 582);
            Controls.Add(hardwareListView);
            Name = "HardwareInfo_view";
            Text = "HardwareInfo_view";
            ResumeLayout(false);
        }

        #endregion

        private ListView hardwareListView;
        private ColumnHeader Sensor;
        private ColumnHeader Value;
        private ColumnHeader Min;
        private ColumnHeader Max;
    }
}