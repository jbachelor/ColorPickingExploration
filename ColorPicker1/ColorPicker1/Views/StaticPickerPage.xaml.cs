using Xamarin.Forms;
using SkiaSharp;
using System.Reflection;
using System.IO;
using SkiaSharp.Views.Forms;
using System;
using System.Diagnostics;

namespace ColorPicker1.Views
{
    public partial class StaticPickerPage : ContentPage
    {
        SKBitmap resourceBitmap;
        SKCanvasView canvasView;

        public StaticPickerPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(StaticPickerPage)}:  ctor");
            InitializeComponent();
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(StaticPickerPage)}:  Finished with InitializeComponent.");

            InitializeSkiaCanvas();
            AddColorPickerImage();
        }

        ~StaticPickerPage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(StaticPickerPage)}:  dtor");
        }

        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnCanvasViewPaintSurface)}");

            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            if (resourceBitmap != null)
            {
                canvas.DrawBitmap(resourceBitmap,
                    new SKRect(0, info.Height / 3, info.Width, 2 * info.Height / 3));
            }
        }

        private void InitializeSkiaCanvas()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(InitializeSkiaCanvas)}");

            canvasView = new SKCanvasView
            {
                BackgroundColor = Color.Aqua,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            ColorImageStack.Children.Add(canvasView);
        }

        public void AddColorPickerImage()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(AddColorPickerImage)}");

            string resourceID = "ColorPicker1.PclResources.color_picker_spectrum.png";
            Assembly assembly = GetType().GetTypeInfo().Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            using (SKManagedStream skStream = new SKManagedStream(stream))
            {
                resourceBitmap = SKBitmap.Decode(skStream);
            }
        }
    }
}
