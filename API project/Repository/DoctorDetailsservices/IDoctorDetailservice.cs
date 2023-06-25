using api_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Repository.DoctorDetailsservices
{
    public interface IDoctorDetailservice
    {
        Task<List<DoctorsDetail>> GetDoctorsDetails();

        Task<List<DoctorsDetail>>PostDoctorsDetail(DoctorsDetail doctorsDetail);

        Task<String> DeleteDoctorsDetail(int id);
    }
}
