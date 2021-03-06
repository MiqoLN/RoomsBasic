using Microsoft.AspNetCore.Mvc;
using Rooms.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rooms.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Messages()
        {
            var res = new List<Message>();
            using (var dbContext = new RoomsContext())
            {
                res = dbContext.Messages.ToList();
            }
            return Ok(res);
        }
        [HttpGet("{id}")]
        public IActionResult Messages([FromRoute] int id)
        {
            var res = new Message();
            using (var dbContext = new RoomsContext())
            {
                res = dbContext.Messages.Find(id);
                if (res == null)
                    return BadRequest();
            }
            return Ok(res);
        }
        [HttpPost("addmessage")]
        public IActionResult AddMessage([FromBody] MessageToSend message)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var messageToAdd = new Message();
            using (var dbContext = new RoomsContext())
            {
                var user = dbContext.Users.Find(message.userId);
                var room = dbContext.Rooms.Find(message.roomId);
                if (user == null || room == null)
                {
                    return BadRequest();
                }
                messageToAdd.message = message.message;
                messageToAdd.user = user;
                messageToAdd.room = room;
                messageToAdd.userId = user.id;
                messageToAdd.roomId = room.id;
                dbContext.Messages.Add(messageToAdd);
                dbContext.SaveChanges();
            }
            return Ok();
        }
        [HttpPut("change/{id}")]
        public IActionResult ChangeMessage([FromRoute] int id,[FromBody] MessageOnly mes)
        {
            using (var dbContext= new RoomsContext())
            {
                var message = dbContext.Messages.Find(id);
                if (message == null)
                    return BadRequest();
                message.message = mes.message;
                dbContext.Messages.Update(message);
                dbContext.SaveChanges();
            }
            return Ok();
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            using (var dbContext = new RoomsContext())
            {
                var messageToDelete = dbContext.Messages.Find(id);
                if (messageToDelete == null)
                    return BadRequest();
                dbContext.Messages.Remove(messageToDelete);
                dbContext.SaveChanges();
            }
            return Ok();
        }
    }
}
