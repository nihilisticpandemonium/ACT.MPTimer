namespace ACT.MPTimer
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    using ACT.MPTimer.Properties;
    using Advanced_Combat_Tracker;

    /// <summary>
    /// MPタイマーForm
    /// </summary>
    public partial class MPTimerForm : Form
    {
        /// <summary>
        /// ロックオブジェクト
        /// </summary>
        private static object lockObject = new object();

        /// <summary>
        /// シングルトンinstance
        /// </summary>
        private static MPTimerForm instance;

        /// <summary>
        /// シングルトンinstance
        /// </summary>
        public static MPTimerForm Default
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new MPTimerForm();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// 最後のマウスの位置
        /// </summary>
        private Point lastMousePosition;

        /// <summary>
        /// 停止中？
        /// </summary>
        private bool isStoped;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MPTimerForm()
        {
            this.InitializeComponent();

            // 背景の透過を設定する
            this.TransparencyKey = Color.MidnightBlue;
            this.BackColor = Color.MidnightBlue;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            // マウスによる移動を設定する
            this.ProgressPictureBox.MouseDown += (s1, e1) =>
            {
                lock (lockObject)
                {
                    try
                    {
                        this.timer.Enabled = false;
                        this.lastMousePosition = e1.Location;
                    }
                    finally
                    {
                        this.timer.Enabled = true;
                    }
                }
            };

            this.ProgressPictureBox.MouseMove += (s1, e1) =>
            {
                lock (lockObject)
                {
                    try
                    {
                        this.timer.Enabled = false;
                        if ((e1.Button & MouseButtons.Left) ==
                            MouseButtons.Left)
                        {
                            this.Location += (Size)e1.Location - (Size)this.lastMousePosition;

                            Settings.Default.OverlayLeft = this.Left;
                            Settings.Default.OverlayTop = this.Top;
                            Settings.Default.Save();
                        }
                    }
                    finally
                    {
                        this.timer.Enabled = true;
                    }
                }
            };
        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void MPTimerForm_Load(object sender, EventArgs e)
        {
            this.timer.Enabled = true;
            this.isStoped = false;

            this.ProgressPictureBox.MouseDoubleClick += (s1, e1) =>
            {
                this.isStoped = !this.isStoped;
            };

            this.RemainTimeLabel.MouseDoubleClick += (s1, e1) =>
            {
                this.isStoped = !this.isStoped;
            };
        }

        /// <summary>
        /// 描画タイマ Tick
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            lock (lockObject)
            {
                try
                {
                    this.timer.Enabled = false;

                    // ACTが表示されていなければ何もしない
                    if (!ActGlobals.oFormActMain.Visible)
                    {
                        this.Visible = false;
                        return;
                    }

#if !DEBUG
                    // FF14Processがなければ何もしない
                    var ff14 = FF14PluginHelper.GetFFXIVProcess;
                    if (ff14 == null)
                    {
                        this.Visible = false;
                        return;
                    }
#endif

                    // MP回復タイミングを描画する
                    this.DrawMPTiming();
                }
                catch (Exception ex)
                {
                    ActGlobals.oFormActMain.WriteExceptionLog(
                        ex,
                        "ACT.MPTimer グラフの描画で例外が発生しました。");

                    this.Visible = false;
                }
                finally
                {
                    this.timer.Enabled = true;
                }
            }
        }

        /// <summary>
        /// MP回復タイミングを描画する
        /// </summary>
        private void DrawMPTiming()
        {
            // 設定をロードする
            this.LoadSettings();

#if !DEBUG
            // プレイヤーがいない？
            if (!FF14Watcher.Default.ExistPlayer)
            {
                this.Visible = false;
                return;
            }
#endif

            // MP回復までの残り秒数を取得する
            if (FF14Watcher.Default.TimeOfRecovery <= 0)
            {
                this.RemainTimeLabel.Text = string.Empty;
            }
            else
            {
                this.RemainTimeLabel.Text =
                    ((decimal)FF14Watcher.Default.TimeOfRecovery / 1000m).ToString("0.00");
            }

            // MP回復の進捗率を取得する
            var rateOfMPRecovery = FF14Watcher.Default.RateOfRecovery;

            // 停止中？
            if (this.isStoped)
            {
                this.RemainTimeLabel.Text = "STOP";
                rateOfMPRecovery = 0;
            }

            var pic = this.ProgressPictureBox;

            // バーとラベルの位置を決める
            pic.Location = new Point(0, 0);
            pic.Size = this.Size;

            this.RemainTimeLabel.Top = (this.Height / 2) - (this.RemainTimeLabel.Height / 2);
            this.RemainTimeLabel.Left = this.Width - this.RemainTimeLabel.Width - 2;

            // バーの長さを決める
            var foreWidth = (int)(pic.Width * rateOfMPRecovery);
            var backWidth = pic.Width - foreWidth;

            // バーの色を決める
            var progressBarColor = Settings.Default.OverlayColor;
            var backColor = Color.FromArgb(
                (int)(progressBarColor.R * 0.4),
                (int)(progressBarColor.G * 0.4),
                (int)(progressBarColor.B * 0.4));

            // バーを描画する
            var bmp = new Bitmap(pic.Width, pic.Height);
            using (var g = Graphics.FromImage(bmp))
            {
                using (var foreBrush = new SolidBrush(progressBarColor))
                using (var backBrush = new SolidBrush(backColor))
                {
                    // 進捗率を描画する
                    g.FillRectangle(
                        foreBrush,
                        0,
                        0,
                        foreWidth,
                        pic.Height);

                    // 残りを描画する
                    g.FillRectangle(
                        backBrush,
                        foreWidth,
                        0,
                        backWidth,
                        pic.Height);
                }
            }

            // バーにセットする
            pic.Image = bmp;

            // ラベルとバーの親子関係を設定する
            this.RemainTimeLabel.Parent = pic;

            // 画面を表示する
            this.Visible = true;
        }

        /// <summary>
        /// 設定をロードする
        /// </summary>
        private void LoadSettings()
        {
            this.Opacity = (100 - Settings.Default.OverlayOpacity) / 100d;

            this.Location = new Point(
                Settings.Default.OverlayLeft,
                Settings.Default.OverlayTop);

            this.Size = new Size(
                Settings.Default.OverlayWidth,
                Settings.Default.OverlayHeight);

            this.RemainTimeLabel.Font = Settings.Default.OverlayFont;
            this.RemainTimeLabel.ForeColor = Settings.Default.OverlayFontColor;
        }
    }
}
