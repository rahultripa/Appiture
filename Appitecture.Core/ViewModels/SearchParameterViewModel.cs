using System;
using Appitecture.Core.Models;
using Appitecture.Core.Requests;
using TinyMvvm;
using Xamarin.Forms;

namespace Appitecture.Core.ViewModels
{
    public class SearchParameterViewModel : ViewModelBase
    {
        private SelectedParameter _selectedParameter;
        public SearchParameterViewModel()
        {
          }
        public async override System.Threading.Tasks.Task Initialize()
        {
            IsBusy = true;
            selectedParameter = (SelectedParameter)NavigationParameter;
            IsBusy = false;

        }
        public Command SubmitCommand => new Command(() =>
        {

            Navigation.NavigateToAsync("AssistantMapView", selectedParameter);
        });

        public SelectedParameter selectedParameter
        {

            get { return _selectedParameter; }

            set
            {
                _selectedParameter = value;
                RaisePropertyChanged("selectedParameter");
            }
        }
    }
    
}

