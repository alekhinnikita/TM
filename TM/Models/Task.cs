using System;

namespace TM.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Project Project { get; set; }
        public User Author { get; set; }
        public User Executor { get; set; }
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime End { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
    }

    public enum Status
    {
        New,
        InProgress,
        Done,
        Reject,
    }
}
