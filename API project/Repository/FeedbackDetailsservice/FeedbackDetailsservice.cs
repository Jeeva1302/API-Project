using api_project.Data;
using Microsoft.EntityFrameworkCore;

namespace api_project.Repository.FeedbackDetailsservice
{
    public class FeedbackDetailsservice:IFeedbackDetailsservice
    {
        private RjHospitalContext _Context;
        public FeedbackDetailsservice(RjHospitalContext context)
        {
            _Context = context;
        }
        public async Task<String> DeleteFeedbackDetail(int id)
        {
            var course = await _Context.FeedbackDetails.FirstOrDefaultAsync(x => x.PatientId == id);
            _Context.Remove(course);
            _Context.SaveChanges();
            return "Deleted Successfully";
        }
    }
}
