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
    
    public partial class ModelImage
    {
        public int ModelImageID { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageFile { get; set; }
        public Nullable<int> ModelPersonID { get; set; }
    
        public virtual ModelPeople ModelPeople { get; set; }
    }
}
