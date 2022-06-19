using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeApps.Model
{
    public class WeightTrackerViewModel
    {
        public List<WeightTracker> BodyWeights { get; set; }
        public Nullable<decimal> MaxWeight { get; set; } 
        public Nullable<decimal> MiniWeight { get; set; }
        public string FirstName { get; set; }
    }
}