using System;
using System.Collections.Generic;
using System.Linq;
using ResearchersWPF.Data.IManagers;
using ResearchersWPF.Data.Model;

namespace ResearchersWPF.Data.Managers
{
    public class PresentationManager : IPresentationManager
    {
        public int Add(string name, string conferenceName, DateTime presentationDate, int researcherId)
        {
            using (var context = new ResDbContext())
            {
                var presentation = new Presentation()
                {
                    Name = name,
                    ConferenceName = conferenceName,
                    PresentationDate = presentationDate
                };
                context.Researchers.First(i => i.Id == researcherId).Presentations.Add(presentation);
                context.SaveChanges();
                return presentation.Id;
            }
        }

        public void Delete(int presentationId)
        {
            using (var context = new ResDbContext())
            {
                var presentation = context.Presentations.First(i => i.Id == presentationId);
                context.Remove(presentation);
                context.SaveChanges();
            }
        }

        public void Update(int presentationId, string name, string conferenceName, DateTime presentationDate)
        {
            using (var context = new ResDbContext())
            {
                var presentation = context.Presentations.First(i => i.Id == presentationId);
                presentation.Name = name;
                presentation.ConferenceName = conferenceName;
                presentation.PresentationDate = presentationDate;
                context.SaveChanges();
            }
        }

        public List<Presentation> FindByResearcher(int researcherId)
        {
            using (var context = new ResDbContext())
            {
                return context.Researchers.First(i => i.Id == researcherId).Presentations.ToList();
            }
        }

        public Presentation Find(int presentationId)
        {
            using (var context = new ResDbContext())
            {
                return context.Presentations.First(i => i.Id == presentationId);
            }
        }
    }
}