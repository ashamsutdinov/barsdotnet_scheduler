namespace Sheduler.Contracts
{
    public interface IServiceFactory
    {
        TInterface Get<TInterface>();
    }
}