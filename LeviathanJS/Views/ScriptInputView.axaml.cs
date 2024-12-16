using System;
using System.Collections.Generic;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using LeviathanJS.Helpers;
using LeviathanJS.Models;
using LeviathanJS.Services;
using LeviathanJS.Services.Interface;
using LeviathanJS.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace LeviathanJS.Views;

public partial class ScriptInputView : UserControl
{
    public ScriptInputView()
    {
        InitializeComponent();
        DataContext = App.Current.Services.GetService<ScriptInputViewModel>();
    }
}