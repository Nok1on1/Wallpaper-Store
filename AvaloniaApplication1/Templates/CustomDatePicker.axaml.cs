using System;
using System.Globalization;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;

namespace AvaloniaApplication1.Templates;

public class CustomDatePicker : TemplatedControl
{
    public String? DateTime;

    private Button _popupButton = null!;
    private DatePickerPresenter _datePickerPresenter = null!;
    private Popup _popup = null!;

    public static readonly StyledProperty<DateTimeOffset?> DateProperty =
        AvaloniaProperty.Register<CustomDatePicker, DateTimeOffset?>(nameof(Date));

    public DateTimeOffset? Date
    {
        get => GetValue(DateProperty);
        set => SetValue(DateProperty, value);
    }


    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        _popup = e.NameScope.Find<Popup>("PART_Popup")!;
        _datePickerPresenter = e.NameScope.Find<DatePickerPresenter>("PART_DatePickerPresenter")!;
        _popupButton = e.NameScope.Find<Button>("PART_PopupButton")!;

        _datePickerPresenter.Date = System.DateTimeOffset.UtcNow;

        _popupButton.Click += OnPopupButton_Click;
        _datePickerPresenter.Confirmed += PickerPresenterBase_OnConfirmed;
        _datePickerPresenter.Dismissed += DatePickerPresenter_OnDismissed;
    }

    private void OnPopupButton_Click(object? sender, RoutedEventArgs e)
    {
        _popup.IsOpen = !_popup.IsOpen;
    }

    private void PickerPresenterBase_OnConfirmed(object? sender, EventArgs e)
    {
        if (sender is not DatePickerPresenter datePicker) return;
        Date = datePicker.Date;
        DateTime =  datePicker.Date.ToString("M/dd/yyyy");
        _popupButton.Content = DateTime;
        _popup.IsOpen = false;
    }

    private void DatePickerPresenter_OnDismissed(object? sender, EventArgs e)
    {
        if (sender is not DatePickerPresenter) return;
        Date = DateTimeOffset.UtcNow;
        DateTime =  System.DateTime.Today.ToString("M/dd/yyyy");
        _popupButton.Content = "Choose Date";
        _popup.IsOpen = false;
    }
}