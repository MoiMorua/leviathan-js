using System;
using System.Collections.Generic;
using AvaloniaEdit.Document;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LeviathanJS.Models;

public partial class Script : ObservableObject
{
    public Script()
    {
        Document = new TextDocument();
    }

    public void SubsribeToChange(EventHandler<DocumentChangeEventArgs> subscriber)
    {
        Document.Changed += subscriber;
    }
    
    [ObservableProperty]
    private TextDocument _document;
}