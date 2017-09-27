using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebJayThomDhuang.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public List<TeaViewModel> Teas { get; set; }
    }
}