namespace CardApps.WindowsApp
{
    partial class Form2
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
            if (disposing && (components != null))
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
            this.cmdShuffle = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdShuffle
            // 
            this.cmdShuffle.Location = new System.Drawing.Point(776, 431);
            this.cmdShuffle.Margin = new System.Windows.Forms.Padding(4);
            this.cmdShuffle.Name = "cmdShuffle";
            this.cmdShuffle.Size = new System.Drawing.Size(117, 28);
            this.cmdShuffle.TabIndex = 3;
            this.cmdShuffle.Text = "Shuffle";
            this.cmdShuffle.UseVisualStyleBackColor = true;
            this.cmdShuffle.Click += new System.EventHandler(this.cmdShuffle_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(776, 467);
            this.cmdExit.Margin = new System.Windows.Forms.Padding(4);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(117, 28);
            this.cmdExit.TabIndex = 2;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 504);
            this.Controls.Add(this.cmdShuffle);
            this.Controls.Add(this.cmdExit);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdShuffle;
        private System.Windows.Forms.Button cmdExit;
    }
}