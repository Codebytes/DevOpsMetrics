﻿using System.Collections.Generic;

namespace DevOpsMetrics.Service.Models.Common
{
    public class ChangeFailureRateModel
    {
        public string DeploymentName { get; set; }
        public DevOpsPlatform TargetDevOpsPlatform { get; set; }
        public bool IsProjectView { get; set; }
        public int MaxNumberOfItems { get; set; }
        public int NumberOfDays { get; set; }
        public int TotalItems { get; set; }
        public List<ChangeFailureRateBuild> ChangeFailureRateBuildList { get; set; }
        public float ChangeFailureRateMetric { get; set; }
        public string ChangeFailureRateMetricDescription { get; set; }
    }
}