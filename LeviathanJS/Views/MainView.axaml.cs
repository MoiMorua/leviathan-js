using Avalonia.Controls;
using LeviathanJS.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LeviathanJS.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = App.Current.Services.GetService<MainViewModel>();
    }
}