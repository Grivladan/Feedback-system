using System;

namespace FeedbackSystem.WebHost.ViewModel
{
    public class VoteViewModel
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public int FeedbackId { get; set; }
        public DateTime Date { get; set; }
        public bool Value { get; set; }
    }
}