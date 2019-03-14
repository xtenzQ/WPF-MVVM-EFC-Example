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
using System.Windows.Shapes;

namespace ResearchersWPF.UI.View
{
    /// <summary>
    /// Логика взаимодействия для Request.xaml
    /// </summary>
    public partial class Request : Window
    {
        public Request()
        {
            InitializeComponent();
        }

        private void Search1_Click(object sender, RoutedEventArgs e)
        {
            var requestServiceClient = new svcRequest.RequestServiceClient();
            SearchResult1.Text = requestServiceClient.GetPresentationRequest(DateTime1.Value ?? DateTime.Now).ToString();
        }

        private void Search2_Click(object sender, RoutedEventArgs e)
        {
            var requestServiceClient = new svcRequest.RequestServiceClient();
            SearchResult2.Text = requestServiceClient.GetReportRequest(Convert.ToInt32(Updown.Text)).ToString();
        }
    }
}
