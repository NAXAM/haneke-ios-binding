using System;
using CoreGraphics;
using UIKit;
using Haneke;

namespace HanekeQs
{
    public partial class ViewController : UIViewController
    {
        private UIImageView image;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            image = new UIImageView { 
                ContentMode = UIViewContentMode.ScaleAspectFit
            };

            View.AddSubview(image);
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

			image.Frame = View.Bounds;

			image.Hnk_setImageFromURL(new Foundation.NSUrl("https://static.pexels.com/photos/39517/rose-flower-blossom-bloom-39517.jpeg"));
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
