
using AppointmentService.Contracts.v1.Requests.Create;
using AppointmentService.Contracts.v1.Requests.Select;
using AppointmentService.Contracts.v1.Responses;
using AppointmentService.Domain.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Services.v1.Interface
{
    public interface IAdvertiesService
    {
        Task<List<AdvertiesResponse>> GetAll(SelectActiveAdvertiesRequest selectActiveAdvetiesRequest);
        Task<Adverties> GetById(int Id);
        Task<bool> Create(Adverties adverties);
        Task<bool> Update(Adverties adverties);
        Task<bool> Delete(int Id);

    }
}
