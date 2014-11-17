namespace ACT.MPTimer
{
    using System;

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
        /// 直前のTP
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
                return;
            }

            var now = DateTime.Now;

            // MPが回復している？
            if (player.CurrentMP > this.PreviousMP)
            {
                this.LastRecoveryDateTime = now;
                this.NextRecoveryDateTime = this.LastRecoveryDateTime.AddSeconds(3);
            }

            // 回復までの残り時間を算出する
            this.TimeOfRecovery = (this.NextRecoveryDateTime - now).Milliseconds;

            // 回復までの残り時間の割合を算出する
            this.RateOfRecovery = this.TimeOfRecovery >= 0 ?
                (decimal)this.TimeOfRecovery / 3000m :
                0m;

            // 現在のMPを保存する
            this.PreviousMP = player.CurrentMP;
        }
    }
}
