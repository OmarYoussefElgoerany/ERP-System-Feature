using ErpSystemFeatureBLL.DTOs.CallsDto;
using ErpSystemFeatureDAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystemFeatureBLL.Mapping
{
    public static class MapCalls
    {
        public static CallsPaginationDto CallsPagination(List<ReadCallsDto> readCallsDtos , int count)
        {
            CallsPaginationDto callsPaginationDto = new CallsPaginationDto();
            callsPaginationDto.ReadCallsDto = readCallsDtos;
            callsPaginationDto.Count = count;
            return callsPaginationDto;
        }
        public static Calls ToCalls(AddCallsDto callsDto)
        {
            Calls calls = new Calls();
            calls.CallTitle = callsDto.CallTitle;
            calls.CallType = callsDto.CallType;
            calls.isDone = callsDto.isDone;
            calls.Date = callsDto.Date;
            calls.EmployeeName = callsDto.EmployeeName;
            calls.Project = callsDto.Project;
            calls.CustomerId = callsDto.CustomerId;
            return calls;
        }
        public static List<ReadCallsDto> ToCallsDto(List<Calls> calls)
        {
            return calls.Select(i => new ReadCallsDto
            {
                isDone = i.isDone,
                CallTitle = i.CallTitle,
                EmployeeName = i.EmployeeName,
                Date = i.Date,
                Project = i.Project,
                CallType = i.CallType,
                CustomerId = i.CustomerId ,
                Id = i.Id
            }).ToList();
        }
    }
}
