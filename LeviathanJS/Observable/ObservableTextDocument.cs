using AvaloniaEdit.Document;
using AvaloniaEdit.Rendering;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LeviathanJS.Observable;

public partial class ObservableTextDocument : ObservableObject 
{
    private readonly TextDocument _document;

    public ObservableTextDocument(TextDocument document)
    {
        _document = document;
    }
    

    [ObservableProperty]
    private string _text;
    
    public int LineCount => _document.LineCount;
    
    partial void OnTextChanging(string value)
    {
        _document.Text = value; // Sincroniza con el documento subyacente
    }

    partial void OnTextChanged(string value)
    {
        OnPropertyChanged(nameof(LineCount)); // Actualiza otras propiedades relacionadas
    }
    
}