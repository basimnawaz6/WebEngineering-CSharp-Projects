using System;

namespace FeedBackWithUI.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public int Rating { get; set; }
        public DateTime DateSubmitted { get; set; } = DateTime.Now;
    }
}