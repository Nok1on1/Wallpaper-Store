using System.IO;
using Avalonia.Media.Imaging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Png;

namespace AvaloniaApplication1.Services;

public static class ImageHelper
{
    public static Bitmap LoadFromResource(string uri)
    {
        return ResizeImage(uri, 300, 300);
    }

    public static byte[] BitmapToBytes(Bitmap bitmap)
    {
        using (var memoryStream = new MemoryStream())
        {
            bitmap.Save(memoryStream);
            return memoryStream.ToArray();
        }
    }
    
    public static Bitmap BytesToBitmap(byte[] byteArray)
    {
        if (byteArray == null || byteArray.Length == 0)
            return null;

        using var ms = new MemoryStream(byteArray);

        return new Bitmap(ms);
    }

    // public static byte[] GetBytesFromDB(ref SqliteDataReader reader)
    // {
    //     if (!reader.IsDBNull(reader.GetOrdinal("w_image")))
    //     {
    //         // Get the size of the BLOB data
    //         long blobSize = reader.GetBytes(reader.GetOrdinal("w_image"), 0, null, 0, 0);
    //
    //         // Create a buffer to hold the BLOB data
    //         byte[] imageData = new byte[blobSize];
    //
    //         // Read the BLOB data into the buffer
    //         reader.GetBytes(reader.GetOrdinal("w_image"), 0, imageData, 0, (int)blobSize);
    //
    //         return imageData;
    //     }
    //
    //     return null;
    // }

    public static Bitmap ResizeImage(string inputPath, int width, int height)
    {
        using (Image image = Image.Load(inputPath))
        {
            // Calculate aspect ratios
            double sourceRatio = (double)image.Width / image.Height;
            double targetRatio = (double)width / height;

            Rectangle cropArea;

            if (sourceRatio > targetRatio)
            {
                // Image is wider than target: Crop left & right
                int newWidth = (int)(image.Height * targetRatio);
                int xOffset = (image.Width - newWidth) / 2;
                cropArea = new Rectangle(xOffset, 0, newWidth, image.Height);
            }
            else
            {
                // Image is taller than target: Crop top & bottom
                int newHeight = (int)(image.Width / targetRatio);
                int yOffset = (image.Height - newHeight) / 2;
                cropArea = new Rectangle(0, yOffset, image.Width, newHeight);
            }

            // Crop and resize
            image.Mutate(x => x
                .Crop(cropArea)     // First, crop the image to fit aspect ratio
                .Resize(width, height)); // Then, resize it to the target dimensions

            // Convert to Bitmap
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, new PngEncoder()); // Save as PNG format
                ms.Position = 0;
                return new Bitmap(ms);
            }
        }
    }

}