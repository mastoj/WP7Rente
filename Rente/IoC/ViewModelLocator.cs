using Rente.Converters;
using TinyIoC;

namespace Rente
{
    public class ViewModelLocator
    {
        private readonly TinyIoCContainer _container;

         public ViewModelLocator()
         {
             _container = TinyIoCContainer.Current;
             _container.Register<DoubleTo2DecimalsStringConverter>().AsSingleton();
             _container.Register<MainViewModel>().AsSingleton();

            #if DEBUG
             _container.Register<IInterestService, InterestServiceStub>();
            #else
                _container.Register<IInterestService, InterestService>();
            #endif
         }

         public MainViewModel MainViewModel
         {
             get { return _container.Resolve<MainViewModel>(); }
         }

         public DoubleTo2DecimalsStringConverter Double2DecimalStringConverter
         {
             get { return _container.Resolve<DoubleTo2DecimalsStringConverter>(); }
         }

         public IInterestService InterestService
         {
             get { return _container.Resolve<IInterestService>(); }
         }
    }
}