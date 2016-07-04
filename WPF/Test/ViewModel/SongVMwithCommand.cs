using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApplication2.Model;
using System.ComponentModel;
using System.Windows.Input;
using WpfApplication2.Helper;

namespace WpfApplication2.ViewModel
{
    /// <summary>
    /// song的VM模型 
    /// 包含自定义Command
    /// </summary>
    public class SongVMwithCommand:INotifyPropertyChanged
    {
        #region Construction
        public SongVMwithCommand()
        {
            _song = new Song { ArtistName = "Unknown", SongTitle = "Unknown" ,ClickCount=0};
        } 
        #endregion

        #region Members
        Song _song; 
        #endregion

        #region Properties
        public Song song
        {
            set { _song = value; }
            get
            {
                if (_song == null)
                {
                    _song = new Song();
                }
                return _song;
            }
        }
        public string ArtistName
        {
            get { return song.ArtistName; }
            set
            {
                if (song.ArtistName != value)
                {
                    song.ArtistName = value;
                    RaisePropertyChanged("ArtistName");
                }
            }
        } 
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
        #endregion

        #region Command
        private ICommand _updateArtistNameCommand;
        public ICommand UpdateArtistNameCommand
        {
            get
            {
                return _updateArtistNameCommand ?? (_updateArtistNameCommand = new MyRoutedUICommands().UpdateSongArtistNameCommand);
            }
        }
	    #endregion
    }
}
