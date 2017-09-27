using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebJayThomDhuang.ViewModels
{
    public class TeaFormViewModel
    {
        
            public HttpPostedFileBase File { get; set; }
            public string TeaTitle { get; set; }
            public string TeaDescription { get; set; }
            public decimal TeaPrice { get; set; }
            public int TeaCategory { get; set; }
        
    }
}