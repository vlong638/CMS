using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WpfApplication2.Model;

namespace WpfApplication2.ViewModel
{
    /// <summary>
    /// SongVM的模型集合
    /// </summary>
    public class SongVMs
    {
        private SongVM _songVM;
        public SongVM SongVM
        {
            get { return _songVM; }
            set { _songVM = value; }
        }

        private SongVMwithCommand _songVMwithCommand;
        public SongVMwithCommand SongVMwithCommand
        {
            get { return _songVMwithCommand; }
            set { _songVMwithCommand = value; }
        }

        private SongVMwithSUICommand _songVMwithSUICommand;
        public SongVMwithSUICommand SongVMwithSUICommand
        {
            get { return _songVMwithSUICommand; }
            set { _songVMwithSUICommand = value; }
        }

        private SongwithModelBase _song;
        public SongwithModelBase Song
        {
            get { return _song; }
            set { _song = value; }
        }



        public SongVMs()
        {
            Song = new SongwithModelBase();
            SongVM = new SongVM();
            SongVMwithCommand = new SongVMwithCommand();
            SongVMwithSUICommand = new SongVMwithSUICommand();
        }
    }
}
