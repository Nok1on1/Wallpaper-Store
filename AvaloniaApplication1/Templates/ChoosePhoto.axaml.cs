using System;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using Avalonia.Svg.Skia;
using AvaloniaApplication1.Services;
using Image = Avalonia.Controls.Image;

namespace AvaloniaApplication1.Templates;

public class ChoosePhoto : TemplatedControl
{

    // private double _svgWidth = 40;
    private Image? _image;
    private Button? _button;


    public static readonly StyledProperty<Bitmap?> ImageSourceProperty =
        AvaloniaProperty.Register<ChoosePhoto, Bitmap?>(nameof(ImageSource));

    public Bitmap? ImageSource
    {
        get => GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        // Attach the click event handler
        _button = e.NameScope.Find<Button>("PART_Button");
        _image = e.NameScope.Find<Image>("PART_Image");
        if (_button != null)
        {
            _button.Click += OnOpenFileClick;
        }
        else
        {
            Console.WriteLine("Button not found In ChoosePhoto1");
        }

    }

    private async void OnOpenFileClick(object? sender, RoutedEventArgs routedEventArgs)
    {
        if (TopLevel.GetTopLevel(this) is not Window parentWindow)
        {
            Console.WriteLine("Error: Could not find parent window.");
            return;
        }

        string? filePath = await OpenFileWithStorageProvider(parentWindow);
        if (filePath != null)
        {
            ImageSource = ImageHelper.ResizeImage(filePath, 600, 600);
            Console.WriteLine("Selected file: " + filePath);
        }
    }

    private static async Task<string?> OpenFileWithStorageProvider(Window parent)
    {
        var files = await parent.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Select a Photo",
            AllowMultiple = false,
            FileTypeFilter = new []
            {
                new FilePickerFileType("Images") { Patterns = new[] { "*.png", "*.jpg", "*.jpeg" } }
            }
        });

        return files.FirstOrDefault()?.Path.LocalPath;
    }
}