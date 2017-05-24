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

        public StaticPickerPageViewModel()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(StaticPickerPageViewModel)}:  ctor");
            CanvasTappedCommand = new DelegateCommand<SimplePoint>(OnCanvasTapped);
        }

        private void OnCanvasTapped(SimplePoint pointTapped)
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnCanvasTapped)}:  X = {pointTapped.X}, Y = {pointTapped.Y}");
        }
    }
}
