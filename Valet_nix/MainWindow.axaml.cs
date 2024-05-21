using Avalonia.Controls;
using Avalonia;
using Avalonia.Markup.Xaml;

namespace Valet_nix;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void InitializeComponent() {
        AvaloniaXamlLoader.Load(this);
        //Set width & height of the window 
        Width = 462;
        Height = 800;
    }
}
