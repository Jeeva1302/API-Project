using api_project.Models;
using Microsoft.AspNetCore.Mvc;
using api_project;

namespace api_project.Repository.AppointmentDatailsservices
{
    public interface IAppointmentDetailsservice
    {
        Task<List<AppointmentDetail>> GetAppointmentDetails();
       
    }
}
