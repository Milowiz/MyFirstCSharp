using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Items
{
    public class BaseItem
    {
        string[] Category { get; set; }
        ushort Price { get; set; }
        public BaseItem(string[] category, ushort price)
        {
            Category = category;
            Price = price;
        }
    }
    
  
    
}