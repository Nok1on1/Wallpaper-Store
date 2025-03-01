using System;

namespace AvaloniaApplication1.Models;

public class Sell
{
    public string WId { get; set; }
    public DateTimeOffset WProdDate { get; set; }
    public string WCompany { get; set; }
    public string CName { get; set; }
    public DateTimeOffset PurchaseDate { get; set; }
    public short Quantity { get; set; }
    public float WholePrice { get; set; }

    public Wallpapers Wallpapers { get; set; }
    public Client Client { get; set; }
}