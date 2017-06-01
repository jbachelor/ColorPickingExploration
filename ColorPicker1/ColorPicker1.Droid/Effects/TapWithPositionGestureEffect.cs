using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sys = System.Diagnostics;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using View = Android.Views.View;
using Android.Widget;
using Xamarin.Forms;
using ColorPicker1.Droid.Effects;
using Xamarin.Forms.Platform.Android;
using Android.Support.V4.View;
using Android.Util;
using System.ComponentModel;
using ColorPicker1.Views;
using Prism.Commands;
using ColorPicker1.Models;

[assembly: ResolutionGroupName("DigiPug")]
[assembly: ExportEffect(typeof(TapWithPositionGestureEffect), nameof(TapWithPositionGestureEffect))]
namespace ColorPicker1.Droid.Effects
{
	public class TapWithPositionGestureEffect : PlatformEffect
	{
		private GestureDetectorCompat gestureRecognizer;
		private readonly InternalGestureDetector tapDetector;
		private DelegateCommand<SimplePoint> tapWithPositionCommand;
		private DisplayMetrics displayMetrics;

		public TapWithPositionGestureEffect()
		{
			tapDetector = new InternalGestureDetector
			{
				TapAction = motionEvent =>
				{
					var tap = tapWithPositionCommand;
					if (tap != null)
					{
						var x = motionEvent.GetX();
						var y = motionEvent.GetY();

						var xfPoint = PxToDp(new Point(x, y));

						if (tap.CanExecute(xfPoint))
							tap.Execute(xfPoint);
					}
				}
			};

		}

		private SimplePoint PxToDp(Point point)
		{
			var simplePoint = new SimplePoint();
			simplePoint.RawX = point.X;
			simplePoint.RawY = point.Y;
			simplePoint.X = point.X / displayMetrics.Density;
			simplePoint.Y = point.Y / displayMetrics.Density;

			sys.Debug.WriteLine($"**** {this.GetType().Name}.{nameof(PxToDp)}:  Adjusting raw point (x = {simplePoint.RawX}, y = {simplePoint.RawY}) to x = {simplePoint.X}, y = {simplePoint.Y} based on displayMetrics.Density of {displayMetrics.Density}");
			return simplePoint;
		}

		protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
		{
			tapWithPositionCommand = Gesture.GetCommand(Element);
		}

		protected override void OnAttached()
		{
			var control = Control ?? Container;

			var context = control.Context;
			displayMetrics = context.Resources.DisplayMetrics;
			tapDetector.Density = displayMetrics.Density;

			if (gestureRecognizer == null)
				gestureRecognizer = new GestureDetectorCompat(context, tapDetector);
			control.Touch += ControlOnTouch;

			OnElementPropertyChanged(new PropertyChangedEventArgs(String.Empty));
		}

		private void ControlOnTouch(object sender, View.TouchEventArgs touchEventArgs)
		{
			gestureRecognizer?.OnTouchEvent(touchEventArgs.Event);
		}

		protected override void OnDetached()
		{
			var control = Control ?? Container;
			control.Touch -= ControlOnTouch;
		}


		sealed class InternalGestureDetector : GestureDetector.SimpleOnGestureListener
		{
			public Action<MotionEvent> TapAction { get; set; }
			public float Density { get; set; }

			public override bool OnSingleTapUp(MotionEvent e)
			{
				TapAction?.Invoke(e);
				return true;
			}
		}
	}
}