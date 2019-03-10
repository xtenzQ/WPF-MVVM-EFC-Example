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
    /// Логика взаимодействия для MonographListView.xaml
    /// </summary>
    public partial class MonographListView : UserControl
    {
        public MonographListView()
        {
            InitializeComponent();
        }

        private void btnAddMonograph_Click(object sender, RoutedEventArgs e)
        {
            var view = new MonographView();
            var monographViewModel = new MonographViewModel()
            {
                Researcher = (ResearcherViewModel)DataContext,
                Mode = Mode.Add
            };

            view.DataContext = monographViewModel;
            view.ShowDialog();
        }

        private void btnEditMonograph_Click(object sender, RoutedEventArgs e)
        {
            var view = new MonographView();
            var monographViewModel = (MonographViewModel)((Button)sender).DataContext;
            monographViewModel.Mode = Mode.Edit;
            view.DataContext = monographViewModel;
            view.ShowDialog();
        }
    }
}
