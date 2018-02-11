using System;
using Xamarin.Forms;

namespace Appitecture.Effects {
    
    public class CornerRadiusEffect : RoutingEffect {
        public CornerRadiusEffect() : base("Appitecture.CornerRadiusEffect") { }
        public double Radius { get; set; }
    }
}
