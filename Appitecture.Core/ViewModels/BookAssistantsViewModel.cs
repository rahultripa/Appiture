using System;
using Appitecture.Core.Models;
using Appitecture.Core.Requests;
using TinyMvvm;

namespace Appitecture.Core.ViewModels
{
    public class BookAssistantsViewModel : ViewModelBase
    {

        private GetBookAssistantsRequest getBookAssistantsRequest;
      
        assistantBooking objassistantBooking;
        private String statusMassege;
        public String StatusMassege
        {
            get
            {
                return statusMassege;
            }

            set
            {
                statusMassege = value;
                RaisePropertyChanged("StatusMassege");
            }
        }

        private DateTime fromDate;
        public DateTime FromDate
        {
            get
            {
                return fromDate;
            }

            set
            {
                fromDate = value;
                RaisePropertyChanged("FromDate");
            }
        }

        private DateTime fromTime;
        public DateTime FromTime
        {
            get
            {
                return fromTime;
            }

            set
            {
                fromTime = value;
                RaisePropertyChanged("FromTime");
            }
        }


        private DateTime toDate;
        public DateTime ToDate
        {
            get
            {
                return toDate;
            }

            set
            {
                toDate = value;
                RaisePropertyChanged("toDate");
            }
        }

        private DateTime toTime;
        public DateTime ToTime
        {
            get
            {
                return toTime;
            }

            set
            {
                toTime = value;
                RaisePropertyChanged("ToTime");
            }
        }
        private assistantBooking _assistantBooking;
        public assistantBooking ObjassistantBooking
        {
            set
            {
               
                _assistantBooking = value;
                RaisePropertyChanged("ObjassistantBooking");

            }
            get
            {
                return _assistantBooking;
            }
        }
        public Myassistant myassistant { set; get; }
        public BookAssistantsViewModel(GetBookAssistantsRequest getBookAssistantsRequest)
        {

            this.getBookAssistantsRequest = getBookAssistantsRequest;
            ObjassistantBooking = new assistantBooking();
            FromTime = DateTime.Now;

           }
        public TinyCommand BookCommand
        {
            get
            {
                return new TinyCommand(async () =>
                {
                    IsBusy = true;
                    PostAssistant();
                    IsBusy = false;
                });
            }
        }
        public async override System.Threading.Tasks.Task Initialize()
        {
            myassistant= (Myassistant)NavigationParameter;
          
            RaisePropertyChanged("myassistant");
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
        public async void PostAssistant()
        {
           
            ObjassistantBooking.assistantId = myassistant.assistantId;
            ObjassistantBooking.name = myassistant.name;
            ObjassistantBooking.UserId=    Constants.userId;
            ObjassistantBooking.date = DateTime.Now;
            ObjassistantBooking.fromDateTime =  FromDate + FromTime.TimeOfDay;
            ObjassistantBooking.ToDate =  toDate + ToTime.TimeOfDay;

            var Item = await getBookAssistantsRequest.PostAssistant(ObjassistantBooking);
            if (Item)
            {
                StatusMassege = "Post Successful";
                }
            else
                StatusMassege = "Post Unuccessful";
             RaisePropertyChanged("Item");

        }
    }
}
