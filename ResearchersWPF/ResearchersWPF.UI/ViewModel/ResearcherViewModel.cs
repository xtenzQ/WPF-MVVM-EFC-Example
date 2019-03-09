using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Windows.Input;
using ResearchersWPF.UI.Common;

namespace ResearchersWPF.UI.ViewModel
{
    public class ResearcherViewModel : ViewModelBase
    {
        private string _lastName;
        private string _firstName;
        private string _middleName;
        private int _departmentNubmer;
        private int _age;
        private string _academicDegree;
        private string _position;

        //private ObservableCollection<ArticleViewModel> _articles;
        private ObservableCollection<MonographViewModel> _monographs;
        private ObservableCollection<PresentationViewModel> _presentations;
        private ObservableCollection<ReportViewModel> _reports;

        private ICommand _showEditCommand;
        private ICommand _updateCommand;
        private ICommand _deleteCommand;
        private ICommand _cancelCommand;

        private ResearcherViewModel _originalValue;
        private ObservableCollection<ArticleViewModel> _articles;

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

        public Mode Mode { get; set; }

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

        public ICommand ShowEditCommand
        {
            get
            {
                if (ShowEditCommand == null)
                {
                    ShowEditCommand = new CommandBase(i => ShowEditDialog(), null);
                }
            }
        }
    }
}