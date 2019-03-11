using System.Collections.Generic;

namespace ResearchersWPF.Data.Model
{
    public sealed class Researcher
    {
        public int Id { get; set; }

        // ФИО
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        // Номер отдела
        public int DepartmentNumber { get; set; }

        // Возраст
        public int Age { get; set; }

        // Ученая степень
        public string AcademicDegree { get; set; }

        // Должность
        public string Position { get; set; }

        public ICollection<Article> Articles { get; set; }
        public ICollection<Monograph> Monographs { get; set; }
        public ICollection<Presentation> Presentations { get; set; }
        public ICollection<Report> Reports { get; set; }

        public Researcher()
        {
            Articles = new HashSet<Article>();
            Monographs = new HashSet<Monograph>();
            Presentations = new HashSet<Presentation>();
            Reports = new HashSet<Report>();
        }
    }
}