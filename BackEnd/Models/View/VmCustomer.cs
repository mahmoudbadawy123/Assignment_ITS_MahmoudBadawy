using Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.View
{

    public class VmCustomerList
    {
    
        public List<Customer> Data { get; set; }
        public Page Page { get; set; }
    }

    public class VmCustomer
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string CustomerName { get; set; }

        [MaxLength(1)]
        public string Class { get; set; }
        [MaxLength(12) , Phone]
        public string Phone { get; set; }
        [MaxLength(50), EmailAddress]
        public string Email { get; set; }
        public string Comment { get; set; }
    }



    public class VmAddCustomerRequest
    {

        [MaxLength(50)]
        public string CustomerName { get; set; }

        [MaxLength(1)]
        public string Class { get; set; }
        [MaxLength(12), Phone]
        public string Phone { get; set; }
        [MaxLength(50), EmailAddress]
        public string Email { get; set; }
        public string Comment { get; set; }
    }


    public class VmAddCustomerResponse
    {
        public int ID { get; set; }
    }


    public class VmUpdateCustomerRequest
    {
        public int ID { get; set; }

        [MaxLength(50)]
        public string CustomerName { get; set; }

        [MaxLength(1)]
        public string Class { get; set; }
        [MaxLength(12), Phone]
        public string Phone { get; set; }
        [MaxLength(50), EmailAddress]
        public string Email { get; set; }
        public string Comment { get; set; }
    }


    public class VmUpdateCustomerResponse
    {
        public bool IsUpdated { get; set; }
    }


    public class VmDeleteCustomerRequest
    {
        public int ID { get; set; }
    }

    public class VmDeleteCustomerResponse
    {
        public bool IsDeleted { get; set; }
    }

}
