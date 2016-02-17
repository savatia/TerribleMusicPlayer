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
    public class AlbumPresenter :PresenterBase<AlbumView>
    {
        ApplicationPresenter _app_presenter;
        Album _album;
        public AlbumPresenter(ApplicationPresenter app_presenter, AlbumView view, Album album):base(view)
        {
            View.DataContext = this;
            _album = album;
            _app_presenter = app_presenter;
        }

        public ObservableCollection<Song> AlbumSongs
        {
            get
            {
                return _album.AlbumSongs;
            }
        }

        internal void Play(Song song)
        {
            if (song == null) return;

            ObservableCollection<Song> playlist = new ObservableCollection<Song>();

            for (int index = AlbumSongs.IndexOf(song); index < _album.AlbumSongs.Count; index++)
            {
                playlist.Add(AlbumSongs[index]);
            }
            for (int i = 0; i < AlbumSongs.IndexOf(song); i++)
            {
                playlist.Add(AlbumSongs[i]);
            }

            _app_presenter.PlaySong(playlist);
        }
    }
}
