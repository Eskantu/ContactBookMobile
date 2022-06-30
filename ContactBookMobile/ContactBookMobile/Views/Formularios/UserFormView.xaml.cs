using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBookMobile.Views.Formularios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserFormView : ContentView
    {
        public static readonly BindableProperty isExpandedButtonProperty = BindableProperty.Create(nameof(IsExpandedButton), typeof(bool), typeof(UserFormView), false);
        public UserFormView()
        {
            InitializeComponent();
        }
        public bool IsExpandedButton { get => (bool)GetValue(isExpandedButtonProperty); set => SetValue(isExpandedButtonProperty, value); }
    }
}