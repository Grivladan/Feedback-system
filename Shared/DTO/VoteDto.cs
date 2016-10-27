using System;

namespace Shared.DTO
{
    public class VoteDto
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public int FeedbackId { get; set; }
        public DateTime Date { get; set; }
        public bool isLike { get; set; }
    }
}
