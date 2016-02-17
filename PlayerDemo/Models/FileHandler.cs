using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace PlayerDemo.Models
{
    public static class FileHandler
    {
        public static List<string> getFiles(string directory)
        {
            List<String> songs = new List<String>();
            
            songs =  Directory.GetFiles(directory, "*.mp3", SearchOption.AllDirectories).Cast<String>().ToList<String>();

            return songs;
        }

        public static string getDirectoryPath()
        {
            string directory;

            OpenFileDialog dialog = new OpenFileDialog();




            dialog.InitialDirectory = "C:\\Users\\Savatia\\Music";


            dialog.Title = "Please choose a folder.";
            dialog.CheckFileExists = false;
            dialog.FileName = "[Get Folder]";
            dialog.Filter = "Folders|no.files";

            if ((bool)dialog.ShowDialog())
            {
                directory = Path.GetDirectoryName(dialog.FileName);
                if (!string.IsNullOrEmpty(directory)) return directory;
            }

            return string.Empty;
        }
    }
}
