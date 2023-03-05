using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using TM.Models;

namespace TM.Reports
{
    /// <summary>
    /// Логика взаимодействия для ReportsPanel.xaml
    /// </summary>
    public partial class ReportsPanel : UserControl
    {
        Database db = new Database();
        public ReportsPanel()
        {
            InitializeComponent();
        }

        private void WeekProject_Click(object sender, RoutedEventArgs e)
        {
            new SelectProjectDialog((Project p) => CreateWeakReporortOnProject(p)).Show();
        }
        private void MonthProject_Click(object sender, RoutedEventArgs e)
        {
            new SelectProjectDialog((Project p) => CreateMonthReporortOnProject(p)).Show();
        }
        private void WeekExecutor_Click(object sender, RoutedEventArgs e)
        {
            new SelectUserDialog((User u) => CreateWeekExecutorReport(u)).Show();
        }
        private void MonthExecutor_Click(object sender, RoutedEventArgs e)
        {
            new SelectUserDialog((User u) => CreateMonthExecutorReport(u)).Show();
        }

        public void CreateWeakReporortOnProject(Project project)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "csv | csv";
            if (sfd.ShowDialog() == true)
            {
                var path = sfd.FileName + ".csv";

                var start = DateTime.Now.AddDays(-7);
                var tasks = db.Tasks.Include((u) => u.Author).Include((u) => u.Executor).Include((u) => u.Project)
                    .Where((t) => t.Project == project 
                    && t.Start >= start).ToList();

                var text = "Отчет по проекту: " + project.Name + "\n";
                text += "За " + start.ToString("dd.MM.yyyy") + "-" + DateTime.Now.ToString("dd.MM.yyyy") + "\n";
                text += "Код,Название,Автор,Исполнитель,Начало,Окончание\n";
                foreach (var task in tasks)
                {
                    text += task.Code + "," + task.Name + ","
                        + task.Author.Name + "," + task.Executor.Name + ","
                        + task.Start.ToString("dd.MM.yyyy") + ","
                        + task.End.ToString("dd.MM.yyyy") + "\n";
                }
                File.WriteAllText(path, text, Encoding.UTF8);
            }
        }
        public void CreateMonthReporortOnProject(Project project)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "csv | csv";
            if (sfd.ShowDialog() == true)
            {
                var path = sfd.FileName + ".csv";

                var start = DateTime.Now.AddMonths(-1);
                var tasks = db.Tasks.Include((u) => u.Author).Include((u) => u.Executor).Include((u) => u.Project)
                    .Where((t) => t.Project == project
                    && t.Start >= start).ToList();

                var text = "Отчет по проекту: " + project.Name + "\n";
                text += "За " + start.ToString("dd.MM.yyyy") + "-" + DateTime.Now.ToString("dd.MM.yyyy") + "\n";
                text += "Код,Название,Автор,Исполнитель,Начало,Окончание\n";
                foreach (var task in tasks)
                {
                    text += task.Code + "," + task.Name + ","
                        + task.Author.Name + "," + task.Executor.Name + ","
                        + task.Start.ToString("dd.MM.yyyy") + ","
                        + task.End.ToString("dd.MM.yyyy") + "\n";
                }
                File.WriteAllText(path, text, Encoding.UTF8);
            }
        }
        public void CreateWeekExecutorReport(User user)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "csv | csv";
            if (sfd.ShowDialog() == true)
            {
                var path = sfd.FileName + ".csv";

                var start = DateTime.Now.AddDays(-7);
                var tasks = db.Tasks.Include((u) => u.Author).Include((u) => u.Executor).Include((u) => u.Project)
                    .Where((t) => t.Executor == user
                    && t.Start >= start).ToList();

                var text = "Отчет по сотруднику: " + user.Name + "\n";
                text += "За " + start.ToString("dd.MM.yyyy") + "-" + DateTime.Now.ToString("dd.MM.yyyy") + "\n";
                text += "Код,Название,Автор,Начало,Окончание\n";
                foreach (var task in tasks)
                {
                    text += task.Code + "," + task.Name + ","
                        + task.Author.Name + ","
                        + task.Start.ToString("dd.MM.yyyy") + ","
                        + task.End.ToString("dd.MM.yyyy") + "\n";
                }
                File.WriteAllText(path, text, Encoding.UTF8);
            }
        }
        public void CreateMonthExecutorReport(User user)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "csv | csv";
            if (sfd.ShowDialog() == true)
            {
                var path = sfd.FileName + ".csv";

                var start = DateTime.Now.AddMonths(-1);
                var tasks = db.Tasks.Include((u) => u.Author).Include((u) => u.Executor).Include((u) => u.Project)
                    .Where((t) => t.Executor == user
                    && t.Start >= start).ToList();

                var text = "Отчет по сотруднику: " + user.Name + "\n";
                text += "За " + start.ToString("dd.MM.yyyy") + "-" + DateTime.Now.ToString("dd.MM.yyyy") + "\n";
                text += "Код,Название,Автор,Начало,Окончание\n";
                foreach (var task in tasks)
                {
                    text += task.Code + "," + task.Name + ","
                        + task.Author.Name + ","
                        + task.Start.ToString("dd.MM.yyyy") + ","
                        + task.End.ToString("dd.MM.yyyy") + "\n";
                }
                File.WriteAllText(path, text, Encoding.UTF8);
            }
        }
    }
}
