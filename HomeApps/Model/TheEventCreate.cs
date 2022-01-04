using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeApps.Models
{
    public class TheEventCreate : TheEvent
    {

        [DisplayName("Date Of Event")]
        public new System.DateTime DateOfEvent { get; set; }

        public new System.DateTimeOffset DateofEventOffSet { get; set; }

        [DisplayName("Event Name?")]
        public new string EventName { get; set; }


        public IList<EventAction> EventActions { get; set; } 

        public TheEventCreate()
        {
            DateofEventOffSet = DateTimeOffset.Now;
            DateOfEvent = DateTime.Now;
        }
    }
}