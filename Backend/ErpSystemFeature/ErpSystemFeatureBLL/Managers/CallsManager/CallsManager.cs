using ErpSystemFeatureBLL.DTOs.CallsDto;
using ErpSystemFeatureBLL.Mapping;
using ErpSystemFeatureDAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureBLL.Managers.CallsManager
{
    public class CallsManager : ICallsManager
    {
        private readonly IUnitOfWork unitOfWork;

        public CallsManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<ReadCallsDto>? GetAll()
        {
            var calls = unitOfWork.callsRepo.GetAll();
            if (calls == null)
                return null;
            var callsDto = MapCalls.ToCallsDto(calls);

            return callsDto;
        }

        public CallsPaginationDto? GetAllPerPage(int page, int countPerPage)
        {
            var calls = unitOfWork.callsRepo.GetAllPerPage(page ,countPerPage);
            if (calls == null)
                return null;
            var count = unitOfWork.callsRepo.GetCount();

            var callsDto = MapCalls.ToCallsDto(calls);

            var callsPagination = MapCalls.CallsPagination(callsDto, count);

            return callsPagination;
        }

        public bool isAdded(AddCallsDto callsDto)
        {
            if (callsDto == null)
                return false;
            var calls = MapCalls.ToCalls(callsDto);

            unitOfWork.callsRepo.Add(calls);
            var savings = unitOfWork.SaveChanges();
            if (savings <= 0)
                return false;
            return true;
        }
    }
}
