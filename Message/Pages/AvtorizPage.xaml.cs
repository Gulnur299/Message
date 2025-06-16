using Message.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Message.Pages
{
    /// <summary>
    /// Логика взаимодействия для AvtorizPage.xaml
    /// </summary>
    public partial class AvtorizPage : Page
    {
        public static User user {  get; set; }
        public AvtorizPage()
        {
            InitializeComponent();
        }

        private void BtnAuthoriz_Click(object sender, RoutedEventArgs e)
        {
            string login = TbLogin.Text.Trim();
            string password = TbPassword.Password.Trim();
            user = DB_Class.connection.User.Where(x => x.Login == login && x.Password== password).FirstOrDefault();
            if(user==null)
            {
                MessageBox.Show("Что-то не так");
            }
            else
            {
                NavigationService.Navigate(new Pages.KomnataPage(user));
            }
        }
    }
}
