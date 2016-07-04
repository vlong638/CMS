using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplication2.ViewModel;
using WpfApplication2.Helper;

namespace WpfApplication2.Windows
{
    /// <summary>
    /// Interaction logic for MVVM.xaml
    /// </summary>
    public partial class MVVMWindow : Window
    {
        #region Members
        int _countforSongVM = 0;
        int _countforSong = 0;
        #endregion

        public MVVMWindow()
        {
            InitializeComponent();
        }

        private void IntializeBinding()
        {
            this.CommandBindings.Add(new MyRoutedUICommands().UpdateSongArtistNameCommandBinding);
        }

        #region Function
        private void btnUpdateArtist_Click(object sender, RoutedEventArgs e)
        {
            ++_countforSongVM;
            songVMs.SongVM.ArtistName = string.Format("xia{0}", _countforSongVM);
        }
        private void btnUpdateArtistwithModelBase_Click(object sender, RoutedEventArgs e)
        {
            songVMs.Song.ClickCount++;
            songVMs.Song.ArtistName = string.Format("xia{0}||{1}", songVMs.Song.ClickCount,songVMs.Song.ClickCount2);
        }
        #endregion

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var item = songVMs.Song.Equipment;
        }

    }
}
