using System;
using FeedbackSystem.DataAccess.Interfaces;

namespace FeedbackSystem.DataAccess.Entities
{
    public class Vote : IEntity
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }
        public int FeedbackId { get; set; }
        public virtual Feedback Feedback { get; set; } 
        public DateTime Date { get; set; }
        public bool isLike { get; set; }

        public Vote()
        {
            Date = DateTime.Now;
        }
    }
}
