using System;
using Appitecture.Core.Requests;
using TinyMvvm;

namespace Appitecture.Core.ViewModels
{
    public class AssistantViewModel : ViewModelBase
    {
        private GetAssistantRequest getAssistantRequest;

        public AssistantViewModel(GetAssistantRequest getAssistantRequest)
        {
            this.getAssistantRequest = getAssistantRequest;
        }

        public Models.Myassistant Item { get; set; }

        public async override System.Threading.Tasks.Task Initialize()
        {
            IsBusy = true;
            var id = (int)NavigationParameter;
            Item = await getAssistantRequest.GetAssistants(id);
            IsBusy = false;
            RaisePropertyChanged("Item");
        }
        public TinyCommand BookCommand
        {
            get
            {
                return new TinyCommand(async () =>
                {
                    Navigation.NavigateToAsync("BookAssistantsView",Item);

                });
            }
        }
    }
}
