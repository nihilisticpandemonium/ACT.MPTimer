namespace ACT.MPTimer
{
    using System;
    using System.Windows.Forms;

    using ACT.MPTimer.Properties;
    using Advanced_Combat_Tracker;

    /// <summary>
    /// Active Combat Tacker v3 MPTimer Plugin
    /// </summary>
    public partial class MPTimerPlugin : IActPluginV1
    {
        /// <summary>
        /// プラグインステータス表示ラベル
        /// </summary>
        private Label PluginStatusLabel
        {
            get;
            set;
        }

        /// <summary>
        /// MPタイマWindow
        /// </summary>
        private MPTimerWindow MPTimerWindow
        {
            get;
            set;
        }

        /// <summary>
        /// プラグインを初期化する
        /// </summary>
        /// <param name="pluginScreenSpace"></param>
        /// <param name="pluginStatusText"></param>
        void IActPluginV1.InitPlugin(
            TabPage pluginScreenSpace,
            Label pluginStatusText)
        {
            try
            {
                pluginScreenSpace.Text = "MPTimer";

                // アップデートを確認する
                this.Update();

                // 設定Panelを追加する
                var panel = new ConfigPanel();
                panel.Dock = DockStyle.Fill;
                pluginScreenSpace.Controls.Add(panel);

                // FF14監視スレッドを開始する
                FF14Watcher.Initialize();

                // MP回復タイミングFormを表示する
                this.MPTimerWindow = new MPTimerWindow();
                this.MPTimerWindow.Show();

                this.PluginStatusLabel = pluginStatusText;
                this.PluginStatusLabel.Text = "Plugin Started";
            }
            catch (Exception ex)
            {
                ActGlobals.oFormActMain.WriteExceptionLog(
                    ex,
                    "ACT.MPTimer プラグインの初期化で例外が発生しました。");
            }
        }

        /// <summary>
        /// プラグインを後片付けする
        /// </summary>
        void IActPluginV1.DeInitPlugin()
        {
            FF14Watcher.Deinitialize();

            this.PluginStatusLabel.Text = "Plugin Exited";
        }

        /// <summary>
        /// アップデートを行う
        /// </summary>
        private void Update()
        {
            if ((DateTime.Now - Settings.Default.LastUpdateDatetime).TotalHours >= 6d)
            {
                var message = UpdateChecker.Update();
                if (!string.IsNullOrWhiteSpace(message))
                {
                    ActGlobals.oFormActMain.WriteExceptionLog(
                        new Exception(),
                        message);
                }

                Settings.Default.LastUpdateDatetime = DateTime.Now;
                Settings.Default.Save();
            }
        }
    }
}
