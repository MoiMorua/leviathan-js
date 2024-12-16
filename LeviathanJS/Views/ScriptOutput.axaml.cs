using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using LeviathanJS.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LeviathanJS.Views;

public partial class ScriptOutput : UserControl
{
    public ScriptOutput()
    {
        InitializeComponent();
        DataContext = App.Current.Services.GetService<ScriptOutputViewModel>();
    }
}