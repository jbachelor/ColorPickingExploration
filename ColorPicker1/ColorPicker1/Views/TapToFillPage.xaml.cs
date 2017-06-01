using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.Diagnostics;
using Xamarin.Forms;

namespace ColorPicker1.Views
{
    public partial class TapToFillPage : ContentPage
    {
        bool _showFill = false;

        public TapToFillPage()
        {
            InitializeComponent();
        }

        private void OnCanvasViewTapped(object sender, System.EventArgs e)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnCanvasViewTapped)}");

            _showFill = !_showFill;
            (sender as SKCanvasView).InvalidateSurface();
        }

        private void OnCanvasViewPaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnCanvasViewPaintSurface)}");

            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = e.Surface.Canvas;

            canvas.Clear();

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Red.ToSKColor(),
                StrokeWidth = 50
            };

            canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);

            if (_showFill)
            {
                paint.Style = SKPaintStyle.Fill;
                paint.Color = Color.Blue.ToSKColor();
                canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);
            }
        }
    }
}
