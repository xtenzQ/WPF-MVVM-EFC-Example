using System.Collections.ObjectModel;
using System.Windows.Input;
using ResearchersWPF.UI.Common;

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
                var resVm = new ResearcherViewModel();
                ResearcherList.Add(resVm);
            }

            return ResearcherList;
        }

        private void ShowAddDialog()
        {
            var reseacher = new ResearcherViewModel();
        

        }
    }
}