using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WpfApplication2.ViewModel;

namespace WpfApplication2.Helper
{
    //public class MyCommand : ICommand
    //{
    //    Action _executeMethod;
    //    Func<bool> _canExecuteMethod;

    //    bool _isAutomaticRequeryDisabled;
    //    public bool IsAutoMaticRequeryDisabled
    //    {
    //        get { return _isAutomaticRequeryDisabled; }
    //        set { _isAutomaticRequeryDisabled = value; }
    //    }

    //    public MyCommand(Action executeMethod)
    //        : this(executeMethod, null, false)
    //    {
    //    }

    //    public MyCommand(Action executeMethod, Func<bool> canExecuteMethod)
    //        : this(executeMethod, canExecuteMethod, false)
    //    {
    //    }

    //    public MyCommand(Action executeMethod, Func<bool> canExecuteMethod, bool isAutomaticRequeryDisabled)
    //    {
    //        if (executeMethod == null)
    //        {
    //            throw new ArgumentException("executeMethod");
    //        }

    //        _executeMethod = executeMethod;
    //        _canExecuteMethod = canExecuteMethod;
    //        _isAutomaticRequeryDisabled = isAutomaticRequeryDisabled;
    //    }

    //    public void CanExecute(object sender, CanExecuteRoutedEventArgs arg)
    //    {
    //        SongVM myControl = sender as SongVM;
    //        arg.CanExecute = (myControl != null);
    //    }

    //    public void Execute(object sender, ExecutedRoutedEventArgs arg)
    //    {
    //        SongVM myControl = sender as SongVM;
    //        UpdateArtistName(myControl);
    //    }

    //    public event EventHandler CanExecuteChanged;

    //    void UpdateArtistName(SongVM model)
    //    {
    //        ++model.song.ClickCount;
    //        model.ArtistName = string.Format("xia{0}", model.song.ClickCount);
    //    }
    //}
}
