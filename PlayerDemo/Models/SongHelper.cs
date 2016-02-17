using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagLib;
using System.IO;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;

namespace PlayerDemo.Models
{
    static class  SongHelper
    {

        public static Song getSongDetails(string path)

        {
            Song song = new Song();
            try {
                

                TagLib.File tagFile = TagLib.File.Create(path);


                if (tagFile.Tag.Performers.Length != 0)
                    song.Artist = tagFile.Tag.Performers[0];



                song.Album = tagFile.Tag.Album;



                song.Path = path;



                song.Length = tagFile.Properties.Duration;


                if (song.Length.Hours < 1)
                    song.FormattedLength = song.Length.ToString(@"mm\:ss");
                else
                    song.FormattedLength = song.Length.ToString(@"hh\:mm\:ss");


                if (tagFile.Tag.Title != null)
                {
                    song.Title = tagFile.Tag.Title;
                }
                else
                {
                    song.Title = Path.GetFileName(tagFile.Name);
                }

                if (tagFile.Tag.Pictures.Length != 0)
                {
                    MemoryStream ms = new MemoryStream(tagFile.Tag.Pictures[0].Data.Data);
                    ms.Seek(0, SeekOrigin.Begin);

                    // ImageSource for System.Windows.Controls.Image
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = ms;
                    bitmap.EndInit();


                    song.AlbumArt = bitmap;
                }
               

                song.Year = (int) tagFile.Tag.Year;

                if (tagFile.Tag.AlbumArtists.Length != 0)
                    song.AlbumArtist = tagFile.Tag.AlbumArtists[0];
            }
            catch(CorruptFileException e)
            {

            }
            
            return song;
        }


        public static BitmapImage GetAlbumArt(string path)
        {
            if(path != null)
            {
                try
                {
                     TagLib.File tagFile = TagLib.File.Create(path);

                        if (tagFile.Tag.Pictures.Length != 0)
                        {
                            MemoryStream ms = new MemoryStream(tagFile.Tag.Pictures[0].Data.Data);
                            ms.Seek(0, SeekOrigin.Begin);

                            // ImageSource for System.Windows.Controls.Image
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.StreamSource = ms;
                            bitmap.EndInit();
                            bitmap.Freeze();

                            return bitmap;
                        }

               
                }
                catch(Exception e)
                {
                   
                }
            }



            return null;
        }

        
    }
}
