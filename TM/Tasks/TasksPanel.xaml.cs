using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TM.Tasks
{
    /// <summary>
    /// Логика взаимодействия для TasksPanel.xaml
    /// </summary>
    public partial class TasksPanel : UserControl
    {
        Database db = new Database();
        public TasksPanel()
        {
            InitializeComponent();

            LoadItemsSource();
        }

        public void LoadItemsSource()
        {
            TasksDataGrid.ItemsSource = db.Tasks.Include((u) => u.Author).Include((u) => u.Executor).Include((u) => u.Project).ToArray();
        }

        private void TasksAdd_Click(object sender, RoutedEventArgs e)
        {
            new AddTaskDialog(this).Show();
        }
    }
}
