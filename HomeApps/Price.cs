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
    
    public partial class Price
    {
        public int PriceID { get; set; }
        public decimal Price1 { get; set; }
        public int StoreID { get; set; }
        public int FoodItemID { get; set; }
        public System.DateTime PriceDate { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Store Store { get; set; }
    }
}
