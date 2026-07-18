namespace ZombieKiller
{
    partial class EndForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EndForm));
            this.btnrestart = new System.Windows.Forms.Button();
            this.exitbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnrestart
            // 
            this.btnrestart.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnrestart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnrestart.BackgroundImage")));
            this.btnrestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnrestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrestart.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnrestart.Location = new System.Drawing.Point(113, 318);
            this.btnrestart.Name = "btnrestart";
            this.btnrestart.Size = new System.Drawing.Size(176, 81);
            this.btnrestart.TabIndex = 0;
            this.btnrestart.Text = "PLAY AGAIN";
            this.btnrestart.UseVisualStyleBackColor = false;
            this.btnrestart.Click += new System.EventHandler(this.btnrestart_Click);
            // 
            // exitbutton
            // 
            this.exitbutton.BackColor = System.Drawing.Color.Red;
            this.exitbutton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitbutton.BackgroundImage")));
            this.exitbutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.exitbutton.Location = new System.Drawing.Point(521, 318);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(176, 81);
            this.exitbutton.TabIndex = 1;
            this.exitbutton.Text = "EXIT";
            this.exitbutton.UseVisualStyleBackColor = false;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // EndForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitbutton);
            this.Controls.Add(this.btnrestart);
            this.Name = "EndForm";
            this.Text = "EndForm";
            this.Load += new System.EventHandler(this.EndForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnrestart;
        private System.Windows.Forms.Button exitbutton;
    }
}