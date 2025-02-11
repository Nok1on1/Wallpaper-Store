using System;
using Avalonia.Controls;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Control_OnSizeChanged(object? sender, SizeChangedEventArgs e)
    {
        MainWindowViewModel.WindowSizeChanged(e.NewSize.Width - 240, e.NewSize.Height);
    }
}