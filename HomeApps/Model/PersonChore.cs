

using System;

namespace HomeApps.Model
{
    public class PersonChore
    {
        public string PersonName { get; set; }

        public string ChoreName { get; set; }

        public Nullable<DateTime> ChoreDone { get; set; }

        public string ChoreTimeType { get; set; }
        public string ChoreDayTimeType { get; set; }

        public bool WeeklyDue { get; set; }

        public DateTime StartDateChore { get; set; }

        public int UserChoreID { get; set; }
    }
}

