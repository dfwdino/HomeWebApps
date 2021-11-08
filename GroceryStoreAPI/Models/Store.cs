using System;
using System.Collections.Generic;

#nullable disable

namespace GroceryStoreAPI.Models
{
    public partial class Store
    {
        public Store()
        {
            Lists = new HashSet<List>();
            Prices = new HashSet<Price>();
        }

        public int StoreId { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<List> Lists { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
