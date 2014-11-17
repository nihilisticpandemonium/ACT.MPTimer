namespace ACT.MPTimer
{
    partial class MPTimerForm
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.RemainTimeLabel = new System.Windows.Forms.Label();
            this.ProgressPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 40;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // RemainTimeLabel
            // 
            this.RemainTimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RemainTimeLabel.AutoSize = true;
            this.RemainTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.RemainTimeLabel.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RemainTimeLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.RemainTimeLabel.Location = new System.Drawing.Point(143, 2);
            this.RemainTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RemainTimeLabel.Name = "RemainTimeLabel";
            this.RemainTimeLabel.Size = new System.Drawing.Size(45, 23);
            this.RemainTimeLabel.TabIndex = 0;
            this.RemainTimeLabel.Text = "1.20";
            this.RemainTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ProgressPictureBox
            // 
            this.ProgressPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ProgressPictureBox.Location = new System.Drawing.Point(1, 4);
            this.ProgressPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ProgressPictureBox.Name = "ProgressPictureBox";
            this.ProgressPictureBox.Size = new System.Drawing.Size(115, 21);
            this.ProgressPictureBox.TabIndex = 1;
            this.ProgressPictureBox.TabStop = false;
            // 
            // MPTimerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 36);
            this.ControlBox = false;
            this.Controls.Add(this.ProgressPictureBox);
            this.Controls.Add(this.RemainTimeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MPTimerForm";
            this.Opacity = 0.6D;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MPTimerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProgressPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label RemainTimeLabel;
        private System.Windows.Forms.PictureBox ProgressPictureBox;
    }
}