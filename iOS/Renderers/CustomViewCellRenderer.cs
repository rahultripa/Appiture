using System;
using Xamarin.Forms.Platform.iOS;
using Appitecture.iOS.Renderers;
using Xamarin.Forms;
using Appitecture.Cells;
using UIKit;

[assembly: ExportRenderer(typeof(CustomViewCell), typeof(CustomViewCellRenderer))]
namespace Appitecture.iOS.Renderers {
    
    public class CustomViewCellRenderer : ViewCellRenderer {
        public override UIKit.UITableViewCell GetCell(Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv) {
            var cell = base.GetCell(item, reusableCell, tv);
            var element = (CustomViewCell)item;
            switch (element.Accessory) {
                case Accessory.DisclosureIndicator:
                    cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                    break;
            }
            return cell;
        }
    }
}
