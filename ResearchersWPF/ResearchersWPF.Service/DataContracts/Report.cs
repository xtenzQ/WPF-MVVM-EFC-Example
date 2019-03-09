using System.Runtime.Serialization;

namespace ResearchersWPF.Service.DataContracts
{
    [DataContract]
    public class Report
    {
        [DataMember]
        public int Id { get; set; }

        // Название научного отчёта
        [DataMember]
        public string Name { get; set; }

        // Регистрационный номер
        [DataMember]
        public int RegisterNumber { get; set; }

        // Год выпуска
        [DataMember]
        public int ReleaseYear { get; set; }

        // Число страниц
        [DataMember]
        public int PageCount { get; set; }

        internal Report(Business.Logic.Report report)
        {
            Id = report.Id;
            Name = report.Name;
            RegisterNumber = report.RegisterNumber;
            ReleaseYear = report.ReleaseYear;
            PageCount = report.PageCount;
        }
    }
}