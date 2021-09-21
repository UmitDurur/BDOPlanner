using System;

namespace BDOPlanner.Models
{
    public class DailyEvent : IEvent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime LastCompletion { get; set; }
        public string ImageURL { get; set; }
    }
}
