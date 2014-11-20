namespace ACT.MPTimer
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Windows.Threading;

    using ACT.MPTimer.Properties;
    using Advanced_Combat_Tracker;

    /// <summary>
    /// MPTimer Window
    /// </summary>
    public partial class MPTimerWindow : Window
    {
        /// <summary>
        /// ロックオブジェクト
        /// </summary>
        private static object lockObject = new object();

        /// <summary>
        /// MP監視タイマ
        /// </summary>
        private DispatcherTimer MPWatchTimer;

        /// <summary>
        /// ドラッグ中か？
        /// </summary>
        private bool IsDragging;

        /// <summary>
        /// 停止中か？
        /// </summary>
        private bool IsStopping;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MPTimerWindow()
        {
            this.InitializeComponent();

            this.ShowInTaskbar = false;
            this.Topmost = true;

            this.Loaded += MPTimerWindow_Loaded;
        }

        /// <summary>
        /// Window Loaded
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void MPTimerWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = Settings.Default.OverlayLeft;
            this.Top = Settings.Default.OverlayTop;

#if !DEBUG
            // リリースではロード時は一先ず消しておく
            this.Visibility = Visibility.Hidden;
#endif

            // マウスの移動を定義する
            this.MouseLeftButtonDown += (s1, e1) =>
            {
                lock (lockObject)
                {
                    this.IsDragging = true;
                    this.DragMove();
                }
            };

            this.MouseLeftButtonUp += (s1, e1) =>
            {
                lock (lockObject)
                {
                    this.IsDragging = false;
                }
            };

            // 停止動作を定義する
            this.MouseDoubleClick += (s1, e1) =>
            {
                lock (lockObject)
                {
                    this.IsStopping = !this.IsStopping;
                    this.IsDragging = false;
                    this.MPWatchCore();
                }
            };

            // MP監視タイマを開始する
            this.MPWatchTimer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0, 0, 0, 0, 50),
            };

            this.MPWatchTimer.Tick += this.MPWatchTimer_Tick;
            this.MPWatchTimer.Start();
        }

        /// <summary>
        /// MP監視タイマ Tick
        /// </summary>
        /// <param name="sender">イベント発生元</param>
        /// <param name="e">イベント引数</param>
        private void MPWatchTimer_Tick(object sender, EventArgs e)
        {
            lock (lockObject)
            {
                this.MPWatchCore();
            }
        }

        /// <summary>
        /// MP監視タイマの中核
        /// </summary>
        private void MPWatchCore()
        {
            try
            {
                this.MPWatchTimer.Stop();

                if (this.IsDragging)
                {
                    return;
                }

                // Windowの位置を保存する
                if (Settings.Default.OverlayLeft != (int)this.Left ||
                    Settings.Default.OverlayTop != (int)this.Top)
                {
                    Settings.Default.OverlayTop = (int)this.Top;
                    Settings.Default.OverlayLeft = (int)this.Left;
                    Settings.Default.Save();
                }

                // ACTが表示されていなければ何もしない
                if (!ActGlobals.oFormActMain.Visible)
                {
                    this.MPWatchTimer.Interval = new TimeSpan(0, 0, 0, 5, 0);
                    this.Visibility = Visibility.Hidden;
                    return;
                }

#if !DEBUG
                // FF14Processがなければ何もしない
                var ff14 = FF14PluginHelper.GetFFXIVProcess;
                if (ff14 == null)
                {
                    this.MPWatchTimer.Interval = new TimeSpan(0, 0, 0, 5, 0);
                    this.Visibility = Visibility.Hidden;
                    return;
                }

                // プレイヤーがいない？
                if (!FF14Watcher.Default.ExistPlayer)
                {
                    this.MPWatchTimer.Interval = new TimeSpan(0, 0, 0, 5, 0);
                    this.Visibility = Visibility.Hidden;
                    return;
                }
#endif

                // 監視間隔を短くする
                this.MPWatchTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);

                // Windowの透過率を設定する
                this.Opacity = (100d - Settings.Default.OverlayOpacity) / 100d;

                // リキャストタイマーを描画する
                this.DrawRecastTimer();
                this.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                ActGlobals.oFormActMain.WriteExceptionLog(
                    ex,
                    "ACT.MPTimer グラフの描画で例外が発生しました。");

                this.Visibility = Visibility.Hidden;
            }
            finally
            {
                this.MPWatchTimer.Start();
            }
        }

        /// <summary>
        /// リキャストタイマを描画する
        /// </summary>
        private void DrawRecastTimer()
        {
            // 残り秒数を取得する
            var recastTime = string.Empty;
            if (FF14Watcher.Default.TimeOfRecovery > 0)
            {
                recastTime = ((decimal)FF14Watcher.Default.TimeOfRecovery / 1000m).ToString("0.0");
            }

#if DEBUG
            if (string.IsNullOrWhiteSpace(recastTime))
            {
                recastTime = "3.0";
            }
#endif

            // 進捗率を取得する
            var rateOfMPRecovery = FF14Watcher.Default.RateOfRecovery;

            // 停止中？
            if (this.IsStopping)
            {
                recastTime = "Stoped";
                rateOfMPRecovery = 1m;
            }

            // 秒数を描画する
            this.RecastTimeLabel.FontFamily = new FontFamily(Settings.Default.OverlayFont.Name);
            this.RecastTimeLabel.FontSize = Settings.Default.OverlayFont.Size / 72.0 * 96.0;
            this.RecastTimeLabel.FontStyle =
                (Settings.Default.OverlayFont.Style & System.Drawing.FontStyle.Italic) != 0 ?
                FontStyles.Italic :
                FontStyles.Normal;
            this.RecastTimeLabel.FontWeight =
                (Settings.Default.OverlayFont.Style & System.Drawing.FontStyle.Bold) != 0 ?
                FontWeights.Bold :
                FontWeights.Normal;
            this.RecastTimeLabel.Foreground = new SolidColorBrush(Color.FromRgb(
                Settings.Default.OverlayFontColor.R,
                Settings.Default.OverlayFontColor.G,
                Settings.Default.OverlayFontColor.B));
            this.RecastTimeLabel.Content = recastTime;

            // プログレスバーを描画する
            var progressBarColor = Color.FromRgb(
                Settings.Default.OverlayColor.R,
                Settings.Default.OverlayColor.G,
                Settings.Default.OverlayColor.B);
            var backColor = Color.FromRgb(
                (byte)(progressBarColor.R * 0.4),
                (byte)(progressBarColor.G * 0.4),
                (byte)(progressBarColor.B * 0.4));

            var foreRect = new Rectangle();
            var foreBrush = new SolidColorBrush(progressBarColor);
            foreRect.Stroke = foreBrush;
            foreRect.Fill = foreBrush;
            foreRect.Width = (double)(Settings.Default.ProgressBarWidth * rateOfMPRecovery);
            foreRect.Height = Settings.Default.ProgressBarHeight;
            foreRect.RadiusX = 5.0d;
            foreRect.RadiusY = 5.0d;
            Canvas.SetLeft(foreRect, 0);
            Canvas.SetTop(foreRect, 0);

            var backRect = new Rectangle();
            var backBrush = new SolidColorBrush(backColor);
            backRect.Stroke = backBrush;
            backRect.Fill = backBrush;
            backRect.Width = Settings.Default.ProgressBarWidth;
            backRect.Height = Settings.Default.ProgressBarHeight;
            backRect.RadiusX = 5.0d;
            backRect.RadiusY = 5.0d;
            Canvas.SetLeft(backRect, foreRect.Width);
            Canvas.SetTop(backRect, 0);

            this.ProgressBarCanvas.Children.Clear();
            this.ProgressBarCanvas.Children.Add(backRect);
            this.ProgressBarCanvas.Children.Add(foreRect);

            // Windowサイズを調整する
            this.Width = Settings.Default.ProgressBarWidth;
            this.Height = (Settings.Default.ProgressBarHeight + this.RecastTimeLabel.Height) * 1.5d;

            // プログレスバーキャンパスのレイアウトを調整する
            this.ProgressBarCanvas.Width = Settings.Default.ProgressBarWidth;
            this.ProgressBarCanvas.Height = Settings.Default.ProgressBarHeight;
            this.ProgressBarCanvas.Margin = new Thickness(0, 0, 0, 0);

            // 秒数ラベルのレイアウトを調整する
            this.RecastTimeLabel.Margin = new Thickness(
                0,
                Settings.Default.ProgressBarHeight,
                0,
                0);
        }
    }
}
