using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace ColorPicker1.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CreateColorStack();
        }

        private void CreateColorStack()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var fixedBrightness = 0.5;
            var verticalStack = new StackLayout();
            verticalStack.Spacing = 0;

            for (int i = 1; i <= 100; i += 1)
            {
                var nextRowStack = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 0
                };

                var saturation = (double)i / 100.0;

                for (int j = 1; j <= 360; j += 6)
                {
                    var hue = (double)j / 360.0;
                    var hsColor = Color.FromHsla(hue, saturation, fixedBrightness);

                    var colorBox = new BoxView
                    {
                        Color = hsColor,
                        HeightRequest = 10,
                        WidthRequest = 10
                    };

                    nextRowStack.Children.Add(colorBox);
                }

                verticalStack.Children.Add(nextRowStack);
            }

            Content = verticalStack;

            stopwatch.Stop();
            Debug.WriteLine($"\n\n**** {this.GetType().Name}.{nameof(CreateColorStack)}:  Total time:  {stopwatch.Elapsed}\n\n");
        }
    }
}
