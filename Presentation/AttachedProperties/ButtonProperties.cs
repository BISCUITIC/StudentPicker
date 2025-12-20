using System.Windows;

namespace Presentation.AttachedProperties;

public static class ButtonProperties
{
    public static readonly DependencyProperty CornerRadiusProperty =
        DependencyProperty.RegisterAttached(
            "CornerRadius",
            typeof(CornerRadius),
            typeof(ButtonProperties),
            new FrameworkPropertyMetadata(new CornerRadius(0),
                                              FrameworkPropertyMetadataOptions.Inherits)
        );

    public static void SetCornerRadius(DependencyObject element, CornerRadius value)
        => element.SetValue(CornerRadiusProperty, value);

    public static CornerRadius GetCornerRadius(DependencyObject element)
        => (CornerRadius)element.GetValue(CornerRadiusProperty);
}