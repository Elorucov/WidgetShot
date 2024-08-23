using AdaptiveCards.ObjectModel.Uwp;
using AdaptiveCards.Rendering.Uwp;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using Windows.UI;

namespace WidgetShot {
    internal class ButtonActionRenderer : IAdaptiveActionRenderer {
        public UIElement Render(IAdaptiveActionElement element, AdaptiveRenderContext context, AdaptiveRenderArgs renderArgs) {
            renderArgs.AddContainerPadding = true;
            var button = new Button {
                Content = new TextBlock {
                    Text = element.Title,
                    FontSize = 13,
                    LineHeight = 16
                },
                Style = (Style)App.Current.Resources["AccentButtonStyle"],
                Height = 32,
                Foreground = new SolidColorBrush(Colors.White),
                Background = new SolidColorBrush(Color.FromArgb(255, 0, 103, 192)),
                Margin = new Thickness(0, 0, 20, 0),
                Padding = new Thickness(12, 5, 12, 7)
            };
            ToolTipService.SetToolTip(button, element.Tooltip);
            return button;
        }
    }
}