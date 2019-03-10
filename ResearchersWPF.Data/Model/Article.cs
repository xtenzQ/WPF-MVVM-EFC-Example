using System;

namespace ResearchersWPF.Data.Model
{
    public class Article
    {
        public int Id { get; set; }

        // Название статьи
        public string Name { get; set; }

        // Название журнала
        public string MagazineName { get; set; }

        // Год и месяц издания
        public DateTime ReleaseDate { get; set; }

        public int? ResearcherId { get; set; }
        public Researcher Researcher { get; set; }
    }
}