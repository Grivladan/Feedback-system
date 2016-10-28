using FeedbackSystem.DataAccess.Repository;
using FeedbackSystem.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedbackSystem.WebHost.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly FeedbackService _feedbackService;
        public FeedBackController(FeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public PartialViewResult GetAllFeedbacks()
        {
            var feedbacks = _feedbackService.GetAllFeedbacks();
            return PartialView(feedbacks);
        }
    }
}