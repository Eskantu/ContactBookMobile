using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookMobile.Helpers
{
   public interface IAlert
    {
        void ShowAlert(string message);
        Task<bool> ShowQuestion(string question);
        Task<string> ShowAction(string message, params string[] options);
        Task<string> ShowPrompt(string message, string accept = "OK", string cancel = "Cancel", string placeholder = null, int maxLength = -1, string initialValue = "");

    }
}
