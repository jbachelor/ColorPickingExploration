using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace ColorPicker1.Views
{
	public partial class SkiaPicker1Page : ContentPage
	{

		public int luminosity = 50;

		public SkiaPicker1Page()
		{
			InitializeComponent();
			LightnessSlider.Value = luminosity;
		}

		void OnCanvasViewTapped(object sender, System.EventArgs e)
		{
			Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnCanvasViewTapped)}");
		}

		private void ColorSpectrumCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
		{
			CreateHslSpectrum(e);
		}

		private void CreateHslSpectrum(SKPaintSurfaceEventArgs e)
		{
			SKImageInfo info = e.Info;
			SKSurface surface = e.Surface;
			SKCanvas canvas = e.Surface.Canvas;
			float halvsies = Math.Min(info.Height, info.Width) * 0.5f;

			Debug.WriteLine($"**** {this.GetType().Name}.{nameof(CreateHslSpectrum)}:  info.Height={info.Height}, info.Width={info.Width}, halvsies={halvsies}");

			canvas.Clear();

			int hue;
			int saturation;

			float widthIncrement = info.Width / 361;
			float heightIncrement = info.Height / 101;

			float left = 0f;
			float top = 0f;
			float right = widthIncrement;
			float bottom = heightIncrement;

			using (SKPaint paint = new SKPaint())
			{
				for (int i = 0; i <= 360; i++)
				{
					//Debug.WriteLine($"\n\n**** {this.GetType().Name}.{nameof(CreateHslSpectrum)}:  Next color column:  S={i}\n");
					hue = i;

					for (int j = 0; j <= 100; j++)
					{
						saturation = j;
						var color = SKColor.FromHsl(hue, saturation, luminosity);

						//Debug.WriteLine($"\t**** {this.GetType().Name}.{nameof(CreateHslSpectrum)}:  H={h}, S={s}, L={luminosity}. RGB = {color.Red}, {color.Green}, {color.Blue}");

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

		void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
		{
			int oldVal = (int)Math.Round(e.OldValue, 0);
			int newVal = (int)Math.Round(e.NewValue, 0);

			if (oldVal != newVal)
			{
				Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnSliderValueChanged)}:  {newVal}");
				luminosity = newVal;
				ColorSpectrumCanvas.InvalidateSurface();
			}
		}
	}
}
