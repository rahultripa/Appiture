using System;
using System.Collections.ObjectModel;
using Appitecture.Core.Models;
using Appitecture.Core.Requests;
using TinyMvvm;

namespace Appitecture.Core.ViewModels
{
    public class AssistantsViewModel : ViewModelBase
    {
        public AssistantsViewModel()
        {
        }

        private GetAssistantsRequest getAssistantsRequest;

        public AssistantsViewModel(GetAssistantsRequest getAssistantsRequest)
        {
            this.getAssistantsRequest = getAssistantsRequest;
        }

        public async override System.Threading.Tasks.Task Initialize()
        {
            IsBusy = true;
            var myassistants = await  getAssistantsRequest.GetAssistants(0,0);
            Myassistants = new ObservableCollection<Myassistant>(myassistants);
            IsBusy = false;
            RaisePropertyChanged("Myassistants");
        }
      
        public ObservableCollection<Myassistant> Myassistants { get; set; }

        public Myassistant Myassistant
        {
            set
            {
                if (value != null)
                {
                    Navigation.NavigateToAsync("AssistantView", value.assistantId);
                }
            }
        }
    }

}
