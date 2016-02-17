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
using PlayerDemo.Models;
using PlayerDemo.Presenters;

namespace PlayerDemo.Views
{
    /// <summary>
    /// Interaction logic for AlbumsView.xaml
    /// </summary>
    public partial class AlbumsView : UserControl
    {
        public AlbumsView()
        {
            InitializeComponent();
        }

        private void OpenAlbumView(object sender, RoutedEventArgs args)
        {
            ListBox album_list = (ListBox)args.Source;
            Album album = album_list.SelectedItem as Album;

            ((AlbumsPresenter)DataContext).showAlbum(album);
        }
    }
}
