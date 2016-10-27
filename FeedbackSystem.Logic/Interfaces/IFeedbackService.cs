using FeedbackSystem.DataAccess.Entities;
using System.Collections.Generic;

namespace FeedbackSystem.Logic.Interfaces
{
    public interface IFeedbackService
    {
        void CreateFeedback(Feedback feedback);
        IEnumerable<Feedback> GetAllFeedbacks();
        void LikeFeedback(int id);
        void DislikeFeedback(int id);

        void Dispose();
    }
}
