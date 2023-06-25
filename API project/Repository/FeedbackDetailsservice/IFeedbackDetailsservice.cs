namespace api_project.Repository.FeedbackDetailsservice
{
    public interface IFeedbackDetailsservice
    {
        Task<String> DeleteFeedbackDetail(int id);
    }
}
