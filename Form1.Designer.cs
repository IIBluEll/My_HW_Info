namespace _1115_HWINFO
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            HWInfoTextBox = new TextBox();
            sensorListView = new ListView();
            Hardware = new ColumnHeader();
            Names = new ColumnHeader();
            Details = new ColumnHeader();
            Value = new ColumnHeader();
            sensorTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // HWInfoTextBox
            // 
            HWInfoTextBox.Location = new Point(0 , 0);
            HWInfoTextBox.Multiline = true;
            HWInfoTextBox.Name = "HWInfoTextBox";
            HWInfoTextBox.Size = new Size(788 , 438);
            HWInfoTextBox.TabIndex = 0;
            // 
            // sensorListView
            // 
            sensorListView.Columns.AddRange(new ColumnHeader[] { Hardware , Names , Details , Value });
            sensorListView.Dock = DockStyle.Fill;
            sensorListView.FullRowSelect = true;
            sensorListView.Location = new Point(0 , 0);
            sensorListView.Name = "sensorListView";
            sensorListView.Size = new Size(1186 , 726);
            sensorListView.TabIndex = 1;
            sensorListView.UseCompatibleStateImageBehavior = false;
            sensorListView.View = View.Details;
            // 
            // sensorTimer
            // 
            sensorTimer.Enabled = true;
            sensorTimer.Interval = 1000;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F , 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1186 , 726);
            Controls.Add(sensorListView);
            Controls.Add(HWInfoTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox HWInfoTextBox;
        private ListView sensorListView;
        private ColumnHeader Hardware;
        private ColumnHeader Names;
        private ColumnHeader Details;
        private ColumnHeader Value;
        private System.Windows.Forms.Timer sensorTimer;
    }
}
