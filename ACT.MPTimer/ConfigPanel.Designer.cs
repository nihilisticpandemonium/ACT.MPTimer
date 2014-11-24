namespace ACT.MPTimer
{
    partial class ConfigPanel
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.OverlayWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.OverlayHeightNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.FontDialog = new System.Windows.Forms.FontDialog();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.DummyOverlayLabel = new System.Windows.Forms.Label();
            this.BackColorButton = new System.Windows.Forms.Button();
            this.FontButton = new System.Windows.Forms.Button();
            this.FontColorButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TokaRitsuNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ShokikaButton = new System.Windows.Forms.Button();
            this.CountInCombatCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TargetJobComboBox = new System.Windows.Forms.ComboBox();
            this.CountInCombatNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ClickThroughCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TokaRitsuNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountInCombatNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "プログレスバーのサイズ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "W";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "H";
            // 
            // OverlayWidthNumericUpDown
            // 
            this.OverlayWidthNumericUpDown.Location = new System.Drawing.Point(181, 23);
            this.OverlayWidthNumericUpDown.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.OverlayWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.OverlayWidthNumericUpDown.Name = "OverlayWidthNumericUpDown";
            this.OverlayWidthNumericUpDown.Size = new System.Drawing.Size(65, 19);
            this.OverlayWidthNumericUpDown.TabIndex = 0;
            this.OverlayWidthNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.OverlayWidthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // OverlayHeightNumericUpDown
            // 
            this.OverlayHeightNumericUpDown.Location = new System.Drawing.Point(285, 23);
            this.OverlayHeightNumericUpDown.Maximum = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.OverlayHeightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.OverlayHeightNumericUpDown.Name = "OverlayHeightNumericUpDown";
            this.OverlayHeightNumericUpDown.Size = new System.Drawing.Size(65, 19);
            this.OverlayHeightNumericUpDown.TabIndex = 1;
            this.OverlayHeightNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.OverlayHeightNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "オーバーレイの見た目";
            // 
            // FontDialog
            // 
            this.FontDialog.AllowScriptChange = false;
            this.FontDialog.AllowVerticalFonts = false;
            this.FontDialog.ShowEffects = false;
            // 
            // DummyOverlayLabel
            // 
            this.DummyOverlayLabel.BackColor = System.Drawing.Color.OrangeRed;
            this.DummyOverlayLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.DummyOverlayLabel.Location = new System.Drawing.Point(163, 53);
            this.DummyOverlayLabel.Name = "DummyOverlayLabel";
            this.DummyOverlayLabel.Size = new System.Drawing.Size(216, 48);
            this.DummyOverlayLabel.TabIndex = 7;
            this.DummyOverlayLabel.Text = "2.56 ";
            this.DummyOverlayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BackColorButton
            // 
            this.BackColorButton.Location = new System.Drawing.Point(163, 104);
            this.BackColorButton.Name = "BackColorButton";
            this.BackColorButton.Size = new System.Drawing.Size(68, 23);
            this.BackColorButton.TabIndex = 2;
            this.BackColorButton.Text = "背景色";
            this.BackColorButton.UseVisualStyleBackColor = true;
            this.BackColorButton.Click += new System.EventHandler(this.BackColorButton_Click);
            // 
            // FontButton
            // 
            this.FontButton.Location = new System.Drawing.Point(237, 104);
            this.FontButton.Name = "FontButton";
            this.FontButton.Size = new System.Drawing.Size(68, 23);
            this.FontButton.TabIndex = 3;
            this.FontButton.Text = "フォント";
            this.FontButton.UseVisualStyleBackColor = true;
            this.FontButton.Click += new System.EventHandler(this.FontButton_Click);
            // 
            // FontColorButton
            // 
            this.FontColorButton.Location = new System.Drawing.Point(311, 104);
            this.FontColorButton.Name = "FontColorButton";
            this.FontColorButton.Size = new System.Drawing.Size(68, 23);
            this.FontColorButton.TabIndex = 4;
            this.FontColorButton.Text = "フォント色";
            this.FontColorButton.UseVisualStyleBackColor = true;
            this.FontColorButton.Click += new System.EventHandler(this.FontColorButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "透過率";
            // 
            // TokaRitsuNumericUpDown
            // 
            this.TokaRitsuNumericUpDown.Location = new System.Drawing.Point(163, 133);
            this.TokaRitsuNumericUpDown.Name = "TokaRitsuNumericUpDown";
            this.TokaRitsuNumericUpDown.Size = new System.Drawing.Size(65, 19);
            this.TokaRitsuNumericUpDown.TabIndex = 5;
            this.TokaRitsuNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TokaRitsuNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ShokikaButton
            // 
            this.ShokikaButton.Location = new System.Drawing.Point(311, 303);
            this.ShokikaButton.Name = "ShokikaButton";
            this.ShokikaButton.Size = new System.Drawing.Size(68, 23);
            this.ShokikaButton.TabIndex = 10;
            this.ShokikaButton.Text = "初期化";
            this.ShokikaButton.UseVisualStyleBackColor = true;
            // 
            // CountInCombatCheckBox
            // 
            this.CountInCombatCheckBox.AutoSize = true;
            this.CountInCombatCheckBox.Location = new System.Drawing.Point(163, 158);
            this.CountInCombatCheckBox.Name = "CountInCombatCheckBox";
            this.CountInCombatCheckBox.Size = new System.Drawing.Size(48, 16);
            this.CountInCombatCheckBox.TabIndex = 6;
            this.CountInCombatCheckBox.Text = "有効";
            this.CountInCombatCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "戦闘中のみ稼働させる";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "特定ジョブのとき稼働させる";
            // 
            // TargetJobComboBox
            // 
            this.TargetJobComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TargetJobComboBox.FormattingEnabled = true;
            this.TargetJobComboBox.Location = new System.Drawing.Point(163, 205);
            this.TargetJobComboBox.Name = "TargetJobComboBox";
            this.TargetJobComboBox.Size = new System.Drawing.Size(216, 20);
            this.TargetJobComboBox.TabIndex = 8;
            // 
            // CountInCombatNumericUpDown
            // 
            this.CountInCombatNumericUpDown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CountInCombatNumericUpDown.Location = new System.Drawing.Point(163, 180);
            this.CountInCombatNumericUpDown.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.CountInCombatNumericUpDown.Name = "CountInCombatNumericUpDown";
            this.CountInCombatNumericUpDown.Size = new System.Drawing.Size(63, 19);
            this.CountInCombatNumericUpDown.TabIndex = 7;
            this.CountInCombatNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(232, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "秒経過で戦闘終了とみなす";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "クリックスルー";
            // 
            // ClickThroughCheckBox
            // 
            this.ClickThroughCheckBox.AutoSize = true;
            this.ClickThroughCheckBox.Location = new System.Drawing.Point(163, 231);
            this.ClickThroughCheckBox.Name = "ClickThroughCheckBox";
            this.ClickThroughCheckBox.Size = new System.Drawing.Size(48, 16);
            this.ClickThroughCheckBox.TabIndex = 9;
            this.ClickThroughCheckBox.Text = "有効";
            this.ClickThroughCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ClickThroughCheckBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CountInCombatNumericUpDown);
            this.Controls.Add(this.TargetJobComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CountInCombatCheckBox);
            this.Controls.Add(this.ShokikaButton);
            this.Controls.Add(this.TokaRitsuNumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FontColorButton);
            this.Controls.Add(this.FontButton);
            this.Controls.Add(this.BackColorButton);
            this.Controls.Add(this.DummyOverlayLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.OverlayHeightNumericUpDown);
            this.Controls.Add(this.OverlayWidthNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ConfigPanel";
            this.Size = new System.Drawing.Size(391, 329);
            this.Load += new System.EventHandler(this.ConfigPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OverlayWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OverlayHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TokaRitsuNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountInCombatNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown OverlayWidthNumericUpDown;
        private System.Windows.Forms.NumericUpDown OverlayHeightNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FontDialog FontDialog;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.Label DummyOverlayLabel;
        private System.Windows.Forms.Button BackColorButton;
        private System.Windows.Forms.Button FontButton;
        private System.Windows.Forms.Button FontColorButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown TokaRitsuNumericUpDown;
        private System.Windows.Forms.Button ShokikaButton;
        private System.Windows.Forms.CheckBox CountInCombatCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox TargetJobComboBox;
        private System.Windows.Forms.NumericUpDown CountInCombatNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox ClickThroughCheckBox;
    }
}
