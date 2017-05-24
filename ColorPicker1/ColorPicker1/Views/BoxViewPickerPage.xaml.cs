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

            Stopwatch swatch = new Stopwatch();
            swatch.Start();

            StackLayout colorStack = CreateColorStack();
            StackLayout brightnessSliderStack = CreateBrightnessSliderLayout();

            //OuterStackLayout.Children.Add(colorStack);
            //OuterStackLayout.Children.Add(brightnessSliderStack);

            Label timeLabel = CreateTimeLabel();
            //OuterStackLayout.Children.Add(timeLabel);
            
        }

        private Label CreateTimeLabel()
        {
            return new Label
            {
                Text = "timer label"
            };
        }

        private StackLayout CreateBrightnessSliderLayout()
        {
            var sliderLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            var slider = new Slider(0.0, 100.0, 50.0);
            var label = new Label();
            label.SetBinding(Label.TextProperty, slider.Value.ToString());

            sliderLayout.Children.Add(slider);
            sliderLayout.Children.Add(label);

            return sliderLayout;
        }

        private StackLayout CreateColorStack()
        {
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

            swatch.Stop();
            colorStackTime = swatch.Elapsed;
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(CreateColorStack)} took {colorStackTime}");

            return verticalStack;
        }

    }
}
