using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBookMobile.Views.Componentes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardComponentView : ContentView
    {
        public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(CardComponentView));
        public static readonly BindableProperty CardTitleColorProperty = BindableProperty.Create(nameof(CardTitleColor), typeof(Color), typeof(CardComponentView));
        public static readonly BindableProperty CardBodyProperty = BindableProperty.Create(nameof(CardBody),typeof(View),typeof(CardComponentView));
        public CardComponentView()
        {
            InitializeComponent();
        }
        public string CardTitle { get => (string)GetValue(CardTitleProperty); set => SetValue(CardTitleProperty, value); }
        public Color CardTitleColor { get=>(Color)GetValue(CardTitleColorProperty); set=>SetValue(CardTitleColorProperty,value); }
        public View CardBody { get=>(View)GetValue(CardBodyProperty); set=>SetValue(CardBodyProperty,value); }
    }
}