using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PlayerDemo.Models
{
    [Serializable]
    public class Album : Notifier
    {
        private string _album_artist;
        private int _year;
        private string _album_name;
        [NonSerialized]
        private BitmapImage _album_art;
        private TimeSpan _length;
        private ObservableCollection<Song> _album_songs;


        public Album()
        {
            _album_songs = new ObservableCollection<Song>();
        }
        public string AlbumArtist
        {
            get { return _album_artist; }
            set { _album_artist = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public string AlbumName
        {
            get { return _album_name; }
            set { _album_name = value; }
        }

        public BitmapImage AlbumArt
        {
            get { return _album_art; }
            set
            {
                _album_art = value;
                OnPropertyChanged("AlbumArt");
            }
        }

        public TimeSpan Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public ObservableCollection<Song> AlbumSongs
        {
            get
            {
                return _album_songs;
            }
            set
            {
                _album_songs = value;
            }

        }
    }
}
