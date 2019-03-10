using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ResearchersWPF.UI.Common;
using ResearchersWPF.UI.svcPresentation;

namespace ResearchersWPF.UI.ViewModel
{
    public class PresentationViewModel : ViewModelBase, IDataErrorInfo
    {
        private string _name;
        private string _conferenceName;
        private DateTime _presentationDate;

        private ICommand _updateCommand;
        private ICommand _deleteCommand;
        private ICommand _cancelCommand;

        private PresentationViewModel _originalValue;

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

        // Название доклада
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

        // Название конференции
        public string ConferenceName
        {
            get => _conferenceName;
            set
            {
                if (value == _conferenceName) return;
                _conferenceName = value;
                OnPropertyChanged();
            }
        }

        // Дата выступления
        public DateTime PresentationDate
        {
            get => _presentationDate;
            set
            {
                if (value.Equals(_presentationDate)) return;
                _presentationDate = value;
                OnPropertyChanged();
            }
        }

        internal PresentationViewModel(svcPresentation.Presentation presentation)
        {
            Id = presentation.Id;
            Name = presentation.Name;
            ConferenceName = presentation.ConferenceName;
            PresentationDate = presentation.PresentationDate;
            _originalValue = (PresentationViewModel) MemberwiseClone();
        }

        internal PresentationViewModel() { }

        private void Update()
        {
            var presentationServiceClient = new svcPresentation.PresentationServiceClient();
            if (Mode == Mode.Add)
            {
                presentationServiceClient.AddPresentation(Researcher.Id, new Presentation
                {
                    Name = Name,
                    ConferenceName = ConferenceName,
                    PresentationDate = PresentationDate
                });
                Researcher.Presentations = Researcher.GetPresentations();
            }
            else if (Mode == Mode.Edit)
            {
                presentationServiceClient.UpdatePresentation(new svcPresentation.Presentation
                {
                    Id = Id,
                    Name = Name,
                    ConferenceName = ConferenceName,
                    PresentationDate = PresentationDate
                });
                _originalValue = (PresentationViewModel) MemberwiseClone();
            }
        }

        private void Delete()
        {
            var presentationServiceClient = new svcPresentation.PresentationServiceClient();
            presentationServiceClient.DeletePresentation(Id);
            Researcher.Presentations = Researcher.GetPresentations();
        }

        private void Undo()
        {
            if (Mode == Mode.Edit)
            {
                Name = _originalValue.Name;
                ConferenceName = _originalValue.ConferenceName;
                PresentationDate = _originalValue.PresentationDate;
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
                            error = "Длина названия доклада должна быть меньше 196 символов!";
                        }
                        break;
                    case nameof(ConferenceName):
                        if (string.IsNullOrEmpty(ConferenceName) || (ConferenceName.Length > 196))
                        {
                            error = "Длина названия конференции должна быть меньше 196 символов!";
                        }
                        break;
                    case nameof(PresentationDate):
                        if (PresentationDate.Year < 1900 && PresentationDate > DateTime.Now)
                        {
                            error = "Год должен быть не меньше 1900 и не больше текущей даты!";
                        }
                        break;
                }
                return error;
            }
        }

        public string Error => string.Empty;
    }
}