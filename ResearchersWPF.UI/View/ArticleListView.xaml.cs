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
    /// Логика взаимодействия для ArticleListView.xaml
    /// </summary>
    public partial class ArticleListView : UserControl
    {
        public ArticleListView()
        {
            InitializeComponent();
        }

        private void btnAddArticle_Click(object sender, RoutedEventArgs e)
        {
            var view = new ArticleView();
            var articleViewModel = new ArticleViewModel()
            {
                Researcher = (ResearcherViewModel)DataContext,
                Mode = Mode.Add
            };

            view.DataContext = articleViewModel;
            view.ShowDialog();
        }

        private void btnEditArticle_Click(object sender, RoutedEventArgs e)
        {
            var view = new ArticleView();
            var articleViewModel = (ArticleViewModel)((Button)sender).DataContext;
            articleViewModel.Mode = Mode.Edit;
            view.DataContext = articleViewModel;
            view.ShowDialog();
        }
    }
}
