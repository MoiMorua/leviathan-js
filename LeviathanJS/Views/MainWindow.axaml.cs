using Avalonia.Controls;
using LeviathanJS.ViewModels;

namespace LeviathanJS.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}