
using AppointmentService.Contracts.v1.Requests.Create;
using AppointmentService.Contracts.v1.Responses;
using AppointmentService.Domain.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Services.v1.Interface
{
    public interface IExpertService
    {
        Task<List<ExpertResponse>> GetAll();
        Task<ExpertResponse> GetById(int Id);
        Task<bool> Create(Expert expert);
        Task<bool> Update(Expert expert);
        Task<bool> Delete(int Id);
        Task<List<ExpertResponse>> GetAllBetterExpertise(CreateBetterExpertRequest createBetterExpertRequest);
        Task<List<ExpertResponse>> GetExpertsByExpertiseId(SelectExpertByExpertiseIdRequest selectExpertByExpertiseIdRequest);


    }
}
