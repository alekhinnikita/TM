using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TM.Models;

namespace TM.Users
{
    /// <summary>
    /// Логика взаимодействия для AddUserDialog.xaml
    /// </summary>
    public partial class AddUserDialog : Window
    {
        Database db = new Database();
        UsersPanel panel;
        public AddUserDialog(UsersPanel panel)
        {
            InitializeComponent();
            this.panel = panel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var user = new User
            {
                Login = LoginBox.Text,
                Password = PasswordBox.Password,
                Name = NameBox.Text,
            };
            if(db.Users.FirstOrDefault((u) => u.Login == user.Login) != null)
            {
                MessageBox.Show("Это логин уже занят");
            }
            else
            {
                try
                {
                    db.Users.Add(user);
                    db.SaveChanges();

                    panel.LoadItemsSource();
                    this.Close();
                } catch
                {
                    MessageBox.Show("Не получилось создать пользователя");
                }
                
            }
        }
    }
}
