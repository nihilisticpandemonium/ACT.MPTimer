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
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.Windows.Forms.Label();
            this.FontDialog = new System.Windows.Forms.FontDialog();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
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
            this.TekiyoButton = new System.Windows.Forms.Button();
            this.VisualSetting = new ACT.MPTimer.VisualSettingControl();
            ((System.ComponentModel.ISupportInitialize)(this.TokaRitsuNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountInCombatNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Appearance";
            // 
            // FontDialog
            // 
            this.FontDialog.AllowScriptChange = false;
            this.FontDialog.AllowVerticalFonts = false;
            this.FontDialog.ShowEffects = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Transmission Rate";
            // 
            // TokaRitsuNumericUpDown
            // 
            this.TokaRitsuNumericUpDown.Location = new System.Drawing.Point(163, 102);
            this.TokaRitsuNumericUpDown.Name = "TokaRitsuNumericUpDown";
            this.TokaRitsuNumericUpDown.Size = new System.Drawing.Size(65, 20);
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
            this.ShokikaButton.Location = new System.Drawing.Point(5, 286);
            this.ShokikaButton.Name = "ShokikaButton";
            this.ShokikaButton.Size = new System.Drawing.Size(68, 25);
            this.ShokikaButton.TabIndex = 10;
            this.ShokikaButton.Text = "Initialize";
            this.ShokikaButton.UseVisualStyleBackColor = true;
            // 
            // CountInCombatCheckBox
            // 
            this.CountInCombatCheckBox.AutoSize = true;
            this.CountInCombatCheckBox.Location = new System.Drawing.Point(163, 129);
            this.CountInCombatCheckBox.Name = "CountInCombatCheckBox";
            this.CountInCombatCheckBox.Size = new System.Drawing.Size(15, 14);
            this.CountInCombatCheckBox.TabIndex = 6;
            this.CountInCombatCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 133);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Only During Battle";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Only for Specific Job";
            // 
            // TargetJobComboBox
            // 
            this.TargetJobComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TargetJobComboBox.FormattingEnabled = true;
            this.TargetJobComboBox.Location = new System.Drawing.Point(163, 180);
            this.TargetJobComboBox.Name = "TargetJobComboBox";
            this.TargetJobComboBox.Size = new System.Drawing.Size(216, 21);
            this.TargetJobComboBox.TabIndex = 8;
            // 
            // CountInCombatNumericUpDown
            // 
            this.CountInCombatNumericUpDown.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CountInCombatNumericUpDown.Location = new System.Drawing.Point(163, 153);
            this.CountInCombatNumericUpDown.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.CountInCombatNumericUpDown.Name = "CountInCombatNumericUpDown";
            this.CountInCombatNumericUpDown.Size = new System.Drawing.Size(63, 20);
            this.CountInCombatNumericUpDown.TabIndex = 7;
            this.CountInCombatNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(232, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "End of Battle in Seconds";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Click Through";
            // 
            // ClickThroughCheckBox
            // 
            this.ClickThroughCheckBox.AutoSize = true;
            this.ClickThroughCheckBox.Location = new System.Drawing.Point(163, 208);
            this.ClickThroughCheckBox.Name = "ClickThroughCheckBox";
            this.ClickThroughCheckBox.Size = new System.Drawing.Size(15, 14);
            this.ClickThroughCheckBox.TabIndex = 9;
            this.ClickThroughCheckBox.UseVisualStyleBackColor = true;
            // 
            // TekiyoButton
            // 
            this.TekiyoButton.Location = new System.Drawing.Point(401, 286);
            this.TekiyoButton.Name = "TekiyoButton";
            this.TekiyoButton.Size = new System.Drawing.Size(68, 25);
            this.TekiyoButton.TabIndex = 22;
            this.TekiyoButton.Text = "Apply";
            this.TekiyoButton.UseVisualStyleBackColor = true;
            // 
            // VisualSetting
            // 
            this.VisualSetting.BackColor = System.Drawing.SystemColors.Control;
            this.VisualSetting.BarColor = System.Drawing.Color.OrangeRed;
            this.VisualSetting.BarEnabled = true;
            this.VisualSetting.BarOutlineColor = System.Drawing.Color.OrangeRed;
            this.VisualSetting.BarSize = new System.Drawing.Size(110, 7);
            this.VisualSetting.FontColor = System.Drawing.Color.LightGoldenrodYellow;
            this.VisualSetting.FontOutlineColor = System.Drawing.Color.LightGoldenrodYellow;
            this.VisualSetting.Location = new System.Drawing.Point(163, 24);
            this.VisualSetting.Name = "VisualSetting";
            this.VisualSetting.Size = new System.Drawing.Size(306, 70);
            this.VisualSetting.TabIndex = 21;
            this.VisualSetting.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            // 
            // ConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TekiyoButton);
            this.Controls.Add(this.VisualSetting);
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
            this.Controls.Add(this.label4);
            this.Name = "ConfigPanel";
            this.Size = new System.Drawing.Size(483, 321);
            this.Load += new System.EventHandler(this.ConfigPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TokaRitsuNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CountInCombatNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FontDialog FontDialog;
        private System.Windows.Forms.ColorDialog ColorDialog;
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
        private VisualSettingControl VisualSetting;
        private System.Windows.Forms.Button TekiyoButton;
    }
}
