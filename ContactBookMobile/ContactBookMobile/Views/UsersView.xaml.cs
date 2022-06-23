using ContactBook.Core.COMMON.Models;

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
        public ObservableCollection<Usuario> Items { get; set; }

        public UsersView()
        {
            InitializeComponent();

            Items = new ObservableCollection<Usuario>
            {
                new Usuario(){ UserName="eskantu", Nombre="Mario", ApellidoMaterno="Cantu", ApellidoPaterno="Escalante", Email="eskantu@hotmail.com", IsActive=0, Modulos="", FechaCreacion=DateTime.Now  },
                new Usuario(){ UserName="eskantu", Nombre="Mario", ApellidoMaterno="Cantu", ApellidoPaterno="Escalante", Email="eskantu@hotmail.com", IsActive=1, Modulos="", FechaCreacion=DateTime.Now  },
                new Usuario(){ UserName="eskantu", Nombre="Mario", ApellidoMaterno="Cantu", ApellidoPaterno="Escalante", Email="eskantu@hotmail.com", IsActive=0, Modulos="", FechaCreacion=DateTime.Now  },
                new Usuario(){ UserName="eskantu", Nombre="Mario", ApellidoMaterno="Cantu", ApellidoPaterno="Escalante", Email="eskantu@hotmail.com", IsActive=1, Modulos="", FechaCreacion=DateTime.Now  },
                new Usuario(){ UserName="eskantu", Nombre="Mario", ApellidoMaterno="Cantu", ApellidoPaterno="Escalante", Email="eskantu@hotmail.com", IsActive=0, Modulos="", FechaCreacion=DateTime.Now  },
                 new Usuario(){ UserName="eskantu", Nombre="Mario", ApellidoMaterno="Cantu", ApellidoPaterno="Escalante", Email="eskantu@hotmail.com", IsActive=0, Modulos="", FechaCreacion=DateTime.Now  },
                new Usuario(){ UserName="eskantu", Nombre="Mario", ApellidoMaterno="Cantu", ApellidoPaterno="Escalante", Email="eskantu@hotmail.com", IsActive=1, Modulos="", FechaCreacion=DateTime.Now  },
                new Usuario(){ UserName="eskantu", Nombre="Mario", ApellidoMaterno="Cantu", ApellidoPaterno="Escalante", Email="eskantu@hotmail.com", IsActive=0, Modulos="", FechaCreacion=DateTime.Now  },
                new Usuario(){ UserName="eskantu", Nombre="Mario", ApellidoMaterno="Cantu", ApellidoPaterno="Escalante", Email="eskantu@hotmail.com", IsActive=1, Modulos="", FechaCreacion=DateTime.Now  },
                new Usuario(){ UserName="eskantu", Nombre="Mario", ApellidoMaterno="Cantu", ApellidoPaterno="Escalante", Email="eskantu@hotmail.com", IsActive=0, Modulos="", FechaCreacion=DateTime.Now  },
                 new Usuario(){ UserName="eskantu", Nombre="Mario", ApellidoMaterno="Cantu", ApellidoPaterno="Escalante", Email="eskantu@hotmail.com", IsActive=0, Modulos="", FechaCreacion=DateTime.Now  },
                new Usuario(){ UserName="eskantu", Nombre="Mario", ApellidoMaterno="Cantu", ApellidoPaterno="Escalante", Email="eskantu@hotmail.com", IsActive=1, Modulos="", FechaCreacion=DateTime.Now  },
                new Usuario(){ UserName="eskantu", Nombre="Mario", ApellidoMaterno="Cantu", ApellidoPaterno="Escalante", Email="eskantu@hotmail.com", IsActive=0, Modulos="", FechaCreacion=DateTime.Now  },
                new Usuario(){ UserName="eskantu", Nombre="Mario", ApellidoMaterno="Cantu", ApellidoPaterno="Escalante", Email="eskantu@hotmail.com", IsActive=1, Modulos="", FechaCreacion=DateTime.Now  },
                new Usuario(){ UserName="eskantu", Nombre="Mario", ApellidoMaterno="Cantu", ApellidoPaterno="Escalante", Email="eskantu@hotmail.com", IsActive=0, Modulos="", FechaCreacion=DateTime.Now  },
            };

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
