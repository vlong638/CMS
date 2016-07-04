using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sui.ComponentModel;
using WpfApplication2.Helper;

namespace WpfApplication2.Model
{
    /// <summary>
    /// 歌曲对象 
    /// ArtistName SongTitle
    /// </summary>
    public class SongwithModelBase : ModelBase
    {
        public SongwithModelBase()
        {
            ClickCount = 0;
            ArtistName = "defaultName";
            SongTitle = "defaultTitle";
            Equipment = new AttEquipment("1,0,0");
        }

        #region Members
        string _artistName;
        string _songTitle;
        int _count;
        AttEquipment _attEquipment;
        #endregion

        #region Properties
        public int ClickCount
        {
            get { return _count; }
            set { SetValue(ref _count, value, () => ClickCount2); SetValue(ref _count, value, () => ClickCount); }
        }

        public string ArtistName
        {
            get { return _artistName; }
            set { SetValue(ref _artistName, value, () => ArtistName); }
        }
        public int ClickCount2
        {
            get { return _count + 10; }
        }
        public string SongTitle
        {
            get { return _songTitle; }
            set { _songTitle = value; }
        }
        public AttEquipment Equipment
        {
            get { return _attEquipment; }
            set { SetValue(ref _attEquipment, value, () => Equipment); }
        }
        #endregion
    }

}
