using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ContactBookMobile.Services;
using ContactBookMobile.Views;
using Microsoft.Extensions.DependencyInjection;
using ContactBook.Core.COMMON.Interfaces;
using ContactBookMobile.Services.Managers;
using ContactBookMobile.ViewModels;
using ContactBookMobile.Services.Intarfaces;
using ContactBookMobile.Services.Navigation;
using ContactBookMobile.Helpers;

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
            services.AddSingleton<INavigationService, NavigationManager>();
            var provider = services.BuildServiceProvider();
            var tokenService = provider.GetRequiredService<IToken>();

            FactoryManager factoryManager = new FactoryManager(tokenService);
            services.AddTransient<IUsuarioManager>(x => factoryManager.GetUsuarioManager());

            //Add viewModels
            services.AddTransient<ItemsViewModel>();
            services.AddTransient<AboutViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<SignInViewModel>();
            ServiceProvider = services.BuildServiceProvider();

        }

        private Page ConfigureNavigation(IServiceProvider provider)
        {

            NavigationManager navigationServices = provider.GetRequiredService<INavigationService>() as NavigationManager;
            navigationServices.Configure("Login", typeof(LoginView));
            navigationServices.Configure("SignIn", typeof(SignInView));
            return navigationServices.SetRootPage("Login");
        }

        public static BaseViewModel GetViewModel<TViewModel>() where TViewModel : BaseViewModel
        {
            return ServiceProvider.GetRequiredService<TViewModel>();
        }
    }
}
