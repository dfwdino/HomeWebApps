using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeApps.Models
{
    public class TheEventDetails : TheEvent
    {
        private DateTimeOffset dateofEventOffSet;

        [DisplayName("Date:")]
        public new string DateOfEvent { get; set; }

        public new System.DateTimeOffset DateofEventOffSet { get; set; }

        [DisplayName("Title")]
        public new string EventName { get; set; }

        public List<GroupAction> Actions { get; set; }

        public TheEventDetails()
        {
            Actions = new List<GroupAction>();
        }

    }

    public class GroupAction
    {
        public string Giving { get; set; }
        public string Recving { get; set; }
        public string Action { get; set; }
    }


}