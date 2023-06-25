using api_project.Data;
using api_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_project.Repository.DoctorDetailsservices
{
    public class DoctorDetailsservice: IDoctorDetailservice
    {
        private RjHospitalContext _Context;
        public DoctorDetailsservice(RjHospitalContext context)
        {
            _Context = context;
        }
        public async Task<List<DoctorsDetail>> GetDoctorsDetails()
        {
            var show=await _Context.DoctorsDetails.ToListAsync();
            return show;
        }

        public async Task<List<DoctorsDetail>>PostDoctorsDetail(DoctorsDetail doctorsDetail)
        {
            _Context.DoctorsDetails.Add(doctorsDetail);
            await _Context.SaveChangesAsync();  
            return await _Context.DoctorsDetails.ToListAsync();
        }

        public async Task <String> DeleteDoctorsDetail(int id)
        {
            var doc = await _Context.DoctorsDetails.FirstOrDefaultAsync(x => x.DoctorId == id);
            _Context.Remove(doc);
            _Context.SaveChanges();
            return "Deleted Successfully";

        }


    }
}

