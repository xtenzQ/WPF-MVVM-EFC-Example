using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ResearchersWPF.Data.IManagers;
using ResearchersWPF.Data.Model;

namespace ResearchersWPF.Data.Managers
{
    public class MonographManager : IMonographManager
    {
        public int Add(string name, string coauthorLastName, string coauthorFirstName, string coauthorMiddleName, int releaseDate,
            int pageCount, int researcherId)
        {
            using (var context = new ResDbContext())
            {
                var monograph = new Monograph
                {
                    Name = name, CoauthorLastName = coauthorLastName, CoauthorFirstName = coauthorFirstName,
                    CoauthorMiddleName = coauthorMiddleName, ReleaseDate = releaseDate, PageCount = pageCount
                };
                context.Researchers.First(i => i.Id == researcherId).Monographs.Add(monograph);
                context.SaveChanges();
                return monograph.Id;
            }
        }

        public void Delete(int monographId)
        {
            using (var context = new ResDbContext())
            {
                var monograph = context.Monographs.First(i => i.Id == monographId);
                context.Remove(monograph);
                context.SaveChanges();
            }
        }

        public void Update(int monographId, string name, string coauthorLastName, string coauthorFirstName, string coauthorMiddleName,
            int releaseDate, int pageCount)
        {
            using (var context = new ResDbContext())
            {
                var monograph = context.Monographs.First(i => i.Id == monographId);
                monograph.Name = name;
                monograph.CoauthorLastName = coauthorLastName;
                monograph.CoauthorFirstName = coauthorFirstName;
                monograph.CoauthorMiddleName = coauthorMiddleName;
                monograph.ReleaseDate = releaseDate;
                monograph.PageCount = pageCount;
                context.SaveChanges();
            }
        }

        public List<Monograph> FindByResearcher(int researcherId)
        {
            using (var context = new ResDbContext())
            {
                return context.Monographs.Where(s => s.ResearcherId == researcherId).ToList();
                //return context.Researchers.First(i => i.Id == researcherId).Monographs.ToList();
            }
        }

        public Monograph Find(int monographId)
        {
            using (var context = new ResDbContext())
            {
                return context.Monographs.First(i => i.Id == monographId);
            }
        }
    }
}