using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ContactBookMobile.Services;
using ContactBookMobile.Views;
using Microsoft.Extensions.DependencyInjection;
using ContactBookMobile.ViewModels;
using ContactBookMobile.Services.Intarfaces;
using ContactBookMobile.Services.Navigation;
using ContactBookMobile.Helpers;
using ContactBookMobile.Views.Menu;
using ContactBookMobile.ViewModels.Menu;
using ContactBookMobile.Views.ContactBook;
using ContactBook.Core.COMMON.Interfaces;

namespace ContactBookMobile
{


    public partial class App : Application
    {
        protected static IServiceProvider ServiceProvider { get; set; }
        public App(Action<IServiceCollection> addPlatformServices = null)
        {
            InitializeComponent();
            SetupServices(addPlatformServices);
            DependencyService.Register<MockDataStore>();
            MainPage = ConfigureNavigation(ServiceProvider);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        void SetupServices(Action<IServiceCollection> addPlatformServices = null)
        {
            var services = new ServiceCollection();
            //servicios especificos de la plataforma
            addPlatformServices?.Invoke(services);

            //servcios para el proyecto principal
            services.AddSingleton<IToken, Token>();
            services.AddTransient<IError, Error>();
            var provider = services.BuildServiceProvider();
            var tokenService = provider.GetRequiredService<IToken>();
            var errorService = provider.GetRequiredService<IError>();
            FactoryManager factoryManager = new FactoryManager(tokenService,errorService);
            services.AddTransient<IUsuarioManager>(x => factoryManager.GetUsuarioManager());
            services.AddSingleton<INavigationService, NavigationManager>();
            services.AddSingleton<IAlert, Alert>();
            //Add viewModels
            services.AddTransient<ItemsViewModel>();
            services.AddTransient<AboutViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<SignInViewModel>();
            services.AddTransient<MenuViewFlyoutViewModel>();
            services.AddTransient<UsersViewModel>();
            services.AddTransient<UploadFileViewModel>();
            ServiceProvider = services.BuildServiceProvider();

        }

        private Page ConfigureNavigation(IServiceProvider provider)
        {

            NavigationManager navigationServices = provider.GetRequiredService<INavigationService>() as NavigationManager;
            navigationServices.Configure("Login", typeof(LoginView));
            navigationServices.Configure("SignIn", typeof(SignInView));
            navigationServices.Configure("MenuView", typeof(MenuView));
            navigationServices.Configure("EditAddUser", typeof(EditUserView));
            return navigationServices.SetRootPage("Login");
        }

        public static BaseViewModel GetViewModel<TViewModel>() where TViewModel : BaseViewModel
        {
            return ServiceProvider.GetRequiredService<TViewModel>();
        }
    }
}
