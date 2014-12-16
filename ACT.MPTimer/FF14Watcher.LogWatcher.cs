namespace ACT.MPTimer
{
    using Advanced_Combat_Tracker;

    /// <summary>
    /// MPの回復状態
    /// </summary>
    public enum MPRecoveryStatus
    {
        /// <summary>0:通常</summary>
        Normal = 0,

        /// <summary>11:アストラルファイア</summary>
        AstralFire = 11,

        /// <summary>21:アンブラルブリザード</summary>
        UmbralIce1 = 21,

        /// <summary>22:アンブラルブリザードII</summary>
        UmbralIce2 = 22,

        /// <summary>23:アンブラルブリザードIII</summary>
        UmbralIce3 = 23,
    }

    /// <summary>
    /// FF14を監視する MPウォッチャー
    /// </summary>
    public partial class FF14Watcher
    {
        /// <summary>
        /// 現在のMP回復状況
        /// </summary>
        private MPRecoveryStatus CurrentMPRecoveryStatus;

        /// <summary>
        /// バラード中か？
        /// </summary>
        private bool BalladEnabled;

        /// <summary>
        /// ログを読取った
        /// </summary>
        /// <param name="isImport">インポートログか？</param>
        /// <param name="logInfo">ログ情報</param>
        private void oFormActMain_OnLogLineRead(bool isImport, LogLineEventArgs logInfo)
        {
            if (isImport)
            {
                return;
            }

            var player = FF14PluginHelper.GetPlayer();
            if (player == null)
            {
                return;
            }

            if (logInfo.logLine.Contains(player.Name + "に「アストラルファイア」の効果。") ||
                logInfo.logLine.Contains(player.Name + "に「アストラルファイアII」の効果。") ||
                logInfo.logLine.Contains(player.Name + "に「アストラルファイアIII」の効果。"))
            {
                this.CurrentMPRecoveryStatus = MPRecoveryStatus.AstralFire;
            }

            if (logInfo.logLine.Contains(player.Name + "に「アンブラルブリザード」の効果。"))
            {
                this.CurrentMPRecoveryStatus = MPRecoveryStatus.UmbralIce1;
            }

            if (logInfo.logLine.Contains(player.Name + "に「アンブラルブリザードII」の効果。"))
            {
                this.CurrentMPRecoveryStatus = MPRecoveryStatus.UmbralIce2;
            }

            if (logInfo.logLine.Contains(player.Name + "に「アンブラルブリザードIII」の効果。"))
            {
                this.CurrentMPRecoveryStatus = MPRecoveryStatus.UmbralIce3;
            }

            if (logInfo.logLine.Contains(player.Name + "に「賢人のバラード」の効果。"))
            {
                this.BalladEnabled = true;
            }

            if (logInfo.logLine.Contains(player.Name + "の「アストラルファイア」が切れた。") ||
                logInfo.logLine.Contains(player.Name + "の「アストラルファイアII」が切れた。") ||
                logInfo.logLine.Contains(player.Name + "の「アストラルファイアIII」が切れた。") ||
                logInfo.logLine.Contains(player.Name + "の「アンブラルブリザード」が切れた。") ||
                logInfo.logLine.Contains(player.Name + "の「アンブラルブリザードII」が切れた。") ||
                logInfo.logLine.Contains(player.Name + "の「アンブラルブリザードIII」が切れた。"))
            {
                this.CurrentMPRecoveryStatus = MPRecoveryStatus.Normal;
            }

            if (logInfo.logLine.Contains(player.Name + "の「賢人のバラード」が切れた。"))
            {
                this.BalladEnabled = false;
            }
        }
    }
}
