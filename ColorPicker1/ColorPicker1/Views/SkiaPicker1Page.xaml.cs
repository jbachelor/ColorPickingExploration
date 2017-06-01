using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace ColorPicker1.Views
{
    public partial class SkiaPicker1Page : ContentPage
    {
        public SkiaPicker1Page()
        {
            InitializeComponent();
        }

        private void ColorSpectrumCanvas_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            CreateHslSpectrum(e);
            //CreateRgbSpectrum(e);
        }

        private void CreateRgbSpectrum(SKPaintSurfaceEventArgs e)
        {
            //SKImageInfo info = e.Info;
            //SKSurface surface = e.Surface;
            //SKCanvas canvas = e.Surface.Canvas;
            //float halvsies = Math.Min(info.Height, info.Width) * 0.5f;

            //Debug.WriteLine($"**** {this.GetType().Name}.{nameof(ColorSpectrumCanvas_PaintSurface)}:  info.Height={info.Height}, info.Width={info.Width}, halvsies={halvsies}");

            //canvas.Clear();

            //int red = 1;
            //int green = 1;
            //int blue = 1;

            //float increment = 8f;

            //float left = 0f;
            //float top = 0f;
            //float right = increment;
            //float bottom = increment;

            //using (SKPaint paint = new SKPaint())
            //{
            //    for (int i = 1; i <= 100; i++)
            //    {
            //        hue = i;
            //        for (int j = 1; j <= 360; j++)
            //        {
            //            saturation = j;
            //            var color = SKColor.FromHsl(hue, saturation, lightness);

            //            SKRect colorRect = new SKRect(left, top, right, bottom);
            //            paint.Color = color;

            //            canvas.DrawRect(colorRect, paint);

            //            top += increment;
            //            bottom += increment;
            //        }

            //        top = 0f;
            //        bottom = increment;

            //        left += increment;
            //        right += increment;
            //    }
            //}
        }

        private void CreateHslSpectrum(SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = e.Surface.Canvas;
            float halvsies = Math.Min(info.Height, info.Width) * 0.5f;

            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(ColorSpectrumCanvas_PaintSurface)}:  info.Height={info.Height}, info.Width={info.Width}, halvsies={halvsies}");

            canvas.Clear();

            int hue;
            int saturation;
            int lightness = 70;

            float heightIncrement = 4f; //info.Height/360;
            float widthIncrement = 8f; // info.Width/100;

            float left = 0f;
            float top = 0f;
            float right = widthIncrement;
            float bottom = heightIncrement;

            using (SKPaint paint = new SKPaint())
            {
                for (int i = 1; i <= 100; i++)
                {
                    hue = i;
                    for (int j = 1; j <= 360; j++)
                    {
                        saturation = j;
                        var color = SKColor.FromHsl(hue, saturation, lightness);

                        SKRect colorRect = new SKRect(left, top, right, bottom);
                        paint.Color = color;

                        canvas.DrawRect(colorRect, paint);

                        top += heightIncrement;
                        bottom += heightIncrement;
                    }

                    top = 0f;
                    bottom = heightIncrement;

                    left += widthIncrement;
                    right += widthIncrement;
                }
            }
        }
    }
}
