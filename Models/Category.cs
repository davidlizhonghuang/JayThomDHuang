using System;
using System.Collections.Generic;

namespace WebJayThomDhuang.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public virtual List<Tea> Teas { get; set; }
        public Category()
        {
            DateCreated = DateTime.Now;
        }
    }
}