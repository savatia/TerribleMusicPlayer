using NAudio.Wave;
using PlayerDemo.Models;
using PlayerDemo.Presenters;
using PlayerDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace PlayerDemo.Presenters
{
    public class ApplicationPresenter: PresenterBase<MainWindow>
    {
        StateManager stateManager;

        /* views */
        AllSongsView _all_songs_view;
        AlbumsView _albums_view;

        MainWindow shell;

        /* player*/
        Player player;

        /* playlist */
        ObservableCollection<Song> _playlist;

        MediaControlPresenter _mediaControlPresenter;
        SidePlaylistPresenter _sidePlaylistPresenter;


        public ApplicationPresenter(MainWindow view):base(view)
        {
            shell = view;
            view.DataContext = this;

            CreatePlayer();

            CreateMediaControls();

            CreateStateManager();

            CreateSidePlaylist();

            GetDatabase();

            _all_songs_view = new AllSongsView();

            AllSongsPresenter all_songs_presenter = new AllSongsPresenter(this, _all_songs_view, stateManager.SongDB.AllSongs);

            _albums_view = new AlbumsView();
            
            AlbumsPresenter _all_albums_presenter = new AlbumsPresenter(this, _albums_view, stateManager.SongDB.AllAlbums);

            GC.Collect();
            GC.WaitForPendingFinalizers();

            view.setSongExplorerView<AlbumsView>(_albums_view);
        }

        public void CreatePlayer()
        {
            player = new Player();
        }

        public void CreateSidePlaylist()
        {
            _sidePlaylistPresenter = new SidePlaylistPresenter(this, View.SidePlaylist);

        }

        private void CreateMediaControls()
        {
            _mediaControlPresenter = new MediaControlPresenter(this, View.MediaControls, player);
        }

        private void CreateStateManager()
        {
            stateManager = new StateManager();
        }

        private void GetDatabase()
        {

            if (stateManager.SongDB.AllAlbums == null)
            {
                stateManager.SongDB.GetSongs();
                stateManager.SaveDatabase();
            }
            else
            {
                
                Thread t = new Thread(
                    () =>
                    {
                        double sleep = 500;
                        foreach (Album album in stateManager.SongDB.AllAlbums)
                        {
                            Thread.Sleep((int)sleep);
                            album.AlbumArt = SongHelper.GetAlbumArt(album.AlbumSongs[0].Path);
                            sleep *= 0.9;                       
                        }

                        foreach (Song song in stateManager.SongDB.AllSongs)
                        {
                            song.AlbumArt = SongHelper.GetAlbumArt(song.Path);
                        }

                        stateManager.SongDB.GetSongs();
                        stateManager.SaveDatabase();
                    }
                );
                t.IsBackground = true;
                t.Start();

            }
        }


        
        public ObservableCollection<Song> Playlist
        {
            get
            {
                return _playlist;
            }

            set
            {
                _playlist = value;
                OnPropertyChanged("Playlist");
            }
        }

        public void displayAlbumsView()
        {
            shell.setSongExplorerView<AlbumsView>(_albums_view);
        }

        public void displayAllSongsView()
        {
            shell.setSongExplorerView<AllSongsView>(_all_songs_view);
        }

        public void displayArtistsView()
        {

        }

        public void displayAlbumView(Album album)
        {
            AlbumPresenter presenter = new AlbumPresenter(this, new AlbumView(), album);
            shell.setSongExplorerView<AlbumView>(presenter.View);
        }

        public ObservableCollection<Song> AllSongs
        {
            get { return stateManager.SongDB.AllSongs; }
        }

        public void PlaySong(ObservableCollection<Song> playlist)
        {
            Playlist = playlist;
            PlayCurrentSong(playlist.First());
  

        }

        private void PlaybackStoppedEventHandler(object sender, StoppedEventArgs e)
        {
            //MessageBox.Show("Was This normal?", "Playback Stopped!", MessageBoxButton.YesNo);

            if( 
                player.Device.PlaybackState == PlaybackState.Stopped && 
                Playlist.Count != (Playlist.IndexOf(_mediaControlPresenter.CurrentSong) + 1)
                )
            {
                _mediaControlPresenter.CurrentSong = Playlist[Playlist.IndexOf(_mediaControlPresenter.CurrentSong) + 1];
                PlayCurrentSong(_mediaControlPresenter.CurrentSong);
            }
           
        }

        public void OnExit()
        {
            player.Dispose();
        }


        private void PlayCurrentSong(Song song)
        {
            player.Load(song.Path);
            player.Play();

            player.Device.PlaybackStopped += PlaybackStoppedEventHandler;
            _mediaControlPresenter.View.Seek.Maximum = player.Length;
            _mediaControlPresenter.View.Seek.Value = player.CurrentPosition;

            DispatcherTimer clock = new DispatcherTimer();
            clock.Interval = TimeSpan.FromMilliseconds(100);
            clock.Tick += new EventHandler(clock_Tick);
            clock.Start();
            _mediaControlPresenter.CurrentSong = song;
            _mediaControlPresenter.OnPropertyChanged("Volume");
            _mediaControlPresenter.OnPropertyChanged("TotalTimeFormatted");
            _mediaControlPresenter.OnPropertyChanged("PlayIcon");
            OnPropertyChanged("Playlist");

        }

        void clock_Tick(object sender, EventArgs e)
        {
            _mediaControlPresenter.OnPropertyChanged("CurrentTime");
            _mediaControlPresenter.OnPropertyChanged("CurrentTimeFormatted");
            _mediaControlPresenter.OnPropertyChanged("TotalTime");
            OnPropertyChanged("Playlist");
            _mediaControlPresenter.OnPropertyChanged("PlayIcon");
        }

        public void PauseSong()
        {
            player.Pause();
        }

        public void PlayNext()
        {
            player.Device.Stop();
        }

        public Song CurrentSong
        {
            get
            {
                return _mediaControlPresenter.CurrentSong;
            }
        }
    }
}
