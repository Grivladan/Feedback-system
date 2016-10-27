using FeedbackSystem.DataAccess.Entities;
using FeedbackSystem.DataAccess.Interfaces;
using FeedbackSystem.Logic.Interfaces;
using System.Collections.Generic;

namespace FeedbackSystem.Logic.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;
        public FeedbackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateFeedback(Feedback feedback)
        {
            
        }

        public IEnumerable<Feedback> GetAllFeedbacks()
        {
            var feedbacks = _unitOfWork.Feedbacks.GetAll();
            return feedbacks;
        }

        public void LikeFeedback(int id)
        {
            var feedback = _unitOfWork.Feedbacks.GetById(id);
            Vote like = new Vote(){
                FeedbackId = id,
                Feedback = feedback, 
                isLike = true
            };
            _unitOfWork.Likes.Create(like);
            _unitOfWork.Save();
        }

        public void DislikeFeedback(int id)
        {
            var feedback = _unitOfWork.Feedbacks.GetById(id);
            Vote like = new Vote()
            {
                FeedbackId = id,
                Feedback = feedback,
                isLike = false
            };
            _unitOfWork.Likes.Create(like);
            _unitOfWork.Save();
        }

        public void Dispose()
        {
           _unitOfWork.Dispose();
        }
    }
}
