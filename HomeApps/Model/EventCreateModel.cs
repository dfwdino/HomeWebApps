using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeApps.Models
{
    public class EventCreateModel
    {
        public string DateOfEvent { get; set; } = DateTime.Now.ToShortDateString();

        public string EventName { get; set; }

        public List<EventActionModel> EventActions { get; set; }


    }

    public class EventActionModel
    {
        public string GivingPersonID { get; set; }

        public string ReveivingPersonID { get; set; }

        public List<string> ActionID { get; set; }
    }
}