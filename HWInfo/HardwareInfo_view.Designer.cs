namespace MyHwInfo.HWInfo
{
    partial class HardwareInfo_view
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
            cpu = new Label();
            cpuNameLabel = new Label();
            label1 = new Label();
            cpuCoreLabel = new Label();
            gpuVramLabel = new Label();
            label3 = new Label();
            gpuNameLabel = new Label();
            gpu = new Label();
            SuspendLayout();
            // 
            // cpu
            // 
            cpu.AutoSize = true;
            cpu.Enabled = false;
            cpu.Location = new Point(12 , 9);
            cpu.Name = "cpu";
            cpu.Size = new Size(73 , 15);
            cpu.TabIndex = 0;
            cpu.Text = "CPU Name :";
            // 
            // cpuNameLabel
            // 
            cpuNameLabel.AutoSize = true;
            cpuNameLabel.Location = new Point(91 , 9);
            cpuNameLabel.Name = "cpuNameLabel";
            cpuNameLabel.Size = new Size(39 , 15);
            cpuNameLabel.TabIndex = 1;
            cpuNameLabel.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Enabled = false;
            label1.Location = new Point(12 , 37);
            label1.Name = "label1";
            label1.Size = new Size(74 , 15);
            label1.TabIndex = 2;
            label1.Text = "CPU Core   :";
            // 
            // cpuCoreLabel
            // 
            cpuCoreLabel.AutoSize = true;
            cpuCoreLabel.Location = new Point(92 , 37);
            cpuCoreLabel.Name = "cpuCoreLabel";
            cpuCoreLabel.Size = new Size(39 , 15);
            cpuCoreLabel.TabIndex = 3;
            cpuCoreLabel.Text = "label1";
            // 
            // gpuVramLabel
            // 
            gpuVramLabel.AutoSize = true;
            gpuVramLabel.Location = new Point(93 , 98);
            gpuVramLabel.Name = "gpuVramLabel";
            gpuVramLabel.Size = new Size(39 , 15);
            gpuVramLabel.TabIndex = 7;
            gpuVramLabel.Text = "label1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Enabled = false;
            label3.Location = new Point(13 , 98);
            label3.Name = "label3";
            label3.Size = new Size(73 , 15);
            label3.TabIndex = 6;
            label3.Text = "GPU VRam :";
            // 
            // gpuNameLabel
            // 
            gpuNameLabel.AutoSize = true;
            gpuNameLabel.Location = new Point(92 , 70);
            gpuNameLabel.Name = "gpuNameLabel";
            gpuNameLabel.Size = new Size(39 , 15);
            gpuNameLabel.TabIndex = 5;
            gpuNameLabel.Text = "label1";
            // 
            // gpu
            // 
            gpu.AutoSize = true;
            gpu.Enabled = false;
            gpu.Location = new Point(13 , 70);
            gpu.Name = "gpu";
            gpu.Size = new Size(73 , 15);
            gpu.TabIndex = 4;
            gpu.Text = "GPU Name :";
            // 
            // HardwareInfo_view
            // 
            AutoScaleDimensions = new SizeF(7F , 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(673 , 163);
            Controls.Add(gpuVramLabel);
            Controls.Add(label3);
            Controls.Add(gpuNameLabel);
            Controls.Add(gpu);
            Controls.Add(cpuCoreLabel);
            Controls.Add(label1);
            Controls.Add(cpuNameLabel);
            Controls.Add(cpu);
            Name = "HardwareInfo_view";
            Text = "HardwareInfo_view";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label cpu;
        private Label cpuNameLabel;
        private Label label1;
        private Label cpuCoreLabel;
        private Label gpuVramLabel;
        private Label label3;
        private Label gpuNameLabel;
        private Label gpu;
    }
}