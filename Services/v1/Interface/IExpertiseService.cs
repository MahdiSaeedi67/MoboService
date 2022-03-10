
using AppointmentService.Contracts.v1.Requests.Create;
using AppointmentService.Contracts.v1.Responses;
using AppointmentService.Domain.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Services.v1.Interface
{
    public interface IExpertiseService
    {
        Task<List<ExpertiseResponse>> GetAll();
        Task<Expertise> GetById(int Id);
        Task<bool> Create(Expertise expertise);
        Task<bool> Update(Expertise expertise);
        Task<bool> Delete(int Id);
        Task<List<ExpertiseResponse>> GetAllExpertiseByCategoryId(CreateExpertiseByCategoryIdRequest createExpertiseByCategoryIdRequest);


    }
}
