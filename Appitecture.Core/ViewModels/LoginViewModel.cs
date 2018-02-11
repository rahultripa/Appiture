
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appitecture.Core.Models;
using Appitecture.Core.Requests;
using TinyMvvm;

namespace Appitecture.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private GetLoginRequests getLoginRequests;
      
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


        public LoginViewModel(GetLoginRequests getLoginRequests)
        {
            this.getLoginRequests = getLoginRequests;
            objassistantUser = new assistantUser();
        }

        public assistantUser Item { get; set; }
            private assistantUser _assistantUser;
        public assistantUser objassistantUser
        {
            set
            {
               
                    _assistantUser = value;
                RaisePropertyChanged("objassistantUser");

            }
            get
            {
                return _assistantUser;
            }
        }
      

        public TinyCommand  LoginCommand
        {
            get
            {
                return new TinyCommand(async () =>
                {
                    IsBusy = true;
                    Login();
                    IsBusy = false;
                });
            }
        }
        public async void Login()
        {
            
            IsBusy = true;
             Item = await getLoginRequests.GetLogin(objassistantUser.UserId,objassistantUser.Password);
            if (Item != null)
            {
                StatusMassege = "Login Successful";
                Constants.userId = Item.Id;
                Navigation.NavigateToAsync("AssistantMapView");
            }
            else
                StatusMassege = "Login unsuccessful";
            IsBusy = false;
            RaisePropertyChanged("Item");
          
        }


    }
}
