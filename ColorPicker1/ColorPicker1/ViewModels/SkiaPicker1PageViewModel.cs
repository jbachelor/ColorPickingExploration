using Prism.Commands;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using ColorPicker1.Models;
using System.Diagnostics;

namespace ColorPicker1.ViewModels
{
	public class SkiaPicker1PageViewModel : BindableBase
	{
		public DelegateCommand<SimplePoint> CanvasTappedCommand { get; set; }

			CanvasTappedCommand = new DelegateCommand<SimplePoint>(OnCanvasTappedAsync);

		}

		private async void OnCanvasTappedAsync(SimplePoint pointTapped)
		{
			Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnCanvasTappedAsync)}");

            foreach (var kvp in Globals.colorDictionary)
            {
                if (kvp.Key.Contains((float)pointTapped.X, (float)pointTapped.Y))
                {
                    Globals.ColorChosen = kvp.Value;
                    break;
                }
            }   
        }
    }
}
