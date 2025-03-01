using System;
using System.Collections.ObjectModel;

namespace AvaloniaApplication1.Models;

public class Filters
{
    public string PriceFrom { get; set; } = "";
    public string PriceTo { get; set; } = "";

    public ObservableCollection<string> WidthVariations { get; set; } = new();
    public ObservableCollection<string> CheckedWidthVariations { get; set; } = new();

    public ObservableCollection<string> CompanyVariations { get; set; } = new();
    public ObservableCollection<string> CheckedCompanyVariations { get; set; } = new();

    public DateTimeOffset DateFrom { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset DateTo { get; set; } = DateTimeOffset.UtcNow;
}
