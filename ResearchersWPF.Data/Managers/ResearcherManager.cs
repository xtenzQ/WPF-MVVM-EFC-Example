using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ResearchersWPF.Data.IManagers;
using ResearchersWPF.Data.Model;

namespace ResearchersWPF.Data.Managers
{
    public class ResearcherManager : IResearcherManager
    {
        public int Add(string lastName, string firstName, string middleName, int departmentNumber, int age, string academicDegree,
            string position)
        {
            using (var context = new ResDbContext())
            {
                var researcher = new Researcher
                {
                    LastName = lastName,
                    FirstName = firstName,
                    MiddleName = middleName,
                    DepartmentNumber = departmentNumber,
                    Age = age,
                    AcademicDegree = academicDegree,
                    Position = position
                };
                context.Researchers.Add(researcher);
                context.SaveChanges();
                return researcher.Id;
            }
        }

        public void Delete(int researcherId)
        {
            using (var context = new ResDbContext())
            {
                var researcher = context.Researchers.First(i => i.Id == researcherId);
                context.Remove(researcher);
                context.SaveChanges();
            }
        }

        public void Update(int researcherId, string lastName, string firstName, string middleName, int departmentNumber, int age,
            string academicDegree, string position)
        {
            using (var context = new ResDbContext())
            {
                var researcher = context.Researchers.First(i => i.Id == researcherId);
                researcher.LastName = lastName;
                researcher.FirstName = firstName;
                researcher.MiddleName = middleName;
                researcher.DepartmentNumber = departmentNumber;
                researcher.Age = age;
                researcher.AcademicDegree = academicDegree;
                researcher.Position = position;
                context.SaveChanges();
            }
        }

        public List<Researcher> FindAll()
        {
            using (var context = new ResDbContext())
            {
                return context.Researchers.ToList();
            }
        }

        public Researcher FindByArticle(int articleId)
        {
            using (var context = new ResDbContext())
            {
                return context.Articles.Include(i => i.Researcher).FirstOrDefault(i => i.Id == articleId)?.Researcher;
            }
        }

        public Researcher FindByMonograph(int monographId)
        {
            using (var context = new ResDbContext())
            {
                return context.Monographs.Include(i => i.Researcher).FirstOrDefault(i => i.Id == monographId)?.Researcher;
            }
        }

        public Researcher FindByPresentation(int presentationId)
        {
            using (var context = new ResDbContext())
            {
                return context.Presentations.Include(i => i.Researcher).FirstOrDefault(i => i.Id == presentationId)?.Researcher;
            }
        }

        public Researcher FindByReport(int reportId)
        {
            using (var context = new ResDbContext())
            {
                return context.Reports.Include(i => i.Researcher).FirstOrDefault(i => i.Id == reportId)?.Researcher;
            }
        }
    }
}