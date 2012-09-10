using System;
using System.Drawing;
using RoundProgressView;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace RoundProgressViewDemo
{
	public partial class RoundProgressViewDemoViewController : UIViewController
	{
		private RPView roundProgess;
		private RPView mRoundProgess;
		private RPView sRoundProgess;

		public RoundProgressViewDemoViewController () : base ("RoundProgressViewDemoViewController", null)
		{
			roundProgess = new RPView(new RectangleF(20, 10, 166,166));
			roundProgess.Image = UIImage.FromBundle("Images/progress-circle-large.png");
			roundProgess.TintColor = UIColor.Blue;
			roundProgess.TextColor = UIColor.FromRGBA(0.70f,0.70f,0.70f,1.0f);
			roundProgess.Font = UIFont.SystemFontOfSize(50f); 
			roundProgess.Progress = 0.5f;

			this.View.Add(roundProgess);

			mRoundProgess = new RPView(new RectangleF(20, 200, 104,104));
			mRoundProgess.Image = UIImage.FromBundle("Images/progress-circle-medium.png");
			mRoundProgess.TintColor = UIColor.Green;
			mRoundProgess.TextColor = UIColor.FromRGBA(0.70f,0.70f,0.70f,1.0f);
			mRoundProgess.Font = UIFont.SystemFontOfSize(25f); 
			mRoundProgess.Progress = 0.5f;
			this.View.Add(mRoundProgess);

			sRoundProgess = new RPView(new RectangleF(20, 325, 54,54));
			sRoundProgess.Image = UIImage.FromBundle("Images/progress-circle-small.png");
			sRoundProgess.TintColor = UIColor.Red;
			sRoundProgess.TextColor = UIColor.FromRGBA(0.70f,0.70f,0.70f,1.0f);
			sRoundProgess.Font = UIFont.SystemFontOfSize(15f); 
			sRoundProgess.Progress = 0.5f;
			this.View.Add(sRoundProgess);

			UISlider percentage = new UISlider(new RectangleF(20,400,200,75));

			percentage.Value = 0.5f;
			percentage.MinValue = 0.0f;
			percentage.MaxValue = 1.0f;

			percentage.ValueChanged += (object sender, EventArgs e) => {
				roundProgess.Progress = percentage.Value;
				mRoundProgess.Progress = percentage.Value;
				sRoundProgess.Progress = percentage.Value;
			}; 

			this.View.Add(percentage);

		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

