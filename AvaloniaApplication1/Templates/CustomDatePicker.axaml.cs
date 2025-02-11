using System;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication1.Templates;

public partial class CustomDatePicker : UserControl
{
    public String? DateTime;

    public CustomDatePicker()
    {
        InitializeComponent();
        DatePickerPresenter.Date = System.DateTime.Today;
    }


    private void OnPopupButton_Click(object? sender, RoutedEventArgs e)
    {
        if (Popup.IsOpen)
        {
            Popup.IsOpen = false;
        }
        else
        {
            Popup.IsOpen = true;
        }
    }

    private void PickerPresenterBase_OnConfirmed(object? sender, EventArgs e)
    {
        if (sender is DatePickerPresenter datePicker)
        {
            DateTime =  datePicker.Date.Year + "-" + datePicker.Date.Month + "-" + datePicker.Date.Day;
            PopupButton.Content = DateTime;
            Popup.IsOpen = false;
        }


    }

    private void DatePickerPresenter_OnDismissed(object? sender, EventArgs e)
    {
        if (sender is DatePickerPresenter datePicker)
        {
            DateTime =  System.DateTime.Today.ToString(CultureInfo.CurrentCulture);
            PopupButton.Content = "Choose Date";
            Popup.IsOpen = false;
        }
    }
}