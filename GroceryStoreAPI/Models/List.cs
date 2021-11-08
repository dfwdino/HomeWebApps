using System;
using System.Collections.Generic;

#nullable disable

namespace GroceryStoreAPI.Models
{
    public partial class List
    {
        public int ListId { get; set; }
        public int FoodItemId { get; set; }
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public bool GotItem { get; set; }
        public bool ShowOnAllLists { get; set; }

        public virtual Item FoodItem { get; set; }
        public virtual Store Store { get; set; }
    }
}
