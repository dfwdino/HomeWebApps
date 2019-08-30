using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeApps.Models
{
    public class MilesViewModel
    {
        public int MilesID { get; set; }
        public bool Deleted { get; set; }
        public int ModfiyID { get; set; }
        public int AutoID { get; set; }
        public System.DateTime GasDate { get; set; }
        public decimal TotalGallons { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal TotalMilesDriven { get; set; }
        public Nullable<System.TimeSpan> EngineRunTime { get; set; }
        public int StationID { get; set; }

        public virtual Station Station { get; set; }
        public virtual CreateModifyLog CreateModifyLog { get; set; }

        public int MPG { get; set; }
        
    }
}