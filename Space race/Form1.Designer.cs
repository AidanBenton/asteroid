namespace Space_race
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.textLabel = new System.Windows.Forms.Label();
            this.playerOneLabel = new System.Windows.Forms.Label();
            this.playerTwoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 17;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // textLabel
            // 
            this.textLabel.BackColor = System.Drawing.Color.Transparent;
            this.textLabel.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textLabel.Location = new System.Drawing.Point(174, -1);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(239, 285);
            this.textLabel.TabIndex = 1;
            this.textLabel.Text = "label1";
            this.textLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerOneLabel
            // 
            this.playerOneLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerOneLabel.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerOneLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playerOneLabel.Location = new System.Drawing.Point(12, 226);
            this.playerOneLabel.Name = "playerOneLabel";
            this.playerOneLabel.Size = new System.Drawing.Size(174, 198);
            this.playerOneLabel.TabIndex = 2;
            this.playerOneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playerTwoLabel
            // 
            this.playerTwoLabel.BackColor = System.Drawing.Color.Transparent;
            this.playerTwoLabel.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerTwoLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.playerTwoLabel.Location = new System.Drawing.Point(424, 226);
            this.playerTwoLabel.Name = "playerTwoLabel";
            this.playerTwoLabel.Size = new System.Drawing.Size(174, 198);
            this.playerTwoLabel.TabIndex = 3;
            this.playerTwoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(610, 360);
            this.Controls.Add(this.playerTwoLabel);
            this.Controls.Add(this.playerOneLabel);
            this.Controls.Add(this.textLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Label playerOneLabel;
        private System.Windows.Forms.Label playerTwoLabel;
    }
}

