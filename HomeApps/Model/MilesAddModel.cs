using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeApps.Models
{
    public class MilesAddModel
    {
        public int ModfiyID { get; set; }
        public int AutoID { get; set; }

        [Required]
        [DisplayName("Gas Date")]
        public System.DateTime GasDate { get; set; } = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));

        [Required]
        [DisplayName("Total Gallons")]
        public Nullable<decimal> TotalGallons { get; set; }

        [Required]
        [DisplayName("Total Price")]
        public Nullable<decimal> TotalPrice { get; set; }

        [Required]
        [DisplayName("Total Miles Driven")]
        public Nullable<decimal> TotalMilesDriven { get; set; }


        [DisplayName("Engine Run Time")]
        public Nullable<System.TimeSpan> EngineRunTime { get; set; }

        [Required]
        [DisplayName("Station")]
        public int StationID { get; set; }

        public virtual Station Station { get; set; }

        [Required]
        [DisplayName("Gas Type")]
        public int GasTypeID { get; set; }
        public virtual Type Type { get; set; }
    

    }
}