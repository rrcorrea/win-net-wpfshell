using BasicWindowsApp.Constants;
using BasicWindowsApp.ViewModels;
using BasicWindowsApp.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Unity;

namespace BasicWindowsApp.Modules
{
    class ExampleModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;

        public ExampleModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
            => _regionManager.RegisterViewWithRegion(Regions.MainRegion, () => _container.Resolve<ExampleView>());

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _container.RegisterType<ExampleViewModel>();
            _container.RegisterTypeForNavigation<ExampleView>();
        }
    }
}
