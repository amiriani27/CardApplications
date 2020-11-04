namespace CardApps.WindowsApp
{
    partial class PlayOrPass
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.optPickItUp = new System.Windows.Forms.RadioButton();
            this.optPass = new System.Windows.Forms.RadioButton();
            this.optAlone = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // optPickItUp
            // 
            this.optPickItUp.Appearance = System.Windows.Forms.Appearance.Button;
            this.optPickItUp.AutoSize = true;
            this.optPickItUp.Location = new System.Drawing.Point(3, 3);
            this.optPickItUp.Name = "optPickItUp";
            this.optPickItUp.Size = new System.Drawing.Size(67, 23);
            this.optPickItUp.TabIndex = 0;
            this.optPickItUp.TabStop = true;
            this.optPickItUp.Text = "Pick It Up!";
            this.optPickItUp.UseVisualStyleBackColor = true;
            this.optPickItUp.CheckedChanged += new System.EventHandler(this.optPickItUp_CheckedChanged);
            // 
            // optPass
            // 
            this.optPass.Appearance = System.Windows.Forms.Appearance.Button;
            this.optPass.AutoSize = true;
            this.optPass.Location = new System.Drawing.Point(76, 3);
            this.optPass.Name = "optPass";
            this.optPass.Size = new System.Drawing.Size(40, 23);
            this.optPass.TabIndex = 1;
            this.optPass.TabStop = true;
            this.optPass.Text = "Pass";
            this.optPass.UseVisualStyleBackColor = true;
            this.optPass.CheckedChanged += new System.EventHandler(this.optPass_CheckedChanged);
            // 
            // optAlone
            // 
            this.optAlone.Appearance = System.Windows.Forms.Appearance.Button;
            this.optAlone.AutoSize = true;
            this.optAlone.Location = new System.Drawing.Point(122, 3);
            this.optAlone.Name = "optAlone";
            this.optAlone.Size = new System.Drawing.Size(69, 23);
            this.optAlone.TabIndex = 2;
            this.optAlone.TabStop = true;
            this.optAlone.Text = "Goin Alone";
            this.optAlone.UseVisualStyleBackColor = true;
            this.optAlone.CheckedChanged += new System.EventHandler(this.optAlone_CheckedChanged);
            // 
            // PlayOrPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.optAlone);
            this.Controls.Add(this.optPass);
            this.Controls.Add(this.optPickItUp);
            this.Name = "PlayOrPass";
            this.Size = new System.Drawing.Size(196, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton optPickItUp;
        private System.Windows.Forms.RadioButton optPass;
        private System.Windows.Forms.RadioButton optAlone;
    }
}
