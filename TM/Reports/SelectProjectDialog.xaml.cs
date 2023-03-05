using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TM.Models;

namespace TM.Reports
{
    /// <summary>
    /// Логика взаимодействия для SelectProjectDialog.xaml
    /// </summary>
    public partial class SelectProjectDialog : Window
    {
        Database db = new Database();
        Action<Project> action;
        public SelectProjectDialog(Action<Project> action)
        {
            InitializeComponent();
            this.action = action;
            ProjectListView.ItemsSource = db.Projects.ToArray();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProjectListView.ItemsSource =
                db.Projects.Where((p) => p.Name.Contains(SearchBox.Text) || p.Code.Contains(SearchBox.Text)).ToArray();
        }

        private void SelectBox_Click(object sender, RoutedEventArgs e)
        {
            var project = ProjectListView.SelectedItem as Project;
            if (project == null)
            {
                MessageBox.Show("Проект не выбран");
            }
            else
            {
                action(project);
                this.Close();
            }
        }
    }
}
