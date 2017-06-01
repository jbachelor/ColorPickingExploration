using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace ColorPicker1
{
    public static class Globals
    {
        public static Image COLOR_IMAGE;

        public static Dictionary<SKRect, SKColor> colorDictionary;
        public static float widthIncrement;
        public static float heightIncrement;
        public static SKColor ColorChosen;
    }
}
