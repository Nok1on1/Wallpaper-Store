using System;
using System.Collections.Generic;
namespace AvaloniaApplication1.Models;

public class Wallpapers
{
    public string WId { get; set; }
    public DateTimeOffset WProdDate  { get; set; } = DateTimeOffset.UtcNow;
    public string WCompany { get; set; }
    public int? WQuantity { get; set; }
    public byte[] WImage { get; set; }
    public string WWidth { get; set; }

    public ICollection<Restock> Restocks { get; set; }
    public ICollection<Sell> Sells { get; set; }
}