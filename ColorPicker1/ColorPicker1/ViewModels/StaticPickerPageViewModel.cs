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

        public StaticPickerPageViewModel(IImageSourceConverter imageSourceConverter)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(StaticPickerPageViewModel)}:  ctor");

            CanvasTappedCommand = new DelegateCommand<SimplePoint>(OnCanvasTappedAsync);
            _imageSourceConverter = imageSourceConverter;
        }

        private async void OnCanvasTappedAsync(SimplePoint pointTapped)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnCanvasTappedAsync)}:  X = {pointTapped.X}, Y = {pointTapped.Y}");

            SelectedColor = await _imageSourceConverter.ConvertAsync(Globals.COLOR_IMAGE.Source, pointTapped.X, pointTapped.Y);
        }
    }
}
