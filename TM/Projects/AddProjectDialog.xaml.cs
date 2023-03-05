using System.Linq;
using System.Windows;
using TM.Models;

namespace TM.Projects
{
    /// <summary>
    /// Логика взаимодействия для AddProjectDialog.xaml
    /// </summary>
    public partial class AddProjectDialog : Window
    {
        Database db = new Database();
        ProjectsPanel panel;
        public AddProjectDialog(ProjectsPanel panel)
        {
            InitializeComponent();

            this.panel = panel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var project = new Project
            {
                Code = CodeBox.Text,
                Name = NameBox.Text,
            };
            if (db.Projects.FirstOrDefault((u) => u.Code == project.Code) != null)
            {
                MessageBox.Show("Это код уже занят");
            }
            else
            {
                try
                {
                    db.Projects.Add(project);
                    db.SaveChanges();

                    panel.LoadItemsSource();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Не получилось создать проект");
                }

            }
        }
    }
}
