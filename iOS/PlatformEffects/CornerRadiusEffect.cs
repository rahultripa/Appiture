using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System.Linq;

[assembly: ResolutionGroupName("Appitecture")]
[assembly: ExportEffect(typeof(Appitecture.iOS.PlatformEffects.CornerRadiusEffect), "CornerRadiusEffect")]
namespace Appitecture.iOS.PlatformEffects {
    
    public class CornerRadiusEffect : PlatformEffect {
        public CornerRadiusEffect() { }

        protected override void OnAttached() {
            var effect = Element.Effects.FirstOrDefault(x => x is Appitecture.Effects.CornerRadiusEffect) as Appitecture.Effects.CornerRadiusEffect;
            var formsImage = (Image)Element;
            var loading = formsImage.IsLoading;
            if(effect != null) {
                Control.Layer.CornerRadius = (float)effect.Radius;
                Control.ClipsToBounds = true;
            }
        }

        protected override void OnDetached() {
            Control.Layer.CornerRadius = 0;
        }
    }
}
