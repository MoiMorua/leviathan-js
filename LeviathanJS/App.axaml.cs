using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using AvaloniaEdit.Highlighting;
using LeviathanJS.Services;
using LeviathanJS.ViewModels;
using LeviathanJS.Views;
using Microsoft.Extensions.DependencyInjection;

namespace LeviathanJS;

public partial class App : Application
{
    public App()
    {
        Services = ConfigureServices(); 
        Initialize();
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        LoadHighlighting();
    }

    public IServiceProvider Services { get; }
    
    public new static App Current => (App)Application.Current;
    
    public override void OnFrameworkInitializationCompleted()
    {
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainWindowViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();
        services.AddTransient<MainViewModel>();
        services.AddTransient<ScriptInputViewModel>();
        services.AddTransient<ScriptOutputViewModel>();
        return services.BuildServiceProvider();
    }

    private void LoadHighlighting()
    {
        HighlightingManager.Instance.RegisterHighlighting(
            "JavaScript",
            new string[] { ".js" },
            SyntaxHighlightingLoader.LoadHighlighting("LeviathanJS.Resources.JavascriptHighlight.xshd")
        );
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}