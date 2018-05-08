namespace VangDeVolgerSetup
{
    partial class Game
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
            this.pbGameBoard = new System.Windows.Forms.PictureBox();
            this.lblHighScore = new System.Windows.Forms.Label();
            this.boxAllHighScores = new System.Windows.Forms.RichTextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.pbHighScoreBackground = new System.Windows.Forms.PictureBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblNewGame = new System.Windows.Forms.Label();
            this.pause = new System.Windows.Forms.Label();
            this.lblMapName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHighScoreBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGameBoard
            // 
            this.pbGameBoard.Location = new System.Drawing.Point(0, 128);
            this.pbGameBoard.Name = "pbGameBoard";
            this.pbGameBoard.Size = new System.Drawing.Size(480, 480);
            this.pbGameBoard.TabIndex = 0;
            this.pbGameBoard.TabStop = false;
            // 
            // lblHighScore
            // 
            this.lblHighScore.AutoSize = true;
            this.lblHighScore.Font = new System.Drawing.Font("Mistral", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScore.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHighScore.Location = new System.Drawing.Point(196, 70);
            this.lblHighScore.Name = "lblHighScore";
            this.lblHighScore.Size = new System.Drawing.Size(106, 38);
            this.lblHighScore.TabIndex = 1;
            this.lblHighScore.Text = "highscore";
            // 
            // boxAllHighScores
            // 
            this.boxAllHighScores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.boxAllHighScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.boxAllHighScores.ForeColor = System.Drawing.Color.White;
            this.boxAllHighScores.Location = new System.Drawing.Point(54, 156);
            this.boxAllHighScores.Name = "boxAllHighScores";
            this.boxAllHighScores.ReadOnly = true;
            this.boxAllHighScores.Size = new System.Drawing.Size(385, 396);
            this.boxAllHighScores.TabIndex = 13;
            this.boxAllHighScores.Text = "";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(95)))));
            this.lblName.Font = new System.Drawing.Font("Mistral", 18F);
            this.lblName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblName.Location = new System.Drawing.Point(198, 178);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(102, 29);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "enter name:";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(203, 219);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(99, 20);
            this.txtBoxName.TabIndex = 4;
            // 
            // pbHighScoreBackground
            // 
            this.pbHighScoreBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(95)))));
            this.pbHighScoreBackground.Location = new System.Drawing.Point(28, 141);
            this.pbHighScoreBackground.Name = "pbHighScoreBackground";
            this.pbHighScoreBackground.Size = new System.Drawing.Size(431, 455);
            this.pbHighScoreBackground.TabIndex = 5;
            this.pbHighScoreBackground.TabStop = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Mistral", 14F);
            this.btnSubmit.ForeColor = System.Drawing.Color.White;
            this.btnSubmit.Location = new System.Drawing.Point(203, 257);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(99, 27);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblNewGame
            // 
            this.lblNewGame.AutoSize = true;
            this.lblNewGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.lblNewGame.Location = new System.Drawing.Point(12, 9);
            this.lblNewGame.Name = "lblNewGame";
            this.lblNewGame.Size = new System.Drawing.Size(133, 13);
            this.lblNewGame.TabIndex = 14;
            this.lblNewGame.Text = "press \'F12\' for a new game";
            // 
            // pause
            // 
            this.pause.AutoSize = true;
            this.pause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.pause.Location = new System.Drawing.Point(12, 35);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(137, 13);
            this.pause.TabIndex = 15;
            this.pause.Text = "press \'P\' to pause the game";
            // 
            // lblMapName
            // 
            this.lblMapName.AutoSize = true;
            this.lblMapName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.lblMapName.Location = new System.Drawing.Point(12, 60);
            this.lblMapName.Name = "lblMapName";
            this.lblMapName.Size = new System.Drawing.Size(63, 13);
            this.lblMapName.TabIndex = 16;
            this.lblMapName.Text = "Map niveau";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(480, 608);
            this.Controls.Add(this.lblMapName);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.lblNewGame);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.boxAllHighScores);
            this.Controls.Add(this.lblHighScore);
            this.Controls.Add(this.pbHighScoreBackground);
            this.Controls.Add(this.pbGameBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbGameBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHighScoreBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGameBoard;
        private System.Windows.Forms.Label lblHighScore;
        public System.Windows.Forms.RichTextBox boxAllHighScores;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.PictureBox pbHighScoreBackground;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblNewGame;
        private System.Windows.Forms.Label pause;
        private System.Windows.Forms.Label lblMapName;
    }
}