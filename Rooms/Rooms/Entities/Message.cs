using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rooms.Entities
{
    public class Message
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int roomId { get; set; }
        [StringLength(300)]
        public string message { get; set; }
        [Required]
        public User user { get; set; }
        [Required]
        public Room room { get; set; }
    }
}
