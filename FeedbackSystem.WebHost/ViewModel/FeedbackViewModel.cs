using FeedbackSystem.DataAccess.Entities;
using System;

namespace FeedbackSystem.WebHost.ViewModel
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
    }
}