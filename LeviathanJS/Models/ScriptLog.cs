namespace LeviathanJS.Models;

public class ScriptLog
{
    public int LineNumber { get; }
    public object EvaluationResult { get; }

    public ScriptLog(int lineNumber, object evaluationResult)
    {
        LineNumber = lineNumber;    
        EvaluationResult = evaluationResult;
    }
}