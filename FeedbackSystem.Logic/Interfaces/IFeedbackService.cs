﻿using FeedbackSystem.DataAccess.Entities;
using Shared.DTO;
using System.Collections.Generic;

namespace FeedbackSystem.Logic.Interfaces
{
    public interface IFeedbackService
    {
        void CreateFeedback(FeedbackDto feedbackDto);
        IEnumerable<FeedbackDto> GetAllFeedbacks();
        FeedbackDto GetFeedbackById(int id);
        bool Vote(VoteDto voteDto);

        void Dispose();
    }
}
