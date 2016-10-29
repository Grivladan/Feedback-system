using AutoMapper;
using FeedbackSystem.DataAccess.Entities;
using FeedbackSystem.DataAccess.Interfaces;
using FeedbackSystem.Logic.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shared.DTO;
using System;
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

        public void CreateFeedback(FeedbackDto feedbackDto)
        {
            Feedback feedback = new Feedback
            {
                Text = feedbackDto.Text,
                Date = DateTime.Now,
                OwnerId = feedbackDto.OwnerId,
                Owner = _unitOfWork.UserManager.FindById(feedbackDto.OwnerId)
            };

            _unitOfWork.Feedbacks.Create(feedback);
            _unitOfWork.Save();
        }

        public IEnumerable<FeedbackDto> GetAllFeedbacks()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Feedback, FeedbackDto>());
            return Mapper.Map<IEnumerable<Feedback>, List<FeedbackDto>>(_unitOfWork.Feedbacks.GetAll());
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
