using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Essentials;

using ContactBookMobile.Models;
using ContactBookMobile.Services;
using System.Diagnostics;

namespace ContactBookMobile.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            // Register for connectivity changes, be sure to unsubscribe when finished
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            IsNetworkConnect = Connectivity.NetworkAccess != NetworkAccess.ConstrainedInternet && Connectivity.NetworkAccess != NetworkAccess.Unknown && Connectivity.NetworkAccess != NetworkAccess.None;
            Debug.WriteLine($"Netwoek state: {Connectivity.NetworkAccess}");
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsNetworkConnect = e.NetworkAccess != NetworkAccess.ConstrainedInternet && e.NetworkAccess != NetworkAccess.Unknown && e.NetworkAccess != NetworkAccess.None;
            Debug.WriteLine($"Netwoek state: {e.NetworkAccess}");

        }

        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        private bool isNetworkConnect;

        public bool IsNetworkConnect
        {
            get { return isNetworkConnect; }
            set { SetProperty(ref isNetworkConnect , value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
