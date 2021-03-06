using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rooms.Entities
{
    public class Room
    {
        public int id { get; set; }
        [StringLength(30)]
        public string name { get; set; }
        public bool type { get; set; }
        public ICollection<Participant> participants { get; set; }
        public ICollection<Message> messages { get; set; }


    }
}
