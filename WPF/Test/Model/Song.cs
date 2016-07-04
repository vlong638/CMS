using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sui.ComponentModel;

namespace WpfApplication2.Model
{
    /// <summary>
    /// 歌曲对象 
    /// ArtistName SongTitle
    /// </summary>
    public class Song
    {
        #region Members
        string _artistName;
        string _songTitle;
        int _count;
        #endregion

        #region Properties
        public int ClickCount
        {
            get { return _count; }
            set { _count = value; }
        }

        public string ArtistName
        {
            get { return _artistName; }
            set { _artistName = value; }
        }

        public string SongTitle
        {
            get { return _songTitle; }
            set { _songTitle = value; }
        }
        #endregion
    }

}
