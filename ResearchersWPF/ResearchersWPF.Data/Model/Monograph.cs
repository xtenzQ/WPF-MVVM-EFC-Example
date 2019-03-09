namespace ResearchersWPF.Data.Model
{
    public class Monograph
    {
        public int Id { get; set; }

        // Название монографии
        public string Name { get; set; }

        // ФИО соавтора
        public string CoauthorLastName { get; set; }
        public string CoauthorFirstName { get; set; }
        public string CoauthorMiddleName { get; set; }

        // Год издания
        public int ReleaseDate { get; set; }

        // Число страниц
        public int PageCount { get; set; }

        public int? ResearcherId { get; set; }
        public Researcher Researcher { get; set; }
    }
}