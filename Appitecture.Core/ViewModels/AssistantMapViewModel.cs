using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Appitecture.Core.Models;
using Appitecture.Core.Requests;
using TinyMvvm;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Appitecture.Core.ViewModels
{
    public class AssistantMapViewModel : ViewModelBase
    {

        public  SelectedParameter selectedParameter;
        private GetAssistantsRequest getAssistantsRequest;

        public AssistantMapViewModel(GetAssistantsRequest getAssistantsRequest)
        {
            this.getAssistantsRequest = getAssistantsRequest;
        }

      
        public async override System.Threading.Tasks.Task Initialize()
        {
            IsBusy = true;
             selectedParameter = (SelectedParameter)NavigationParameter;
            // This Value will replace with actual  latitude and longitude  with using Xam.plugin Locator 
            var myassistants = await getAssistantsRequest.GetAssistants(19.22, 72.85);
                Myassistants = new ObservableCollection<Myassistant>(myassistants);
           
            if (selectedParameter != null)
            {
                if(selectedParameter.selectedProfession!=null) 
                {
                    Myassistants = UtilitiesClass.ToObservableCollection(Myassistants.Where(c => c.profession == selectedParameter.selectedProfession).ToList<Myassistant>());
                }
                if (selectedParameter.selectedRatting != null)
                {
                    Myassistants = UtilitiesClass.ToObservableCollection(Myassistants.Where(c => c.ratting == selectedParameter.selectedRatting).ToList<Myassistant>());
                }
                if (selectedParameter.selectedLocalKnowlage != null)
                {
                    if(selectedParameter.selectedLocalKnowlage == "Yes")
                       Myassistants = UtilitiesClass.ToObservableCollection(Myassistants.Where(c => c.localplaceknowledge == 1).ToList<Myassistant>());
                    else
                        Myassistants = UtilitiesClass.ToObservableCollection(Myassistants.Where(c => c.localplaceknowledge == 0).ToList<Myassistant>());
                  
                }
            }
            foreach(var item in Myassistants)
            {

                var pin = new Pin()
                {   ZIndex= item.assistantId,
                    Type = PinType.Place,
                    Label = item.name,
                    Address = "Profession : " + item.profession + " Wages($) " + item.wagesPerHour ,
                    Position = new Position(item.lat, item.lng),
                    };
                pin.Clicked += (sender, e) =>
                
                {
                    var clickPin =(Pin) sender;
                    Navigation.NavigateToAsync("AssistantView", clickPin.ZIndex);

                };
               Pins.Add(pin);
            }
            IsBusy = false;

            RaisePropertyChanged("Myassistants");
        }
       
        public Command filterCommand => new Command(()=>
          {
            if (selectedParameter == null)
           selectedParameter = new SelectedParameter();
            selectedParameter.listProfession = Myassistants.Select(c => c.profession).Distinct().ToList(); 
            Navigation.NavigateToAsync("SearchParameterView",selectedParameter);
            });
      
        public ObservableCollection<Pin> Pins { get; set; }
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
        public TinyCommand HistoryCommand
        {
            get
            {
                return new TinyCommand(async () =>
                {
                    Navigation.NavigateToAsync("HistoryAssistantsView");
                });
            }
        }
       
    }


   
}
