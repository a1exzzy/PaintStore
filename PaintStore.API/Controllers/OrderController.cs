using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Models;

namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        //Mock data for orders
        public List<Order> OrderData = new()
        {
            new Order(1, 1, new List<PaintProduct>
            {
                new PaintProduct(1, "Interior Wall Paint", 45.99m, PaintType.Matte),
                new PaintProduct(2, "Kitchen Low Sheen Paint", 52.50m, PaintType.LowSheen)
            }),

            new Order(2, 2, new List<PaintProduct>
            {
                new PaintProduct(3, "Premium Gloss Enamel", 68.99m, PaintType.Gloss)
            }),

            new Order(3, 2, new List<PaintProduct>
            {
                new PaintProduct(1, "Interior Wall Paint", 45.99m, PaintType.Matte),
                new PaintProduct(1, "Interior Wall Paint", 45.99m, PaintType.Matte),
                new PaintProduct(3, "Premium Gloss Enamel", 68.99m, PaintType.Gloss)
            })
        };

        //Get all orders, with pagination.
        [HttpGet("GetAllOrders")]
        public ActionResult GetAllOrders(int pageNum, int pageSize)
        {
            List<Order> result = OrderData.Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
            return Ok(result);        
        }   

        //Get orders by price range
        [HttpGet("GetOrdersByPriceRange")]
        public ActionResult GetOrdersByPriceRange(decimal min, decimal max)
        {
            List<Order> result = OrderData.Where(o => o.TotalPrice >= min && o.TotalPrice <= max).ToList();
            return Ok(result);
        }
        
        //Get orders that contains paint of certain id 
        [HttpGet("GetOrdersByPaintld")]
        public ActionResult GetOrdersByPaintld (int id)
        {
            List<Order> result = OrderData.Where(o => o.Products.Any(p => p.Id == id)).ToList();
            return Ok(result);
        }
        
        //Get orders that belongs to user of certain id 
        [HttpGet("GetOrdersByUserld")]
        public ActionResult GetOrdersByUserld (int id)
        {
            List<Order> result = OrderData.Where(o => o.Products.Any(p => p.Id == id)).ToList();
            return Ok(result);
        }

        //Get orders which are created in last month
        [HttpGet("GetLastMonthOrders")]
        public ActionResult GetLastMonthOrders()
        {
            List<Order> result = OrderData.Where(o => o.CreateAt.Month == DateTime.Now.Month - 1 && o.CreateAt.Year == DateTime.Now.Year ).ToList();
            return Ok(result);
        }

        //Get orders which are created in certain day
        [HttpGet("GetOrdersByDate")]
        public ActionResult GetOrdersByDate( int day, int month, int year)
        {
            List<Order> result = OrderData.Where(o => o.CreateAt.Day == day && o.CreateAt.Month == month && o.CreateAt.Year == year ).ToList();
            return Ok(result);
        }
    }
}
