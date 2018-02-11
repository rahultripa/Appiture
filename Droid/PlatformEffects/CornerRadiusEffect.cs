using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.Linq;

[assembly: ResolutionGroupName("Appitecture")]
[assembly: ExportEffect(typeof(Appitecture.Droid.PlatformEffects.CornerRadiusEffect), "CornerRadiusEffect")]
namespace Appitecture.Droid.PlatformEffects {
    
    public class CornerRadiusEffect : PlatformEffect {
        protected override void OnAttached() {
            var effect = Element.Effects.FirstOrDefault(x => x is Appitecture.Effects.CornerRadiusEffect) as Appitecture.Effects.CornerRadiusEffect;
            var formsImage = (Image)Element;
            var loading = formsImage.IsLoading;
            var image = (ImageView)Control;
            image.BuildDrawingCache(true);
            var bitmap = image.DrawingCache;

            //var bitmap = ((ColorDrawable)image.Drawable).g;
            var w = bitmap.Width;
            var h = bitmap.Height;

            var rounder = Bitmap.CreateBitmap(w,h,Bitmap.Config.Argb8888);
            var canvas = new Canvas(rounder);  

            Paint paint = new Paint(PaintFlags.AntiAlias);
            paint.Color = Android.Graphics.Color.Red;

            canvas.DrawRoundRect(new RectF(0, 0, w, h), (float)effect.Radius, (float)effect.Radius, paint);

            paint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.DstIn));

            Bitmap result = Bitmap.CreateBitmap(w, h, Bitmap.Config.Argb8888);
            Canvas resultCanvas = new Canvas(result);
            resultCanvas.DrawBitmap(bitmap, 0, 0, null);
            resultCanvas.DrawBitmap(rounder, 0, 0, paint);
        }

        protected override void OnDetached() { }
    }
}
