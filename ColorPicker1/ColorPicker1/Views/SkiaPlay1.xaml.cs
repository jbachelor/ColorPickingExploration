using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;

namespace ColorPicker1.Views
{
    public partial class SkiaPlay1 : ContentPage
    {
        public SkiaPlay1()
        {
            InitializeComponent();

            DrawSimpleCircle();

        }

        private void DrawSimpleCircle()
        {
            Title = "Simple Circle";

            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = e.Surface.Canvas;

            canvas.Clear();

            // Draw border of circle: 
            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Red.ToSKColor(),
                StrokeWidth = 25
            };
            canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);

            // Draw fill of circle
            paint.Style = SKPaintStyle.Fill;
            paint.Color = SKColors.BlanchedAlmond;
            canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);
        }
    }
}
