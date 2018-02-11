using System;

using Xamarin.Forms;

namespace Appitecture.Cells {
    
    public class CustomViewCell : ViewCell {
        public Accessory Accessory {
            get;
            set;
        }
    }

    public enum Accessory {
        DisclosureIndicator
    }
}

