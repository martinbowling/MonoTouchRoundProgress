using System;
using RoundProgressView;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace RoundProgressViewDemo
{
	public class RPView : UIView
	{
		private RoundProgressView.RoundProgressView pieView;
		private UILabel lblValue;
		private UIImageView imgView;

		private float _progress;
		private float _piePadding;
	
		private UIFont _font;
		private UIColor _textColor;
		private UIColor _tintColor;

		public float PiePadding {get {
				return _piePadding;
			}
			set {
				if(value == _piePadding)
					return;

				_piePadding = value;
				RectangleF pieFrame = this.Bounds;
				pieFrame.X = _piePadding;
				pieFrame.Y = _piePadding;
				pieFrame.Size.Width  -= 2*pieFrame.X;
				pieFrame.Size.Height -= 2*pieFrame.Y;

				this.pieView.Frame = pieFrame;
			}

		}

		public UIFont Font { get{
				return _font;
			} 
			set{
				_font = value;
				lblValue.Font = _font;
			}
		}



		public float Progress { get{
				return _progress;
			} set{
				float _newProgress = value;
				if(value < 0.0f)
					_newProgress = 0.0f;
				else if(value > 1.0f)
					_newProgress = 1.0f;

				if(_newProgress == _progress)
					return;

				_progress = _newProgress;
				lblValue.Text = String.Format("{0:0\\%}", Progress *100);
				this.pieView.SetProgress(_progress);
			} 
		}

		public UIColor TextColor { get{
				return _textColor;
			} 
			set{
				_textColor = value;
				lblValue.TextColor = _textColor;
			}
		}

		public UIColor TintColor { get{
				return _tintColor;
			}
			set {
				_tintColor = value;
				pieView.TintColor = _tintColor;
				pieView.SetNeedsDisplay();
			}
		}


		public RPView (RectangleF frame): base(frame)
		{

			this.Initialize();
		}

		protected virtual void Initialize()
		{
			pieView = new RoundProgressView.RoundProgressView(this.Bounds);
			pieView.StartAngle = (float)Math.PI/2;
			this.AddSubview(pieView);

			imgView = new UIImageView(this.Bounds);
			imgView.Image = UIImage.FromBundle("Images/progress-circle-large.png");
			this.AddSubview(imgView);

			lblValue = new UILabel(this.Bounds);
			lblValue.BackgroundColor = UIColor.Clear;
			lblValue.TextAlignment = UITextAlignment.Center;
			lblValue.ShadowColor = UIColor.White;
			lblValue.ShadowOffset = new SizeF(0,1);
			this.AddSubview(lblValue);

			PiePadding = 0.0f;

		}
	}
}

