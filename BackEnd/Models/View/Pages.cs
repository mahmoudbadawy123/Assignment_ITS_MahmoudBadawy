using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.View
{
    public class Page
    {
        [Required]
        public Int32 TotalElements { get; set; }
        [Required]
        public Int32 PageNumber { get; set; }
        [Required]
        public Int32 Size { get; set; }
        public string OrderBy { get; set; }
        public string Filter { get; set; }
    }
}
