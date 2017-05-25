using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Util;
using ColorPicker1.Droid.Services;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: Dependency(typeof(ImageSourceConverterDroid))]
namespace ColorPicker1.Droid.Services
{
    public class ImageSourceConverterDroid : IImageSourceConverter
    {
        public async Task<Xamarin.Forms.Color> ConvertAsync(ImageSource imageSource, double x, double y)
        {
            Debug.WriteLine($"{this.GetType().Name}.{nameof(ConvertAsync)}");

            Bitmap bitmap = await GetBitmap(imageSource);

            Resources resource = Forms.Context.Resources;
            DisplayMetrics metrics = resource.DisplayMetrics;
            var dpX = (int)x * ((float)metrics.DensityDpi / 160);
            var dpY = (int)y * ((float)metrics.DensityDpi / 160);


            var intX = (int)x;
            var intY = (int)y;


            var colorInt = bitmap.GetPixel((int)dpX, (int)dpY);

            Xamarin.Forms.Color color = ConvertDecimalToColor(colorInt);

            Debug.WriteLine($"{this.GetType().Name}.{nameof(ConvertAsync)}:  {colorInt}");

            return color;
        }

        private Xamarin.Forms.Color ConvertDecimalToColor(int colorInt)
        {
            int a = (colorInt >> 24) & 0xff;
            int r = (colorInt >> 16) & 0xff;
            int g = (colorInt >> 8) & 0xff;
            int b = (colorInt) & 0xff;

            var color = Xamarin.Forms.Color.FromRgba(r, g, b, a);

            Debug.WriteLine($"{this.GetType().Name}.{nameof(ConvertDecimalToColor)}:  {color}");
            return color;
        }

        async Task<Bitmap> GetBitmap(ImageSource image)
        {
            return await GetImageFromImageSource(image, Forms.Context);
        }

        private async Task<Bitmap> GetImageFromImageSource(ImageSource imageSource, Context context)
        {
            IImageSourceHandler handler;

            if (imageSource is FileImageSource)
            {
                handler = new FileImageSourceHandler();
            }
            else if (imageSource is StreamImageSource)
            {
                handler = new StreamImagesourceHandler(); // sic
            }
            else if (imageSource is UriImageSource)
            {
                handler = new ImageLoaderSourceHandler(); // sic
            }
            else
            {
                throw new NotImplementedException();
            }

            return await handler.LoadImageAsync(imageSource, context);
        }
    }
}
