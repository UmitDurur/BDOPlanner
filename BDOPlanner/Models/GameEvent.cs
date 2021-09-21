using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOPlanner.Models
{
    public class GameEvent
    {
        public int EventID { get; set; }
        public string Name { get; set; }
        public EventType Type { get; set; }
        public string ImageURL { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }

        public enum EventType
        {
            Boss = 0,
            War = 1
        }
    }
}
