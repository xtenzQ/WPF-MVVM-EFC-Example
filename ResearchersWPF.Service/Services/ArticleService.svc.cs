using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ResearchersWPF.Service.DataContracts;
using ResearchersWPF.Service.IServices;

namespace ResearchersWPF.Service.Services
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ArticleService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы ArticleService.svc или ArticleService.svc.cs в обозревателе решений и начните отладку.
    public class ArticleService : IArticleService
    {
        public List<Article> GetArticleByResearcher(int researcherId)
        {
            var result = new List<Article>();
            foreach (var article in Business.Logic.ResearcherManager.Instance().GetResearcher(researcherId).Articles)
            {
                result.Add(new Article(article));
            }

            return result;
        }

        public int AddArticle(int researcherId, Article article)
        {
            return Business.Logic.ResearcherManager.Instance().GetResearcher(researcherId)
                .AddArticle(article.Name, article.MagazineName, article.ReleaseDate);
        }

        public void UpdateArticle(Article article)
        {
            new Business.Logic.Article(article.Id).Researcher.UpdateArticle(new Business.Logic.Article(article.Id, article.Name, article.MagazineName, article.ReleaseDate));
        }

        public void DeleteArticle(int articleId)
        {
            new Business.Logic.Article(articleId).Researcher.DeleteArticle(articleId);
        }

        public Article GetArticle(int articleId)
        {
            var aricle = new Business.Logic.Article(articleId);
            aricle.Refresh();
            return new Article(aricle);
        }
    }
}
