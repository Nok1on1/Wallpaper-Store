using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Media.Imaging;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Services;

namespace AvaloniaApplication1.Controllers;

public class WallpaperController
{
    private readonly WallpaperService _wallpaperService = new ();

    public List<Wallpapers> GetWallpapers(int pageNum, int pageSize, Filters filters)
    {
        return _wallpaperService.GetWallpapers(pageNum, pageSize, filters);
    }

    public ObservableCollection<string> LoadWidthVariations()
        => new (_wallpaperService.LoadWidthVariations());

    public ObservableCollection<string> LoadCompanyVariations()
        => new (_wallpaperService.LoadCompanyVariations());

    public void AddWallpaper(Wallpapers wallpaper, Restock restock, string chosenWidth, Bitmap image)
    {
        _wallpaperService.AddWallpaper(wallpaper, restock, chosenWidth, image);
    }
}