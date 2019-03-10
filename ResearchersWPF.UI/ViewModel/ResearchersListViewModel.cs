using System.Collections.ObjectModel;
using System.Windows.Input;
using ResearchersWPF.UI.Common;
using ResearchersWPF.UI.Interface;
using ResearchersWPF.UI.Service;

namespace ResearchersWPF.UI.ViewModel
{
    public class ResearchersListViewModel : ViewModelBase
    {
        private static ResearchersListViewModel _instance;

        private ResearcherViewModel _selectedResearcher;

        private ObservableCollection<ResearcherViewModel> _researcherList;

        private ICommand _showAddCommand;

        public ObservableCollection<ResearcherViewModel> ResearcherList
        {
            get => GetResearchers();
            set
            {
                if (Equals(value, _researcherList)) return;
                _researcherList = value;
                OnPropertyChanged();
            }
        }

        public ResearcherViewModel SelectedResearcher
        {
            get => _selectedResearcher;
            set
            {
                if (Equals(value, _selectedResearcher)) return;
                _selectedResearcher = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowAddCommand
        {
            get { return _showAddCommand ?? (_showAddCommand = new CommandBase(i => ShowAddDialog(), null)); }
            
        }

        private ResearchersListViewModel()
        {
            ResearcherList = GetResearchers();
        }

        public static ResearchersListViewModel Instance()
        {
            return _instance ?? (_instance = new ResearchersListViewModel());
        }

        internal ObservableCollection<ResearcherViewModel> GetResearchers()
        {
            if (ResearcherList == null)
            {
                ResearcherList = new ObservableCollection<ResearcherViewModel>();
            }
            ResearcherList.Clear();
            foreach (var researcher in new svcResearcher.ResearcherServiceClient().GetResearchers())
            {
                var resVm = new ResearcherViewModel(researcher);
                ResearcherList.Add(resVm);
            }

            return ResearcherList;
        }

        private void ShowAddDialog()
        {
            var reseacher = new ResearcherViewModel {Mode = Mode.Add};

            var dialog = ServiceProvider.Instance.Get<IModalDialog>();
            dialog.BindViewModel(reseacher);
            dialog.ShowDialog();
        }
    }
}