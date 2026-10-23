using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Models;
using PaintStore.API.Data;

namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Get all users by page.
        [HttpGet("GetUsers")]
        public ActionResult GetUsers(int pageNum, int pageSize)
        {
            return Ok(MockData.UserData.Skip((pageNum-1)*pageSize).Take(pageSize).ToList());
        }

        //Get user by id
        [HttpGet("GetUserById")]
        public ActionResult GetUserById(int userId)
        {
            return Ok(MockData.UserData.SingleOrDefault(u => u.Id == userId));
        }

        //Get user by name, if users have same name return all of them
        [HttpGet("GetUserByName")]
        public ActionResult GetUserByName(string name)
        {
            return Ok(MockData.UserData.Where(u => u.Name == name).ToList());
        }

        //Get user by email, every email must be unique
        [HttpGet("GetUserByEmail")]
        public ActionResult GetUserByEmail(string email)
        {
            return Ok(MockData.UserData.SingleOrDefault(u => u.Email == email));
        }
    }
}
