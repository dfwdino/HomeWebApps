//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeApps
{
    using System;
    using System.Collections.Generic;
    
    public partial class Auto
    {
        public int AutoID { get; set; }
        public bool Deleted { get; set; }
        public int ModfiyID { get; set; }
        public string AutoName { get; set; }
        public int UserID { get; set; }
    
        public virtual CreateModifyLog CreateModifyLog { get; set; }
        public virtual User User { get; set; }
    }
}
