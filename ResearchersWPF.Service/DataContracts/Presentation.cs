using System;
using System.Runtime.Serialization;

namespace ResearchersWPF.Service.DataContracts
{
    [DataContract]
    public class Presentation
    {
        [DataMember]
        public int Id { get; set; }

        // Название доклада
        [DataMember]
        public string Name { get; set; }

        // Название конференции
        [DataMember]
        public string ConferenceName { get; set; }

        // Дата выступления
        [DataMember]
        public DateTime PresentationDate { get; set; }

        internal Presentation(Business.Logic.Presentation presentation)
        {
            Id = presentation.Id;
            Name = presentation.Name;
            ConferenceName = presentation.ConferenceName;
            PresentationDate = presentation.PresentationDate;
        }
    }
}