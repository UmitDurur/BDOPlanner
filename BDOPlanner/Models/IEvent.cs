using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDOPlanner.Models
{
    public interface IEvent
    {
        int ID { get; set; }
        string Name { get; set; }
        DateTime LastCompletion { get; set; }
        string ImageURL { get; set; }
    }
}
