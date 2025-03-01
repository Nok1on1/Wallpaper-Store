using System;

namespace AvaloniaApplication1.Models;

public class Restock
{
    public string WId { get; set; }
    public DateTimeOffset WProdDate { get; set; }
    public string WCompany { get; set; }
    public string SName { get; set; }
    public DateTimeOffset RestockDate { get; set; } = DateTimeOffset.UtcNow;
    public float? BasePrice { get; set; }
    public int Quantity { get; set; }

    public Wallpapers Wallpapers { get; set; }
    public Seller Seller { get; set; }
}