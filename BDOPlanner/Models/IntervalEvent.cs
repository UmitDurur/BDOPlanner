using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOPlanner.Models
{

    public class IntervalEvent : IEvent
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime LastCompletion { get; set; }
        public int Interval { get; set; }
        public string ImageURL { get; set; }
    }

}
