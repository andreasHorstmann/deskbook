using System;

namespace Core.Entities
{
    public class Search : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rooms { get; set; }
        public int Desks { get; set; }
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public Interval Interval { get; set; } = Interval.OneTimeOnly;
        public int Repeated { get; set; }
        public int Hours { get; set; }
        public int Start { get; set; }
        
    }
}