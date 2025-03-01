using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using System.IO;

namespace AvaloniaApplication1.Services;

public class ByteArrayToBitmapConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        try
        {
            // Check if the value is a non-null byte array
            if (value is byte[] byteArray && byteArray.Length > 0)
            {
                using (var stream = new MemoryStream(byteArray))
                {
                    return new Bitmap(stream);
                }
            }

            // Return a default image or null if the byte array is empty or invalid
            return null!; // Or return a placeholder image
        }
        catch (Exception ex)
        {
            // Log the error (optional)
            Console.WriteLine($"Error converting byte array to bitmap: {ex.Message}");

            // Return a default image or null in case of an error
            return null!; // Or return a placeholder image
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException("Converting from Bitmap to byte[] is not supported.");
    }
}