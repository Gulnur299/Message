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
    /// Логика взаимодействия для KomnataPage.xaml
    /// </summary>
    public partial class KomnataPage : Page
    {
        public List<ChatRoom> chatRooms { get; set; }
        public User usr { get; set; }
        public KomnataPage(User user)
        {
            InitializeComponent();
            chatRooms= DB_Class.connection.ChatRoom.ToList();
            usr = user;
            lvChat.ItemsSource = chatRooms;
            DataContext = this;
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Otpr_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Pages.SearchPage(null));
        }

        private void tbSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(tbSearch.Text.Trim().Length !=0)
            {
                List<ChatRoom> searchedChats = new List<ChatRoom>();
                searchedChats = DB_Class.connection.ChatRoom.Where(x=> x.Name.Contains(tbSearch.Text.Trim())).ToList();
                lvChat.ItemsSource = searchedChats;
            }
        }

        private void lvChat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvChat.SelectedItems !=null)
            {
                var item = lvChat.SelectedItems as ChatRoom;
                NavigationService.Navigate(new Pages.inChatPage(item));
            }
        }
    }
}
