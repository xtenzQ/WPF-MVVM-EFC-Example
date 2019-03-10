using System.Runtime.Serialization;

namespace ResearchersWPF.Service.DataContracts
{
    [DataContract]
    public class Researcher
    {
        [DataMember]
        public int ResearcherId { get; private set; }

        [DataMember]
        public string LastName { get; private set; }

        [DataMember]
        public string FirstName { get; private set; }

        [DataMember]
        public string MiddleName { get; private set; }

        [DataMember]
        public int DepartmentNumber { get; private set; }

        [DataMember]
        public int Age { get; }

        [DataMember]
        public string AcademicDegree { get; }

        [DataMember]
        public string Position { get; }

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