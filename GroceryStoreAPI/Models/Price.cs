using System;
using System.Collections.Generic;

#nullable disable

namespace GroceryStoreAPI.Models
{
    public partial class Price
    {
        public int PriceId { get; set; }
        public decimal Price1 { get; set; }
        public int StoreId { get; set; }
        public int FoodItemId { get; set; }
        public DateTime PriceDate { get; set; }

        public virtual Item FoodItem { get; set; }
        public virtual Store Store { get; set; }
    }
}
