using ContactBookMobile.Helpers.UIModels;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBookMobile.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuViewFlyout : ContentPage
    {
        public CollectionView ListView;

        public MenuViewFlyout()
        {
            InitializeComponent();

            BindingContext = new MenuViewFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MenuViewFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuItemModel> MenuItems { get; set; }

            public MenuViewFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MenuItemModel>(new[]
                {
                    new MenuItemModel(){ HasChildrens=false, Modulo="Dashboard", Icon="\ue871" },
                    new MenuItemModel(){ HasChildrens=false, Modulo="Usuarios", Icon="\ue853" },
                    new MenuItemModel(){ HasChildrens=true, Modulo="Contact Book", Icon="\uf22e" },
                    new MenuItemModel(){ HasChildrens=false, Modulo="Upload file", Icon="\ue2c6" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        Label latestItem=new Label();
        private void MenuItemsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TapGestureRecognizer_Tapped(latestItem, new EventArgs());
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (latestItem != null && latestItem != label)
            {
                label.BackgroundColor = Color.Gray;
                latestItem.BackgroundColor = Color.Transparent;
            }
            else
            {
                label.BackgroundColor = Color.Gray;
            }
            latestItem = label;
        }
    }
}