using System;
using ResearchersWPF.Data.Managers;

namespace ResearchersWPF.Business.Logic
{
    public class Presentation
    {
        private string _name;
        private string _conferenceName;
        private DateTime _presentationDate;
        private Researcher _researcher;

        public int Id { get; }

        // Название доклада
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    Refresh();
                }

                return _name;
            }
        }

        // Название конференции
        public string ConferenceName
        {
            get
            {
                if (_conferenceName == null)
                {
                    Refresh();
                }

                return _conferenceName;
            }
        }

        // Дата выступления
        public DateTime PresentationDate
        {
            get
            {
                if (_presentationDate == DateTime.MinValue)
                {
                    Refresh();
                }

                return _presentationDate;
            }
        }

        public Researcher Researcher
        {
            get
            {
                if (_researcher == null)
                {
                    GetResearcher();
                }

                return _researcher;
            }
        }

        public Presentation(int presentationId)
        {
            Id = presentationId;
        }

        public Presentation(int presentationId, string name, string conferenceName, DateTime presentationDate)
        {
            Id = presentationId;
            _name = name;
            _conferenceName = conferenceName;
            _presentationDate = presentationDate;
        }

        public void Refresh()
        {
            var manager = new FactoryManager();
            var presentation = manager.GetPresentationManager().Find(Id);
            _name = presentation.Name;
            _conferenceName = presentation.ConferenceName;
            _presentationDate = presentation.PresentationDate;
        }

        private void GetResearcher()
        {
            var manager = new FactoryManager();
            var researcher = manager.GetResearcherManager().FindByPresentation(Id);
            _researcher = new Researcher(researcher.Id, researcher.LastName, researcher.FirstName, researcher.MiddleName,
                researcher.DepartmentNumber, researcher.Age, researcher.AcademicDegree, researcher.Position);
        }
    }
}