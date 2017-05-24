using Xamarin.Forms;
using SkiaSharp;
using System.Reflection;
using System.IO;
using SkiaSharp.Views.Forms;
using System;
using System.Diagnostics;
using ColorPicker1;

namespace ColorPicker1.Views
{
    public partial class StaticPickerPage : ContentPage
    {
        public StaticPickerPage()
        {
            InitializeComponent();

            Globals.COLOR_IMAGE = ColorPicker;
        }
    }
}
