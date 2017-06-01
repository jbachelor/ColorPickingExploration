using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace ColorPicker1.Views
{
    public partial class ColorExplorerPage : ContentPage
    {
        public ColorExplorerPage()
        {
            InitializeComponent();

            hueSlider.Value = 0;
            saturationSlider.Value = 100;
            lightnessSlider.Value = 50;
            valueSlider.Value = 100;
        }

        private void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            hslCanvasView.InvalidateSurface();
            hsvCanvasView.InvalidateSurface();
        }

        private void OnHslCanvasViewPaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKColor color = SKColor.FromHsl(
                (float)hueSlider.Value,
                (float)saturationSlider.Value,
                (float)lightnessSlider.Value);

            e.Surface.Canvas.Clear(color);
            hslLabel.Text = $"RGB = R{color.Red:X2}, G{color.Green:X2}, B{color.Blue:X2}";
        }

        private void OnHsvCanvasViewPaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKColor color = SKColor.FromHsv(
                (float)hueSlider.Value,
                (float)saturationSlider.Value,
                (float)valueSlider.Value);

            e.Surface.Canvas.Clear(color);
            hsvLabel.Text = $"RGB = R{color.Red:X2}, G{color.Green:X2}, B{color.Blue:X2}";
        }
    }
}
