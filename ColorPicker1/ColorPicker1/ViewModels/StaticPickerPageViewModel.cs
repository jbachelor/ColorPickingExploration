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
        public DelegateCommand<Point> CanvasTappedCommand { get; set; }

        public StaticPickerPageViewModel()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(StaticPickerPageViewModel)}:  ctor");
            //CanvasTappedCommand = new DelegateCommand<Point>(OnCanvasTapped);
        }

        private void OnCanvasTapped(Point pointTapped)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnCanvasTapped)}:  X = {pointTapped.X}, Y = {pointTapped.Y}");
        }
    }
}
