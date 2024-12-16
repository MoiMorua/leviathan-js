using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeviathanJS.Models;
using LeviathanJS.Services.Interface;

namespace LeviathanJS.Services;

public class ScriptResultParser : IScriptResultParser
{
    public string ParseScriptResult(List<ScriptLog> scriptResult)
    {
        var outputString = new StringBuilder(String.Empty); 
        var lastScriptLogLineNumber = 0;
        foreach (var log in scriptResult)
        {
            var currentLog = Enumerable.Range(lastScriptLogLineNumber + 1, log.LineNumber - lastScriptLogLineNumber)
                .Select(lineNumber =>
                    lineNumber == log.LineNumber
                        ? $"{log.EvaluationResult.ToString()}{Environment.NewLine}"
                        : Environment.NewLine)
                .Aggregate((prev, current) => prev + current);
            
            outputString.Append(currentLog);
            
            lastScriptLogLineNumber = log.LineNumber;
        }
            
        return outputString.ToString();
    }
    
}