namespace ResearchersWPF.Data.IManagers
{
    public interface IDataManager
    {
        IResearcherManager GetResearcherManager();
        IArticleManager GetArticleManager();
        IMonographManager GetMonographManager();
        IPresentationManager GetPresentationManager();
        IReportManager GetReportManager();
        IRequestManager GetRequestManager();
    }
}