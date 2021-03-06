using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rooms.Entities
{
    public class Participant
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int roomId { get; set; }
        [Required]
        public User user { get; set; }
        [Required]
        public Room room { get; set; }
    }
}
