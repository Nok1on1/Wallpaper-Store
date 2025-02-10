
using System;
using System.IO;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;

namespace AvaloniaApplication1.Services;

public static class ImageHelper
{
    public static Bitmap LoadFromResource(string uri)
    {
        return ResizeImage(uri, 300, 300);
    }

    private static Bitmap ResizeImage(string inputPath, int width, int height)
    {
        using (Image image = Image.Load(inputPath))
        {
            image.Mutate(x => x.Resize(width, height));

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, new PngEncoder()); // Save as PNG format
                ms.Position = 0;
                return new Bitmap(ms);
            }
        }
    }
}