using ColorPicker1.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;

namespace ColorPicker1.ViewModels
{
    public class StaticPickerPageViewModel : BindableBase
    {
        public DelegateCommand<SimplePoint> CanvasTappedCommand { get; set; }
        IImageSourceConverter _imageSourceConverter;

        private Color _selectedColor;
        public Color SelectedColor
        {
            get { return _selectedColor; }
            set { SetProperty(ref _selectedColor, value); }
        }

        private Color _selectedColorRaw;
        public Color SelectedColorRaw
        {
            get { return _selectedColorRaw; }
            set { SetProperty(ref _selectedColorRaw, value); }
        }

        private string _labelText1;
        public string LabelText1
        {
            get { return _labelText1; }
            set { SetProperty(ref _labelText1, value); }
        }

        private string _labelText2;
        public string LabelText2
        {
            get { return _labelText2; }
            set { SetProperty(ref _labelText2, value); }
        }

        public StaticPickerPageViewModel(IImageSourceConverter imageSourceConverter)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(StaticPickerPageViewModel)}:  ctor");

            CanvasTappedCommand = new DelegateCommand<SimplePoint>(OnCanvasTappedAsync);
            _imageSourceConverter = imageSourceConverter;
        }

        private async void OnCanvasTappedAsync(SimplePoint pointTapped)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnCanvasTappedAsync)}");

            SelectedColorRaw = await _imageSourceConverter.ConvertAsync(Globals.COLOR_IMAGE.Source, pointTapped.RawX, pointTapped.RawY);
            SelectedColor = await _imageSourceConverter.ConvertAsync(Globals.COLOR_IMAGE.Source, pointTapped.X, pointTapped.Y);

            LabelText1 = $"{pointTapped.RawX}, {pointTapped.RawY}:  H {SelectedColorRaw.Hue}, S {SelectedColorRaw.Saturation}, L {SelectedColorRaw.Luminosity}";
            LabelText2 = $"{pointTapped.X}, {pointTapped.Y}:  H {SelectedColor.Hue}, S {SelectedColor.Saturation}, L {SelectedColor.Luminosity}";
        }
    }
}
