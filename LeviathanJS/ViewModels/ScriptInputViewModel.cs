using System;
using System.Collections.Generic;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LeviathanJS.Helpers;
using LeviathanJS.Models;
using LeviathanJS.Services;
using LeviathanJS.Services.Interface;

namespace LeviathanJS.ViewModels;

public partial class ScriptInputViewModel : ViewModelBase
{
    private readonly IScriptExecutor _scriptExecutor = new ScriptEvaluator();
    private readonly DebounceExecutor _debounceExecutor = new DebounceExecutor();
    
    [ObservableProperty]
    private Script _script = new();

    [ObservableProperty]
    private List<ScriptLog> _scriptLog = new();

    public ScriptInputViewModel()
    {
        Script.SubsribeToChange(OnDocumentChanged);
    } 
   
    public void OnDocumentChanged(object? sender, EventArgs e)
    {   
        _debounceExecutor.Execute(() =>
        {
            //TODO set and parse script errors
            var scriptLog = ExecuteScript();
            WeakReferenceMessenger.Default.Send(new ScriptLoggedMessage(scriptLog));
            
        }, TimeSpan.FromMilliseconds(500));
    }

    private List<ScriptLog>? ExecuteScript()
    {
        try
        {
            return _scriptExecutor.Execute(Script.Document.Text);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    [RelayCommand]
    public void IncrementFontSize()
    {
        App.Current.Resources["EditorFontSize"] = (double) App.Current.Resources["EditorFontSize"] + 1.0;
    }
    
}