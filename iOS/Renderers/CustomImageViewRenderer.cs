using System;
using Appitecture.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Image), typeof(CustomImageViewRenderer))]
namespace Appitecture.iOS.Renderers {
    
    public class CustomImageViewRenderer : ImageRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Image> e) {
            base.OnElementChanged(e);

            if(e.NewElement != null) {
                var radius = Utilities.GetCornerRadius(e.NewElement);

                Control.Layer.CornerRadius = radius;
                Control.ClipsToBounds = true;
                Control.Layer.MasksToBounds = true;
            }
        }
    }
}
