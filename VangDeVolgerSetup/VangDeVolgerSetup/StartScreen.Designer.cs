﻿namespace VangDeVolgerSetup
{
    partial class StartScreen
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
            this.easy = new System.Windows.Forms.Label();
            this.crazy = new System.Windows.Forms.Label();
            this.VangDeVolgerLbl = new System.Windows.Forms.Label();
            this.hard = new System.Windows.Forms.Label();
            this.changeEasyMap = new System.Windows.Forms.Button();
            this.changeHardMap = new System.Windows.Forms.Button();
            this.changeCrazyMap = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // easy
            // 
            this.easy.AutoSize = true;
            this.easy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.easy.Location = new System.Drawing.Point(358, 188);
            this.easy.Name = "easy";
            this.easy.Size = new System.Drawing.Size(58, 25);
            this.easy.TabIndex = 1;
            this.easy.Tag = "";
            this.easy.Text = "easy";
            this.easy.Click += new System.EventHandler(this.easy_Click);
            this.easy.MouseEnter += new System.EventHandler(this.easy_MouseEnter);
            this.easy.MouseLeave += new System.EventHandler(this.easy_MouseLeave);
            // 
            // crazy
            // 
            this.crazy.AutoSize = true;
            this.crazy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.crazy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.crazy.Location = new System.Drawing.Point(358, 265);
            this.crazy.Name = "crazy";
            this.crazy.Size = new System.Drawing.Size(64, 25);
            this.crazy.TabIndex = 5;
            this.crazy.Tag = "";
            this.crazy.Text = "crazy";
            this.crazy.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.crazy.Click += new System.EventHandler(this.crazy_Click);
            this.crazy.MouseEnter += new System.EventHandler(this.crazy_MouseEnter);
            this.crazy.MouseLeave += new System.EventHandler(this.crazy_MouseLeave);
            // 
            // VangDeVolgerLbl
            // 
            this.VangDeVolgerLbl.AutoSize = true;
            this.VangDeVolgerLbl.BackColor = System.Drawing.Color.Transparent;
            this.VangDeVolgerLbl.Font = new System.Drawing.Font("Mistral", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VangDeVolgerLbl.ForeColor = System.Drawing.Color.Snow;
            this.VangDeVolgerLbl.Location = new System.Drawing.Point(236, 67);
            this.VangDeVolgerLbl.Name = "VangDeVolgerLbl";
            this.VangDeVolgerLbl.Size = new System.Drawing.Size(327, 76);
            this.VangDeVolgerLbl.TabIndex = 6;
            this.VangDeVolgerLbl.Tag = "";
            this.VangDeVolgerLbl.Text = "Vang de Volger";
            // 
            // hard
            // 
            this.hard.AutoSize = true;
            this.hard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.hard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.hard.Location = new System.Drawing.Point(357, 226);
            this.hard.Name = "hard";
            this.hard.Size = new System.Drawing.Size(55, 25);
            this.hard.TabIndex = 7;
            this.hard.Tag = "";
            this.hard.Text = "hard";
            this.hard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hard.Click += new System.EventHandler(this.hard_Click);
            this.hard.MouseEnter += new System.EventHandler(this.hard_MouseEnter);
            this.hard.MouseLeave += new System.EventHandler(this.hard_MouseLeave);
            // 
            // changeEasyMap
            // 
            this.changeEasyMap.ForeColor = System.Drawing.Color.White;
            this.changeEasyMap.Location = new System.Drawing.Point(522, 188);
            this.changeEasyMap.Name = "changeEasyMap";
            this.changeEasyMap.Size = new System.Drawing.Size(75, 23);
            this.changeEasyMap.TabIndex = 8;
            this.changeEasyMap.Text = "change map";
            this.changeEasyMap.UseVisualStyleBackColor = true;
            this.changeEasyMap.Click += new System.EventHandler(this.changeEasyMap_Click);
            // 
            // changeHardMap
            // 
            this.changeHardMap.ForeColor = System.Drawing.Color.White;
            this.changeHardMap.Location = new System.Drawing.Point(522, 230);
            this.changeHardMap.Name = "changeHardMap";
            this.changeHardMap.Size = new System.Drawing.Size(75, 23);
            this.changeHardMap.TabIndex = 9;
            this.changeHardMap.Text = "change map";
            this.changeHardMap.UseVisualStyleBackColor = true;
            this.changeHardMap.Click += new System.EventHandler(this.changeHardMap_Click);
            // 
            // changeCrazyMap
            // 
            this.changeCrazyMap.ForeColor = System.Drawing.Color.White;
            this.changeCrazyMap.Location = new System.Drawing.Point(522, 269);
            this.changeCrazyMap.Name = "changeCrazyMap";
            this.changeCrazyMap.Size = new System.Drawing.Size(75, 23);
            this.changeCrazyMap.TabIndex = 10;
            this.changeCrazyMap.Text = "change map";
            this.changeCrazyMap.UseVisualStyleBackColor = true;
            this.changeCrazyMap.Click += new System.EventHandler(this.changeCrazyMap_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.changeCrazyMap);
            this.Controls.Add(this.changeHardMap);
            this.Controls.Add(this.changeEasyMap);
            this.Controls.Add(this.hard);
            this.Controls.Add(this.VangDeVolgerLbl);
            this.Controls.Add(this.crazy);
            this.Controls.Add(this.easy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StartScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label easy;
        private System.Windows.Forms.Label crazy;
        private System.Windows.Forms.Label VangDeVolgerLbl;
        private System.Windows.Forms.Label hard;
        private System.Windows.Forms.Button changeEasyMap;
        private System.Windows.Forms.Button changeHardMap;
        private System.Windows.Forms.Button changeCrazyMap;
    }
}

