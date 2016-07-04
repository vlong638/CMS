using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApplication2.Model;
using System.ComponentModel;
using System.Windows.Input;
using Sui.ComponentModel.Command;
using System.Windows;
using WpfApplication2.Helper;
using Sui.ComponentModel;

namespace WpfApplication2.ViewModel
{
    /// <summary>
    /// song的VM模型 
    /// 实现INotifyPropertyChanged接口
    /// 该接口可实现监听Property的功能
    /// </summary>
    public class SongVM:ModelBase,INotifyPropertyChanged
    {

        #region Construction
        public SongVM()
        {
            song = new Song { ArtistName = "Unknown", SongTitle = "Unknown"};
            Equipment = new AttEquipment("1,1,0");
        } 
        #endregion

        #region Members
        Song _song;
        private AttEquipment _attEquipment;
        //public AttEquipment Equipment
        //{
        //    get { return _attEquipment; }
        //    set
        //    {
        //        _attEquipment = value;
        //        RaisePropertyChanged("Equipment");
        //    }
        //}
        public AttEquipment Equipment
        {
            get { return _attEquipment; }
            set { SetValue(ref _attEquipment, value, () => Equipment); }
        }
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
        //受INPC监控的属性
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
        /// <summary>
        /// 实现INPC接口 监控属性改变
        /// </summary>
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
    }
}
