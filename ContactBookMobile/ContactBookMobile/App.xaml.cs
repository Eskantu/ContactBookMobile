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
            MainPage = new LoginView();
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
            var provider = services.BuildServiceProvider();
            var tokenService = provider.GetRequiredService<IToken>();
            FactoryManager factoryManager = new FactoryManager(tokenService);
            services.AddTransient<IUsuarioManager>(x => factoryManager.GetUsuarioManager());

            //Add viewModels
            services.AddTransient<ItemsViewModel>();
            services.AddTransient<AboutViewModel>();
            services.AddTransient<LoginViewModel>();
            ServiceProvider = services.BuildServiceProvider();
        }

        public static BaseViewModel GetViewModel<TViewModel>() where TViewModel : BaseViewModel
        {
            return ServiceProvider.GetRequiredService<TViewModel>();
        }
    }
}
