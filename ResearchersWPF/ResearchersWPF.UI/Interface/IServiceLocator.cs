namespace ResearchersWPF.UI.Interface
{
    public interface IServiceLocator
    {
        void Register<TInterface, TImplementation>() where TImplementation : TInterface;

        TInterface Get<TInterface>();
    }
}