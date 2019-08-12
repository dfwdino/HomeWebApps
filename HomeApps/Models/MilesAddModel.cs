using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HomeApps.Models
{
    public class MilesAddModel
    {
        public int AutoID { get; set; }
        [DisplayName("Gas Date")]
        public System.DateTime GasDate { get; set; }
        [DisplayName("Total Gallons")]
        public Nullable<decimal> TotalGallons { get; set; }
        [DisplayName("Total Price")]
        public Nullable<decimal> TotalPrice { get; set; }
        [DisplayName("Total Miles Driven")]
        public Nullable<decimal> TotalMilesDriven { get; set; }
        [DisplayName("Engine Run Time")]
        public Nullable<System.TimeSpan> EngineRunTime { get; set; }
        [DisplayName("Station")]
        public int StationID { get; set; }

        public virtual Station Station { get; set; }

    }
}