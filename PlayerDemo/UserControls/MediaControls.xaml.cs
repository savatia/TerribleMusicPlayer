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

namespace PlayerDemo.UserControls
{
    /// <summary>
    /// Interaction logic for MediaControls.xaml
    /// </summary>
    public partial class MediaControls : UserControl
    {
        public MediaControls()
        {
            InitializeComponent();
        }


        private void Volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = (Slider)e.Source;
            ((MediaControlPresenter)DataContext).ChangeVolume((float)slider.Value);
        }

        private void Volume_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Seek_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void Seek_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            ((MediaControlPresenter)DataContext).PauseOrPlay();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            ((MediaControlPresenter)DataContext).Next();
        }
    }
}
