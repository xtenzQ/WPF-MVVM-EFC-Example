using ResearchersWPF.UI.Interface;
using ResearchersWPF.UI.Service;
using ResearchersWPF.UI.ViewModel;

namespace ResearchersWPF.UI
{
    public class Bootstrapper
    {
        public static void Initialize()
        {
            //initialize all the services needed for dependency injection
            //we use the unity framework for dependency injection, but you can choose others
            ServiceProvider.RegisterServiceLocator(new UnityServiceLocator());

            //register the IModalDialog using an instance of the CustomerViewDialog
            //this sets up the view
            ServiceProvider.Instance.Register<IModalDialog, ResearcherViewModel>();
        }
    }
}