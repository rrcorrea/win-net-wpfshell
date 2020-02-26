using System;
using System.Collections.Generic;
using System.Text;
using BasicWindowsApp.Constants;
using BasicWindowsApp.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace BasicWindowsApp.ViewModels
{
    class ShellViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;

        private IRegionManager _appRegionManager;
        public IRegionManager AppRegionManager { get => _appRegionManager; set => SetProperty(ref _appRegionManager, value); }

        private string _shellTitle;
        public string ShellTitle { get => _shellTitle; set => SetProperty(ref _shellTitle, value); }

        public ShellViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _eventAggregator = eventAggregator;
            AppRegionManager = regionManager;

            ShellTitle = "My simple application";
            _eventAggregator.GetEvent<RequestNavigationEvent>().Subscribe(OnRequestNavigation);
            //subscribe to other events as needed
        }

        /// <summary>
        /// Request navigation for main region
        /// </summary>
        /// <param name="viewName">User control name</param>
        private void OnRequestNavigation(string viewName)
        {
            App.Current.Dispatcher.Invoke(() => AppRegionManager.RequestNavigate(Regions.MainRegion, viewName));
        }
    }
}
