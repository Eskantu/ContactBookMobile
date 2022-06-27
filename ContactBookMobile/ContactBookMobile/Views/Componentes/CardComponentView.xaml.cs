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
        public static readonly BindableProperty CardBodyProperty = BindableProperty.Create(nameof(CardBody), typeof(View), typeof(CardComponentView));
        public static readonly BindableProperty CardColorProperty = BindableProperty.Create(nameof(CardColor), typeof(Color), typeof(CardComponentView), Color.White);
        public static readonly BindableProperty IsVisibleTitleProperty = BindableProperty.Create(nameof(IsVisibleTitle), typeof(bool), typeof(CardComponentView), true);
        public static readonly BindableProperty CardWidthProperty = BindableProperty.Create(nameof(CardWidth), typeof(float), typeof(CardComponentView), 300f);
        public CardComponentView()
        {
            InitializeComponent();
        }
        public string CardTitle { get => (string)GetValue(CardTitleProperty); set => SetValue(CardTitleProperty, value); }
        public Color CardTitleColor { get => (Color)GetValue(CardTitleColorProperty); set => SetValue(CardTitleColorProperty, value); }
        public View CardBody { get => (View)GetValue(CardBodyProperty); set => SetValue(CardBodyProperty, value); }
        public Color CardColor { get => (Color)GetValue(CardColorProperty); set => SetValue(CardColorProperty, value); }
        public bool IsVisibleTitle { get => (bool)GetValue(IsVisibleTitleProperty); set => SetValue(IsVisibleTitleProperty, value); }
        public float CardWidth { get => (float)GetValue(CardWidthProperty); set => SetValue(CardWidthProperty, value); }
    }
}