using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookMobile.Helpers
{
    public class Alert : IAlert
    {
        public Task<string> ShowAction(string message, params string[] options)
        {
          return  App.Current.MainPage.DisplayActionSheet("ContactBookMobile", "Cancelar", null, options);
        }

        public void ShowAlert(string message)
        {
            App.Current.MainPage.DisplayAlert("ContactBookMobile", message,"Ok");
            
        }

        public Task<string> ShowPrompt(string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, string initialValue = "")
        {
           return App.Current.MainPage.DisplayPromptAsync("ContactBookMobile",message,accept,cancel,placeholder,maxLength,initialValue:initialValue);
        }

        public Task<bool> ShowQuestion(string question)
        {
           return App.Current.MainPage.DisplayAlert("ContactBookMobile", question,"Accept","Cancel");
        }
    }
}
