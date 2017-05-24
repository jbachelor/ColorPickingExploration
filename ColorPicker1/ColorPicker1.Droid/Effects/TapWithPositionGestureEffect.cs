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

[assembly: ResolutionGroupName("AvalonSoftware")]
[assembly: ExportEffect(typeof(TapWithPositionGestureEffect), nameof(TapWithPositionGestureEffect))]
namespace ColorPicker1.Droid.Effects
{
    class TapWithPositionGestureEffect : PlatformEffect
    {
        private GestureDetectorCompat gestureRecognizer;
        private readonly InternalGestureDetector tapDetector;
        private Command<Point> tapWithPositionCommand;
        private DisplayMetrics displayMetrics;

        public TapWithPositionGestureEffect()
        {
            sys.Debug.WriteLine($"**** {this.GetType().Name}.{nameof(TapWithPositionGestureEffect)}:  ctor");
            tapDetector = new InternalGestureDetector
            {
                TapAction = motionEvent =>
                {
                    sys.Debug.WriteLine($"**** {this.GetType().Name}.{nameof(TapWithPositionGestureEffect)}:  tapDetector motionEvent");

                    var tap = tapWithPositionCommand;
                    if (tap != null)
                    {
                        var x = motionEvent.GetX();
                        var y = motionEvent.GetY();

                        var point = PxToDp(new Point(x, y));
                        sys.Debug.WriteLine($"\t**** Tap detected at {x} x {y} in forms: {point.X} x {point.Y}");
                        if (tap.CanExecute(point))
                            tap.Execute(point);
                    }
                }
            };
        }

        private Point PxToDp(Point point)
        {
            sys.Debug.WriteLine($"**** {this.GetType().Name}.{nameof(PxToDp)}:  point.X = {point.X}, point.Y = {point.Y}");
            point.X = point.X / displayMetrics.Density;
            point.Y = point.Y / displayMetrics.Density;
            sys.Debug.WriteLine($"\t**** {this.GetType().Name}.{nameof(PxToDp)}:  Returning point.X = {point.X}, point.Y = {point.Y} due to displayMetrics.Density = {displayMetrics.Density}");
            return point;
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            sys.Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnElementPropertyChanged)}");
            tapWithPositionCommand = Gesture.GetCommand(Element);
        }

        protected override void OnAttached()
        {
            sys.Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnAttached)}");
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
            sys.Debug.WriteLine($"**** {this.GetType().Name}.{nameof(ControlOnTouch)}");

            gestureRecognizer?.OnTouchEvent(touchEventArgs.Event);
        }

        protected override void OnDetached()
        {
            sys.Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnDetached)}");

            var control = Control ?? Container;
            control.Touch -= ControlOnTouch;
        }


        sealed class InternalGestureDetector : GestureDetector.SimpleOnGestureListener
        {
            public Action<MotionEvent> TapAction { get; set; }
            public float Density { get; set; }

            public override bool OnSingleTapUp(MotionEvent e)
            {
                sys.Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnSingleTapUp)}");
                TapAction?.Invoke(e);
                return true;
            }
        }
    }
}