using System;

namespace ResearchersWPF.Data.Model
{
    public class Presentation
    {
        public int Id { get; set; }

        // Название доклада
        public string Name { get; set; }

        // Название конференции
        public string ConferenceName { get; set; }

        // Дата выступления
        public DateTime PresentationDate { get; set; }

        public int? ResearcherId { get; set; }
        public Researcher Researcher { get; set; }
    }
}