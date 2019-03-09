using System;
using System.Collections.Generic;
using System.Linq;
using ResearchersWPF.Data.IManagers;
using ResearchersWPF.Data.Model;

namespace ResearchersWPF.Data.Managers
{
    public class ArticleManager : IArticleManager
    {
        public int Add(string name, string magazineName, DateTime releaseDate, int researcherId)
        {
            using (var context = new ResDbContext())
            {
                var article = new Article { Name = name, MagazineName = magazineName, ReleaseDate = releaseDate };
                context.Researchers.First(i => i.Id == researcherId).Articles.Add(article);
                context.SaveChanges();
                return article.Id;
            }
        }

        public void Delete(int articleId)
        {
            using (var context = new ResDbContext())
            {
                var article = context.Articles.First(i => i.Id == articleId);
                context.Remove(article);
                context.SaveChanges();
            }
        }

        public void Update(int articleId, string name, string magazineName, DateTime releaseDate)
        {
            using (var context = new ResDbContext())
            {
                var article = context.Articles.First(i => i.Id == articleId);
                article.Name = name;
                article.MagazineName = magazineName;
                article.ReleaseDate = releaseDate;
                context.SaveChanges();
            }
        }

        public List<Article> FindByResearcher(int researcherId)
        {
            using (var context = new ResDbContext())
            {
                return context.Researchers.First(i => i.Id == researcherId).Articles.ToList();
            }
        }

        public Article Find(int articleId)
        {
            using (var context = new ResDbContext())
            {
                return context.Articles.First(i => i.Id == articleId);
            }
        }
    }
}