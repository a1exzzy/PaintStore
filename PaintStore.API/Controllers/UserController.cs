using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Models;

namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private List<User> UserData = new()
        {
            new User(1, "AZ", 18, "123@qq.com"),
            new User(2, "BC", 27, "1234@qq.com"),
            new User(3, "TJ", 22, "tj@gmail.com")
        };

        //Get all users by page.
        [HttpGet("GetUsers")]
        public ActionResult GetUsers(int pageNum, int pageSize)
        {
            return Ok(UserData.Skip((pageNum-1)*pageSize).Take(pageSize).ToList());
        }

        //Get user by id
        [HttpGet("GetUserById")]
        public ActionResult GetUserById(int userId)
        {
            return Ok(UserData.SingleOrDefault(u => u.Id == userId));
        }

        //Get user by name, if users have same name return all of them
        [HttpGet("GetUserByName")]
        public ActionResult GetUserByName(string name)
        {
            return Ok(UserData.Where(u => u.Name == name).ToList());
        }

        //Get user by email, every email must be unique
        [HttpGet("GetUserByEmail")]
        public ActionResult GetUserByEmail(string email)
        {
            return Ok(UserData.SingleOrDefault(u => u.Email == email));
        }
    }
}
