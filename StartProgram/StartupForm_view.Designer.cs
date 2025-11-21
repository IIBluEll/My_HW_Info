namespace MyHwInfo.StartProgram
{
    partial class StartupForm_view
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
            hardwareMonitorCheckBox = new CheckBox();
            hardwareInfoCheckBox = new CheckBox();
            eventLogCheckBox = new CheckBox();
            startBtn = new Button();
            SuspendLayout();
            // 
            // hardwareMonitorCheckBox
            // 
            hardwareMonitorCheckBox.AutoSize = true;
            hardwareMonitorCheckBox.Location = new Point(31 , 12);
            hardwareMonitorCheckBox.Name = "hardwareMonitorCheckBox";
            hardwareMonitorCheckBox.Size = new Size(93 , 19);
            hardwareMonitorCheckBox.TabIndex = 0;
            hardwareMonitorCheckBox.Text = "HW Monitor";
            hardwareMonitorCheckBox.UseVisualStyleBackColor = true;
            // 
            // hardwareInfoCheckBox
            // 
            hardwareInfoCheckBox.AutoSize = true;
            hardwareInfoCheckBox.Location = new Point(31 , 37);
            hardwareInfoCheckBox.Name = "hardwareInfoCheckBox";
            hardwareInfoCheckBox.Size = new Size(71 , 19);
            hardwareInfoCheckBox.TabIndex = 1;
            hardwareInfoCheckBox.Text = "HW Info";
            hardwareInfoCheckBox.UseVisualStyleBackColor = true;
            // 
            // eventLogCheckBox
            // 
            eventLogCheckBox.AutoSize = true;
            eventLogCheckBox.Location = new Point(31 , 62);
            eventLogCheckBox.Name = "eventLogCheckBox";
            eventLogCheckBox.Size = new Size(79 , 19);
            eventLogCheckBox.TabIndex = 2;
            eventLogCheckBox.Text = "Event Log";
            eventLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // startBtn
            // 
            startBtn.Location = new Point(31 , 87);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(119 , 36);
            startBtn.TabIndex = 3;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            // 
            // StartupForm_view
            // 
            AutoScaleDimensions = new SizeF(7F , 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(228 , 154);
            Controls.Add(startBtn);
            Controls.Add(eventLogCheckBox);
            Controls.Add(hardwareInfoCheckBox);
            Controls.Add(hardwareMonitorCheckBox);
            Name = "StartupForm_view";
            Text = "Option";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox hardwareMonitorCheckBox;
        private CheckBox hardwareInfoCheckBox;
        private CheckBox eventLogCheckBox;
        private Button startBtn;
    }
}
