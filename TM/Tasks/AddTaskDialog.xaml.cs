using System;
using System.Windows;
using System.Windows.Input;
using TM.Models;

namespace TM.Tasks
{
    /// <summary>
    /// Логика взаимодействия для AddTaskDialog.xaml
    /// </summary>
    public partial class AddTaskDialog : Window
    {
        Database db = new Database();
        TasksPanel panel;
        public AddTaskDialog(TasksPanel panel)
        {
            InitializeComponent();

            this.panel = panel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var task = new Task
            {
                Name = NameBox.Text,
                Start = (DateTime)StartBox.SelectedDate,
                End = (DateTime)EndBox.SelectedDate,
            };
            task.Code = "Code";
            try
            {
                task =  db.Tasks.Add(task).Entity;
                db.SaveChanges();

                task.Project = ProjectBox.SelectedItem as Project;
                task.Author = AuthorBox.SelectedItem as User;
                task.Executor = ExecutorBox.SelectedItem as User;
                task.Code = task.Project.Code + "-" + DateTime.Now.DayOfYear + DateTime.Now.Hour + DateTime.Now.Minute;

                db.Update(task);
                db.SaveChanges();

                panel.LoadItemsSource();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
                MessageBox.Show("Не получилось создать задачу");
            }
        }

        private void ProjectBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new SelectProjectDialog(this).Show();
        }

        private void AuthorBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new SelectAuthorDialog(this).Show();
        }

        private void ExecutorBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new SelectExecutorWindow(this).Show();
        }
    }
}
