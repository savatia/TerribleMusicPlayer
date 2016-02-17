using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PlayerDemo.Models
{
    [Serializable]
    public class Song
    {
        private string _path;
        private string _title;
        private string _artist;
        private string _album_artist;
        private int _year;
        [NonSerialized]
        private BitmapImage _album_art;
        private string _formatted_length;
        private TimeSpan _length;
        private string _album;
        
        public Song()
        {
            
        }

        public string Path
        {
            set { _path = value; }
            get { return _path; }
        }

        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }

        public string Artist
        {
            set { _artist = value; }
            get { return _artist; }
        }


        public BitmapImage AlbumArt
        {
            set { _album_art = value; }
            get { return _album_art; }
        }

        public TimeSpan Length
        {
            set { _length = value; }
            get { return _length; }
        }

        public string Album
        {
            get { return _album; }
            set { _album = value; }
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

        public string FormattedLength
        {
            get { return _formatted_length; }
            set { _formatted_length = value; }
        }
    }
}
