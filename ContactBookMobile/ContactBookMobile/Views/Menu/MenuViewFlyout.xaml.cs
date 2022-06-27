using ContactBookMobile.Helpers.UIModels;
using ContactBookMobile.ViewModels.Menu;

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
        readonly MenuViewFlyoutViewModel context;
        public MenuViewFlyout()
        {
            InitializeComponent();

            context = (MenuViewFlyoutViewModel)App.GetViewModel<MenuViewFlyoutViewModel>();
            BindingContext = context;
        }


        Label latestItem = new Label();
        private void MenuItemsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (latestItem != null)
            {
                latestItem.BackgroundColor = Color.Transparent;
            }
            if (e.CurrentSelection.Count > 0)
            {
                MenuItemModel item = e.CurrentSelection[0] as MenuItemModel;
                ChangePageOnFlyoutMenu(item.Page);
            }
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            MenuItemsListView.SelectedItem = null;
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
            TappedEventArgs tappedArgs = e as TappedEventArgs;
            //await context.NavigateToPage(tappedArgs.Parameter as string);
            ChangePageOnFlyoutMenu(tappedArgs.Parameter as string);

        }

        private void ChangePageOnFlyoutMenu(string page)
        {
            MessagingCenter.Send<MenuViewFlyout, string>(this, "Detail", page);
        }
    }
}