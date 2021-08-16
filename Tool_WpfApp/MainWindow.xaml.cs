using System.Windows;

using AzureDevOpsAPI;

namespace Tool_WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_GetProjectsList_Click(object sender, RoutedEventArgs e)
        {
            var result = Core.Projects.OrganizationProjectsList(Organization.Text, Token.Text);

            DataOutput.ItemsSource = result.value;
        }
    }
}
