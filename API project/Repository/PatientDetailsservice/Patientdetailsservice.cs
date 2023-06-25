using api_project.Data;
using api_project.Models;
using Microsoft.EntityFrameworkCore;

namespace api_project.Repository.PatientDetailsservice
{
    public class Patientdetailsservice:IPatientdetailsservice
    {
        private RjHospitalContext _Context;
        public Patientdetailsservice(RjHospitalContext context)
        {
            _Context = context;
        }
        public async Task<List<PatientDetail>> GetPatientDetails()
        {
           var show2= await _Context.PatientDetails.ToListAsync();
            return show2;
        }
        public async Task<List<PatientDetail>> PostPatientDetail(PatientDetail patientDetail)
        {
            _Context.PatientDetails.Add(patientDetail);
            await _Context.SaveChangesAsync();
            return await _Context.PatientDetails.ToListAsync();

        }
        public async Task<String> DeletePatientDetail(int id)
        {
            var course = await _Context.PatientDetails.FirstOrDefaultAsync(x => x.PatientId == id);
            _Context.Remove(course);
            _Context.SaveChanges();
            return "Deleted Successfully";
        }
    }
}
