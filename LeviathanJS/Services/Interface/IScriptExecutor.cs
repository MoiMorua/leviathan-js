using System.Collections.Generic;
using LeviathanJS.Models;

namespace LeviathanJS.Services.Interface;

public interface IScriptExecutor
{
    public List<ScriptLog> Execute(string script);
}