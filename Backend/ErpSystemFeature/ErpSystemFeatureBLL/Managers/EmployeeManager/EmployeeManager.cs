using ErpSystemFeatureBLL.DTOs.EmployeeDto;
using ErpSystemFeatureBLL.Mapping;
using ErpSystemFeatureDAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureBLL.Managers.CustomerManager
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public List<EmployeeDto>? GetAll()
        {
            var employees = unitOfWork.employeeRepo.GetAll();
            if (employees == null)
                return null;

            var empsDto = MapEmployee.ToEmployeeDto(employees);

            return empsDto;
        }

        public EmployeeDto? GetById(int id)
        {
           var emp = unitOfWork.employeeRepo.GetById(id);

            if (emp == null)
                return null;

            var employeeDto = MapEmployee.ToEmployeeDto(emp);

            return employeeDto;
        }
    }
}
