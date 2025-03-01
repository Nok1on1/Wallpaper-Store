using Avalonia.Controls;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1.Views;

public partial class WallpaperSearchFilter : UserControl
{
    public WallpaperSearchFilter()
    {
        InitializeComponent();
        DataContext = new WallpaperSearchViewModel();
    }
}