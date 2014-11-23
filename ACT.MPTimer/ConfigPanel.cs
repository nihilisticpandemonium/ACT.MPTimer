namespace ACT.MPTimer
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using ACT.MPTimer.Properties;

    /// <summary>
    /// 設定Panel
    /// </summary>
    public partial class ConfigPanel : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ConfigPanel()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// MPTimer Window
        /// </summary>
        public MPTimerWindow MPTimerWindow { get; set; }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void ConfigPanel_Load(object sender, EventArgs e)
        {
            this.TargetJobComboBox.DataSource = Job.GetJobList();
            this.TargetJobComboBox.ValueMember = "JobId";
            this.TargetJobComboBox.DisplayMember = "JobName";

            this.LoadSettings();

            this.OverlayWidthNumericUpDown.ValueChanged += (s1, e1) => this.SaveSettings();
            this.OverlayHeightNumericUpDown.ValueChanged += (s1, e1) => this.SaveSettings();
            this.TokaRitsuNumericUpDown.ValueChanged += (s1, e1) => this.SaveSettings();
            this.CountInCombatCheckBox.CheckedChanged += (s1, e1) => this.SaveSettings();
            this.TargetJobComboBox.SelectedValueChanged += (s1, e1) => this.SaveSettings();

            this.ShokikaButton.Click += (s1, e1) =>
            {
                Settings.Default.Reset();
                Settings.Default.Save();

                this.MPTimerWindow.Top = Settings.Default.OverlayTop;
                this.MPTimerWindow.Left = Settings.Default.OverlayLeft;

                this.LoadSettings();
            };
        }

        /// <summary>
        /// 背景色ボタン Click
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void BackColorButton_Click(object sender, EventArgs e)
        {
            this.ColorDialog.Color = this.DummyOverlayLabel.BackColor;
            if (this.ColorDialog.ShowDialog(this) != DialogResult.Cancel)
            {
                this.DummyOverlayLabel.BackColor = this.ColorDialog.Color;
                this.SaveSettings();
            }
        }

        /// <summary>
        /// フォントボタン Click
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void FontButton_Click(object sender, EventArgs e)
        {
            this.FontDialog.Font = this.DummyOverlayLabel.Font;
            if (this.FontDialog.ShowDialog(this) != DialogResult.Cancel)
            {
                this.DummyOverlayLabel.Font = this.FontDialog.Font;
                this.SaveSettings();
            }
        }

        /// <summary>
        /// フォント色ボタン Click
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void FontColorButton_Click(object sender, EventArgs e)
        {
            this.ColorDialog.Color = this.DummyOverlayLabel.ForeColor;
            if (this.ColorDialog.ShowDialog(this) != DialogResult.Cancel)
            {
                this.DummyOverlayLabel.ForeColor = this.ColorDialog.Color;
                this.SaveSettings();
            }
        }

        /// <summary>
        /// 設定をLoadする
        /// </summary>
        private void LoadSettings()
        {
            this.OverlayWidthNumericUpDown.Value = Settings.Default.ProgressBarWidth;
            this.OverlayHeightNumericUpDown.Value = Settings.Default.ProgressBarHeight;

            this.DummyOverlayLabel.BackColor = Settings.Default.OverlayColor;
            this.DummyOverlayLabel.ForeColor = Settings.Default.OverlayFontColor;
            this.DummyOverlayLabel.Font = Settings.Default.OverlayFont;

            this.TokaRitsuNumericUpDown.Value = Settings.Default.OverlayOpacity;

            this.CountInCombatCheckBox.Checked = Settings.Default.CountInCombat;
            this.TargetJobComboBox.SelectedValue = Settings.Default.TargetJobId;
        }

        /// <summary>
        /// 設定をSaveする
        /// </summary>
        private void SaveSettings()
        {
            Settings.Default.ProgressBarWidth = (int)this.OverlayWidthNumericUpDown.Value;
            Settings.Default.ProgressBarHeight = (int)this.OverlayHeightNumericUpDown.Value;

            Settings.Default.OverlayColor = this.DummyOverlayLabel.BackColor;
            Settings.Default.OverlayFontColor = this.DummyOverlayLabel.ForeColor;
            Settings.Default.OverlayFont = this.DummyOverlayLabel.Font;

            Settings.Default.OverlayOpacity = (int)this.TokaRitsuNumericUpDown.Value;

            Settings.Default.CountInCombat = this.CountInCombatCheckBox.Checked;
            Settings.Default.TargetJobId = (int)this.TargetJobComboBox.SelectedValue;

            Settings.Default.Save();
        }
    }
}
