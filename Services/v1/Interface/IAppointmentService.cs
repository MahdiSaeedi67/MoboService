
using AppointmentService.Contracts.v1.Requests.Create;
using AppointmentService.Contracts.v1.Requests.Select;
using AppointmentService.Contracts.v1.Requests.Update;
using AppointmentService.Contracts.v1.Responses;
using AppointmentService.Domain.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Services.v1.Interface
{
    public interface IAppointmentService
    {
        //Task<List<AppointmentResponse>> GetAll();
        Task<Appointment> GetById(int Id);
        Task<bool> Create(CreateAppointmentRequest createAppointmentRequest);
        Task<bool> Update(Appointment appointment);
        Task<bool> Delete(int Id);
        Task<List<AppointmentDateResponse>> GetFreeAppointmentDateByExpertID(SelectFreeAppointmentDateByExpertIdRequest selectFreeAppointmentDateByExpertIdRequest);
        Task<List<AppointmentTimeResponse>> GetAppointmentTimesByExpertID(SelectAppointmentTimeByExpertIdRequest selectAppointmentTimeByExpertIdRequest);
        Task<List<AppointmentTypeResponse>> GetAppointmentTypeByExpertID(SelectAppointmentTypeByExpertIdRequest selectAppointmentTypeByExpertIdRequest);
        Task<List<AppointmentResponse>> GetAppointmentByCustomerID(SelectAppointmentByCustomerIdRequest selectAppointmentByCustomerIdRequest);
        Task<bool> SetAppointment(UpdateSetAppointmentRequest updateSetAppointmentRequest);

    }
}
