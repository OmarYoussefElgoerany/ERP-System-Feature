using ErpSystemFeatureBLL.DTOs.EmployeeDto;
using ErpSystemFeatureBLL.Managers.CustomerManager;
using ErpSystemFeatureDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureBLL.Mapping
{
    public static class MapEmployee
    {
        public static List<EmployeeDto> ToEmployeeDto(List<Employee> employees)
        {
            return employees.Select(i => new EmployeeDto
            {
                Id = i.Id,
                Name = i.Name,
                Title = i.Name
            }).ToList();
        }
        public static EmployeeDto ToEmployeeDto(Employee employee)
        {
            EmployeeDto employeeDto = new EmployeeDto();

            employeeDto.Id = employeeDto.Id;
            employeeDto.Name = employee.Name;
            employeeDto.Title = employee.Title;

            return employeeDto;
        }
    }
}
