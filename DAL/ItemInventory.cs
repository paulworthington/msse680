//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemInventory
    {
        public ItemInventory()
        {
            this.Items = new HashSet<Item>();
        }
    
        public int ItemInvID { get; set; }
        public Nullable<int> ItemID { get; set; }
    
        public virtual ICollection<Item> Items { get; set; }
    }
}
