using System.Collections.Generic;
using System.Linq;
using ResearchersWPF.Data.IManagers;
using ResearchersWPF.Data.Model;

namespace ResearchersWPF.Data.Managers
{
    public class ReportManager : IReportManager
    {
        public int Add(string name, int registerNumber, int releaseYear, int pageCount, int researcherId)
        {
            using (var context = new ResDbContext())
            {
                var report = new Report()
                {
                    Name = name,
                    RegisterNumber = registerNumber,
                    ReleaseYear = releaseYear,
                    PageCount = pageCount
                };
                context.Researchers.First(i => i.Id == researcherId).Reports.Add(report);
                context.SaveChanges();
                return report.Id;
            }
        }

        public void Delete(int reportId)
        {
            using (var context = new ResDbContext())
            {
                var report = context.Reports.First(i => i.Id == reportId);
                context.Remove(report);
                context.SaveChanges();
            }
        }

        public void Update(int reportId, string name, int registerNumber, int releaseYear, int pageCount)
        {
            using (var context = new ResDbContext())
            {
                var report = context.Reports.First(i => i.Id == reportId);
                report.Name = name;
                report.RegisterNumber = registerNumber;
                report.ReleaseYear = releaseYear;
                report.PageCount = pageCount;
                context.SaveChanges();
            }
        }

        public List<Report> FindByResearcher(int researcherId)
        {
            using (var context = new ResDbContext())
            {
                return context.Researchers.First(i => i.Id == researcherId).Reports.ToList();
            }
        }

        public Report Find(int reportId)
        {
            using (var context = new ResDbContext())
            {
                return context.Reports.First(i => i.Id == reportId);
            }
        }
    }
}