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

		private void ColorSpectrumCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
		{
			CreateHslSpectrum(e);
		}

        private void Handle_Tap(object sender, EventArgs e)
		{
			Debug.WriteLine("TAPPED");
		}

		private void CanvasTappedCommand(object sender, SKPaintSurfaceEventArgs e)
		{
            Debug.WriteLine("TAPPED");
		}

		private void CreateHslSpectrum(SKPaintSurfaceEventArgs e)
		{
            Globals.colorDictionary = new System.Collections.Generic.Dictionary<SKRect, SKColor>();
			SKImageInfo info = e.Info;
			SKSurface surface = e.Surface;
			SKCanvas canvas = e.Surface.Canvas;
			float halvsies = Math.Min(info.Height, info.Width) * 0.5f;

			Debug.WriteLine($"**** {this.GetType().Name}.{nameof(CreateHslSpectrum)}:  info.Height={info.Height}, info.Width={info.Width}, halvsies={halvsies}");

			canvas.Clear();
			int hue;
			int saturation;

			Globals.widthIncrement = info.Width / 361;
			Globals.heightIncrement = info.Height / 101;

			float left = 0f;
			float top = 0f;
			float right = Globals.widthIncrement;
			float bottom = Globals.heightIncrement;

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

                        Globals.colorDictionary.Add(colorRect, color);

						canvas.DrawRect(colorRect, paint);

						top += Globals.heightIncrement;
						bottom += Globals.heightIncrement;
					}

					top = 0f;
					bottom = Globals.heightIncrement;

					left += Globals.widthIncrement;
					right += Globals.widthIncrement;
				}
			}

		}

		void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
		{
			int oldVal = (int)Math.Round(e.OldValue, 0);
			int newVal = (int)Math.Round(e.NewValue, 0);

            label1.BackgroundColor = Globals.ColorChosen.ToFormsColor();

			if (oldVal != newVal)
			{
				Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnSliderValueChanged)}:  {newVal}");
				luminosity = newVal;
				ColorSpectrumCanvas.InvalidateSurface();
			}
		}
	}
}
