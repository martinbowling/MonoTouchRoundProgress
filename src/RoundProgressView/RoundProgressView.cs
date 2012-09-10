using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreAnimation;
using System.Drawing;
using MonoTouch.ObjCRuntime;

namespace RoundProgressView
{
	public class RoundProgressView : UIView 
	{


		public float Progress { get{
				var rl = this.Layer as RoundProgressLayer;
				return rl.Progress;
			} 
			set{
				var rl = this.Layer as RoundProgressLayer;
				rl.Progress = value;
				rl.SetNeedsDisplay();
			} 
		}

		public float StartAngle { get{
				var rl = this.Layer as RoundProgressLayer;
				return rl.StartAngle;
			} 
			set{
				var rl = this.Layer as RoundProgressLayer;
				rl.StartAngle = value;
				rl.SetNeedsDisplay();
			} 
		
		}

		public UIColor TintColor { get{
				var rl = this.Layer as RoundProgressLayer;
				return rl.TintColor;
			} 
			set{
				var rl = this.Layer as RoundProgressLayer;
				rl.TintColor = value;
				rl.SetNeedsDisplay();
			} 
		}

		public UIColor TrackColor { get{
				var rl = this.Layer as RoundProgressLayer;
				return rl.TrackColor;
			} 
			set{
				var rl = this.Layer as RoundProgressLayer;
				rl.TrackColor = value;
				rl.SetNeedsDisplay();
			} 
		}

		public RoundProgressView ()
		{

		}

		public RoundProgressView (RectangleF frame) : base(frame)
		{
			Initialize();
		}

		protected virtual void Initialize()
		{
			this.TrackColor = UIColor.Clear;
			this.BackgroundColor  = UIColor.Clear;
			this.Opaque = false;
		}

		[Export ("layerClass")]
		public static Class LayerClass () {
			return new Class (typeof (RoundProgressLayer));
		}

		public void SetProgress(float progress){
			bool growing = false;
			if(progress > this.Progress){
				growing = true;
			}

			SetProgress(progress, growing);
		}

		public void SetTintColor(UIColor tintColor)
		{
			var rl = this.Layer as RoundProgressLayer;
			rl.TintColor = tintColor;
			rl.SetNeedsDisplay();
		}

		public void SetProgress(float progress, bool animated){

			if(progress < 0.0f)
				progress = 0.0f;
			else if(progress > 1.0f)
				progress = 1.0f;
			var rl = this.Layer as RoundProgressLayer;

			if(animated){
				CABasicAnimation animation = new CABasicAnimation();
				animation.KeyPath = "progress";
				animation.Duration = 0.25;
				animation.From = NSNumber.FromFloat(rl.Progress);
				animation.To = NSNumber.FromFloat(progress);
				rl.AddAnimation(animation,"progressAnimation");
				rl.Progress = progress;
			}
			else {
				rl.Progress = progress;
				rl.SetNeedsDisplay();
			}
		}

	}
}

