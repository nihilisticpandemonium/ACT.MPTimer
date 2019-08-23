namespace ACT.MPTimer
{
    using System.Collections.Generic;

    /// <summary>
    /// ジョブ
    /// </summary>
    public class Job
    {
        /// <summary>
        /// JobId
        /// </summary>
        public int JobId { get; set; }

        /// <summary>
        /// JobName
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// ジョブリストを取得する
        /// </summary>
        /// <returns>
        /// ジョブリスト</returns>
        /// 
        public static Job[] GetJobList()
        {
            var list = new List<Job>();
            list.Add(new Job() { JobId = 0, JobName = string.Empty });
            list.Add(new Job() { JobId = 1, JobName = "GLA" });
            list.Add(new Job() { JobId = 2, JobName = "PGL" });
            list.Add(new Job() { JobId = 3, JobName = "MRD" });
            list.Add(new Job() { JobId = 4, JobName = "LNC" });
            list.Add(new Job() { JobId = 5, JobName = "ARC" });
            list.Add(new Job() { JobId = 6, JobName = "CNJ" });
            list.Add(new Job() { JobId = 7, JobName = "THM" });
            list.Add(new Job() { JobId = 8, JobName = "CRP" });
            list.Add(new Job() { JobId = 9, JobName = "BSM" });
            list.Add(new Job() { JobId = 10, JobName = "ARM" });
            list.Add(new Job() { JobId = 11, JobName = "GSM" });
            list.Add(new Job() { JobId = 12, JobName = "LTW" });
            list.Add(new Job() { JobId = 13, JobName = "WVR" });
            list.Add(new Job() { JobId = 14, JobName = "ALC" });
            list.Add(new Job() { JobId = 15, JobName = "CUL" });
            list.Add(new Job() { JobId = 16, JobName = "MIN" });
            list.Add(new Job() { JobId = 17, JobName = "BTN" });
            list.Add(new Job() { JobId = 18, JobName = "FSH" });
            list.Add(new Job() { JobId = 19, JobName = "PLD" });
            list.Add(new Job() { JobId = 20, JobName = "MNK" });
            list.Add(new Job() { JobId = 21, JobName = "WAR" });
            list.Add(new Job() { JobId = 22, JobName = "DRG" });
            list.Add(new Job() { JobId = 23, JobName = "BRD" });
            list.Add(new Job() { JobId = 24, JobName = "WHM" });
            list.Add(new Job() { JobId = 25, JobName = "BLM" });
            list.Add(new Job() { JobId = 26, JobName = "ACN" });
            list.Add(new Job() { JobId = 27, JobName = "SMN" });
            list.Add(new Job() { JobId = 28, JobName = "SCH" });
            list.Add(new Job() { JobId = 29, JobName = "ROG" });
            list.Add(new Job() { JobId = 30, JobName = "NIN" });
            list.Add(new Job() { JobId = 31, JobName = "MCH" });
            list.Add(new Job() { JobId = 32, JobName = "DRK" });
            list.Add(new Job() { JobId = 33, JobName = "AST" });
            list.Add(new Job() { JobId = 34, JobName = "SAM" });
            list.Add(new Job() { JobId = 35, JobName = "RDM" });
            list.Add(new Job() { JobId = 36, JobName = "BLU" });
            list.Add(new Job() { JobId = 37, JobName = "GNB" });
            list.Add(new Job() { JobId = 38, JobName = "DNC" });

            return list.ToArray();
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return this.JobName;
        }
    }
}
