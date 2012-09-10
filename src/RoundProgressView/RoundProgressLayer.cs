using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreAnimation;
using System.Drawing;

namespace RoundProgressView
{
	public class RoundProgressLayer : CALayer
	{
		public RoundProgressLayer ()
		{
		}


		[Export ("initWithLayer:")]
		public RoundProgressLayer (CALayer other)
			: base (other)
		{
		}
		
		public override void Clone (CALayer other)
		{
			RoundProgressLayer o = (RoundProgressLayer) other;
			Progress = o.Progress;
			StartAngle = o.StartAngle;
			TintColor = o.TintColor;
			TrackColor = o.TrackColor;
			base.Clone (other);
		}
		
		[Export ("progress")]
		public float Progress { get; set; }
		
		[Export ("startAngle")]
		public float StartAngle { get; set; }
		
		[Export ("tintColor")]
		public UIColor TintColor { get; set; }

		[Export ("trackColor")]
		public UIColor TrackColor { get; set; }

		
		[Export ("needsDisplayForKey:")]
		static bool NeedsDisplayForKey (NSString key)
		{
			if (key.ToString () == "progress") 
				return true;
			else
				return CALayer.NeedsDisplayForKey (key);
		}

		public override void DrawInContext (MonoTouch.CoreGraphics.CGContext ctx)
		{
			base.DrawInContext (ctx);
			 
			float radius = Math.Min(this.Bounds.Width, this.Bounds.Height)/2;
			PointF center = new PointF (this.Bounds.Width / 2, this.Bounds.Height / 2);

			//Background Circle
			ctx.AddEllipseInRect(new RectangleF(center.X,center.Y, radius *2, radius *2));
			ctx.SetFillColor(TrackColor.CGColor);
			ctx.FillPath();

			// Elapsed Arc
			ctx.AddArc(center.X,center.Y,radius, StartAngle, (float)(StartAngle + Progress * 2.0f * Math.PI),false);
			ctx.AddLineToPoint(center.X,center.Y);
			ctx.ClosePath();
			ctx.SetFillColor(TintColor.CGColor);
			ctx.FillPath();

		}


	}
}

