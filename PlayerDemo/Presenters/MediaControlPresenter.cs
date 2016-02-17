using NAudio.Wave;
using PlayerDemo.Models;
using PlayerDemo.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PlayerDemo.Presenters
{
    public class MediaControlPresenter:PresenterBase<MediaControls>
    {
        ApplicationPresenter _app_presenter;
        Song _current_song;
        Player _player;
        public bool _seeking;
        public BitmapImage _playing_icon;
        public BitmapImage _paused_icon;
        
        

        public MediaControlPresenter(ApplicationPresenter app_presenter, MediaControls view,  Player player):base(view)
        {
            View.DataContext = this;
            _app_presenter = app_presenter;
            _player = player;

            Uri uri  = new Uri("pack://application:,,,/PlayerDemo;component/Resources/Images/play.png");
            _paused_icon = new BitmapImage(uri);
            uri = new Uri("pack://application:,,,/PlayerDemo;component/Resources/Images/pause.png");
            _playing_icon = new BitmapImage(uri);

        }

        public BitmapImage PlayIcon
        {
            get
            {
                
                if(_player.Device != null)
                {
                    if (_player.Device.PlaybackState == PlaybackState.Playing)
                        return _playing_icon;
                    else if (_player.Device.PlaybackState == PlaybackState.Paused)
                        return _paused_icon;
                }

                return _paused_icon;
            }

        }


        public void PauseIconEvenHandler(object sender, EventArgs args)
        {
            
        }

        public void ChangeVolume(float value)
        {
            try
            {
                _player.Device.Volume = value;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
           
        }

        public double Volume
        {
            get
            {
                if(_player.Device != null)
                {
                    return (double)_player.Device.Volume;
                }
                else
                {
                    return 0.5;
                }
                
            }
            set
            {
                if (_player.Device != null)
                {
                    _player.Device.Volume = (float)value;
                    OnPropertyChanged("Volume");
                }
                
            }

        }

        public double CurrentTime
        {
            get
            {
                if (_player.fileStream != null)
                    return _player.fileStream.CurrentTime.TotalMilliseconds;
                else
                    return 0;
            }


            set
            {
                if (_player.fileStream != null)
                {
                    _player.fileStream.CurrentTime = TimeSpan.FromMilliseconds(value);
                    OnPropertyChanged("CurrentTime");
                }

            }

        }

        public string CurrentTimeFormatted
        {
            get
            {
                if (_player.fileStream != null)
                {
                    if(_player.fileStream.CurrentTime.Hours < 1)
                        return _player.fileStream.CurrentTime.ToString(@"mm\:ss");
                    else 
                        return _player.fileStream.CurrentTime.ToString(@"hh\:mm\:ss");
                }
                    

                else
                    return "--/--";
            }
        }

        public double TotalTime
        {
            get
            {
                return _player.Length;
            }
        }

        public string TotalTimeFormatted
        {
            get
            {
                if (_player.fileStream != null)
                {
                    if (_player.fileStream.TotalTime.Hours < 1)
                        return _player.fileStream.TotalTime.ToString(@"mm\:ss");
                    else
                        return _player.fileStream.TotalTime.ToString(@"hh\:mm\:ss");

                }
                else
                    return "--/--";
            }
        }

        public BitmapImage AlbumArt
        {
            get
            {
                if (CurrentSong != null)
                    return CurrentSong.AlbumArt;
                else
                    return null;
            }
        }

        public string Artist
        {
            get
            {
                if (CurrentSong != null)
                    return CurrentSong.Artist;
                else
                    return "--";
            }
        } 

        public string Title
        {
            get
            {
                if (CurrentSong != null)
                    return CurrentSong.Title;
                else
                    return "--";
            }
        }

        public Song CurrentSong
        {
            get
            {
                return _current_song;
            }
            set
            {
                _current_song = value;
                OnPropertyChanged("AlbumArt");
                OnPropertyChanged("Artist");
                OnPropertyChanged("Title");
                OnPropertyChanged("CurrentSong");
            }
        }

        public void PauseOrPlay()
        {
            if(_player.Device != null)
            {

                if (_player.Device.PlaybackState == PlaybackState.Paused)
                    _player.Device.Play();
                else if (_player.Device.PlaybackState == PlaybackState.Playing)
                    _player.Device.Pause();
                else if (_player.Device.PlaybackState == PlaybackState.Stopped)
                {
                    ObservableCollection<Song> song = new ObservableCollection<Song>();
                    song.Add(CurrentSong);
                    _app_presenter.PlaySong(song);
                }

            }

            OnPropertyChanged("PlayIcon");

        }

        public void Pause()
        {
            _player.Device.Pause();
        }

        public void Play()
        {
            _player.Device.Play();
        }

        public void Next()
        {
            _app_presenter.PlayNext();
        }

    }
}
