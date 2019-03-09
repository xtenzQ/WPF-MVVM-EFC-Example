using System.Collections.Generic;
using ResearchersWPF.Data.Model;

namespace ResearchersWPF.Data.IManagers
{
    public interface IMonographManager
    {
        int Add(string name, string coauthorLastName, string coauthorFirstName, string coauthorMiddleName, int releaseDate, int pageCount, int researcherId);
        void Delete(int monographId);
        void Update(int monographId, string name, string coauthorLastName, string coauthorFirstName, string coauthorMiddleName, int releaseDate, int pageCount);
        List<Monograph> FindByResearcher(int researcherId);
        Monograph Find(int monographId);
    }
}