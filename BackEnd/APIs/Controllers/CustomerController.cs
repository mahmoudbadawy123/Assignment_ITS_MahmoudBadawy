using Business.Interfaces;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Data;
using Models.View;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _CustomerService;
        private readonly IUnitOfWork _UnitOfWork;
        public CustomerController(ICustomerService CustomerService  , IUnitOfWork UnitOfWork)
        {
            this._CustomerService = CustomerService;
            this._UnitOfWork = UnitOfWork;
        }

        [HttpPost]
        [Route("Add")]
        public VmAddCustomerResponse Add_TEMP_DEFENDANTS(VmAddCustomerRequest Request)
        {
            var  Data = _CustomerService.Add(Request);
            //result.Message.Data.Content = Mapper.Map<VM_ONLINE_DEFENDANTS_Add_Response>(ResponseData);
            return Data;
        }


        [Route("GetAll")]
        [HttpPost]
        public VmCustomerList GetAll(Page Page)
        {
           var data =  _CustomerService.GetAllCustomers(Page);
           return data;
        }


        [Route("Delete")]
        [HttpPost]
        public VmDeleteCustomerResponse Delete(VmDeleteCustomerRequest Request)
        {
            VmDeleteCustomerResponse result = new VmDeleteCustomerResponse();
            result = _CustomerService.Delete(Request);
            return result;
        }

        [HttpPost]
        [Route("Update")]

        public VmUpdateCustomerResponse Update(VmUpdateCustomerRequest Request)
        {
            var result = _CustomerService.Ediit(Request);
            return result;
        }



        [Route("GetByID/{ID}")]
        [HttpPost]
        public Customer GetByID(int ID)
        {

            var data = _CustomerService.GetCusotomersByID(ID);
            return data;
        }

    }
}
