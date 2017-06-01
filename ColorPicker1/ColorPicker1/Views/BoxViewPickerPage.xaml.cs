using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace ColorPicker1.Views
{
    public partial class BoxViewPickerPage : ContentPage
    {
        TimeSpan colorStackTime;
        TimeSpan overallTime;

        public BoxViewPickerPage()
        {
            InitializeComponent();
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(BoxViewPickerPage)}:  ctor");

            StackLayout colorStack = CreateColorStack();
            UpperStackLayout.Children.Add(colorStack);
        }

        private StackLayout CreateColorStack()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(CreateColorStack)}");

            var swatch = new Stopwatch();
            swatch.Start();

            var fixedBrightness = 0.5;
            var verticalStack = new StackLayout
            {
                Spacing = 0,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                HeightRequest = 100
            };

            for (int i = 1; i <= 100; i += 2)
            {
                var nextRowStack = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 0
                };

                var saturation = (double)i / 100.0;

                for (int j = 1; j <= 360; j += 3)
                {
                    var hue = (double)j / 360.0;
                    var hsColor = Color.FromHsla(hue, saturation, fixedBrightness);

                    var colorButton = new Button
                    {
                        BackgroundColor = hsColor,
                        HeightRequest = 3,
                        WidthRequest = 4
                    };

                    

                    nextRowStack.Children.Add(colorButton);
                }

                verticalStack.Children.Add(nextRowStack);
            }

            swatch.Stop();
            colorStackTime = swatch.Elapsed;
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(CreateColorStack)} took {colorStackTime}");

            return verticalStack;
        }

    }
}
