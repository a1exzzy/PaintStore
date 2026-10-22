using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.API.Data;
using PaintStore.Models;


namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintProductController : ControllerBase
    {
        //Get all orders in the OrderData, with pagination.
        [HttpGet("GetAllPaintProducts")]
        public ActionResult GetAllPaintProducts(int pageNum, int pageSize)
        {
            List<PaintProduct> result = MockData.ProductData.Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
            return Ok(result);
        }

        //Get products by price range
        [HttpGet("GetProductsByPriceRange")]
        public ActionResult GetProductsByPriceRange(decimal min, decimal max)
        {
            List<PaintProduct> result = MockData.ProductData.Where(p => p.Price >= min && p.Price <= max).ToList();
            return Ok(result);
        }

        //Get certain product by id
        [HttpGet("GetPaintProductsByPaintId")]
        public ActionResult GetPaintProductsByPaintId(int id)
        {
            PaintProduct result = MockData.ProductData.SingleOrDefault(p => p.Id == id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        //Get paint products in the orders by user id
        [HttpGet("GetPaintProductsByUserId")]
        public ActionResult GetPaintProductsByUserId(int userId)
        {
            //Select the orders of that user
            List<Order> ordersOfUser = MockData.OrderData.Where(o => o.UserId == userId).ToList();
            //Select the paint products in those orders, and not showing duplicate products.
            List<PaintProduct> paintProducts = ordersOfUser.SelectMany(o => o.Products).Distinct().ToList();
            return Ok(paintProducts);
        }
    }
}
