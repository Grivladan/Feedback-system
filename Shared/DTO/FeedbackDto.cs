﻿using FeedbackSystem.DataAccess.Entities;
using System;

namespace Shared.DTO
{
    public class FeedbackDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
    }
}
