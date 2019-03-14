using ResearchersWPF.Data.IManagers;

namespace ResearchersWPF.Data.Managers
{
    public class FactoryManager
    {
        private readonly IDataManager _dataManager;

        public FactoryManager()
        {
            _dataManager = new EntityFrameworkManager();
        }

        public IResearcherManager GetResearcherManager()
        {
            return _dataManager.GetResearcherManager();
        }

        public IArticleManager GetArticleManager()
        {
            return _dataManager.GetArticleManager();
        }

        public IMonographManager GetMonographManager()
        {
            return _dataManager.GetMonographManager();
        }

        public IPresentationManager GetPresentationManager()
        {
            return _dataManager.GetPresentationManager();
        }

        public IReportManager GetReportManager()
        {
            return _dataManager.GetReportManager();
        }

        public IRequestManager GetRequestManager()
        {
            return _dataManager.GetRequestManager();
        }
    }
}