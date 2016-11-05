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

        public bool Vote(VoteDto voteDto)
        {
            var voteOwner = _unitOfWork.UserManager.FindById(voteDto.OwnerId);
            if (voteOwner.VotesCount <= 0)
                return false;
            voteOwner.VotesCount -= 1;
            _unitOfWork.UserManager.Update(voteOwner);

            var feedback = _unitOfWork.Feedbacks.GetById(voteDto.FeedbackId);

            Vote vote = new Vote(){
                Value = voteDto.Value,
                FeedbackId = voteDto.FeedbackId,
                Feedback = feedback, 
                OwnerId = voteDto.OwnerId,
                Owner = _unitOfWork.UserManager.FindById(voteDto.OwnerId)
            };

            if (vote.Value == true)
                feedback.Rating++;
            else
                feedback.Rating--;

            _unitOfWork.Votes.Create(vote);
            _unitOfWork.Feedbacks.Update(feedback);
            _unitOfWork.Save();

            return true;
        }

        public void Dispose()
        {
           _unitOfWork.Dispose();
        }


        public FeedbackDto GetFeedbackById(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Feedback, FeedbackDto>());
            return Mapper.Map<Feedback, FeedbackDto>(_unitOfWork.Feedbacks.GetById(id));
        }
    }
}
