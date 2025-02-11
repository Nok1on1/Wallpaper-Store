using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using static AvaloniaApplication1.Services.FilterHelper;
using static AvaloniaApplication1.Services.DbService;

namespace AvaloniaApplication1.ViewModels;

public partial class WallpaperSearchViewModel : ObservableObject
{

    [ObservableProperty]
    private static double _windowWidth = 1920;
    [ObservableProperty]
    private static double _windowHeight = 1080;


    public void ChangeWindowSize(double windowWidth, double windowHeight)
    {
        WindowWidth = windowWidth;
        WindowHeight = windowHeight;
    }
    public ObservableCollection<Wallpapers> Photos { get; } = new()
    {
        new ("ABCDEFGHIJKLMN", "12005-10", "/home/noklon/Projects/Csharp_Projects/AvaloniaApplication1/AvaloniaApplication1/Assets/640316-1275536973.jpg"),
        new ("ABCDEFGHIJKLMN", "12005-10", "/home/noklon/Projects/Csharp_Projects/AvaloniaApplication1/AvaloniaApplication1/Assets/640316-1275536973.jpg"),
        new ("ABCDEFGHIJKLMN", "12005-10", "/home/noklon/Projects/Csharp_Projects/AvaloniaApplication1/AvaloniaApplication1/Assets/640316-1275536973.jpg"),
        new ("ABCDEFGHIJKLMN", "12005-10", "/home/noklon/Projects/Csharp_Projects/AvaloniaApplication1/AvaloniaApplication1/Assets/640316-1275536973.jpg"),
        new ("ABCDEFGHIJKLMN", "12005-10", "/home/noklon/Projects/Csharp_Projects/AvaloniaApplication1/AvaloniaApplication1/Assets/640316-1275536973.jpg"),
        new ("ABCDEFGHIJKLMN", "12005-10", "/home/noklon/Projects/Csharp_Projects/AvaloniaApplication1/AvaloniaApplication1/Assets/640316-1275536973.jpg"),
        new ("ABCDEFGHIJKLMN", "12005-10", "/home/noklon/Projects/Csharp_Projects/AvaloniaApplication1/AvaloniaApplication1/Assets/640316-1275536973.jpg"),
        new ("ABCDEFGHIJKLMN", "12005-10", "/home/noklon/Projects/Csharp_Projects/AvaloniaApplication1/AvaloniaApplication1/Assets/640316-1275536973.jpg"),
        new ("ABCDEFGHIJKLMN", "12005-10", "/home/noklon/Projects/Csharp_Projects/AvaloniaApplication1/AvaloniaApplication1/Assets/640316-1275536973.jpg"),
        new ("ABCDEFGHIJKLMN", "12005-10", "/home/noklon/Projects/Csharp_Projects/AvaloniaApplication1/AvaloniaApplication1/Assets/640316-1275536973.jpg"),
        new ("ABCDEFGHIJKLMN", "12005-10", "/home/noklon/Projects/Csharp_Projects/AvaloniaApplication1/AvaloniaApplication1/Assets/640316-1275536973.jpg"),
        new ("ABCDEFGHIJKLMN", "12005-10", "/home/noklon/Projects/Csharp_Projects/AvaloniaApplication1/AvaloniaApplication1/Assets/640316-1275536973.jpg"),
    };
}