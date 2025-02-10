using System;
using Avalonia.Media.Imaging;
using AvaloniaApplication1.Services;
using static AvaloniaApplication1.Services.ImageHelper;
namespace AvaloniaApplication1.Models;

public class Wallpapers(string name, string id, string path)
{
    public string Name { get; set; } = name;
    public string Id { get; set; } = id;
    public Bitmap Path { get; set; } = LoadFromResource(path);
}