using Microsoft.Practices.Unity;
using Sheduler.Contracts;

namespace UI
{
    public class UnityServiceFactory :
       IServiceFactory
    {
        public TService Get<TService>()
        {
            return UnityHelper.Container.Resolve<TService>();
        }
    }
}