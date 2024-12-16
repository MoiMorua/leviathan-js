using System;
using System.IO;
using System.Reflection;
using System.Xml;
using AvaloniaEdit.Highlighting;
using AvaloniaEdit.Highlighting.Xshd;

namespace LeviathanJS.Services;

public static class SyntaxHighlightingLoader 
{
    public static IHighlightingDefinition LoadHighlighting(string filename)
    {
       var assembly = Assembly.GetExecutingAssembly(); 
       using var stream = assembly.GetManifestResourceStream(filename);
       using var reader = new XmlTextReader(stream);
       return HighlightingLoader.Load(reader, HighlightingManager.Instance);
    }
}