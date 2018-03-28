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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblPause = new System.Windows.Forms.Label();
            this.pause = new System.Windows.Forms.Label();
            this.resume = new System.Windows.Forms.Label();
            this.playerHealthBar = new System.Windows.Forms.ProgressBar();
            this.enemyHealthBar = new System.Windows.Forms.ProgressBar();
            this.lblGameOver = new System.Windows.Forms.Label();
            this.newgame = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 24;
            this.timer1.Tick += new System.EventHandler(this.GameEngine);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(108)))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
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
            this.playerHealthBar.Location = new System.Drawing.Point(319, 21);
            this.playerHealthBar.Name = "playerHealthBar";
            this.playerHealthBar.Size = new System.Drawing.Size(151, 13);
            this.playerHealthBar.Step = 20;
            this.playerHealthBar.TabIndex = 6;
            this.playerHealthBar.Value = 100;
            // 
            // enemyHealthBar
            // 
            this.enemyHealthBar.ForeColor = System.Drawing.Color.Green;
            this.enemyHealthBar.Location = new System.Drawing.Point(319, 52);
            this.enemyHealthBar.Name = "enemyHealthBar";
            this.enemyHealthBar.Size = new System.Drawing.Size(151, 13);
            this.enemyHealthBar.TabIndex = 7;
            this.enemyHealthBar.Value = 100;
            // 
            // lblGameOver
            // 
            this.lblGameOver.AutoSize = true;
            this.lblGameOver.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameOver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.lblGameOver.Location = new System.Drawing.Point(142, 220);
            this.lblGameOver.Name = "lblGameOver";
            this.lblGameOver.Size = new System.Drawing.Size(203, 57);
            this.lblGameOver.TabIndex = 8;
            this.lblGameOver.Text = "Game Over!";
            // 
            // newgame
            // 
            this.newgame.AutoSize = true;
            this.newgame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.newgame.Location = new System.Drawing.Point(12, 24);
            this.newgame.Name = "newgame";
            this.newgame.Size = new System.Drawing.Size(123, 13);
            this.newgame.TabIndex = 9;
            this.newgame.Text = "press \'N\' for a new game";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(491, 552);
            this.Controls.Add(this.newgame);
            this.Controls.Add(this.lblGameOver);
            this.Controls.Add(this.lblPause);
            this.Controls.Add(this.enemyHealthBar);
            this.Controls.Add(this.playerHealthBar);
            this.Controls.Add(this.resume);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPause;
        private System.Windows.Forms.Label pause;
        private System.Windows.Forms.Label resume;
        private System.Windows.Forms.ProgressBar playerHealthBar;
        private System.Windows.Forms.ProgressBar enemyHealthBar;
        private System.Windows.Forms.Label lblGameOver;
        private System.Windows.Forms.Label newgame;
    }
}