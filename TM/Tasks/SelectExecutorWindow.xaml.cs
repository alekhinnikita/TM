using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TM.Models;

namespace TM.Tasks
{
    /// <summary>
    /// Логика взаимодействия для SelectExecutorWindow.xaml
    /// </summary>
    public partial class SelectExecutorWindow : Window
    {
        Database db = new Database();
        AddTaskDialog dialog;
        public SelectExecutorWindow(AddTaskDialog dialog)
        {
            InitializeComponent();
            this.dialog = dialog;

            UsersListView.ItemsSource = db.Users.ToArray();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsersListView.ItemsSource =
                db.Users.Where((u) => u.Name.Contains(SearchBox.Text) || u.Login.Contains(SearchBox.Text)).ToArray();
        }

        private void SelectBox_Click(object sender, RoutedEventArgs e)
        {
            var user = UsersListView.SelectedItem as User;
            if (user == null)
            {
                MessageBox.Show("Пользователь не выбран");
            }
            else
            {
                dialog.ExecutorBox.ItemsSource = new User[] { user };
                dialog.ExecutorBox.SelectedIndex = 0;
                this.Close();
            }
        }
    }
}
