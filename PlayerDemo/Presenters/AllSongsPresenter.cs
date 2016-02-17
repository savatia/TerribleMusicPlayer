using PlayerDemo.Models;
using PlayerDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerDemo.Presenters
{
    class AllSongsPresenter:PresenterBase<AllSongsView>
    {
        private ObservableCollection<Song> _all_songs;
        ApplicationPresenter _app_presenter;
        public AllSongsPresenter(ApplicationPresenter app_presenter, AllSongsView view, ObservableCollection<Song> all_songs) :base(view)
        {
            _all_songs = all_songs;
            _app_presenter = app_presenter;
            _view.DataContext = this;
        }

        public ObservableCollection<Song> AllSongsList
        {
            get { return _all_songs; }
        }

        public void Play(Song song)
        {
            ObservableCollection<Song> playlist = new ObservableCollection<Song>();

            for (int index = AllSongsList.IndexOf(song); index < AllSongsList.Count - index; index++)
            {
                playlist.Add(AllSongsList[index]);
            }
            for (int i = 0; i < AllSongsList.IndexOf(song); i++)
            {
                playlist.Add(AllSongsList[i]);
            }

            _app_presenter.PlaySong(playlist);
        }
    }
}
