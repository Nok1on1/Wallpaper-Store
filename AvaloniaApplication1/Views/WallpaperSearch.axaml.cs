using Avalonia.Controls;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1.Views;

public partial class WallpaperSearch : UserControl
{
    public WallpaperSearch()
    {
        InitializeComponent();
        DataContext = new WallpaperSearchViewModel();
    }
}