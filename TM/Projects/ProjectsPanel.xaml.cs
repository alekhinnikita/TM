using System.Linq;
using System.Windows.Controls;

namespace TM.Projects
{
    /// <summary>
    /// Логика взаимодействия для ProjectsPanel.xaml
    /// </summary>
    public partial class ProjectsPanel : UserControl
    {
        Database db = new Database();

        public ProjectsPanel()
        {
            InitializeComponent();
            LoadItemsSource();
        }

        public void LoadItemsSource()
        {
            ProjectsDataGrid.ItemsSource = db.Projects.ToArray();
        }

        private void ProjectsAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            new AddProjectDialog(this).Show();
        }
    }
}
