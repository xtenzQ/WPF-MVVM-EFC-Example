using System.Collections.Generic;

namespace ResearchersWPF.Data.Model
{
    public class Researcher
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

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Monograph> Monographs { get; set; }
        public virtual ICollection<Presentation> Presentations { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}