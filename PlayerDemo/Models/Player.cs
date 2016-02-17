using System;
using NAudio.Wave;
using System.Windows;
using System.IO;

namespace PlayerDemo.Models
{
    public class Player
    {
        WaveOut playbackDevice;
        public  WaveStream fileStream;



        public void Load(string fileName)
        {

            Stop();
            CloseFile();
            Dispose();

            WaveOut waveOut = new WaveOut { DesiredLatency = 200 };
            
            try
            {
                fileStream = new AudioFileReader(fileName);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Problem opening " + Path.GetFileName(fileName) + ".");
                CloseFile();
            }

            waveOut.Init(fileStream);

            playbackDevice = waveOut;
            playbackDevice.Volume = 0.5f;
        }

        public void Play()
        {
            if (playbackDevice != null && fileStream != null && playbackDevice.PlaybackState != PlaybackState.Playing)
            {
                playbackDevice.Play();

            }
        }

        public void Pause()
        {
            if (playbackDevice != null)
            {
                playbackDevice.Pause();
            }
        }

        public void Stop()
        {
            if (playbackDevice != null)
            {
                playbackDevice.Stop();
            }
            if (fileStream != null)
            {
                fileStream.Position = 0;
            }
        }

        public void Dispose()
        {
            Stop();
            CloseFile();
            if (playbackDevice != null)
            {
                playbackDevice.Dispose();
                playbackDevice = null;

            }
        }

        private void CloseFile()
        {
            if (fileStream != null)
            {
                fileStream.Dispose();
                fileStream = null;
            }
        }

        public WaveOut Device
        {
            get
            {
                return playbackDevice;

            }

        }

        public double Volume
        {
            get
            {
                if(playbackDevice != null)
                {
                    return playbackDevice.Volume;
                }
                else
                {
                    return 0.5;
                }
            }

            set
            {
                if(playbackDevice !=null)
                {
                    playbackDevice.Volume = (float) value;
                }
            }
        }

        public double Length
        {
            get
            {
                if(playbackDevice != null)
                {
                    return fileStream.TotalTime.TotalMilliseconds;
                }
                else
                {
                    return 1;
                }
                
            }

        }


        public double CurrentPosition
        {
            get
            {
                if(playbackDevice != null)
                {
                    return fileStream.CurrentTime.TotalMilliseconds;
                }
                else
                {
                    return 0;
                }
                
            }
            set
            {
                if(playbackDevice != null)
                {
                    fileStream.CurrentTime = fileStream.CurrentTime.Add(TimeSpan.FromMilliseconds(value));
                }
                
            }

        }

    }
}
