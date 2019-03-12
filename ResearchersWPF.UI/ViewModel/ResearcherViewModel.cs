using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using ResearchersWPF.UI.Common;
using ResearchersWPF.UI.Interface;
using ResearchersWPF.UI.svcResearcher;
using ResearchersWPF.UI.Service;

namespace ResearchersWPF.UI.ViewModel
{
    public class ResearcherViewModel : ViewModelBase, IDataErrorInfo
    {
        private string _lastName;
        private string _firstName;
        private string _middleName;
        private int _departmentNubmer;
        private int _age;
        private string _academicDegree;
        private string _position;

        private ObservableCollection<ArticleViewModel> _articles;
        private ObservableCollection<MonographViewModel> _monographs;
        private ObservableCollection<PresentationViewModel> _presentations;
        private ObservableCollection<ReportViewModel> _reports;

        private ICommand _showEditCommand;
        private ICommand _updateCommand;
        private ICommand _deleteCommand;
        private ICommand _cancelCommand;

        private ResearcherViewModel _originalValue;

        public Mode Mode { get; set; }

        public ICommand ShowEditCommand
        {
            get { return _showEditCommand ?? (_showEditCommand = new CommandBase(i => ShowEditDialog(), null)); }
        }

        public ICommand UpdateCommand
        {
            get { return _updateCommand ?? (_updateCommand = new CommandBase(i => Update(), null)); }
        }

        public ICommand DeleteCommand
        {
            get { return _deleteCommand ?? (_deleteCommand = new CommandBase(i => Delete(), null)); }
        }

        public ICommand CancelCommand
        {
            get { return _cancelCommand ?? (_cancelCommand = new CommandBase(i => Undo(), null)); }
        }

        public int Id { get; set; }

        // ФИО
        public string LastName
        {
            get => _lastName;
            set
            {
                if (value == _lastName) return;
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                if (value == _firstName) return;
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string MiddleName
        {
            get => _middleName;
            set
            {
                if (value == _middleName) return;
                _middleName = value;
                OnPropertyChanged();
            }
        }

        // Номер отдела
        public int DepartmentNumber
        {
            get => _departmentNubmer;
            set
            {
                if (value == _departmentNubmer) return;
                _departmentNubmer = value;
                OnPropertyChanged();
            }
        }

        // Возраст
        public int Age
        {
            get => _age;
            set
            {
                if (value == _age) return;
                _age = value;
                OnPropertyChanged();
            }
        }

        // Ученая степень
        public string AcademicDegree
        {
            get => _academicDegree;
            set
            {
                if (value == _academicDegree) return;
                _academicDegree = value;
                OnPropertyChanged();
            }
        }

        // Должность
        public string Position
        {
            get => _position;
            set
            {
                if (value == _position) return;
                _position = value;
                OnPropertyChanged();
            }
        }

        public ResearchersListViewModel Container => ResearchersListViewModel.Instance();

        public ObservableCollection<ArticleViewModel> Articles
        {
            get => GetArticles();
            set
            {
                if (Equals(value, _articles)) return;
                _articles = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<MonographViewModel> Monographs
        {
            get => GetMonographs();
            set
            {
                if (Equals(value, _monographs)) return;
                _monographs = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PresentationViewModel> Presentations
        {
            get => GetPresentations();
            set
            {
                if (Equals(value, _presentations)) return;
                _presentations = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ReportViewModel> Reports
        {
            get => GetReports();
            set
            {
                if (Equals(value, _reports)) return;
                _reports = value;
                OnPropertyChanged();
            }
        }

        public ResearcherViewModel(svcResearcher.Researcher researcher)
        {
            Id = researcher.ResearcherId;
            LastName = researcher.LastName;
            FirstName = researcher.FirstName;
            MiddleName = researcher.MiddleName;
            DepartmentNumber = researcher.DepartmentNumber;
            Age = researcher.Age;
            AcademicDegree = researcher.AcademicDegree;
            Position = researcher.Position;
            _originalValue = (ResearcherViewModel) MemberwiseClone();
        }

        internal  ResearcherViewModel() { }

        internal ObservableCollection<ArticleViewModel> GetArticles()
        {
            if (_articles == null)
            {
                _articles = new ObservableCollection<ArticleViewModel>();
            }
            _articles.Clear();
            var articleServiceClient = new svcArticle.ArticleServiceClient();
            foreach (var article in articleServiceClient.GetArticleByResearcher(Id))
            {
                var articleVm = new ArticleViewModel(article) { Researcher = this };
                _articles.Add(articleVm);
            }

            return _articles;
        }

        internal ObservableCollection<MonographViewModel> GetMonographs()
        {
            if (_monographs == null)
            {
                _monographs = new ObservableCollection<MonographViewModel>();
            }
            _monographs.Clear();
            var monographServiceClient = new svcMonograph.MonographServiceClient();
            foreach (var monograph in monographServiceClient.GetMonographByResearcher(Id))
            {
                var monographVm = new MonographViewModel(monograph) { Researcher = this };
                _monographs.Add(monographVm);
            }

            return _monographs;
        }

        internal ObservableCollection<PresentationViewModel> GetPresentations()
        {
            if (_presentations == null)
            {
                _presentations = new ObservableCollection<PresentationViewModel>();
            }
            _presentations.Clear();
            var presentationServiceClient = new svcPresentation.PresentationServiceClient();
            foreach (var presentation in presentationServiceClient.GetPresentationByResearcher(Id))
            {
                var presentationVm = new PresentationViewModel(presentation) { Researcher = this };
                _presentations.Add(presentationVm);
            }

            return _presentations;
        }

        internal ObservableCollection<ReportViewModel> GetReports()
        {
            if (_reports == null)
            {
                _reports = new ObservableCollection<ReportViewModel>();
            }
            _reports.Clear();
            var reportServiceClient = new svcReport.ReportServiceClient();
            foreach (var report in reportServiceClient.GetReportByResearcher(Id))
            {
                var reportVm = new ReportViewModel(report) { Researcher = this };
                _reports.Add(reportVm);
            }

            return _reports;
        }

        private void ShowEditDialog()
        {
            Mode = Mode.Edit;
            var dialog = ServiceProvider.Instance.Get<IModalDialog>();
            dialog.BindViewModel(this);
            dialog.ShowDialog();
        }

        private void Update()
        {
            var researcherServiceClient = new svcResearcher.ResearcherServiceClient();
            if (Mode == Mode.Add)
            {
                researcherServiceClient.AddResearcher(LastName, FirstName, MiddleName, DepartmentNumber, Age,
                    AcademicDegree, Position);
                Container.ResearcherList = Container.GetResearchers();
            }
            else if (Mode == Mode.Edit)
            {
                researcherServiceClient.UpdateResearcher(new svcResearcher.Researcher
                {
                    ResearcherId = Id,
                    LastName = LastName,
                    FirstName = FirstName,
                    MiddleName = MiddleName,
                    Age = Age,
                    DepartmentNumber = DepartmentNumber,
                    AcademicDegree = AcademicDegree,
                    Position = Position
                });
                _originalValue = (ResearcherViewModel) MemberwiseClone();
            }
        }

        private void Delete()
        {
            var researcherServiceClient = new ResearcherServiceClient();
            researcherServiceClient.DeleteResearcher(Id);
            Container.ResearcherList = Container.GetResearchers();
        }

        private void Undo()
        {
            if (Mode != Mode.Edit) return;
            LastName = _originalValue.LastName;
            FirstName = _originalValue.FirstName;
            MiddleName = _originalValue.MiddleName;
            Age = _originalValue.Age;
            DepartmentNumber = _originalValue.DepartmentNumber;
            AcademicDegree = _originalValue.AcademicDegree;
            Position = _originalValue.Position;
        }

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case nameof(LastName):
                        if (string.IsNullOrEmpty(LastName) || (LastName.Length > 196))
                        {
                            error = "Длина Вашей фамлилии должна быть меньше 196 символов!";
                        }
                        else if (!Regex.IsMatch(LastName, @"^[а-яА-Я]+$"))
                        {
                            error = "Фамилия должна содержать только русские буквы!";
                        }
                        break;
                    case nameof(FirstName):
                        if (string.IsNullOrEmpty(FirstName) || FirstName.Length > 196)
                        {
                            error = "Длина Вашего имени должна быть меньше 196 символов!";
                        }
                        else if (!Regex.IsMatch(FirstName, @"^[а-яА-Я]+$"))
                        {
                            error = "Имя должно содержать только русские буквы!";
                        }
                        break;
                    case nameof(MiddleName):
                        if (string.IsNullOrEmpty(MiddleName) || MiddleName.Length > 196)
                        {
                            error = "Длина Вашего отчества должна быть меньше 196 символов!";
                        }
                        else if (!Regex.IsMatch(MiddleName, @"^[а-яА-Я]+$"))
                        {
                            error = "Отчество должно содержать только русские буквы!";
                        }
                        break;
                    case nameof(DepartmentNumber):
                        if (DepartmentNumber < 1 || DepartmentNumber > 1000)
                        {
                            error = "Номер отдела должен быть больше 1 и меньше 1000!";
                        }

                        break;
                    case nameof(Age):
                        if (Age < 1 || Age > 130)
                        {
                            error = "Возраст должен быть больше 0 и меньше 130";
                        }

                        break;
                    case nameof(AcademicDegree):
                        if (string.IsNullOrEmpty(AcademicDegree))
                        {
                            error = "Выберите степень!";
                        }

                        break;
                    case nameof(Position):
                        if (string.IsNullOrEmpty(Position) || Position.Length > 100)
                        {
                            error = "Длина должности должна быть меньше 100 символов!";
                        }
                        else if (!Regex.IsMatch(Position, @"^[а-яА-Я]+$"))
                        {
                            error = "Должность должна содержать только русские буквы!";
                        }

                        break;
                }
                return error;
            }
        }

        public string Error => string.Empty;
    }
}