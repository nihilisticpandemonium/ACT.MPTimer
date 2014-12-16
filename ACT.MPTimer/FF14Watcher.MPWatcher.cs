namespace ACT.MPTimer
{
    using System;
    using System.Collections.Generic;

    using ACT.MPTimer.Properties;

    /// <summary>
    /// FF14を監視する MPウォッチャー
    /// </summary>
    public partial class FF14Watcher
    {
        /// <summary>
        /// 回復までの残り割合
        /// </summary>
        public decimal RateOfRecovery { get; private set; }

        /// <summary>
        /// 回復までの時間(ミリ秒)
        /// </summary>
        public int TimeOfRecovery { get; private set; }

        /// <summary>
        /// 最後に回復した日時
        /// </summary>
        public DateTime LastRecoveryDateTime { get; private set; }

        /// <summary>
        /// 次に回復するであろう日時
        /// </summary>
        public DateTime NextRecoveryDateTime { get; private set; }

        /// <summary>
        /// 最後にMPが満タンになった日時
        /// </summary>
        public DateTime LastMPFullDateTime { get; private set; }

        /// <summary>
        /// プレイヤーがいるか？
        /// </summary>
        public bool ExistPlayer { get; private set; }

        /// <summary>
        /// 戦闘中？
        /// </summary>
        public bool InCombat { get; private set; }

        /// <summary>
        /// 直前のMP
        /// </summary>
        private int PreviousMP { get; set; }

        /// <summary>
        /// 状態別のMP回復値の辞書
        /// </summary>
        private Dictionary<string, int> MPRecoveryValueDictionary = new Dictionary<string, int>();

        /// <summary>
        /// MP回復スパンを監視する
        /// </summary>
        public void WacthMPRecovery()
        {
            FF14PluginHelper.RefreshPlayer();
            var player = FF14PluginHelper.GetPlayer();
            if (player == null)
            {
                this.ExistPlayer = false;
                return;
            }

            this.ExistPlayer = true;

            // ジョブ指定？
            if (Settings.Default.TargetJobId != 0)
            {
                this.ExistPlayer = player.Job == Settings.Default.TargetJobId;
                if (!this.ExistPlayer)
                {
                    return;
                }
            }

            // 戦闘中のみ稼働させる？
            if (Settings.Default.CountInCombat)
            {
                // MPが満タンになった？
                if (player.CurrentMP > this.PreviousMP &&
                    player.CurrentMP >= player.MaxMP)
                {
                    this.LastMPFullDateTime = DateTime.Now;
                }

                // 現在がMP満タン状態？
                if (player.CurrentMP >= player.MaxMP ||
                    this.PreviousMP < 0)
                {
                    // 前回の満タンから20秒以上経過した？
                    if ((DateTime.Now - this.LastMPFullDateTime).TotalSeconds >=
                        Settings.Default.CountInCombatSpan)
                    {
                        this.InCombat = false;
                    }
                }
                else
                {
                    this.InCombat = true;
                }
            }

            // プレイヤーのステータスを取得する
            var playerStatus = FF14PluginHelper.GetPlayerData();

            var now = DateTime.Now;

            // MPが回復している？
            if (player.CurrentMP > this.PreviousMP)
            {
                // 現在のプレイヤー状態を辞書向けのキーに変換する
                var key = playerStatus.Pie.ToString() + "-" + this.CurrentMPRecoveryStatus.ToString();

                // 今回で満タンではない？
                if (this.PreviousMP > -1 &&
                    player.CurrentMP < player.MaxMP)
                {
                    // 回復量を算出する
                    var mpRecoveryValue = player.CurrentMP - this.PreviousMP;

                    // バラード中ではなくアストラルファイア中でもない？
                    if (!this.BalladEnabled &&
                        this.CurrentMPRecoveryStatus != MPRecoveryStatus.AstralFire)
                    {
                        // 現在の状態の回復量を記録する
                        this.MPRecoveryValueDictionary[key] = mpRecoveryValue;
                    }

                    // 今の状態の回復量の辞書がある？
                    if (this.MPRecoveryValueDictionary.ContainsKey(key))
                    {
                        // アストラファイア中ではない？
                        if (this.CurrentMPRecoveryStatus != MPRecoveryStatus.AstralFire)
                        {
                            // 記録された回復量と今回の回復量が一致する？
                            if (mpRecoveryValue == this.MPRecoveryValueDictionary[key])
                            {
                                this.LastRecoveryDateTime = now;
                                this.NextRecoveryDateTime = this.LastRecoveryDateTime.AddSeconds(3d);
                            }
                        }
                    }
                }
            }

            // 回復までの残り時間を算出する
            var remain = (this.NextRecoveryDateTime - now).TotalMilliseconds;

            // 回復までの時間が過ぎている？
            if (remain <= 0.0d)
            {
                this.LastRecoveryDateTime = now.AddMilliseconds(remain);
                this.NextRecoveryDateTime = this.LastRecoveryDateTime.AddSeconds(3d);
            }

            if (remain < 0d)
            {
                remain = 0d;
            }

            this.TimeOfRecovery = Convert.ToInt32(remain);

            // 回復までの残り時間の割合を算出する
            this.RateOfRecovery = (decimal)(3000 - this.TimeOfRecovery) / 3000m;

            // 現在のMPを保存する
            this.PreviousMP = player.CurrentMP;
        }
    }
}
