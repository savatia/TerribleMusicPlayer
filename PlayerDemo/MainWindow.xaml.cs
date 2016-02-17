using PlayerDemo.Presenters;
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

namespace PlayerDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationPresenter presenter;
        public MainWindow()
        {          
            InitializeComponent();
            presenter = new ApplicationPresenter(this);
        }

        public void setSongExplorerView<T>(T view)
        {

            SongExplorerBody.Content = view;
        }

        private void displayAlbumsView(object sender, RoutedEventArgs e)
        {
            ((ApplicationPresenter)DataContext).displayAlbumsView();
        }

        private void displayAllSongsView(object sender, RoutedEventArgs e)
        {
            ((ApplicationPresenter)DataContext).displayAllSongsView();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            presenter.OnExit();
        }
    }
}
