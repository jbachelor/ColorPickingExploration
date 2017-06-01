using Prism.Commands;
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

		public SkiaPicker1PageViewModel()
		{
			CanvasTappedCommand = new DelegateCommand<SimplePoint>(OnCanvassTapped);
		}

		void OnCanvassTapped(SimplePoint tapPoint)
		{
			Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnCanvassTapped)}:  raw x:{tapPoint.RawX}, raw y:{tapPoint.RawY}, x:{tapPoint.X}, y:{tapPoint.Y}");

		}
	}
}
