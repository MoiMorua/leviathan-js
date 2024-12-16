using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using LeviathanJS.Models;
using LeviathanJS.Services.Interface;

namespace LeviathanJS.Services;

[ObservableObject]
public partial class ScriptResultService : IScriptResultService
{
   [ObservableProperty] 
   private List<ScriptLog>? _scriptLogs;
}