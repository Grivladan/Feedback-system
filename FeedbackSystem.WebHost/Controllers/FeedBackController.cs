using AutoMapper;
using FeedbackSystem.DataAccess.Entities;
using FeedbackSystem.DataAccess.Repository;
using FeedbackSystem.Logic.Services;
using FeedbackSystem.WebHost.ViewModel;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace FeedbackSystem.WebHost.Controllers
{
    public class FeedBackController : Controller
    {
        private readonly FeedbackService _feedbackService;
        public FeedBackController(FeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetAllFeedbacks()
        {
            var feedbackDtos = _feedbackService.GetAllFeedbacks();
            Mapper.Initialize( cfg => cfg.CreateMap<FeedbackDto, FeedbackViewModel>());
            var feedbacks = Mapper.Map<IEnumerable<FeedbackDto>, List<FeedbackViewModel>>(feedbackDtos);
            return PartialView(feedbacks);
        }

        [HttpPost]
        public ActionResult Create(FeedbackViewModel feedback)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<FeedbackViewModel, FeedbackDto>());
            var feedbackDto = Mapper.Map<FeedbackViewModel, FeedbackDto>(feedback);
            feedbackDto.OwnerId = User.Identity.GetUserId();
            _feedbackService.CreateFeedback(feedbackDto);
            ModelState.Clear();
            return View("Index");
        }

        [HttpPost]
        public ActionResult Vote(bool voteValue, int feedbackId)
        {
            VoteViewModel voteViewModel = new VoteViewModel
            {
                Value = voteValue,
                FeedbackId = feedbackId,
                OwnerId = User.Identity.GetUserId()
            };

            Mapper.Initialize(cfg => cfg.CreateMap<VoteViewModel, VoteDto>());
            var voteDto = Mapper.Map<VoteViewModel, VoteDto>(voteViewModel);
            _feedbackService.Vote(voteDto);

            return View("Index");
        }
    }
}