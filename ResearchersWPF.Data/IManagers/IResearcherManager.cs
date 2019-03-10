using System.Collections.Generic;
using ResearchersWPF.Data.Model;

namespace ResearchersWPF.Data.IManagers
{
    public interface IResearcherManager
    {
        int Add(string lastName, string firstName, string middleName, int departmentNumber, int age, string academicDegree, string position);
        void Delete(int researcherId);
        void Update(int researcherId, string lastName, string firstName, string middleName, int departmentNumber, int age, string academicDegree, string position);
        List<Researcher> FindAll();
        Researcher FindByArticle(int articleId);
        Researcher FindByMonograph(int monographId);
        Researcher FindByPresentation(int presentationId);
        Researcher FindByReport(int reportId);
    }
}