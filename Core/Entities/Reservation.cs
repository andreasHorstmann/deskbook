using System;

namespace Core.Entities
{
    public class Reservation : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Desk Desk { get; set; }
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public Interval Interval { get; set; }
        public int Repeated { get; set; }
        public int Hours { get; set; }
        public int Start { get; set; }
        
    }
}