using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Appitecture.Views
{
    public partial class AssistantsView 
    {
        public AssistantsView()
        {
            InitializeComponent();
        }
        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (Myassistants.SelectedItem != null)
            {
                Myassistants.SelectedItem = null;
            }

        }
    }
}
