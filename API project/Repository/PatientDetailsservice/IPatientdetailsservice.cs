using api_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Repository.PatientDetailsservice
{
    public interface IPatientdetailsservice
    {
        Task<List<PatientDetail>> GetPatientDetails();

        Task<List<PatientDetail>> PostPatientDetail(PatientDetail patientDetail);

        Task<String> DeletePatientDetail(int id);
    }
}
