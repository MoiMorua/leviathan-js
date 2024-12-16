using System;
using Avalonia.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LeviathanJS.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{

    public MainWindowViewModel()
    {
        var osModifier = OperatingSystem.IsMacOS()
            ? KeyModifiers.Meta 
            : KeyModifiers.Control;
        _incrementGesture = new KeyGesture(Key.Add, osModifier);
        _decrementGesture = new KeyGesture(Key.Subtract, osModifier);
    }
   
    [ObservableProperty] 
    private KeyGesture _incrementGesture; 
    
    [ObservableProperty] 
    private KeyGesture _decrementGesture; 
    
    [RelayCommand]
    public void IncreaseFontSize()
    {
        App.Current.Resources["EditorFontSize"] = (Double)App.Current.Resources["EditorFontSize"] + 1.0;
    }

    [RelayCommand]
    public void DecreaseFontSize()
    {
        var fontSize = (double) App.Current.Resources["EditorFontSize"];
        if (fontSize <= 1.0) return;
        App.Current.Resources["EditorFontSize"] = fontSize - 1.0;
    } 
}