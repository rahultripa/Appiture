using System;
using System.Collections.Generic;
using Xamarin.Forms.GoogleMaps;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace Appitecture.Views
{
    public partial class AssistantMapView 
    {
        public AssistantMapView()
        {
            InitializeComponent();
            MapMyassistants.InitialCameraUpdate = CameraUpdateFactory.NewPositionZoom(new Position(19.2288d, 72.854d), 12d);
        }
        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (ListMyassistants.SelectedItem != null)
            {
                ListMyassistants.SelectedItem = null;
            }

        }
        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if(!switchView.IsToggled)
            {

                ListMyassistants.IsVisible = true;
                MapMyassistants.IsVisible = false;
            }
            else
            {
                ListMyassistants.IsVisible = false; 
                MapMyassistants.IsVisible = true;
            }
        }
    }
}
