using System.Runtime.Serialization;

namespace ResearchersWPF.Service.DataContracts
{
    [DataContract]
    public class Monograph
    {
        [DataMember]
        public int Id { get; set; }

        // Название монографии
        [DataMember]
        public string Name { get; set; }

        // ФИО соавтора
        [DataMember]
        public string CoauthorLastName { get; set; }

        [DataMember]
        public string CoauthorFirstName { get; set; }

        [DataMember]
        public string CoauthorMiddleName { get; set; }

        // Год издания
        [DataMember]
        public int ReleaseDate { get; set; }

        // Число страниц
        [DataMember]
        public int PageCount { get; set; }

        internal Monograph(Business.Logic.Monograph monograph)
        {
            Id = monograph.Id;
            Name = monograph.Name;
            CoauthorLastName = monograph.CoauthorLastName;
            CoauthorFirstName = monograph.CoauthorFirstName;
            CoauthorMiddleName = monograph.CoauthorMiddleName;
            ReleaseDate = monograph.ReleaseDate;
            PageCount = monograph.PageCount;
        }
    }
}