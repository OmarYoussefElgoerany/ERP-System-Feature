using ErpSystemFeatureBLL.DTOs.CustomerDto;
using ErpSystemFeatureBLL.Mapping;
using ErpSystemFeatureDAL.Data.Models;
using ErpSystemFeatureDAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureBLL.Managers.EmployeeManager
{
    public class CustomerManager : ICustomerManager
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public List<ReadCustomerDto>? GetAll()
        {
            var customers = unitOfWork.customerRepo.GetAll();

            if (customers == null)
                return null;
            var customerDto = MapCustomer.ToCustomerDto(customers);

            return customerDto;
        }

        public List<ReadCustomerDto>? GetAllPerPage(int page, int countPerPage)
        {
            var customers = unitOfWork.customerRepo.GetAllPerPage(page,countPerPage);

            if (customers == null)
                return null;

            var customerDto = MapCustomer.ToCustomerDto(customers);

            return customerDto;
        }

        public bool isAdded(AddCustomerDto customerDto)
        {
           if(customerDto == null) 
                return false;

            var customer = MapCustomer.ToCustomer(customerDto);

            unitOfWork.customerRepo.Add(customer);

            var saving = unitOfWork.SaveChanges();

            if (saving <= 0)
                return false;

            return true;
        }


        public bool isUpdated(ReadCustomerDto customerDto)
        {
            if (customerDto == null)
                return false;

            var customer = MapCustomer.ToCustomerWithID(customerDto);

            unitOfWork.customerRepo.isUpdated(customer);

            var saving = unitOfWork.SaveChanges();

            if (saving <= 0)
                return false;

            return true;
        }


        public bool isDeleted(int id)
        {
            if (id == 0)
                return false;

            var customer = unitOfWork.customerRepo.GetById(id);
            if (customer == null)
                return false;

            unitOfWork.customerRepo.isDeleted(customer);

            var saving = unitOfWork.SaveChanges();

            if (saving <= 0)
                return false;

            return true;
        }
    }
}
