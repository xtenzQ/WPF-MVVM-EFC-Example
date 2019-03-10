using System;
using System.ComponentModel;
using System.Windows.Input;
using ResearchersWPF.UI.Common;

namespace ResearchersWPF.UI.ViewModel
{
    public class ArticleViewModel : ViewModelBase, IDataErrorInfo
    {
        public int Id { get; set; }
        private string _name;
        private string _magazineName;
        private DateTime _releaseDate;

        private ICommand _updateCommand;
        private ICommand _deleteCommand;
        private ICommand _cancelCommand;

        private ArticleViewModel _originalValue;

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

        // Название статьи
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

        // Название журнала
        public string MagazineName
        {
            get => _magazineName;
            set
            {
                if (value == _magazineName) return;
                _magazineName = value;
                OnPropertyChanged();
            }
        }

        // Год и месяц издания
        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set
            {
                if (value == _releaseDate) return;
                _releaseDate = value;
                OnPropertyChanged();
            }
        }

        internal ArticleViewModel(svcArticle.Article article)
        {
            Id = article.Id;
            Name = article.Name;
            MagazineName = article.MagazineName;
            ReleaseDate = article.ReleaseDate;
            _originalValue = (ArticleViewModel) MemberwiseClone();
        }

        internal ArticleViewModel() { }

        private void Update()
        {
            var articleServiceClient = new svcArticle.ArticleServiceClient();
            if (Mode == Mode.Add)
            {
                articleServiceClient.AddArticle(Researcher.Id, new svcArticle.Article
                {
                    Id = Id,
                    Name = Name,
                    MagazineName = MagazineName,
                    ReleaseDate = ReleaseDate
                });
                Researcher.Articles = Researcher.GetArticles();
            }
            else if (Mode == Mode.Edit)
            {
                articleServiceClient.UpdateArticle(new svcArticle.Article
                {
                        Id = Id,
                        Name = Name,
                        MagazineName = MagazineName,
                        ReleaseDate = ReleaseDate
                });
                _originalValue = (ArticleViewModel) MemberwiseClone();
            }
        }

        private void Delete()
        {
            var articleServiceClient = new svcArticle.ArticleServiceClient();
            articleServiceClient.DeleteArticle(Id);
            Researcher.Articles = Researcher.GetArticles();
        }

        private void Undo()
        {
            if (Mode != Mode.Edit) return;
            Name = _originalValue.Name;
            MagazineName = _originalValue.MagazineName;
            ReleaseDate = _originalValue.ReleaseDate;
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
                            error = "Длина названия статьи должна быть меньше 196 символов!";
                        }
                        break;
                    case nameof(MagazineName):
                        if (string.IsNullOrEmpty(MagazineName) || MagazineName.Length > 196)
                        {
                            error = "Длина незвания журнала должна быть меньше 196 символов!";
                        }
                        break;
                    case nameof(ReleaseDate):
                        if (ReleaseDate.Year < 1900 && ReleaseDate > DateTime.Now)
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