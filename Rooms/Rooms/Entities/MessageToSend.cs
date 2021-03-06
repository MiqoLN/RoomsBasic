using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Rooms.Entities
{
    public class MessageToSend
    {
        [Required]
        public int userId { get; set; }
        [Required]
        public int roomId { get; set; }
        [StringLength(300)]
        public string message { get; set; }
    }
}
