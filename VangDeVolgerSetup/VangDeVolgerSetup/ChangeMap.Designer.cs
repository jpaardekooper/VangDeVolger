namespace VangDeVolgerSetup
{
    partial class ChangeMap
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
            this.lblMapName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.changeMapBox = new System.Windows.Forms.RichTextBox();
            this.lblBoxInfo = new System.Windows.Forms.Label();
            this.lblWallInfo = new System.Windows.Forms.Label();
            this.lvlEmptyInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMapName
            // 
            this.lblMapName.AutoSize = true;
            this.lblMapName.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMapName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.lblMapName.Location = new System.Drawing.Point(111, 19);
            this.lblMapName.Name = "lblMapName";
            this.lblMapName.Size = new System.Drawing.Size(112, 44);
            this.lblMapName.TabIndex = 1;
            this.lblMapName.Text = "example";
            this.lblMapName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(135, 439);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 32);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.save_Click);
            // 
            // changeMapBox
            // 
            this.changeMapBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changeMapBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(114)))), ((int)(((byte)(204)))));
            this.changeMapBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.changeMapBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeMapBox.ForeColor = System.Drawing.Color.White;
            this.changeMapBox.Location = new System.Drawing.Point(71, 168);
            this.changeMapBox.Name = "changeMapBox";
            this.changeMapBox.Size = new System.Drawing.Size(193, 246);
            this.changeMapBox.TabIndex = 5;
            this.changeMapBox.Text = "";
            // 
            // lblBoxInfo
            // 
            this.lblBoxInfo.AutoSize = true;
            this.lblBoxInfo.ForeColor = System.Drawing.Color.White;
            this.lblBoxInfo.Location = new System.Drawing.Point(116, 82);
            this.lblBoxInfo.Name = "lblBoxInfo";
            this.lblBoxInfo.Size = new System.Drawing.Size(94, 13);
            this.lblBoxInfo.TabIndex = 6;
            this.lblBoxInfo.Text = "D: Box (moveable)";
            // 
            // lblWallInfo
            // 
            this.lblWallInfo.AutoSize = true;
            this.lblWallInfo.ForeColor = System.Drawing.Color.White;
            this.lblWallInfo.Location = new System.Drawing.Point(116, 106);
            this.lblWallInfo.Name = "lblWallInfo";
            this.lblWallInfo.Size = new System.Drawing.Size(114, 13);
            this.lblWallInfo.TabIndex = 7;
            this.lblWallInfo.Text = "V: Wall (not moveable)";
            // 
            // lvlEmptyInfo
            // 
            this.lvlEmptyInfo.AutoSize = true;
            this.lvlEmptyInfo.ForeColor = System.Drawing.Color.White;
            this.lvlEmptyInfo.Location = new System.Drawing.Point(116, 130);
            this.lvlEmptyInfo.Name = "lvlEmptyInfo";
            this.lvlEmptyInfo.Size = new System.Drawing.Size(82, 13);
            this.lvlEmptyInfo.TabIndex = 8;
            this.lvlEmptyInfo.Text = "N: Empty object";
            // 
            // ChangeMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(32)))), ((int)(((byte)(108)))));
            this.ClientSize = new System.Drawing.Size(334, 499);
            this.Controls.Add(this.lvlEmptyInfo);
            this.Controls.Add(this.lblWallInfo);
            this.Controls.Add(this.lblBoxInfo);
            this.Controls.Add(this.changeMapBox);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMapName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChangeMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeMap";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMapName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox changeMapBox;
        private System.Windows.Forms.Label lblBoxInfo;
        private System.Windows.Forms.Label lblWallInfo;
        private System.Windows.Forms.Label lvlEmptyInfo;
    }
}