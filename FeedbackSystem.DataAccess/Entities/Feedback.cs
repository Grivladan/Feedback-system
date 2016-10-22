using System;
using FeedbackSystem.DataAccess.Interfaces;

namespace FeedbackSystem.DataAccess.Entities
{
    class Feedback : IEntity
    {
        public int Id { get; set; }
        public DateTime Date{get;set;}
        public string Text{get; set;}

        public int OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }

        public Feedback()
        {
            Date = DateTime.Now;
        }
    }
}
