using System;

namespace PaintStore.Models;

public class Order
{
    public DateTime CreateAt { get; private set; } 
    public int Id { get; set; }
    public int UserId { get; set; }
    public List<PaintProduct> Products { get; set; }
    public int Quantity { get => Products.Count; } 
    public decimal TotalPrice { get => Products.Sum( p => p.Price);}
    public Order(int id, int userId, List<PaintProduct> products)
    {
        Id = id;
        UserId = userId;
        Products = products;
        CreateAt = DateTime.Now;
    }
}
