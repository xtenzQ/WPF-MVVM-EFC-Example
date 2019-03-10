using ResearchersWPF.Data.Managers;

namespace ResearchersWPF.Business.Logic
{
    public class Monograph
    {
        public int Id { get; }

        private string _name;
        private string _coauthorLastName;
        private string _coauthorFirstName;
        private string _coauthorMiddleName;
        private int _releaseDate;
        private int _pageCount;
        private Researcher _researcher;

        // Название монографии
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

        // ФИО соавтора
        public string CoauthorLastName
        {
            get
            {
                if (_coauthorLastName == null)
                {
                    Refresh();
                }

                return _coauthorLastName;
            } 
            
        }

        public string CoauthorFirstName
        {
            get
            {
                if (_coauthorFirstName == null)
                {
                    Refresh();
                }

                return _coauthorFirstName;
            }
        }

        public string CoauthorMiddleName
        {
            get
            {
                if (_coauthorMiddleName == null)
                {
                    Refresh();
                }

                return _coauthorMiddleName;
            }
        }

        // Год издания
        public int ReleaseDate
        {
            get
            {
                if (_releaseDate == 0)
                {
                    Refresh();
                }

                return _releaseDate;
            }
        }

        // Число страниц
        public int PageCount
        {
            get
            {
                if (_pageCount == 0)
                {
                    Refresh();
                }

                return _pageCount;
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

        public Monograph(int monographId)
        {
            Id = monographId;
        }

        public Monograph(int monographId, string name, string coauthorLastName, string coauthorFirstName,
            string coauthorMiddleName,
            int releaseDate, int pageCount)
        {
            Id = monographId;
            _name = name;
            _coauthorLastName = coauthorLastName;
            _coauthorFirstName = coauthorFirstName;
            _coauthorMiddleName = coauthorMiddleName;
            _releaseDate = releaseDate;
            _pageCount = pageCount;
        }

        public void Refresh()
        {
            var manager = new FactoryManager();
            var monograph = manager.GetMonographManager().Find(Id);
            _name = monograph.Name;
            _coauthorLastName = monograph.CoauthorLastName;
            _coauthorFirstName = monograph.CoauthorFirstName;
            _coauthorMiddleName = monograph.CoauthorMiddleName;
            _releaseDate = monograph.ReleaseDate;
            _pageCount = monograph.PageCount;
        }

        private void GetResearcher()
        {
            var manager = new FactoryManager();
            var researcher = manager.GetResearcherManager().FindByMonograph(Id);
            _researcher = new Researcher(researcher.Id, researcher.LastName, researcher.FirstName, researcher.MiddleName,
                researcher.DepartmentNumber, researcher.Age, researcher.AcademicDegree, researcher.Position);
        }
    }
}