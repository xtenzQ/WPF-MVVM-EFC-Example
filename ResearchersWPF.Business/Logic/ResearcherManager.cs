using System.Collections.Generic;
using System.Linq;
using ResearchersWPF.Data.Managers;

namespace ResearchersWPF.Business.Logic
{
    public class ResearcherManager
    {
        private static ResearcherManager _instance = null;

        public List<Researcher> ResearcherList => GetResearchersList();

        public static ResearcherManager Instance()
        {
            return _instance ?? (_instance = new ResearcherManager());
        }

        public Researcher GetResearcher(int researcherId)
        {
            return ResearcherList.First(i => i.ResearcherId == researcherId);
        }

        public int AddResearcher(string lastName, string firstName, string middleName, int departmentNumber, int age,
            string academicDegree, string position)
        {
            var manager = new FactoryManager();
            return manager.GetResearcherManager().Add(lastName, firstName, middleName, departmentNumber, age,
                academicDegree, position);
        }

        public void UpdateResearcher(Researcher researcher)
        {
            var manager = new FactoryManager();
            manager.GetResearcherManager().Update(researcher.ResearcherId, researcher.LastName, researcher.FirstName, 
                researcher.MiddleName, researcher.DepartmentNumber, researcher.Age, researcher.AcademicDegree, researcher.Position);
        }

        public void DeleteResearcher(int researcherId)
        {
            var manager = new FactoryManager();
            manager.GetResearcherManager().Delete(researcherId);
        }

        private List<Researcher> GetResearchersList()
        {
            var researchers = new List<Researcher>();
            var manager = new FactoryManager();
            foreach (var researcher in manager.GetResearcherManager().FindAll())
            {
                var res = new Researcher(researcher.Id, researcher.LastName, researcher.FirstName,
                    researcher.MiddleName, researcher.DepartmentNumber, researcher.Age, researcher.AcademicDegree, researcher.Position);
                researchers.Add(res);
            }
            return researchers;
        }
    }
}