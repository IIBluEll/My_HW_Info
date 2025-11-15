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
            HWInfoTextBox = new TextBox();
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F , 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800 , 450);
            Controls.Add(HWInfoTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox HWInfoTextBox;
    }
}
