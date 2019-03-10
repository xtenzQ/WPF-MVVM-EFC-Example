using System;
using System.Runtime.Serialization;

namespace ResearchersWPF.Service.DataContracts
{
    [DataContract]
    public class Article
    {
        [DataMember]
        public int Id { get; set; }

        // Название статьи
        [DataMember]
        public string Name { get; set; }

        // Название журнала
        [DataMember]
        public string MagazineName { get; set; }

        // Год и месяц издания
        [DataMember]
        public DateTime ReleaseDate { get; set; }

        internal Article(Business.Logic.Article article)
        {
            Id = article.Id;
            Name = article.Name;
            MagazineName = article.MagazineName;
            ReleaseDate = article.ReleaseDate;
        }
    }
}