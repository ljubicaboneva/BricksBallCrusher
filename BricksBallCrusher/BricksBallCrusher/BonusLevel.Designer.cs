﻿namespace BricksBallCrusher
{
    partial class BonusLevel
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
            this.lbltext = new System.Windows.Forms.Label();
            this.lblPointsBonus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbltext
            // 
            this.lbltext.AutoSize = true;
            this.lbltext.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbltext.Font = new System.Drawing.Font("Curlz MT", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltext.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbltext.Location = new System.Drawing.Point(26, 13);
            this.lbltext.Name = "lbltext";
            this.lbltext.Size = new System.Drawing.Size(0, 39);
            this.lbltext.TabIndex = 0;
            // 
            // lblPointsBonus
            // 
            this.lblPointsBonus.AutoSize = true;
            this.lblPointsBonus.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPointsBonus.Font = new System.Drawing.Font("Curlz MT", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointsBonus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblPointsBonus.Location = new System.Drawing.Point(127, 13);
            this.lblPointsBonus.Name = "lblPointsBonus";
            this.lblPointsBonus.Size = new System.Drawing.Size(0, 39);
            this.lblPointsBonus.TabIndex = 1;
            // 
            // BonusLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(801, 450);
            this.Controls.Add(this.lblPointsBonus);
            this.Controls.Add(this.lbltext);
            this.Name = "BonusLevel";
            this.Text = "BonusLevel";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BonusLevel_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BonusLevel_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltext;
        private System.Windows.Forms.Label lblPointsBonus;
    }
}