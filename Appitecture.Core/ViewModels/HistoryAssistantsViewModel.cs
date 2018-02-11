using System;
using System.Collections.ObjectModel;
using Appitecture.Core.Models;
using Appitecture.Core.Requests;
using TinyMvvm;

namespace Appitecture.Core.ViewModels
{
    public class HistoryAssistantsViewModel : ViewModelBase
    {

        private GetHistoryAssistantsRequest getHistoryAssistantsRequest;

        public HistoryAssistantsViewModel(GetHistoryAssistantsRequest getHistoryAssistantsRequest)
        {
            this.getHistoryAssistantsRequest = getHistoryAssistantsRequest;
        }

        public async override System.Threading.Tasks.Task Initialize()
        {
            IsBusy = true;
            var myassistants = await getHistoryAssistantsRequest.GetassistantBooking();
            assistantBookings = new ObservableCollection<assistantBooking>(myassistants);
            IsBusy = false;
            RaisePropertyChanged("assistantBookings");
        }

        public ObservableCollection<assistantBooking> assistantBookings { get; set; }

    }
}
