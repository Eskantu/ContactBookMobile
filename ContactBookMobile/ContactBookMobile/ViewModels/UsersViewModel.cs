using ContactBook.Core.COMMON.Models;

using ContactBookMobile.Services.Navigation;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

using Xamarin.Forms;

namespace ContactBookMobile.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        
        private ObservableCollection<Usuario> items;

        public ObservableCollection<Usuario> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }
        public ICommand EditAddUserCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }
        public UsersViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            EditAddUserCommand = new Command<Usuario>((Usuario u) => OnEditAddUser(u));
            DeleteUserCommand = new Command<Usuario>((Usuario u) => OnDeleteUser(u));
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
        }

        private void OnDeleteUser(Usuario u)
        {
            Items.Remove(u);
        }

        private async void OnEditAddUser(Usuario u)
        {
           await navigationService.NavigateAsync("EditAddUser");
        }
    }
}
