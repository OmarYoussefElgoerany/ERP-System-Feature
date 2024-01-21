using ErpSystemFeatureBLL.DTOs.CustomerDto;
using ErpSystemFeatureDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureBLL.Mapping
{
    public static class MapCustomer
    {
        public static CustomerPaginationDto CustomerPagination(List<ReadCustomerDto> customerReadDtos, int count)
        {
            CustomerPaginationDto customerPagination = new CustomerPaginationDto();
            customerPagination.CustomerDtos = customerReadDtos;
            customerPagination.TotalCount = count;
            return customerPagination;
        }
        public static Customer ToCustomer(AddCustomerDto customerDto)
        {
            Customer customer = new Customer();
            customer.Name = customerDto.Name;
            customer.Address = customerDto.Address;
            customer.Residance = customerDto.Residance;
            customer.CustomerRating = customerDto.CustomerRating;
            customer.EmployeeId =customerDto.EmployeeId;
            customer.Job = customerDto.Job;
            customer.Mobile = customerDto.Mobile;
            customer.DateAdded = customerDto.DateAdded;
            customer.Nationality = customerDto.Nationality;
            customer.Whatsapp = customerDto.Whatsapp;
            customer.LastEdit = customerDto.LastEdit;
            return customer;
        }

        public static Customer ToCustomerWithID(ReadCustomerDto customerDto)
        {
            Customer customer = new Customer();
            customer.Id = customerDto.Id;
            customer.Name = customerDto.Name;
            customer.Address = customerDto.Address;
            customer.Residance = customerDto.Residance;
            customer.CustomerRating = customerDto.CustomerRating;
            customer.EmployeeId = customerDto.EmployeeId;
            customer.Job = customerDto.Job;
            customer.Mobile = customerDto.Mobile;
            customer.DateAdded = customerDto.DateAdded;
            customer.Nationality = customerDto.Nationality;
            customer.Whatsapp = customerDto.Whatsapp;
            customer.LastEdit = customerDto.LastEdit;
            return customer;
        }

        public static List<ReadCustomerDto> ToCustomerDto(List<Customer> customers)
        {
            return customers.Select(i => new ReadCustomerDto
            {
                Id = i.Id,
                Name = i.Name,
                Mobile = i.Mobile,
                Residance = i.Residance,
                DateAdded = i.DateAdded,
                Job = i.Job,
                Address = i.Address,
                Nationality = i.Nationality,
                LastEdit = i.LastEdit,
                CustomerRating = i.CustomerRating,
                Whatsapp = i.Whatsapp,
                EmployeeId = i.EmployeeId
            }).ToList();
        }
        public static ReadCustomerDto ToCustomerDto(Customer customer)
        {
            ReadCustomerDto customerDto = new ReadCustomerDto();
            customerDto.Id = customer.Id;
            customerDto.Name = customer.Name;
            customerDto.Address = customer.Address;
            customerDto.Residance = customer.Residance;
            customerDto.CustomerRating = customer.CustomerRating;
            customerDto.EmployeeId = customer.EmployeeId;
            customerDto.Job = customer.Job;
            customerDto.Mobile = customer.Mobile;
            customerDto.DateAdded = customer.DateAdded;
            customerDto.Nationality = customer.Nationality;
            customerDto.Whatsapp = customer.Whatsapp;
            customerDto.LastEdit = customer.LastEdit;
            return customerDto;
        }
    }
}
