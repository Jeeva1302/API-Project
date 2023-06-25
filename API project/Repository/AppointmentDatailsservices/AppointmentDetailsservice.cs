using api_project.Data;
using api_project.Models;
using Microsoft.EntityFrameworkCore;

namespace api_project.Repository.AppointmentDatailsservices
{
    public class AppointmentDetailsservice: IAppointmentDetailsservice
    {

        private RjHospitalContext _Context;
        public AppointmentDetailsservice(RjHospitalContext context)
        {
            _Context=context;
        }
        public async Task<List<AppointmentDetail>> GetAppointmentDetails()
        {
            var detail = await _Context.AppointmentDetails.ToListAsync();
            return detail;
        }
       
    }
}
