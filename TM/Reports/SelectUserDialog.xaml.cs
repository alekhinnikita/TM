using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TM.Models;

namespace TM.Reports
{
    /// <summary>
    /// Логика взаимодействия для SelectUserDialog.xaml
    /// </summary>
    public partial class SelectUserDialog : Window
    {
        Database db = new Database();
        Action<User> action;
        public SelectUserDialog(Action<User> action)
        {
            InitializeComponent();
            this.action = action;

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
                action(user);
                this.Close();
            }
        }
    }
}
