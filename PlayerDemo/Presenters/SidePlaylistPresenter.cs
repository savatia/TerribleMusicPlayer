using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerDemo.Models;
using System.Collections.ObjectModel;
using PlayerDemo.UserControls;

namespace PlayerDemo.Presenters
{
    public class SidePlaylistPresenter:PresenterBase<SidePlaylist>
    {

        ApplicationPresenter _app_presenter;


        public SidePlaylistPresenter(ApplicationPresenter app_presenter, SidePlaylist view ):base(view)
        {
            _app_presenter = app_presenter;
            View.DataContext = this;
        }

        public ApplicationPresenter AppPresenter
        {
            get
            {
                return _app_presenter;
            }
        }


        private void Play()
        {

        }

        public ObservableCollection<Song> Playlist
        {
            get
            {
                return AppPresenter.Playlist;
            }
        }


    }
}
