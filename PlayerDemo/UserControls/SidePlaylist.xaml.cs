using System.Windows.Controls;
using System.Collections.ObjectModel;
using PlayerDemo.Models;
using PlayerDemo.Presenters;
using System;
using System.IO;

namespace PlayerDemo.UserControls
{
    /// <summary>
    /// Interaction logic for SidePlaylist.xaml
    /// </summary>
    public partial class SidePlaylist : UserControl
    {
        SidePlaylistPresenter _presenter;

        public SidePlaylist()
        {
            InitializeComponent();
        }

        public SidePlaylistPresenter Presenter
        {
            get
            {
                _presenter = DataContext as SidePlaylistPresenter;
                return _presenter;
            }

        }

    }
}
