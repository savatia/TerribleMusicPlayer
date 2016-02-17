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
    /// Interaction logic for AllSongsView.xaml
    /// </summary>
    public partial class AllSongsView : UserControl
    {
        public AllSongsView()
        {
            InitializeComponent();
            
        }

        private void PlaySong(object sender, RoutedEventArgs args)
        {
            try
            {
                PlayerDemo.Models.Song song = ((ListView)(args.Source)).SelectedItem as PlayerDemo.Models.Song;
                ((AllSongsPresenter)DataContext).Play(song);
            }
            catch(Exception e)
            {

            }  
            
        }
    }
}
