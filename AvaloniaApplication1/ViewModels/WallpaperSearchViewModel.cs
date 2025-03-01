using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using AvaloniaApplication1.Controllers;
using AvaloniaApplication1.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels;

public partial class WallpaperSearchViewModel : ObservableObject
{
    private WallpaperController _wallpaperController = new ();

    [ObservableProperty]
    private static double _windowWidth = 1920;
    [ObservableProperty]
    private static double _windowHeight = 1080;

    [ObservableProperty]
    private Filters _filters = new();

    [ObservableProperty]
    private ObservableCollection<Wallpapers> _photos = new();


    public WallpaperSearchViewModel()
    {
        SearchWallpapers();

        Filters.WidthVariations = _wallpaperController.LoadWidthVariations();
        Filters.CompanyVariations = _wallpaperController.LoadCompanyVariations();
    }


    [RelayCommand]
    public void SearchWallpapers()
    {
        var wallpapers = _wallpaperController.GetWallpapers(1, 10, Filters);

        Photos = new ObservableCollection<Wallpapers>(wallpapers);
    }


    [RelayCommand]
    private void CheckedChanged(string selected)
    {
        if (Filters.WidthVariations.Contains(selected))
        {
            if (Filters.CheckedWidthVariations.Contains(selected))
                Filters.CheckedWidthVariations.Remove(selected);
            else
            {
                Filters.CheckedWidthVariations.Add(selected);
            }
        }
        else if (Filters.CompanyVariations.Contains(selected))
        {
            if (Filters.CheckedCompanyVariations.Contains(selected))
                Filters.CheckedCompanyVariations.Remove(selected);
            else
            {
                Filters.CheckedCompanyVariations.Add(selected);
            }
        }
    }
}