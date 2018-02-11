using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace Appitecture.iOS {
    
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options) {
            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsGoogleMaps.Init("AIzaSyADi2OXxr0OEUKMWdKNS-avIs-Y5_sMmDk"); 
        
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }
    }
}
