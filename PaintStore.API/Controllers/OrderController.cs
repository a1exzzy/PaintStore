using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Models;
using PaintStore.API.Data;

namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        

        //Get all orders, with pagination.
        [HttpGet("GetAllOrders")]
        public ActionResult GetAllOrders(int pageNum, int pageSize)
        {
            List<Order> result = MockData.OrderData.Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
            return Ok(result);        
        }   

        //Get orders by price range
        [HttpGet("GetOrdersByPriceRange")]
        public ActionResult GetOrdersByPriceRange(decimal min, decimal max)
        {
            List<Order> result = MockData.OrderData.Where(o => o.TotalPrice >= min && o.TotalPrice <= max).ToList();
            return Ok(result);
        }
        
        //Get orders that contains paint of certain id 
        [HttpGet("GetOrdersByPaintld")]
        public ActionResult GetOrdersByPaintld (int id)
        {
            List<Order> result = MockData.OrderData.Where(o => o.Products.Any(p => p.Id == id)).ToList();
            return Ok(result);
        }
        
        //Get orders that belongs to user of certain id 
        [HttpGet("GetOrdersByUserld")]
        public ActionResult GetOrdersByUserld (int id)
        {
            List<Order> result = MockData.OrderData.Where(o => o.Products.Any(p => p.Id == id)).ToList();
            return Ok(result);
        }

        //Get orders which are created in last month
        [HttpGet("GetLastMonthOrders")]
        public ActionResult GetLastMonthOrders()
        {
            List<Order> result = MockData.OrderData.Where(o => o.CreateAt.Month == DateTime.Now.Month - 1 && o.CreateAt.Year == DateTime.Now.Year ).ToList();
            return Ok(result);
        }

        //Get orders which are created in certain day
        [HttpGet("GetOrdersByDate")]
        public ActionResult GetOrdersByDate( int day, int month, int year)
        {
            List<Order> result = MockData.OrderData.Where(o => o.CreateAt.Day == day && o.CreateAt.Month == month && o.CreateAt.Year == year ).ToList();
            return Ok(result);
        }
    }
}
