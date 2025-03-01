using System.Collections.Generic;

namespace AvaloniaApplication1.Models;

public class Seller
{
    public string SName { get; set; }
    public ICollection<Restock> Restocks { get; set; }
}