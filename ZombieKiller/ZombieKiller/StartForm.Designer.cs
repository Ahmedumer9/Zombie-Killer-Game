namespace ZombieKiller
{
    partial class StartForm
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
            this.strtbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // strtbutton
            // 
            this.strtbutton.BackColor = System.Drawing.Color.Olive;
            this.strtbutton.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strtbutton.Location = new System.Drawing.Point(319, 280);
            this.strtbutton.Name = "strtbutton";
            this.strtbutton.Size = new System.Drawing.Size(155, 77);
            this.strtbutton.TabIndex = 0;
            this.strtbutton.Text = "PLAY";
            this.strtbutton.UseVisualStyleBackColor = false;
            this.strtbutton.Click += new System.EventHandler(this.strtbutton_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ZombieKiller.Properties.Resources.startmenu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(822, 450);
            this.Controls.Add(this.strtbutton);
            this.DoubleBuffered = true;
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button strtbutton;
    }
}