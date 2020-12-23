using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HomeApps.Models
{
    public class MilesViewModel
    {
        public List<MilesModel> Miles = new List<MilesModel>();
        public decimal MPG { get; set; }
        public decimal LastMiles { get; set; }
        public decimal MaxMiles { get; set; }
        public decimal MinMiles { get; set; }
        public decimal TotalGallons { get; set; }
        public decimal TotalMiles { get; set; }
        public DateTime Date30 { get; set; }
        public decimal Day30MaxMiles { get; set; }
        public decimal Day30MaxMinMiles { get; set; }
        public decimal Day30MaxTotalGallons { get; set; }
        public decimal Day30MaxTotalMiles { get; set; }

    }


    public class MilesModel
    {
        public int MilesID { get; set; }
        public bool Deleted { get; set; }
        public int ModfiyID { get; set; }
        public int AutoID { get; set; }
        public System.DateTime GasDate { get; set; }
        public decimal TotalGallons { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalMilesDriven { get; set; }

        public decimal MilesDrove { get; set; }

        public Nullable<System.TimeSpan> EngineRunTime { get; set; }
        public int StationID { get; set; }

        public virtual Station Station { get; set; }
        public virtual CreateModifyLog CreateModifyLog { get; set; }

        public virtual Type Type { get; set; }

        public int MPG { get; set; }
    }

}