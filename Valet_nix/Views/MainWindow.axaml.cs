using Avalonia.Controls;
using System;
using Avalonia.Interactivity;

namespace Valet_nix.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ButtonOnClick(object? sender, RoutedEventArgs e) {
      Console.WriteLine("hello button hit");
      TextBlockName.Text = "CLICKED";
    }
}
