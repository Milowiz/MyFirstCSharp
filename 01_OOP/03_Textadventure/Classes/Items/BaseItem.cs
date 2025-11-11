using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;



namespace Items
{
    public class BaseItem
    {
        public virtual string ItemName => new string("None") ;
        public virtual ushort Price => 0;
        public virtual bool IsUsed { get; set; } =  false;
        string[] Category { get; set; }

        public BaseItem(string[] category)
        {
            Category = category;
        }
        
        public virtual void Use()
        {
            IsUsed = true;
        }

    }
    
  
    
}