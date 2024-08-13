using System.Text.RegularExpressions;

namespace PousadaIomar.Behaviors;

public class MaskedBehavior : Behavior<Entry>
{
    private string _mask;
    private string _oldText;
    private bool _isUpdating;
    private Entry _entry;

    public static readonly BindableProperty MaskProperty =
        BindableProperty.Create(nameof(Mask), typeof(string), typeof(MaskedBehavior), string.Empty);

    public string Mask
    {
        get => (string)GetValue(MaskProperty);
        set => SetValue(MaskProperty, value);
    }

    protected override void OnAttachedTo(Entry bindable)
    {
        base.OnAttachedTo(bindable);
        _entry = bindable;
        _entry.TextChanged += OnEntryTextChanged;
    }

    protected override void OnDetachingFrom(Entry bindable)
    {
        base.OnDetachingFrom(bindable);
        _entry.TextChanged -= OnEntryTextChanged;
    }

    private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (_isUpdating)
            return;

        _isUpdating = true;

        var rawText = GetRawText(e.NewTextValue);
        if (rawText.Length > 0 && !string.IsNullOrEmpty(Mask))
        {
            var maskedText = ApplyMask(rawText);
            _entry.Text = maskedText;
        }

        _isUpdating = false;
    }

    private string GetRawText(string input)
    {
        return string.IsNullOrEmpty(input) ? string.Empty : Regex.Replace(input, "[^0-9]", string.Empty);
    }

    private string ApplyMask(string input)
    {
        if (string.IsNullOrEmpty(Mask))
            return input;

        var output = string.Empty;
        var maskIndex = 0;
        var inputIndex = 0;

        while (maskIndex < Mask.Length && inputIndex < input.Length)
        {
            if (Mask[maskIndex] == '#')
            {
                output += input[inputIndex];
                inputIndex++;
            }
            else
            {
                output += Mask[maskIndex];
            }

            maskIndex++;
        }

        return output;
    }
}
