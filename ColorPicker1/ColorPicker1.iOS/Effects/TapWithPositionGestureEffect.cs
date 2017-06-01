using System;
using System.ComponentModel;
using ColorPicker1.iOS.Effects;
using ColorPicker1.Models;
using ColorPicker1.Views;
using Prism.Commands;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("DigiPug")]
[assembly: ExportEffect(typeof(TapWithPositionGestureEffect), nameof(TapWithPositionGestureEffect))]
namespace ColorPicker1.iOS.Effects
{
	public class TapWithPositionGestureEffect : PlatformEffect
	{
		private readonly UITapGestureRecognizer tapDetector;
		private DelegateCommand<SimplePoint> tapWithPositionCommand;

		public TapWithPositionGestureEffect()
		{
			tapDetector = CreateTapRecognizer(() => tapWithPositionCommand); ;
		}

		private UITapGestureRecognizer CreateTapRecognizer(Func<DelegateCommand<SimplePoint>> getCommand)
		{
			return new UITapGestureRecognizer(() =>
			{
				var handler = getCommand();
				if (handler != null)
				{
					var control = Control ?? Container;
					var tapPoint = tapDetector.LocationInView(control);
					var touchPoint = tapDetector.LocationOfTouch(0, control);
					var point = new SimplePoint
					{
						X = tapPoint.X,
						Y = tapPoint.Y,
						RawX = touchPoint.X,
						RawY = touchPoint.Y
					};

					if (handler.CanExecute(point) == true)
						handler.Execute(point);
				}
			})
			{
				Enabled = false,
				ShouldRecognizeSimultaneously = (recognizer, gestureRecognizer) => true,
			};
		}

		protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
		{
			tapWithPositionCommand = Gesture.GetCommand(Element);
		}

		protected override void OnAttached()
		{
			var control = Control ?? Container;

			control.AddGestureRecognizer(tapDetector);
			tapDetector.Enabled = true;

			OnElementPropertyChanged(new PropertyChangedEventArgs(String.Empty));
		}

		protected override void OnDetached()
		{
			var control = Control ?? Container;
			tapDetector.Enabled = false;
			control.RemoveGestureRecognizer(tapDetector);
		}
	}
}
