using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Valet_nix.ViewModels;

public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string _textBlockName = "testing getter";
    public string TextBlockName {
      get => _textBlockName;
      set {
        _textBlockName = value;
        OnPropertyChanged();
      }
    }

    public void ButtonOnClick() {
      Console.WriteLine("hello button hit");
      TextBlockName = "Clicked";
    }
}
