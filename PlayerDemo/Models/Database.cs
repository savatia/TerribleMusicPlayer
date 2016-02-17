using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerDemo.Models
{
    [Serializable]
    public class Database:Notifier
    {
        private ObservableCollection<Song> _all_songs;
        private ObservableCollection<Album> _all_albums;

        public Database()
        {

        }

        public ObservableCollection<Song> AllSongs
        {
            get
            {
                return _all_songs;
            }

            set
            {
                OnPropertyChanged("AllSongs");
                _all_songs = value;
            }
        }

        public ObservableCollection<Album> AllAlbums
        {
            get
            {
                return _all_albums;
            }
            set
            {           
                _all_albums = value;
                OnPropertyChanged("AllAlbums");
            }
        }

        public void GetSongs()
        {
            _all_songs = new ObservableCollection<Song>();
            _all_albums = new ObservableCollection<Album>();

            List<string> songs = FileHandler.getFiles("C:\\Users\\Savatia\\Music");

            for (int i = 0; i < songs.Capacity; i++)
            {
                bool execute = true;
                Song song = new Song();

                song = SongHelper.getSongDetails(songs[i]);
                _all_songs.Add(song);

                for (int y = 0; y < _all_albums.Count; y++)
                {
                    if (_all_albums[y].AlbumName == song.Album)
                    {
                        _all_albums[y].Length.Add(song.Length);
                        _all_albums[y].AlbumSongs.Add(song);
                        execute = false;
                        break;
                    }

                }

                if (execute)
                {
                    Album album = new Album();

                    album.AlbumArt = song.AlbumArt;
                    album.AlbumArtist = song.AlbumArtist;
                    album.Year = song.Year;
                    album.AlbumName = song.Album;
                    album.Length = song.Length;
                    album.AlbumSongs.Add(song);
                    _all_albums.Add(album);
                }

                execute = true;

            }
        }

        private void GetAlbums()
        {

        }
    }
}
