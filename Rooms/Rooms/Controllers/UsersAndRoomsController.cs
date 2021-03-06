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
    public class UsersAndRoomsController : ControllerBase
    {
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var res = new List<User>();
            using (var dbContext = new RoomsContext())
            {
                res = dbContext.Users.ToList();
            }
            return Ok(res);
        }
        [HttpGet("user/{id}")]
        public IActionResult GetUsers(int id)
        {
            var res = new User();
            using (var dbContext = new RoomsContext())
            {
                if (dbContext.Users.Find(id) == null)
                    return BadRequest("There is no user with that Id");
                res = dbContext.Users.Find(id);
            }
            return Ok(res);
        }
        [HttpPost("adduser")]
        public IActionResult AddUser([FromBody] UserToSend user)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var userToAdd = new User();
            using (var dbContext = new RoomsContext())
            {
                userToAdd.name = user.name;
                dbContext.Users.Add(userToAdd);
                dbContext.SaveChanges();
            }
            return Created("/users", user);
        }
        [HttpPut("changeuser/{id}")]
        public IActionResult ChangeUser([FromRoute] int id, [FromBody] UserToSend user)
        {
            using (var dbContext = new RoomsContext())
            {
                var userToEdit = dbContext.Users.Find(id);
                if (userToEdit == null)
                    return BadRequest("Incorrect Id");
                userToEdit.name = user.name;
                dbContext.Users.Update(userToEdit);
                dbContext.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete("deleteuser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            using (var dbContext= new RoomsContext())
            {
                User user = dbContext.Users.Find(id);
                if (user == null)
                    return BadRequest();
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
            return Ok();
        }
        [HttpGet("rooms")]
        public IActionResult GetRooms()
        {
            var res = new List<Room>();
            using (var dbContext = new RoomsContext())
            {
                res = dbContext.Rooms.ToList();
            }
            return Ok(res);
        }
        [HttpGet("room/{id}")]
        public IActionResult GetRooms(int id)
        {
            var res = new Room();
            using (var dbContext = new RoomsContext())
            {
                if (dbContext.Rooms.Find(id) == null)
                    return BadRequest("There is no user with that Id");
                res = dbContext.Rooms.Find(id);
            }
            return Ok(res);
        }
        [HttpPost("addroom")]
        public IActionResult AddUser([FromBody] RoomToSend room)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var roomToAdd = new Room();
            using (var dbContext = new RoomsContext())
            {
                roomToAdd.name = room.name;
                dbContext.Rooms.Add(roomToAdd);
                dbContext.SaveChanges();
            }
            return Created("/users", room);
        }
        [HttpPut("changeroom/{id}")]
        public IActionResult ChangeUser([FromRoute] int id, [FromBody] RoomToSend room)
        {
            using (var dbContext = new RoomsContext())
            {
                var roomToEdit = dbContext.Rooms.Find(id);
                if (roomToEdit == null)
                    return BadRequest("Incorrect Id");
                roomToEdit.name = room.name;
                roomToEdit.type = room.type;
                dbContext.Rooms.Update(roomToEdit);
                dbContext.SaveChanges();
            }
            return Ok();
        }

        [HttpDelete("deleteroom/{id}")]
        public IActionResult DeleteRoom(int id)
        {
            using (var dbContext = new RoomsContext())
            {
                Room room = dbContext.Rooms.Find(id);
                if (room == null)
                    return BadRequest();
                dbContext.Rooms.Remove(room);
                dbContext.SaveChanges();
            }
            return Ok();
        }

    }
}
