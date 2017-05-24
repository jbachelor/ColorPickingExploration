using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ColorPicker1
{
    public interface IImageSourceConverter
    {
        Task<Color> ConvertAsync(ImageSource imageSource, double x, double y);
    }
}
