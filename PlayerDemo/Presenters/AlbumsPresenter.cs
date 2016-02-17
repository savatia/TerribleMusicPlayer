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
    public class AlbumsPresenter :PresenterBase<AlbumsView>
    {
        ObservableCollection<Album> _all_albums;
        ApplicationPresenter _app_presenter;
        public AlbumsPresenter(ApplicationPresenter app_presenter, AlbumsView view, ObservableCollection<Album> all_albums) : base(view)
        {
            _app_presenter = app_presenter;
            _all_albums = all_albums;
            _view.DataContext = this;
        }

        public ObservableCollection<Album> AlbumsList
        {
            get
            {
                return _all_albums;
            }
        }

        public void showAlbum(Album album)
        {
            _app_presenter.displayAlbumView(album);
        }
    }
}
