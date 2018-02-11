
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Appitecture {
    
    public class Utilities {
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.CreateAttached("CornerRadius", typeof(int), typeof(Utilities), 0);
 
        public static int GetCornerRadius(BindableObject view) {
            return (int)view.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(BindableObject view, int value) {
            view.SetValue(CornerRadiusProperty, value);
        }
       
    }
}
