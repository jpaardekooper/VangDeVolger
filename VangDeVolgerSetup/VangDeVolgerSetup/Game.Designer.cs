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
            this.components = new System.ComponentModel.Container();
            this.GameEngineTimer = new System.Windows.Forms.Timer(this.components);
            this.lblLevelName = new System.Windows.Forms.Label();
            this.lblPause = new System.Windows.Forms.Label();
            this.pause = new System.Windows.Forms.Label();
            this.resume = new System.Windows.Forms.Label();
            this.playerHealthBar = new System.Windows.Forms.ProgressBar();
            this.enemyHealthBar = new System.Windows.Forms.ProgressBar();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.lblNewGame = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.inputPlayerName = new System.Windows.Forms.TextBox();
            this.btnShowScore = new System.Windows.Forms.Button();
            this.boxAllHighScores = new System.Windows.Forms.RichTextBox();
            this.lblHighscore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameEngineTimer
            // 
            this.GameEngineTimer.Enabled = true;
            this.GameEngineTimer.Interval = 24;
            this.GameEngineTimer.Tick += new System.EventHandler(this.GameEngine);
            // 
            // lblLevelName
            // 
            this.lblLevelName.AutoSize = true;
            this.lblLevelName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(108)))));
            this.lblLevelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.lblLevelName.Location = new System.Drawing.Point(12, 9);
            this.lblLevelName.Name = "lblLevelName";
            this.lblLevelName.Size = new System.Drawing.Size(35, 13);
            this.lblLevelName.TabIndex = 0;
            this.lblLevelName.Text = "label2";
            // 
            // lblPause
            // 
            this.lblPause.AutoSize = true;
            this.lblPause.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.lblPause.Location = new System.Drawing.Point(131, 220);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(227, 57);
            this.lblPause.TabIndex = 1;
            this.lblPause.Text = "Game Paused";
            // 
            // pause
            // 
            this.pause.AutoSize = true;
            this.pause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.pause.Location = new System.Drawing.Point(12, 39);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(137, 13);
            this.pause.TabIndex = 4;
            this.pause.Text = "press \'P\' to pause the game";
            // 
            // resume
            // 
            this.resume.AutoSize = true;
            this.resume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.resume.Location = new System.Drawing.Point(12, 53);
            this.resume.Name = "resume";
            this.resume.Size = new System.Drawing.Size(143, 13);
            this.resume.TabIndex = 5;
            this.resume.Text = "press \'R\' to resume the game";
            // 
            // playerHealthBar
            // 
            this.playerHealthBar.ForeColor = System.Drawing.Color.Green;
            this.playerHealthBar.Location = new System.Drawing.Point(349, 24);
            this.playerHealthBar.Name = "playerHealthBar";
            this.playerHealthBar.Size = new System.Drawing.Size(113, 13);
            this.playerHealthBar.Step = 20;
            this.playerHealthBar.TabIndex = 6;
            this.playerHealthBar.Value = 100;
            // 
            // enemyHealthBar
            // 
            this.enemyHealthBar.ForeColor = System.Drawing.Color.Green;
            this.enemyHealthBar.Location = new System.Drawing.Point(349, 53);
            this.enemyHealthBar.Name = "enemyHealthBar";
            this.enemyHealthBar.Size = new System.Drawing.Size(113, 13);
            this.enemyHealthBar.TabIndex = 7;
            this.enemyHealthBar.Value = 100;
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.lblGameOver.Location = new System.Drawing.Point(141, 131);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(203, 57);
            this.lblGameOver.TabIndex = 8;
            this.lblGameOver.Text = "Game Over!";
            // 
            // lblNewGame
            // 
            this.lblNewGame.AutoSize = true;
            this.lblNewGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.lblNewGame.Location = new System.Drawing.Point(12, 24);
            this.lblNewGame.Name = "lblNewGame";
            this.lblNewGame.Size = new System.Drawing.Size(184, 13);
            this.lblNewGame.TabIndex = 9;
            this.lblNewGame.Text = "press \'N\' for a new game or click here";
            this.lblNewGame.Click += new System.EventHandler(this.newgame_Click);
            this.lblNewGame.MouseEnter += new System.EventHandler(this.newgame_MouseEnter);
            this.lblNewGame.MouseLeave += new System.EventHandler(this.newgame_MouseLeave);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(108)))));
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.lblScore.Location = new System.Drawing.Point(225, 24);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(13, 13);
            this.lblScore.TabIndex = 10;
            this.lblScore.Text = "0";
            // 
            // inputPlayerName
            // 
            this.inputPlayerName.Location = new System.Drawing.Point(196, 197);
            this.inputPlayerName.Name = "inputPlayerName";
            this.inputPlayerName.Size = new System.Drawing.Size(94, 20);
            this.inputPlayerName.TabIndex = 11;
            this.inputPlayerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnShowScore
            // 
            this.btnShowScore.Location = new System.Drawing.Point(206, 290);
            this.btnShowScore.Name = "btnShowScore";
            this.btnShowScore.Size = new System.Drawing.Size(75, 23);
            this.btnShowScore.TabIndex = 12;
            this.btnShowScore.Text = "submit";
            this.btnShowScore.UseVisualStyleBackColor = true;
            this.btnShowScore.Click += new System.EventHandler(this.btnShowScore_Click);
            // 
            // boxAllHighScores
            // 
            this.boxAllHighScores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.boxAllHighScores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.boxAllHighScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.boxAllHighScores.ForeColor = System.Drawing.Color.White;
            this.boxAllHighScores.Location = new System.Drawing.Point(58, 143);
            this.boxAllHighScores.Name = "boxAllHighScores";
            this.boxAllHighScores.ReadOnly = true;
            this.boxAllHighScores.Size = new System.Drawing.Size(374, 328);
            this.boxAllHighScores.TabIndex = 13;
            this.boxAllHighScores.Text = "";
            // 
            // lblHighscore
            // 
            this.lblHighscore.AutoSize = true;
            this.lblHighscore.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighscore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.lblHighscore.Location = new System.Drawing.Point(150, 74);
            this.lblHighscore.Name = "lblHighscore";
            this.lblHighscore.Size = new System.Drawing.Size(181, 57);
            this.lblHighscore.TabIndex = 14;
            this.lblHighscore.Text = "Highscore!";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(491, 552);
            this.Controls.Add(this.lblHighscore);
            this.Controls.Add(this.boxAllHighScores);
            this.Controls.Add(this.btnShowScore);
            this.Controls.Add(this.inputPlayerName);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblNewGame);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.lblPause);
            this.Controls.Add(this.enemyHealthBar);
            this.Controls.Add(this.playerHealthBar);
            this.Controls.Add(this.resume);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.lblLevelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer GameEngineTimer;
        private System.Windows.Forms.Label lblLevelName;
        private System.Windows.Forms.Label lblPause;
        private System.Windows.Forms.Label pause;
        private System.Windows.Forms.Label resume;
        private System.Windows.Forms.ProgressBar playerHealthBar;
        private System.Windows.Forms.ProgressBar enemyHealthBar;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Label lblNewGame;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.TextBox inputPlayerName;
        private System.Windows.Forms.Button btnShowScore;
        public System.Windows.Forms.RichTextBox boxAllHighScores;
        private System.Windows.Forms.Label lblHighscore;
    }
}