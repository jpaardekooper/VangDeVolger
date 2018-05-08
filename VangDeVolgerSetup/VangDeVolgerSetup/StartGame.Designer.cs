namespace VangDeVolgerSetup
{
    partial class StartGame
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
            this.btnPlay = new System.Windows.Forms.Button();
            this.VangDeVolgerLbl = new System.Windows.Forms.Label();
            this.easy = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Font = new System.Drawing.Font("Mistral", 15F);
            this.btnPlay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.btnPlay.Location = new System.Drawing.Point(461, 162);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(55, 30);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.BtnPlayEasy_Click);
            // 
            // VangDeVolgerLbl
            // 
            this.VangDeVolgerLbl.AutoSize = true;
            this.VangDeVolgerLbl.BackColor = System.Drawing.Color.Transparent;
            this.VangDeVolgerLbl.Font = new System.Drawing.Font("Mistral", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VangDeVolgerLbl.ForeColor = System.Drawing.Color.Snow;
            this.VangDeVolgerLbl.Location = new System.Drawing.Point(246, 39);
            this.VangDeVolgerLbl.Name = "VangDeVolgerLbl";
            this.VangDeVolgerLbl.Size = new System.Drawing.Size(327, 76);
            this.VangDeVolgerLbl.TabIndex = 7;
            this.VangDeVolgerLbl.Tag = "";
            this.VangDeVolgerLbl.Text = "Vang de Volger";
            // 
            // easy
            // 
            this.easy.AutoSize = true;
            this.easy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.easy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.easy.Location = new System.Drawing.Point(357, 162);
            this.easy.Name = "easy";
            this.easy.Size = new System.Drawing.Size(58, 25);
            this.easy.TabIndex = 8;
            this.easy.Tag = "";
            this.easy.Text = "easy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.label1.Location = new System.Drawing.Point(357, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 9;
            this.label1.Tag = "";
            this.label1.Text = "medium";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.label2.Location = new System.Drawing.Point(357, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 25);
            this.label2.TabIndex = 10;
            this.label2.Tag = "";
            this.label2.Text = "hard";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Mistral", 15F);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.button1.Location = new System.Drawing.Point(461, 229);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 30);
            this.button1.TabIndex = 11;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BtnPlayMedium_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Mistral", 15F);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.button2.Location = new System.Drawing.Point(461, 297);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(55, 30);
            this.button2.TabIndex = 12;
            this.button2.Text = "Play";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.BtnPlayHard_Click);
            // 
            // StartGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.easy);
            this.Controls.Add(this.VangDeVolgerLbl);
            this.Controls.Add(this.btnPlay);
            this.Name = "StartGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label VangDeVolgerLbl;
        private System.Windows.Forms.Label easy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

