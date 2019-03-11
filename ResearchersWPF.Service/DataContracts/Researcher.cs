using System.Runtime.Serialization;

namespace ResearchersWPF.Service.DataContracts
{
    [DataContract]
    public class Researcher
    {
        [DataMember]
        public int ResearcherId { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public int DepartmentNumber { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public string AcademicDegree { get; set; }

        [DataMember]
        public string Position { get; set; }

        internal Researcher(Business.Logic.Researcher researcher)
        {
            ResearcherId = researcher.ResearcherId;
            LastName = researcher.LastName;
            FirstName = researcher.FirstName;
            MiddleName = researcher.MiddleName;
            DepartmentNumber = researcher.DepartmentNumber;
            Age = researcher.Age;
            AcademicDegree = researcher.AcademicDegree;
            Position = researcher.Position;
        }

    }
}