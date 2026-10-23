using System;
using PaintStore.API;
using PaintStore.Models;
namespace PaintStore.API.Data;

public static class MockData
{
    //Mock data for orders
    public static List<Order> OrderData { get; set; } = new()
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

    //Mock data for users
    public static List<User> UserData = new()
    {
        new User(1, "AZ", 18, "123@qq.com"),
        new User(2, "BC", 27, "1234@qq.com"),
        new User(3, "TJ", 22, "tj@gmail.com")
    };

    //Mock data for paint products
    public static List<PaintProduct> ProductData = new()
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
}
