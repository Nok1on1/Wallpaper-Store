using System.Collections.Generic;

namespace AvaloniaApplication1.Models;

public class Client
{
    public string CName { get; set; }
    public ICollection<Sell> Sells { get; set; }
}