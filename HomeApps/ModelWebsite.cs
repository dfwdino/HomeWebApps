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
    
    public partial class ModelWebsite
    {
        public int ModelWebsitesID { get; set; }
        public int WebsiteID { get; set; }
        public int CameraModelID { get; set; }
    
        public virtual Website Website { get; set; }
        public virtual CameraModel CameraModel { get; set; }
    }
}
