using Business.Interfaces;
using DataAccessLayer.Interfaces;
using Models.Data;
using Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CustomerService : ICustomerService
    {



        private readonly IUnitOfWork UnitOfWork;
        public CustomerService(IUnitOfWork UnitOfWork)
        {
            this.UnitOfWork = UnitOfWork;
        }

        public VmAddCustomerResponse Add(VmAddCustomerRequest VM)
        {
            VmAddCustomerResponse Res = new VmAddCustomerResponse();

            try
            {
                Customer Data = new Customer();
                Data.ID = (UnitOfWork.CustomerRepository.GetAll().Max(r => (Int32?)r.ID) ?? 0) + 1;
                Data.CustomerName = VM.CustomerName;
                Data.Class = VM.Class;
                Data.Phone = VM.Phone;
                Data.Email = VM.Email;
                Data.Comment = VM.Comment;
                UnitOfWork.CustomerRepository.Add(Data);
                this.UnitOfWork.Commit();
                Res.ID = Data.ID;
                return Res;
            }
            catch (Exception ex)
            {
                Res.ID = -1;
                return Res;
            }
        }

        public VmDeleteCustomerResponse Delete(VmDeleteCustomerRequest VM)
        {
            VmDeleteCustomerResponse Res = new VmDeleteCustomerResponse();

            try
            {
                Customer Data = UnitOfWork.CustomerRepository.FirstOrDefault(_ => _.ID == VM.ID);
             
                if(Data is not null)
                {
                    UnitOfWork.CustomerRepository.Remove(Data);
                    this.UnitOfWork.Commit();
                    Res.IsDeleted = true;
                }
                else
                {
                    Res.IsDeleted = false;
                }
                return Res;
            }
            catch (Exception ex)
            {
                Res.IsDeleted = false;
                return Res;
            }
        }

        public VmUpdateCustomerResponse Ediit(VmUpdateCustomerRequest VM)
        {
            VmUpdateCustomerResponse Res = new VmUpdateCustomerResponse();

            try
            {
                Customer Data = UnitOfWork.CustomerRepository.FirstOrDefault(_=>_.ID == VM.ID);
                Data.CustomerName = VM.CustomerName;
                Data.Class = VM.Class;
                Data.Phone = VM.Phone;
                Data.Email = VM.Email;
                Data.Comment = VM.Comment;
                this.UnitOfWork.Commit();
                Res.IsUpdated = true;
                return Res;
            }
            catch (Exception ex)
            {
                Res.IsUpdated = false;
                return Res;
            }
        }

        public VmCustomerList GetAllCustomers(Page Page)
        {
            try
            {
                var data = UnitOfWork.CustomerRepository.GetAll();

                bool IsEmpty = false;
                if (string.IsNullOrWhiteSpace(Page.Filter))
                {
                    IsEmpty = true;
                }
                var skipped = data.Where(r => IsEmpty || r.ID.ToString() == Page.Filter
                                || r.CustomerName.Contains(Page.Filter)
                                || r.Email.Contains(Page.Filter)
                                || r.Phone.Contains(Page.Filter)
                                || r.Comment.Contains(Page.Filter)
                                || r.Class.Contains(Page.Filter)).ToList();

                Page.TotalElements = skipped.Count();

                switch (Page.OrderBy)
                {

                    case "idasc":
                        skipped = skipped.OrderBy(r => r.ID).ToList();
                        break;
                    case "iddesc":
                        skipped = skipped.OrderByDescending(r => r.ID).ToList();
                        break;

                    case "customerNameasc":
                        skipped = skipped.OrderBy(r => r.CustomerName).ToList();
                        break;
                    case "customerNamedesc":
                        skipped = skipped.OrderByDescending(r => r.CustomerName).ToList();
                        break;
                    case "emailNameasc":
                        skipped = skipped.OrderBy(r => r.Email).ToList();
                        break;
                    case "emaildesc":
                        skipped = skipped.OrderByDescending(r => r.Email).ToList();
                        break;
                    case "phoneasc":
                        skipped = skipped.OrderBy(r => r.Phone).ToList();
                        break;
                    case "phonedesc":
                        skipped = skipped.OrderByDescending(r => r.Phone).ToList();
                        break;
                    case "commentasc":
                        skipped = skipped.OrderBy(r => r.Comment).ToList();
                        break;
                    case "commentdesc":
                        skipped = skipped.OrderByDescending(r => r.Comment).ToList();
                        break;
                    case "classasc":
                        skipped = skipped.OrderBy(r => r.Class).ToList();
                        break;
                    case "classdesc":
                        skipped = skipped.OrderByDescending(r => r.Class).ToList();
                        break;

                    default:
                        skipped = skipped.OrderBy(r => r.ID).ToList();
                        break;
                }

                VmCustomerList VmCusData = new VmCustomerList();
                skipped = skipped.Take((Page.PageNumber + 1) * Page.Size).Skip((Page.PageNumber) * Page.Size).ToList();
                VmCusData.Data = skipped;

                if (skipped.Count > 0)
                    VmCusData.Page = Page;

                return VmCusData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public Customer GetCusotomersByID( int ID)
        {
            try
            {
                var customer = UnitOfWork.CustomerRepository.FirstOrDefault(_=>_.ID == ID);
                return customer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
