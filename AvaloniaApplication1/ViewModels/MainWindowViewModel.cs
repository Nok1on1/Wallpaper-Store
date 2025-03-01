using System;
using System.Collections.Generic;
using AvaloniaApplication1.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{

    private static readonly List<Object> _cviews =
    [
        new WallpaperSearch(),
        new AddWallpaper(),
    ];

    private static readonly List<Object> _fviews =
    [
        new WallpaperSearchFilter()
    ];


    private static double _windowWidth;
    private static double _windowHeight;


    private static object _currentView = _cviews[0];
    private static object _filterView = _fviews[0];

    public object CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value);
    }
    public object FilterView
    {
        get => _filterView;
        set => SetProperty(ref _filterView, value);
    }




    [RelayCommand]
    private void WallpaperSearchView()
    {
        CurrentView = _cviews[0];

        WallpaperSearchViewModel search = ((CurrentView as WallpaperSearch)!.DataContext as WallpaperSearchViewModel)!;

        search.SearchWallpapers();

        WindowSizeChanged(_windowWidth, _windowHeight);
    }

    [RelayCommand]
    private void AddWallpaperView()
    {
        _cviews[1] = new AddWallpaper();
        CurrentView = _cviews[1];
        WindowSizeChanged(_windowWidth, _windowHeight);
    }

    public static void WindowSizeChanged(double width, double height)
    {
        _windowWidth = width;
        _windowHeight = height;

        switch (_currentView)
        {
            case WallpaperSearch wallpaperSearch:
                wallpaperSearch.Width = width;
                break;
            case AddWallpaper addWallpaper:
                addWallpaper.Width = width;
                addWallpaper.Height = height;
                break;
        }

        switch (_filterView)
        {
            case WallpaperSearchFilter wallpaperSearchFilter:
                wallpaperSearchFilter.Width = width;
                break;
        }
    }
}