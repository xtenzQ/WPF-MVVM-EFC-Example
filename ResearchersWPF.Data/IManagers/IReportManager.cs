using System.Collections.Generic;
using ResearchersWPF.Data.Model;

namespace ResearchersWPF.Data.IManagers
{
    public interface IReportManager
    {
        int Add(string name, int registerNumber, int releaseYear, int pageCount, int researcherId);
        void Delete(int reportId);
        void Update(int reportId, string name, int registerNumber, int releaseYear, int pageCount);
        List<Report> FindByResearcher(int researcherId);
        Report Find(int reportId);
    }
}