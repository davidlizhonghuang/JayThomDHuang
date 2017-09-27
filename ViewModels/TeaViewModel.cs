using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebJayThomDhuang.ViewModels
{
    public class TeaViewModel
    {
        [Key]
        public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string Image { get; set; }
            public int CategoryID { get; set; }
        
    }
}