using ResearchersWPF.Data.Managers;

namespace ResearchersWPF.Business.Logic
{
    public class Report
    {
        private string _name;
        private int _registerNumber;
        private int _releaseYear;
        private int _pageCount;
        private Researcher _researcher;

        public int Id { get; }

        // Название научного отчёта
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

        // Регистрационный номер
        public int RegisterNumber
        {
            get
            {
                if (_registerNumber == 0)
                {
                    Refresh();
                }

                return _registerNumber;
            }
        }

        // Год выпуска
        public int ReleaseYear
        {
            get
            {
                if (_releaseYear == 0)
                {
                    Refresh();
                }

                return _releaseYear;
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

        public Report(int reportId)
        {
            Id = reportId;
        }

        public Report(int reportId, string name, int registerNumber, int releaseYear, int pageCount)
        {
            Id = reportId;
            _name = name;
            _registerNumber = registerNumber;
            _releaseYear = releaseYear;
            _pageCount = pageCount;
        }

        public void Refresh()
        {
            var manager = new FactoryManager();
            var report = manager.GetReportManager().Find(Id);
            _name = report.Name;
            _registerNumber = report.RegisterNumber;
            _releaseYear = report.ReleaseYear;
            _pageCount = report.PageCount;
        }

        private void GetResearcher()
        {
            var manager = new FactoryManager();
            var researcher = manager.GetResearcherManager().FindByReport(Id);
            _researcher = new Researcher(researcher.Id, researcher.LastName, researcher.FirstName, researcher.MiddleName,
                researcher.DepartmentNumber, researcher.Age, researcher.AcademicDegree, researcher.Position);
        }
    }
}