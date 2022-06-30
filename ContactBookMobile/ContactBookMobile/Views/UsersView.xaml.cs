using ContactBook.Core.COMMON.Models;

using ContactBookMobile.ViewModels;

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBookMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersView : ContentPage
    {

        public UsersView()
        {
            InitializeComponent();
            BindingContext = App.GetViewModel<UsersViewModel>();
        }
    }
}
