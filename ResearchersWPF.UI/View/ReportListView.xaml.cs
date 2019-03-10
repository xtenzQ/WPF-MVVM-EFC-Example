using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ResearchersWPF.UI.ViewModel;

namespace ResearchersWPF.UI.View
{
    /// <summary>
    /// Логика взаимодействия для ReportListView.xaml
    /// </summary>
    public partial class ReportListView : UserControl
    {
        public ReportListView()
        {
            InitializeComponent();
        }

        private void btnAddReport_Click(object sender, RoutedEventArgs e)
        {
            var view = new ReportView();
            var reportViewModel = new ReportViewModel
            {
                Researcher = (ResearcherViewModel) DataContext,
                Mode = Mode.Add
            };

            view.DataContext = reportViewModel; 
            view.ShowDialog();
        }

        private void btnEditReport_Click(object sender, RoutedEventArgs e)
        {
            var view = new ReportView();
            var reportViewModel = (ReportViewModel)((Button)sender).DataContext;
            reportViewModel.Mode = Mode.Edit;
            view.DataContext = reportViewModel;
            view.ShowDialog();
        }
    }
}
