using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PlayerDemo.Models;
using System.Collections.ObjectModel;

namespace PlayerDemo.UserControls
{
    /// <summary>
    /// Interaction logic for SongExplorer.xaml
    /// </summary>
    public partial class SongExplorer : UserControl
    {
        ObservableCollection<String> _song_list;

        public SongExplorer()
        {
            DataContext = this;

            /*
            _song_list = new ObservableCollection<string>(
                FileHandler.getFiles(
                    FileHandler.getDirectoryPath()
                    )
                    );
                    */

            InitializeComponent();
            
        }

        public ObservableCollection<string> SongList
        {
            get
            {
                return _song_list;
            }
        }
    }
}
