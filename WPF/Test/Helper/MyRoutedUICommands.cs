using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WpfApplication2.ViewModel;

namespace WpfApplication2.Helper
{
    public class MyRoutedUICommands
    {
        //vlong638
        public MyRoutedUICommands()
        {
            InputBinding inputBinding = new InputBinding(UpdateSongArtistNameCommand, new MouseGesture(MouseAction.LeftClick));
            CommandManager.RegisterClassInputBinding(typeof(MyRoutedUICommands), inputBinding);

            //InputGestureCollection inputs = new InputGestureCollection();
            //inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl+R"));
            //UpdateSongArtistNameCommand = new RoutedUICommand("UpdateSongArtistName", "UpdateSongArtistName", typeof(MyRoutedUICommands),inputs);
        }

        private RoutedUICommand _updateSongArtistNameCommand;
        public RoutedUICommand UpdateSongArtistNameCommand
        {
            set { _updateSongArtistNameCommand = value; }
            get
            {
                if (_updateSongArtistNameCommand == null)
                    UpdateSongArtistNameCommand = new RoutedUICommand("UpdateSongArtistName", "UpdateSongArtistName", typeof(MyRoutedUICommands));

                return _updateSongArtistNameCommand;
            }
        }

        private CommandBinding _updateSongArtistNameCommandBinding;
        public CommandBinding UpdateSongArtistNameCommandBinding
        {
            get
            {
                return _updateSongArtistNameCommandBinding =
                    new CommandBinding(UpdateSongArtistNameCommand
                  , new ExecutedRoutedEventHandler(ExecuteUpdateSongArtistName)
                  , new CanExecuteRoutedEventHandler(CanExecuteUpdateSongArtistName));
            }
            set { _updateSongArtistNameCommandBinding = value; }
        }

        private void ExecuteUpdateSongArtistName(object sender, ExecutedRoutedEventArgs arg)
        {
            SongVMwithCommand myControl = sender as SongVMwithCommand;
            if (myControl!=null)
            {
                UpdateArtistName(myControl);
            }
        }

        private void CanExecuteUpdateSongArtistName(object sender, CanExecuteRoutedEventArgs arg)
        {
            SongVMwithCommand myControl = sender as SongVMwithCommand;
            arg.CanExecute = (myControl != null);
        }

        private void UpdateArtistName(SongVMwithCommand model)
        {
            ++model.song.ClickCount;
            model.ArtistName = string.Format("xia{0}", model.song.ClickCount);
        }
    }
}
