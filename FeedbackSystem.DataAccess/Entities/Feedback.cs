using System;
using FeedbackSystem.DataAccess.Interfaces;
using System.Collections.Generic;

namespace FeedbackSystem.DataAccess.Entities
{
    public class Feedback : IEntity
    {
        public int Id { get; set; }
        public DateTime Date{get;set;}
        public string Text{get; set;}
        public int Rating { get; set; }

        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }
        public virtual ICollection<Vote> Likes { get; set; }

        public Feedback()
        {
            Date = DateTime.Now;
            Likes = new List<Vote>();
        }
    }
}
