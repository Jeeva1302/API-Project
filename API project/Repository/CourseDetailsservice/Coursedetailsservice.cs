using api_project.Data;
using api_project.Models;
using Microsoft.EntityFrameworkCore;

namespace api_project.Repository.CourseDetailsservice
{
    public class Coursedetailsservice:ICoursedetailsservice
    {
        private RjHospitalContext _Context;
        public Coursedetailsservice(RjHospitalContext context)
        {
            _Context = context;
        }
        public async Task<List<CourseDetail>> GetCourseDetails()
        {


            var show = await _Context.CourseDetails.ToListAsync();
            return show;
          
        }
        public async Task<List<CourseDetail>> PostCourseDetail(CourseDetail courseDetail)
        {
            _Context.CourseDetails.Add(courseDetail);
            await _Context.SaveChangesAsync();
            return await _Context.CourseDetails.ToListAsync();
        }

        public async Task<String> DeleteCourseDetail(int id)
        {
            var course = await _Context.CourseDetails.FirstOrDefaultAsync(x => x.CourseId == id);
            _Context.Remove(course);
            _Context.SaveChanges();
            return "Deleted Successfully";
        }

        public async Task<List<CourseDetail>> PutCourseDetail(int id, CourseDetail Coursedetails)
        {
            var Cus = await _Context.CourseDetails.FirstOrDefaultAsync(x => x.CourseId == id);
            Cus.Fees = Coursedetails.Fees;
            await _Context.SaveChangesAsync();
            return await _Context.CourseDetails.ToListAsync() ; 
          

        }
    }
}
