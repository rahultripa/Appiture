using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Appitecture.Droid.Renderers;
using Android.Graphics;

[assembly: ExportRenderer(typeof(Image), typeof(CustomImageRenderer))]
namespace Appitecture.Droid.Renderers
{
    public class CustomImageRenderer : ImageRenderer
    {

        public CustomImageRenderer() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e) {
            base.OnElementChanged(e);
            if (e.OldElement == null) {
            }
        }

        protected override bool DrawChild(Canvas canvas, Android.Views.View child, long drawingTime) {
            try {
                var radius = Utilities.GetCornerRadius(Element);
                var rect = new Rect(0, 0, Width, Height);
                var rectF = new RectF(rect);
                var path = new Path();
                path.AddRoundRect(rectF,radius, radius, Path.Direction.Ccw);
                canvas.Save();
                canvas.ClipPath(path);
                var paint = new Paint();
                paint.AntiAlias = true;
                paint.SetStyle(Paint.Style.Fill);
                canvas.DrawPath(path, paint);
                paint.Dispose();
                var result = base.DrawChild(canvas, child, drawingTime);
                path.Dispose();
                canvas.Restore();
                path = new Path();
                path.AddRoundRect(rectF, radius, radius, Path.Direction.Ccw);
                path.Dispose();
                return result;
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine("Unable to create circle image: " + ex);
            }
            return base.DrawChild(canvas, child, drawingTime);
        }
    }
}