using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using static AvaloniaApplication1.Services.FilterHelper;
using static  AvaloniaApplication1.Services.DbService;


namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    public MainWindowViewModel()
    {
        _dateBefore = DateTime.Today.ToString("dd/MM/yyyy");
    }

    public LinkedList<string> SelectedFilters { get; } = new();
    [ObservableProperty]
    private string _low = "0";
    [ObservableProperty]
    private string _high = "9999";
    [ObservableProperty]
    private string _dateBefore;
    [ObservableProperty]
    private string _dateAfter= "1995-10-10";
    [ObservableProperty]
    private string? _filterText;
    [ObservableProperty]
    private string? _priceText;

    private static double _windowWidth;
    private static double _windowHeight;


    private static Object _currentView = new WallpaperSearch();
    public Object CurrentView
    {
        get => _currentView;
        set => SetProperty(ref _currentView, value);
    }
    [RelayCommand]
    public void ChangeView()
    {
        AddWallpaper addWallpaper = new AddWallpaper();
        CurrentView = addWallpaper;
        WindowSizeChanged(_windowWidth, _windowHeight);
    }

    public static void WindowSizeChanged(double width, double height)
    {
        _windowWidth = width;
        _windowHeight = height;

        if (_currentView is WallpaperSearch wallpaperSearch)
        {
                    wallpaperSearch.Width = width;
        }
        else if (_currentView is AddWallpaper addWallpaper)
        {
            addWallpaper.Width = width;
            addWallpaper.Height = height;
        }
    }
    partial void OnHighChanged(string value) => UpdatePriceText();
    partial void OnLowChanged(string value) => UpdatePriceText();


    // private void UpdateTheWindowSize()
    // {
    //     if(CurrentView is WallpaperSearchViewModel)
    //     {
    //     }
    //
    // }


    [RelayCommand]
    private void UpdateFilterText(string filter)
    {
        if (SelectedFilters.Contains(filter))
            SelectedFilters.Remove(filter);
        else
            SelectedFilters.AddLast(filter);

        if (SelectedFilters.Count == 0)
            FilterText = "";
        else
        {
            FilterText = "Filters:";
            foreach (var value in SelectedFilters)
            {
                FilterText += " " + value;
            }
        }
    }


    private void UpdatePriceText()
    {
        string tmp = "";
            if ((Low != PriceTextDefaults("Low") || Low != PriceTextDefaults("High")) && Low.Length > 0)
            {
                tmp += " Low " + Low;
            }
            if ((High != PriceTextDefaults("High") || High != PriceTextDefaults("Low")) && High.Length > 0)
            {
                tmp += " High " + High;
            }

        if (tmp.Length > 0) FilterText = "Price:" + tmp;
        else FilterText = "";

        if (Low.Length == 0) Low = PriceTextDefaults("Low");
        if (High.Length == 0) High = PriceTextDefaults("High");
    }

    public void Loadphoto()
    {
        LoadPhotos(null, null, null, Low, High, null);
    }
}