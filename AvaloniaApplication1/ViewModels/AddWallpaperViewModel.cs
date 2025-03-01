using System.Collections.ObjectModel;
using Avalonia.Media.Imaging;
using AvaloniaApplication1.Controllers;
using AvaloniaApplication1.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels;

public partial class AddWallpaperViewModel : ObservableObject
{
    WallpaperController _wallpaperController = new ();

    [ObservableProperty]
    private Wallpapers _wallpaper = new();
    [ObservableProperty]
    private Restock _restock = new ();
    [ObservableProperty]
    private Bitmap? _image;

    [ObservableProperty]
    private ObservableCollection<string> _widths = ["50 cm", "53 cm", "100 cm", "106 cm"];
    [ObservableProperty]
    private string _chosenWidth = "";

    [RelayCommand]
    private void AddButtonClicked()
    {
        if (Image != null)
            _wallpaperController.AddWallpaper(Wallpaper, Restock, ChosenWidth, Image);
    }

    [RelayCommand]
    private void ClearButtonClicked()
    {
        Image = null;
        ChosenWidth = "";
        Wallpaper = new();
        Restock = new ();
    }

}