using Models.Data;
using Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        VmAddCustomerResponse Add(VmAddCustomerRequest VM);
        VmCustomerList GetAllCustomers(Page Page);
        Customer GetCusotomersByID(int ID);
        VmDeleteCustomerResponse Delete(VmDeleteCustomerRequest VM);
        VmUpdateCustomerResponse Ediit(VmUpdateCustomerRequest VM);
    }
}
