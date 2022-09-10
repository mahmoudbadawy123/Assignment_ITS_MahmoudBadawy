using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Data
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        public string CustomerName { get; set; }

        [MaxLength(1)]
        public string Class { get; set; }
        [MaxLength(12) , Phone]
        public string Phone { get; set; }
        [MaxLength(50) , EmailAddress]
        public string Email { get; set; }
        public string Comment { get; set; }
    }
}
