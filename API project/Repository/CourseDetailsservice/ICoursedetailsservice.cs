using api_project.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_project.Repository.CourseDetailsservice
{
    public interface ICoursedetailsservice
    {
        Task<List<CourseDetail>> GetCourseDetails();

        Task<List<CourseDetail>> PostCourseDetail(CourseDetail courseDetail);

        Task<String> DeleteCourseDetail(int id);

        Task<List<CourseDetail>> PutCourseDetail(int id, CourseDetail Coursedetails);
    }
}
