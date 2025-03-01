using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1.Views;

public partial class AddWallpaper : UserControl
{

    public AddWallpaper()
    {
        InitializeComponent();
        DataContext = new AddWallpaperViewModel();

    }

}