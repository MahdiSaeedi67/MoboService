using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentService.Contracts.v1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Expert
        {
            public const string GetAll = Base + "/Expert";
            public const string Get = Base + "/Expert/{Id}";
            public const string Create = Base + "/Expert";
            public const string Update = Base + "/Expert/{Id}";
            public const string Delete = Base + "/Expert/{Id}";
            public const string GetAllBetterExpert = Base + "/BetterExpert";
            public const string GetExpertsByExpertiseId = Base + "/ExpertsByExpertiseId";
            
        }

        public static class Expertise
        {
            public const string GetAll = Base + "/Expertise";
            public const string Get = Base + "/Expertise/{Id}";
            public const string Create = Base + "/Expertise";
            public const string Update = Base + "/Expertise/{Id}";
            public const string Delete = Base + "/Expertise/{Id}";
            public const string GetAllExpertiseByParentId = Base + "/ExpertiseByParentId";
        }

        public static class Adverties
        {
            public const string GetAll = Base + "/Adverties";
            public const string Get = Base + "/Adverties/{Id}";
            public const string Create = Base + "/Adverties";
            public const string Update = Base + "/Adverties/{Id}";
            public const string Delete = Base + "/Adverties/{Id}";
        }

        public static class Appointment
        {
            //public const string GetAll = Base + "/Appointment";
            public const string Get = Base + "/Appointment/{Id}";
            public const string Create = Base + "/Appointment";
            public const string Update = Base + "/Appointment/{Id}";
            public const string Delete = Base + "/Appointment/{Id}";
            public const string GetFreeAppointmentDateByExpertID = Base + "/FreeAppointmentDate";
            public const string GetAppointmentTimeByExpertID = Base + "/AppointmentTime";
            public const string GetAppointmentTypeByExpertID = Base + "/AppointmentType";
            public const string GetAppointmentByCustomerID = Base + "/AppointmentByCustomerId";
            public const string SetAppointment = Base + "/SetAppointment";
        }
        //public static class MeetingPerson
        //{
        //    public const string GetAll = Base + "/MeetingPerson";
        //    public const string GetByMeetingId = Base + "/MeetingPerson/MeetingId/{MeetingId}";
        //    public const string Get = Base + "/MeetingPerson/{Id}";
        //    public const string Create = Base + "/MeetingPerson";
        //    public const string Update = Base + "/MeetingPerson/{Id}";
        //    public const string Delete = Base + "/MeetingPerson/{Id}";
        //    public const string Filter = Base + "/MeetingPerson/Filter";
        //}

        public static class InformationBase
        {
            //public const string BranchGetAll = Base + "/Branch";
            //public const string ReagentGetAll = Base + "/Reagent/{branch}";
            //public const string MeetingTypeGetAll = Base + "/MeetingType";
            public const string GetAllGetAllCountyByProvinceId = Base + "/CountyByProvinceId";

        }

        public static class Account
        {
            public const string Authenticate = Base + "/Account/Authenticate";
            public const string CurrentUser = Base + "/Account/CurrentUser";
            public const string GetOTP = Base + "/Account/GetOTP";
            public const string HasActiveOTP = Base + "/Account/HasActiveOTP";
            public const string RegisterOTP = Base + "/Account/RegisterOTP";
            public const string IsRegistered = Base + "/Account/IsRegistered";
            public const string Register = Base + "/Account/Register";
            public const string UpdatePassword = Base + "/Account/UpdatePassword";
            public const string UpdateUserInformation = Base + "/Account/UpdateUserInformation";

        }

        public static class User
        {
            public const string UpdateUserInformation = Base + "/User/UpdateUserInformation";
        }

        public static class Search
        {
            public const string search = Base + "/Search";
            public const string searchCity = Base + "/SearchCity";


        }
    }
}
