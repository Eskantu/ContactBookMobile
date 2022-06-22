﻿using ContactBookMobile.Services.Navigation;
using ContactBookMobile.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ContactBookMobile.Helpers
{
    public class NavigationManager : INavigationService
    {
        private readonly object _sync = new object();
        private readonly Dictionary<string, Type> _pageByKey = new Dictionary<string, Type>();
        private readonly Stack<NavigationPage> _navigationPageStack = new Stack<NavigationPage>();
        private NavigationPage CurrentNavigationPage => _navigationPageStack.Peek();
        public string CurrentPageKey 
        {
            get 
            {
                lock (_sync)
                {
                    if (CurrentNavigationPage?.CurrentPage == null)
                    {
                        return null;
                    }
                    var pageType = CurrentNavigationPage.CurrentPage.GetType();
                    return _pageByKey.ContainsValue(pageType) ? _pageByKey.First(p => p.Value == pageType).Key : null;
                }
            }
        }

        public void Configure(string pageKey, Type pageType)
        {
            lock (_sync)
            {
                if (_pageByKey.ContainsKey(pageKey))
                {
                    _pageByKey[pageKey] = pageType;
                }
                else
                {
                    _pageByKey.Add(pageKey, pageType);
                }
            }
        }
        public Page SetRootPage(string rootPageKey)
        {
            var rootPage = GetPage(rootPageKey);
            _navigationPageStack.Clear();
            var mainPage = new NavigationPage(rootPage);
            _navigationPageStack.Push(mainPage);
            return mainPage;
        }

      

        public async Task GoBack()
        {
            var navigationStack = CurrentNavigationPage.Navigation;
            if (navigationStack.NavigationStack.Count()>1)
            {
                await CurrentNavigationPage.PopAsync();
                return;
            }
            if (_navigationPageStack.Count>1)
            {
                _navigationPageStack.Pop();
                await CurrentNavigationPage.Navigation.PopModalAsync();
                return;
            }
            await CurrentNavigationPage.Navigation.PopModalAsync();
        }

        public async Task NavigateAsync(string pageKey, bool animated = true)
        {
            await NavigateAsync(pageKey, null, animated);
        }

        public async Task NavigateAsync(string pageKey, object parameter, bool animated = true)
        {
            var page = GetPage(pageKey, parameter);
            await CurrentNavigationPage.Navigation.PushAsync(page, animated);
        }


        public async Task NavigateModalAsync(string pageKey, bool animated = true)
        {
            await NavigateModalAsync(pageKey, null, animated);
        }

        public async Task NavigateModalAsync(string pageKey, object parameter, bool animated = true)
        {
            var page = GetPage(pageKey, parameter);
            NavigationPage.SetHasNavigationBar(page, false);
            var modalNavigationPage = new NavigationPage(page);
            await CurrentNavigationPage.Navigation.PushModalAsync(modalNavigationPage, animated);
            _navigationPageStack.Push(modalNavigationPage);
        }

        private Page GetPage(string pageKey, object parameter = null)
        {

            lock (_sync)
            {
                if (!_pageByKey.ContainsKey(pageKey))
                {
                    throw new ArgumentException(
                        $"No such page: {pageKey}. Did you forget to call NavigationService.Configure?");
                }

                var type = _pageByKey[pageKey];
                ConstructorInfo constructor;
                object[] parameters;

                if (parameter == null)
                {
                    constructor = type.GetTypeInfo()
                        .DeclaredConstructors
                        .FirstOrDefault(c => !c.GetParameters().Any());

                    parameters = new object[]
                    {
                    };
                }
                else
                {
                    constructor = type.GetTypeInfo()
                        .DeclaredConstructors
                        .FirstOrDefault(
                            c =>
                            {
                                var p = c.GetParameters();
                                return p.Length == 1
                                       && p[0].ParameterType == parameter.GetType();
                            });

                    parameters = new[]
                    {
                    parameter
                };
                }

                if (constructor == null)
                {
                    throw new InvalidOperationException(
                        "No suitable constructor found for page " + pageKey);
                }

                var page = constructor.Invoke(parameters) as Page;
                return page;
            }
        }
    }
}
