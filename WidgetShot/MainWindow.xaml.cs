using AdaptiveCards.ObjectModel.WinUI3;
using AdaptiveCards.Rendering.WinUI3;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Markup;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Graphics.Imaging;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.Storage;
using WinUIEx;
using AdaptiveCards.Templating;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WidgetShot {
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : WindowEx {
        AdaptiveCardRenderer renderer;
        string LightConfig = "{\"supportsInteractivity\":true,\"spacing\":{\"small\":8,\"default\":12,\"medium\":16,\"large\":20,\"extraLarge\":24,\"padding\":16},\"fontSizes\":{\"small\":12,\"default\":14,\"medium\":18,\"large\":20,\"extraLarge\":28},\"fontWeights\":{\"lighter\":400,\"default\":400,\"bolder\":600},\"fontTypes\":{\"default\":{\"fontSizes\":{\"small\":12,\"default\":14,\"medium\":18,\"large\":20,\"extraLarge\":28},\"fontWeights\":{\"lighter\":400,\"default\":400,\"bolder\":600}},\"monospace\":{\"fontFamily\":\"Consolas\",\"fontSizes\":{\"small\":12,\"default\":14,\"medium\":18,\"large\":20,\"extraLarge\":28},\"fontWeights\":{\"lighter\":400,\"default\":400,\"bolder\":600}}},\"containerStyles\":{\"default\":{\"foregroundColors\":{\"default\":{\"default\":\"#E4000000\",\"subtle\":\"#9E000000\"},\"light\":{\"default\":\"#FFFFFFFF\",\"subtle\":\"#C5FFFFFF\"},\"dark\":{\"default\":\"#000000\",\"subtle\":\"#000000\"},\"accent\":{\"default\":\"#003E92\",\"subtle\":\"#003E92\"},\"good\":{\"default\":\"#0F7B0F\",\"subtle\":\"#0F7B0F\"},\"warning\":{\"default\":\"#9D5D00\",\"subtle\":\"#9D5D00\"},\"attention\":{\"default\":\"#C42B1C\",\"subtle\":\"#C42B1C\"}}},\"emphasis\":{\"foregroundColors\":{\"default\":{\"default\":\"#E4000000\",\"subtle\":\"#9E000000\"},\"light\":{\"default\":\"#FFFFFFFF\",\"subtle\":\"#C5FFFFFF\"},\"dark\":{\"default\":\"#000000\",\"subtle\":\"#000000\"},\"accent\":{\"default\":\"#003E92\",\"subtle\":\"#003E92\"},\"good\":{\"default\":\"#0F7B0F\",\"subtle\":\"#0F7B0F\"},\"warning\":{\"default\":\"#9D5D00\",\"subtle\":\"#9D5D00\"},\"attention\":{\"default\":\"#C42B1C\",\"subtle\":\"#C42B1C\"}}},\"accent\":{\"foregroundColors\":{\"default\":{\"default\":\"#E4000000\",\"subtle\":\"#9E000000\"},\"light\":{\"default\":\"#FFFFFFFF\",\"subtle\":\"#C5FFFFFF\"},\"dark\":{\"default\":\"#000000\",\"subtle\":\"#000000\"},\"accent\":{\"default\":\"#003E92\",\"subtle\":\"#003E92\"},\"good\":{\"default\":\"#0F7B0F\",\"subtle\":\"#0F7B0F\"},\"warning\":{\"default\":\"#9D5D00\",\"subtle\":\"#9D5D00\"},\"attention\":{\"default\":\"#C42B1C\",\"subtle\":\"#C42B1C\"}}},\"good\":{\"foregroundColors\":{\"default\":{\"default\":\"#E4000000\",\"subtle\":\"#9E000000\"},\"light\":{\"default\":\"#FFFFFFFF\",\"subtle\":\"#C5FFFFFF\"},\"dark\":{\"default\":\"#000000\",\"subtle\":\"#000000\"},\"accent\":{\"default\":\"#003E92\",\"subtle\":\"#003E92\"},\"good\":{\"default\":\"#0F7B0F\",\"subtle\":\"#0F7B0F\"},\"warning\":{\"default\":\"#9D5D00\",\"subtle\":\"#9D5D00\"},\"attention\":{\"default\":\"#C42B1C\",\"subtle\":\"#C42B1C\"}}},\"warning\":{\"foregroundColors\":{\"default\":{\"default\":\"#E4000000\",\"subtle\":\"#9E000000\"},\"light\":{\"default\":\"#FFFFFFFF\",\"subtle\":\"#C5FFFFFF\"},\"dark\":{\"default\":\"#000000\",\"subtle\":\"#000000\"},\"accent\":{\"default\":\"#003E92\",\"subtle\":\"#003E92\"},\"good\":{\"default\":\"#0F7B0F\",\"subtle\":\"#0F7B0F\"},\"warning\":{\"default\":\"#9D5D00\",\"subtle\":\"#9D5D00\"},\"attention\":{\"default\":\"#C42B1C\",\"subtle\":\"#C42B1C\"}}},\"attention\":{\"foregroundColors\":{\"default\":{\"default\":\"#E4000000\",\"subtle\":\"#9E000000\"},\"light\":{\"default\":\"#FFFFFFFF\",\"subtle\":\"#C5FFFFFF\"},\"dark\":{\"default\":\"#000000\",\"subtle\":\"#000000\"},\"accent\":{\"default\":\"#003E92\",\"subtle\":\"#003E92\"},\"good\":{\"default\":\"#0F7B0F\",\"subtle\":\"#0F7B0F\"},\"warning\":{\"default\":\"#9D5D00\",\"subtle\":\"#9D5D00\"},\"attention\":{\"default\":\"#C42B1C\",\"subtle\":\"#C42B1C\"}}}},\"imageSizes\":{\"small\":32,\"medium\":52,\"large\":100},\"textStyles\":{\"heading\":{\"fontType\":\"default\",\"size\":\"large\",\"weight\":\"bolder\",\"color\":\"default\",\"isSubtle\":false}},\"textBlock\":{\"maxWidth\":\"252px\"},\"separator\":{\"lineThickness\":1,\"lineColor\":\"#333333\"}}";
        string DarkConfig = "{\"supportsInteractivity\":true,\"spacing\":{\"small\":8,\"default\":12,\"medium\":16,\"large\":20,\"extraLarge\":24,\"padding\":16},\"fontSizes\":{\"small\":12,\"default\":14,\"medium\":18,\"large\":20,\"extraLarge\":28},\"fontWeights\":{\"lighter\":400,\"default\":400,\"bolder\":600},\"fontTypes\":{\"default\":{\"fontSizes\":{\"small\":12,\"default\":14,\"medium\":18,\"large\":20,\"extraLarge\":28},\"fontWeights\":{\"lighter\":400,\"default\":400,\"bolder\":600}},\"monospace\":{\"fontFamily\":\"Consolas\",\"fontSizes\":{\"small\":12,\"default\":14,\"medium\":18,\"large\":20,\"extraLarge\":28},\"fontWeights\":{\"lighter\":400,\"default\":400,\"bolder\":600}}},\"containerStyles\":{\"default\":{\"foregroundColors\":{\"default\":{\"default\":\"#FFFFFFFF\",\"subtle\":\"#C5FFFFFF\"},\"accent\":{\"default\":\"#FF60CDFF\",\"subtle\":\"#60CDFF\"},\"dark\":{\"default\":\"#E4000000\",\"subtle\":\"#9E000000\"},\"good\":{\"default\":\"#6CCB5E\",\"subtle\":\"#6CCB5E\"},\"warning\":{\"default\":\"#FCE100\",\"subtle\":\"#FCE100\"},\"attention\":{\"default\":\"#FF99A4\",\"subtle\":\"#FF99A4\"}}},\"emphasis\":{\"foregroundColors\":{\"default\":{\"default\":\"#FFFFFFFF\",\"subtle\":\"#C5FFFFFF\"},\"accent\":{\"default\":\"#FF60CDFF\",\"subtle\":\"#60CDFF\"},\"dark\":{\"default\":\"#E4000000\",\"subtle\":\"#9E000000\"},\"good\":{\"default\":\"#6CCB5E\",\"subtle\":\"#6CCB5E\"},\"warning\":{\"default\":\"#FCE100\",\"subtle\":\"#FCE100\"},\"attention\":{\"default\":\"#FF99A4\",\"subtle\":\"#FF99A4\"}}},\"accent\":{\"foregroundColors\":{\"default\":{\"default\":\"#FFFFFFFF\",\"subtle\":\"#C5FFFFFF\"},\"accent\":{\"default\":\"#FF60CDFF\",\"subtle\":\"#60CDFF\"},\"dark\":{\"default\":\"#E4000000\",\"subtle\":\"#9E000000\"},\"good\":{\"default\":\"#6CCB5E\",\"subtle\":\"#6CCB5E\"},\"warning\":{\"default\":\"#FCE100\",\"subtle\":\"#FCE100\"},\"attention\":{\"default\":\"#FF99A4\",\"subtle\":\"#FF99A4\"}}},\"good\":{\"foregroundColors\":{\"default\":{\"default\":\"#FFFFFFFF\",\"subtle\":\"#C5FFFFFF\"},\"accent\":{\"default\":\"#FF60CDFF\",\"subtle\":\"#60CDFF\"},\"dark\":{\"default\":\"#E4000000\",\"subtle\":\"#9E000000\"},\"good\":{\"default\":\"#6CCB5E\",\"subtle\":\"#6CCB5E\"},\"warning\":{\"default\":\"#FCE100\",\"subtle\":\"#FCE100\"},\"attention\":{\"default\":\"#FF99A4\",\"subtle\":\"#FF99A4\"}}},\"warning\":{\"foregroundColors\":{\"default\":{\"default\":\"#FFFFFFFF\",\"subtle\":\"#C5FFFFFF\"},\"accent\":{\"default\":\"#FF60CDFF\",\"subtle\":\"#60CDFF\"},\"dark\":{\"default\":\"#E4000000\",\"subtle\":\"#9E000000\"},\"good\":{\"default\":\"#6CCB5E\",\"subtle\":\"#6CCB5E\"},\"warning\":{\"default\":\"#FCE100\",\"subtle\":\"#FCE100\"},\"attention\":{\"default\":\"#FF99A4\",\"subtle\":\"#FF99A4\"}}},\"attention\":{\"foregroundColors\":{\"default\":{\"default\":\"#FFFFFFFF\",\"subtle\":\"#C5FFFFFF\"},\"accent\":{\"default\":\"#FF60CDFF\",\"subtle\":\"#60CDFF\"},\"dark\":{\"default\":\"#E4000000\",\"subtle\":\"#9E000000\"},\"good\":{\"default\":\"#6CCB5E\",\"subtle\":\"#6CCB5E\"},\"warning\":{\"default\":\"#FCE100\",\"subtle\":\"#FCE100\"},\"attention\":{\"default\":\"#FF99A4\",\"subtle\":\"#FF99A4\"}}}},\"textStyles\":{\"heading\":{\"fontType\":\"default\",\"size\":\"large\",\"weight\":\"bolder\",\"color\":\"default\",\"isSubtle\":false}},\"textBlock\":{\"headingLevel\":2},\"imageSizes\":{\"small\":32,\"medium\":52,\"large\":100},\"separator\":{\"lineThickness\":1,\"lineColor\":\"#FFFFFF\"}}";

        public MainWindow() {
            this.InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            this.SystemBackdrop = new MicaBackdrop();
            WindowState = WindowState.Maximized;

            Title = Package.Current.DisplayName;
            WindowName.Text = Package.Current.DisplayName;

            ShadowRoot.Receivers.Add(ShadowReceiver);
            WidgetPreview.Translation += new System.Numerics.Vector3(0, 0, 8);
        }
        private async void ChooseIcon(object sender, RoutedEventArgs e) {
            FileOpenPicker fop = new FileOpenPicker() {
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };
            InitializeWithWindow.Initialize(fop, this.GetWindowHandle());
            fop.FileTypeFilter.Add(".png");
            fop.FileTypeFilter.Add(".jpg");
            StorageFile file = await fop.PickSingleFileAsync();
            if (file != null) {
                SelectedIconPath.Text = file.Path;
                using (var stream = await file.OpenReadAsync()) {
                    double scale = Content.XamlRoot.RasterizationScale;
                    int size = Convert.ToInt32(16 * scale);

                    BitmapImage img = new BitmapImage {
                        DecodePixelType = DecodePixelType.Physical,
                        DecodePixelWidth = size,
                        DecodePixelHeight = size,
                    };
                    await img.SetSourceAsync(stream);
                    WHIcon.Source = img;
                }
            }
        }

        private async void HyperlinkButton_Click(object sender, RoutedEventArgs e) {
            var package = Package.Current;
            string version = $"{package.Id.Version.Major}.{package.Id.Version.Minor}.{package.Id.Version.Build}";
            string xaml = $"<TextBlock xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" TextWrapping=\"Wrap\"><Run Text=\"by Elchin Orujov (ELOR)\"/><LineBreak/><LineBreak/><Run Text=\"Version:\"/> <Bold>{version}</Bold><LineBreak/><Hyperlink NavigateUri=\"https://github.com/Elorucov/WidgetShot\">Source code on GitHub</Hyperlink></TextBlock>";

            ContentDialog dialog = new ContentDialog {
                XamlRoot = Root.XamlRoot,
                Title = package.DisplayName,
                Content = XamlReader.Load(xaml) as TextBlock,
                PrimaryButtonText = "Close"
            };
            await dialog.ShowAsync();
        }

        private void RenderWidget(object sender, RoutedEventArgs e) {
            Errors.Children.Clear();
            if (renderer == null) {
                renderer = new AdaptiveCardRenderer();
                renderer.SetFixedDimensions(Convert.ToUInt32(WidgetPreview.Width), Convert.ToUInt32(WidgetPreview.Height + 72));
                renderer.ActionRenderers.Set("Action.OpenUrl", new ButtonActionRenderer());
                renderer.ActionRenderers.Set("Action.ShowCard", new ButtonActionRenderer());
                renderer.ActionRenderers.Set("Action.Submit", new ButtonActionRenderer());
                renderer.ActionRenderers.Set("Action.ToggleVisibility", new ButtonActionRenderer());
            }

            var template = new AdaptiveCardTemplate(TemplateCodeInput.Text);
            var expanded = template.Expand(DataCodeInput.Text);

            var warns = template.GetLastTemplateExpansionWarnings();
            foreach (var warn in warns) {
                Errors.Children.Add(new TextBlock {
                    Text = warn.ToString(),
                    TextWrapping = TextWrapping.Wrap,
                    FontSize = 13,
                    Foreground = new SolidColorBrush(Colors.Yellow)
                });
            }

            renderer.HostConfig = AdaptiveHostConfig.FromJsonString(App.Current.RequestedTheme == ApplicationTheme.Dark ? DarkConfig : LightConfig).HostConfig;
            var card = AdaptiveCard.FromJsonString(expanded);
            RenderedAdaptiveCard renderedAdaptiveCard = renderer.RenderAdaptiveCard(card.AdaptiveCard);

            // Check if the render was successful
            if (renderedAdaptiveCard.FrameworkElement != null) {
                WPHost.Child = null;
                var uiCard = renderedAdaptiveCard.FrameworkElement;
                uiCard.RequestedTheme = ElementTheme.Dark;

                if (uiCard is Grid wg) {
                    wg.Background = new SolidColorBrush(Colors.Transparent);
                    if (wg.Children.Count == 1 && wg.Children.FirstOrDefault() is WholeItemsPanel wip) {
                        wip.Margin = new Thickness(16, 48, 16, 0);
                    } else if (wg.Children.Count == 2 && wg.Children.LastOrDefault() is WholeItemsPanel wip2) {
                        wip2.Margin = new Thickness(16, 48, 16, 0);
                    }
                }

                WPHost.Child = uiCard;
            }

            if (card.Errors.Count > 0) {
                foreach (var error in card.Errors) {
                    Errors.Children.Add(new TextBlock {
                        Text = $"{error.StatusCode}: {error.Message}",
                        TextWrapping = TextWrapping.Wrap,
                        FontSize = 13,
                        Foreground = new SolidColorBrush(Colors.Red)
                    });
                }
            }

            if (card.Warnings.Count > 0) {
                foreach (var warning in card.Warnings) {
                    Errors.Children.Add(new TextBlock {
                        Text = $"{warning.StatusCode}: {warning.Message}",
                        TextWrapping = TextWrapping.Wrap,
                        FontSize = 13,
                        Foreground = new SolidColorBrush(Colors.Yellow)
                    });
                }
            }
        }

        private async void TakeWidgetScreenshot(object sender, RoutedEventArgs e) {
            var rtb = new RenderTargetBitmap();
            await rtb.RenderAsync(WidgetPreview);

            // Get pixels from RTB
            IBuffer pixelBuffer = await rtb.GetPixelsAsync();
            byte[] pixels = pixelBuffer.ToArray();

            // Support custom DPI
            var xroot = WidgetPreview.XamlRoot;
            var stream = new InMemoryRandomAccessStream();
            BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
            encoder.SetPixelData(BitmapPixelFormat.Bgra8, // RGB with alpha
                                 BitmapAlphaMode.Premultiplied,
                                 (uint)rtb.PixelWidth,
                                 (uint)rtb.PixelHeight,
                                 xroot.RasterizationScale,
                                 xroot.RasterizationScale,
                                 pixels);

            await encoder.FlushAsync(); // Write data to the stream
            stream.Seek(0); // Set cursor to the beginning

            StorageFile file = null;
            FileSavePicker fsp = new FileSavePicker() {
                DefaultFileExtension = ".png",
                SuggestedFileName = "WidgetScreenshot.png",
                SuggestedStartLocation = PickerLocationId.PicturesLibrary
            };
            InitializeWithWindow.Initialize(fsp, this.GetWindowHandle());
            fsp.FileTypeChoices.Add("PNG", new List<string> { ".png" });
            file = await fsp.PickSaveFileAsync();
            if (file != null) {
                using (var fstream = await file.OpenAsync(FileAccessMode.ReadWrite)) {
                    await RandomAccessStream.CopyAndCloseAsync(stream.GetInputStreamAt(0), fstream.GetOutputStreamAt(0));
                }
            }
        }
    }
}