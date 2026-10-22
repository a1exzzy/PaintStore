using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.Models;


namespace PaintStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaintProductController : ControllerBase
    {
        //Mock data for orders
        private List<PaintProduct> ProductData = new()
        {
            new PaintProduct(1, "Interior Wall Paint", 45.99m, PaintType.Matte),
            new PaintProduct(2, "Kitchen Low Sheen Paint", 52.50m, PaintType.LowSheen),
            new PaintProduct(3, "Premium Gloss Enamel", 68.99m, PaintType.Gloss),
            new PaintProduct(4, "High Sheen White Paint", 59.99m, PaintType.HighSheen),
            new PaintProduct(5, "Basic Ceiling Paint", 29.99m, PaintType.Basic),
            new PaintProduct(6, "Semi Gloss Trim Paint", 64.50m, PaintType.SemiGloss),
            new PaintProduct(7, "White on White Paint", 55.99m, PaintType.WhiteOnWhite),
            new PaintProduct(8, "Bathroom Matte Paint", 49.99m, PaintType.Matte),
            new PaintProduct(9, "Exterior Basic Paint", 39.99m, PaintType.Basic),
            new PaintProduct(10, "Premium Low Sheen Paint", 62.99m, PaintType.LowSheen)
        };

        //Get all orders in the OrderData, with pagination.
        [HttpGet("GetAllPaintProducts")]
        public ActionResult GetAllPaintProducts(int pageNum, int pageSize)
        {
            List<PaintProduct> result = ProductData.Skip((pageNum-1) * pageSize).Take(pageSize).ToList();
            return Ok(result);
        }

        //Get products by price range
        [HttpGet("GetProductsByPriceRange")]
        public ActionResult GetProductsByPriceRange(decimal min, decimal max)
        {
            List<PaintProduct> result = ProductData.Where(p => p.Price >= min && p.Price <= max).ToList();
            return Ok(result);
        }

        //Get certain product by id
        [HttpGet("GetPaintProductsByPaintId")]
        public ActionResult GetPaintProductsByPaintId(int id)
        {
            PaintProduct result = ProductData.SingleOrDefault(p => p.Id == id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        //Get paint products in the orders by user id
    }
}
