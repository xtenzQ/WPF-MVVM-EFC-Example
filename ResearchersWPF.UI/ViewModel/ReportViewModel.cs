using System;
using System.ComponentModel;
using System.Windows.Input;
using ResearchersWPF.UI.Common;

namespace ResearchersWPF.UI.ViewModel
{
    public class ReportViewModel : ViewModelBase, IDataErrorInfo
    {
        private string _name;
        private int _registerNumber;
        private int _releaseYear;
        private int _pageCount;

        private ICommand _updateCommand;
        private ICommand _deleteCommand;
        private ICommand _cancelCommand;

        private ReportViewModel _originalValue;

        public ResearcherViewModel Researcher { get; set; }

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

        public Mode Mode { get; set; }   

        public int Id { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        // Регистрационный номер
        public int RegisterNumber
        {
            get => _registerNumber;
            set
            {
                if (value == _registerNumber) return;
                _registerNumber = value;
                OnPropertyChanged();
            }
        }

        // Год выпуска
        public int ReleaseYear
        {
            get => _releaseYear;
            set
            {
                if (value == _releaseYear) return;
                _releaseYear = value;
                OnPropertyChanged();
            }
        }

        // Число страниц
        public int PageCount
        {
            get => _pageCount;
            set
            {
                if (value == _pageCount) return;
                _pageCount = value;
                OnPropertyChanged();
            }
        }

        internal ReportViewModel(svcReport.Report report)
        {
            Id = report.Id;
            Name = report.Name;
            RegisterNumber = report.RegisterNumber;
            ReleaseYear = report.ReleaseYear;
            PageCount = report.PageCount;
            _originalValue = (ReportViewModel) MemberwiseClone();
        }

        internal ReportViewModel() { }

        private void Update()
        {
            var reportServiceClient = new svcReport.ReportServiceClient();
            if (Mode == Mode.Add)
            {
                reportServiceClient.AddReport(Researcher.Id, new svcReport.Report
                {
                    Name = Name,
                    RegisterNumber = RegisterNumber,
                    ReleaseYear = ReleaseYear,
                    PageCount = PageCount
                });
                Researcher.Reports = Researcher.GetReports();
            }
            else if (Mode == Mode.Edit)
            {
                reportServiceClient.UpdateReport(new svcReport.Report
                {
                    Id = Id,
                    Name = Name,
                    RegisterNumber = RegisterNumber,
                    ReleaseYear = ReleaseYear,
                    PageCount = PageCount
                });
                _originalValue = (ReportViewModel) MemberwiseClone();
            }
        }

        private void Delete()
        {
            var reportServiceClient = new svcReport.ReportServiceClient();
            reportServiceClient.DeleteReport(Id);
            Researcher.Reports = Researcher.GetReports();
        }

        private void Undo()
        {
            if (Mode == Mode.Edit)
            {
                Name = _originalValue.Name;
                RegisterNumber = _originalValue.RegisterNumber;
                ReleaseYear = _originalValue.ReleaseYear;
                PageCount = _originalValue.PageCount;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    case nameof(Name):
                        if (string.IsNullOrEmpty(Name) || (Name.Length > 196))
                        {
                            error = "Длина названия отчета должна быть меньше 196 символов!";
                        }
                        break;
                    case nameof(RegisterNumber):
                        if (RegisterNumber < 1 && RegisterNumber > 1000)
                        {
                            error = "Регистрационный номер должен лежать в интервале от 0 до 1000!";
                        }
                        break;
                    case nameof(ReleaseYear):
                        if (ReleaseYear < 1900 && ReleaseYear > DateTime.Now.Year)
                        {
                            error = "Год должен быть не меньше 1900 и не больше текущей даты!";
                        }
                        break;
                    case nameof(PageCount):
                        if (PageCount < 1)
                        {
                            error = "Длина научного отчета должна быть не меньше 1!";
                        }
                        break;
                }
                return error;
            }
        }

        public string Error => string.Empty;
    }
}