namespace ACT.MPTimer
{
    using System;

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
        /// MP回復スパンを監視する
        /// </summary>
        public void WacthMPRecovery()
        {
            var player = this.GetPlayer();

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

            var now = DateTime.Now;

            // MPが回復している？
            if (player.CurrentMP > this.PreviousMP)
            {
                this.LastRecoveryDateTime = now;
                this.NextRecoveryDateTime = this.LastRecoveryDateTime.AddSeconds(3d);
            }
            else
            {
                // 一旦満タンである？
                if (this.TimeOfRecovery <= 0)
                {
                    this.LastRecoveryDateTime = now;
                    this.NextRecoveryDateTime = this.LastRecoveryDateTime.AddSeconds(3d);
                }
            }

            // 回復までの残り時間を算出する
            var remain = (this.NextRecoveryDateTime - now).TotalMilliseconds;

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
