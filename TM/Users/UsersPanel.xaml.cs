using System.Linq;
using System.Windows.Controls;

namespace TM.Users
{
    /// <summary>
    /// Логика взаимодействия для UsersPanel.xaml
    /// </summary>
    public partial class UsersPanel : UserControl
    {
        Database db = new Database();

        public UsersPanel()
        {
            InitializeComponent();

            LoadItemsSource();
        }

        public void LoadItemsSource()
        {
            UsersDataGrid.ItemsSource = db.Users.ToArray();
        }

        private void UsersAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            new AddUserDialog(this).Show();
        }
    }
}
