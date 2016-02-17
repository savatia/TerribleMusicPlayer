using PlayerDemo.Models;
using PlayerDemo.Presenters;
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

namespace PlayerDemo.Views
{
    /// <summary>
    /// Interaction logic for AlbumView.xaml
    /// </summary>
    public partial class AlbumView : UserControl
    {
        public AlbumView()
        {
            InitializeComponent();
        }

        private void PlaySong(object sender, RoutedEventArgs args)
        {
            var listbox = (ListBox)args.Source;
            var song = (Song) listbox.SelectedItem;
            ((AlbumPresenter)DataContext).Play(song);
        }
    }
}
