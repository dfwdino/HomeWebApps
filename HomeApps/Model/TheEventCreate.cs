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
        private DateTimeOffset dateofEventOffSet;

        [DisplayName("Date Of Event")]
        public new DateTime DateOfEvent { get; set; }

        public new System.DateTimeOffset DateofEventOffSet { get => dateofEventOffSet; set => dateofEventOffSet = value; }

        [DisplayName("Event Name?")]
        public new string EventName { get; set; }


        public IList<EventAction> EventActions { get; set; }

        public TheEventCreate() => DateOfEvent = DateTime.Now;
    }
}