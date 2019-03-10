using System;
using ResearchersWPF.UI.Interface;

namespace ResearchersWPF.UI.View
{
    public class ResearcherViewDialog : IModalDialog
    {
        private ResearcherView _view;

        public void BindViewModel<TViewModel>(TViewModel viewModel)
        {
            GetDialog().DataContext = viewModel;
        }

        public void ShowDialog()
        {
            GetDialog().ShowDialog();
        }

        public void Close()
        {
            GetDialog().Close();
        }

        private ResearcherView GetDialog()
        {
            if (_view != null) return _view;
            _view = new ResearcherView();
            _view.Closed += view_Closed;
            return _view;
        }

        void view_Closed(object sender, EventArgs e)
        {
            _view = null;
        }
    }
}