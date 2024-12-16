using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using AvaloniaEdit.Document;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using LeviathanJS.Models;
using LeviathanJS.Services;
using LeviathanJS.Services.Interface;
using LeviathanJS.Views;
using Microsoft.VisualBasic.FileIO;

namespace LeviathanJS.ViewModels;

public partial class ScriptOutputViewModel : ViewModelBase, IRecipient<ScriptLoggedMessage>
{

    private readonly IScriptResultParser _resultParser = new ScriptResultParser();
    
    [ObservableProperty]
    private TextDocument _scriptLogOutput;
    
    public ScriptOutputViewModel()
    {
        WeakReferenceMessenger.Default.Register<ScriptLoggedMessage>(this);
        _scriptLogOutput = new TextDocument();
    }

    public void Receive(ScriptLoggedMessage message)
    {
        Avalonia.Threading.Dispatcher.UIThread.Post(() =>
        {
            var currentResult = _resultParser.ParseScriptResult(message.Value);

            ScriptLogOutput.Text = currentResult;
        });
    }
}