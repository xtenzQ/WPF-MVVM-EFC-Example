using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using ResearchersWPF.UI.Common;

namespace ResearchersWPF.UI.ViewModel
{
    public class MonographViewModel : ViewModelBase, IDataErrorInfo
    {
        public int Id { get; set; }
        private string _name;
        private string _coauthorLastName;
        private string _coauthorFirstName;
        private string _coauthorMiddleName;
        private int _releaseDate;
        private int _pageCount;

        private ICommand _updateCommand;
        private ICommand _deleteCommand;
        private ICommand _cancelCommand;

        private MonographViewModel _originalValue;

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

        // ФИО соавтора
        public string CoauthorLastName
        {
            get => _coauthorLastName;
            set
            {
                if (value == _coauthorLastName) return;
                _coauthorLastName = value;
                OnPropertyChanged();
            }
        }

        public string CoauthorFirstName
        {
            get => _coauthorFirstName;
            set
            {
                if (value == _coauthorFirstName) return;
                _coauthorFirstName = value;
                OnPropertyChanged();
            }
        }

        public string CoauthorMiddleName
        {
            get => _coauthorMiddleName;
            set
            {
                if (value == _coauthorMiddleName) return;
                _coauthorMiddleName = value;
                OnPropertyChanged();
            }
        }

        // Год издания
        public int ReleaseDate
        {
            get => _releaseDate;
            set
            {
                if (value.Equals(_releaseDate)) return;
                _releaseDate = value;
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

        internal MonographViewModel(svcMonograph.Monograph monograph)
        {
            Id = monograph.Id;
            CoauthorLastName = monograph.CoauthorLastName;
            CoauthorFirstName = monograph.CoauthorFirstName;
            CoauthorMiddleName = monograph.CoauthorMiddleName;
            ReleaseDate = monograph.ReleaseDate;
            PageCount = monograph.PageCount;
            _originalValue = (MonographViewModel) MemberwiseClone();
        }

        internal MonographViewModel() { }

        private void Update()
        {
            var monographServiceClient = new svcMonograph.MonographServiceClient();
            if (Mode == Mode.Add)
            {
                monographServiceClient.AddMonograph(Researcher.Id, new svcMonograph.Monograph
                {
                    CoauthorLastName = CoauthorLastName,
                    CoauthorFirstName = CoauthorFirstName,
                    CoauthorMiddleName = CoauthorMiddleName,
                    ReleaseDate = ReleaseDate,
                    PageCount = PageCount
                });
                Researcher.Monographs = Researcher.GetMonographs();
            }
            else if (Mode == Mode.Edit)
            {
                monographServiceClient.UpdateMonograph(new svcMonograph.Monograph
                {
                    Id = Id,
                    CoauthorLastName = CoauthorLastName,
                    CoauthorFirstName = CoauthorFirstName,
                    CoauthorMiddleName = CoauthorMiddleName,
                    ReleaseDate = ReleaseDate,
                    PageCount = PageCount
                });
                _originalValue = (MonographViewModel) MemberwiseClone();
            }
        }

        private void Delete()
        {
            var monographServiceClient = new svcMonograph.MonographServiceClient();
            monographServiceClient.DeleteMonograph(Id);
            Researcher.Monographs = Researcher.GetMonographs();
        }

        private void Undo()
        {
            if (Mode != Mode.Edit) return;
            CoauthorLastName = _originalValue.CoauthorLastName;
            CoauthorFirstName = _originalValue.CoauthorFirstName;
            CoauthorMiddleName = _originalValue.CoauthorMiddleName;
            ReleaseDate = _originalValue.ReleaseDate;
            PageCount = _originalValue.PageCount;
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
                            error = "Длина названия монографии должна быть меньше 196 символов!";
                        }
                        break;
                    case nameof(CoauthorLastName):
                        if (string.IsNullOrEmpty(CoauthorLastName) || (CoauthorLastName.Length > 196))
                        {
                            error = "Длина фамлилии должна быть меньше 196 символов!";
                        }
                        else if (!Regex.IsMatch(CoauthorLastName, @"^[а-яА-Я]+$"))
                        {
                            error = "Фамилия должна содержать только русские буквы!";
                        }
                        break;
                    case nameof(CoauthorFirstName):
                        if (string.IsNullOrEmpty(CoauthorFirstName) || CoauthorFirstName.Length > 196)
                        {
                            error = "Длина имени должна быть меньше 196 символов!";
                        }
                        else if (!Regex.IsMatch(CoauthorFirstName, @"^[а-яА-Я]+$"))
                        {
                            error = "Имя должно содержать только русские буквы!";
                        }
                        break;
                    case nameof(CoauthorMiddleName):
                        if (string.IsNullOrEmpty(CoauthorMiddleName) || CoauthorMiddleName.Length > 196)
                        {
                            error = "Длина Вашего отчества должна быть меньше 196 символов!";
                        }
                        else if (!Regex.IsMatch(CoauthorMiddleName, @"^[а-яА-Я]+$"))
                        {
                            error = "Отчество должно содержать только русские буквы!";
                        }
                        break;
                    case nameof(ReleaseDate):
                        if (ReleaseDate < 1900 && ReleaseDate > DateTime.Now.Year)
                        {
                            error = "Год должен быть не меньше 1900 и не больше текущей даты!";
                        }
                        break;
                    case nameof(PageCount):
                        if (PageCount < 1)
                        {
                            error = "Длина монографии должна быть не меньше 1!";
                        }
                        break;
                }
                return error;
            }
        }

        public string Error => string.Empty;

    }
}