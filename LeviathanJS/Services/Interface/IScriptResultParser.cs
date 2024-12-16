using System.Collections.Generic;
using LeviathanJS.Models;

namespace LeviathanJS.Services.Interface;

public interface IScriptResultParser
{
    public string ParseScriptResult(List<ScriptLog> scriptResult);
}