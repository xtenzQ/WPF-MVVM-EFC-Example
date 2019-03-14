using ResearchersWPF.Data.IManagers;

namespace ResearchersWPF.Data.Managers
{
    public class EntityFrameworkManager : IDataManager
    {
        IResearcherManager IDataManager.GetResearcherManager()
        {
            return new ResearcherManager();
        }

        IArticleManager IDataManager.GetArticleManager()
        {
            return new ArticleManager();
        }

        public IMonographManager GetMonographManager()
        {
            return new MonographManager();
        }

        public IPresentationManager GetPresentationManager()
        {
            return new PresentationManager();
        }

        public IReportManager GetReportManager()
        {
            return new ReportManager();
        }

        public IRequestManager GetRequestManager()
        {
            return new RequestManager();
        }
    }
}