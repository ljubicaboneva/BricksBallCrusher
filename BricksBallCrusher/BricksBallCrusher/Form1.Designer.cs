namespace BricksBallCrusher
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblLives = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.lblMore = new System.Windows.Forms.Label();
            this.lblTwo = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.lblSuprise = new System.Windows.Forms.Label();
            this.progrssBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Curlz MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lives:";
            // 
            // lblLives
            // 
            this.lblLives.AutoSize = true;
            this.lblLives.Font = new System.Drawing.Font("Curlz MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLives.Location = new System.Drawing.Point(110, 9);
            this.lblLives.Name = "lblLives";
            this.lblLives.Size = new System.Drawing.Size(0, 32);
            this.lblLives.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Curlz MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(183, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Points:";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Font = new System.Drawing.Font("Curlz MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoints.Location = new System.Drawing.Point(282, 10);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(0, 32);
            this.lblPoints.TabIndex = 3;
            // 
            // lblMore
            // 
            this.lblMore.AutoSize = true;
            this.lblMore.Font = new System.Drawing.Font("Curlz MT", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblMore.Location = new System.Drawing.Point(740, 15);
            this.lblMore.Name = "lblMore";
            this.lblMore.Size = new System.Drawing.Size(70, 27);
            this.lblMore.TabIndex = 7;
            this.lblMore.Text = "MORE";
            this.lblMore.Click += new System.EventHandler(this.lblMore_Click);
            // 
            // lblTwo
            // 
            this.lblTwo.AutoSize = true;
            this.lblTwo.Font = new System.Drawing.Font("Curlz MT", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTwo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblTwo.Location = new System.Drawing.Point(677, 15);
            this.lblTwo.Name = "lblTwo";
            this.lblTwo.Size = new System.Drawing.Size(57, 27);
            this.lblTwo.TabIndex = 5;
            this.lblTwo.Text = "TWO";
            this.lblTwo.Click += new System.EventHandler(this.lblTwo_Click);
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Curlz MT", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.ForeColor = System.Drawing.Color.Aqua;
            this.lblMenu.Location = new System.Drawing.Point(369, 15);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(72, 27);
            this.lblMenu.TabIndex = 8;
            this.lblMenu.Text = "MENU";
            this.lblMenu.Click += new System.EventHandler(this.lblMenu_Click);
            // 
            // lblSuprise
            // 
            this.lblSuprise.AutoSize = true;
            this.lblSuprise.Font = new System.Drawing.Font("Curlz MT", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuprise.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSuprise.Location = new System.Drawing.Point(447, 15);
            this.lblSuprise.Name = "lblSuprise";
            this.lblSuprise.Size = new System.Drawing.Size(91, 27);
            this.lblSuprise.TabIndex = 9;
            this.lblSuprise.Text = "SUPRISE";
            this.lblSuprise.Click += new System.EventHandler(this.lblSuprise_Click);
            // 
            // progrssBar
            // 
            this.progrssBar.Location = new System.Drawing.Point(268, 465);
            this.progrssBar.Name = "progrssBar";
            this.progrssBar.Size = new System.Drawing.Size(326, 10);
            this.progrssBar.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(837, 487);
            this.Controls.Add(this.progrssBar);
            this.Controls.Add(this.lblSuprise);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.lblMore);
            this.Controls.Add(this.lblTwo);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLives);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLives;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblMore;
        private System.Windows.Forms.Label lblTwo;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Label lblSuprise;
        private System.Windows.Forms.ProgressBar progrssBar;
        private System.Windows.Forms.Timer timer1;
    }
}
