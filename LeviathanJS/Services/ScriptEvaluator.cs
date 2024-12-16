using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Esprima;
using Esprima.Ast;
using Jint;
using LeviathanJS.Models;
using LeviathanJS.Services.Interface;
using MemberExpression = Esprima.Ast.MemberExpression;

namespace LeviathanJS.Services;

public class ScriptEvaluator : IScriptExecutor
{
    private readonly JavaScriptParser _parser = new();
    
    public ScriptEvaluator()
    {
    }
    
    
    private string WrapScript(string script) => string.Format("JSON.stringify({0}, null, 2)", script);
    
    public List<ScriptLog> Execute(string script)
    {
        var result = new List<ScriptLog>();
        
        try
        {
            using(var engine = new Engine())
            {
                var program = _parser.ParseScript(script);
                foreach (var statement in program.Body)
                {
                    if (statement is ExpressionStatement expressionStatement)
                    {
                        if (expressionStatement.Expression is CallExpression { Callee: MemberExpression { Object: Identifier { Name: "console" } } } callExpression)
                        {
                            foreach (var argument in callExpression.Arguments)
                            {
                                var argumentEvaluationResult = engine.Evaluate(WrapScript(argument.ToString())).ToObject(); 
                                var newLog = new ScriptLog(expressionStatement.Location.Start.Line, argumentEvaluationResult);
                                result.Add(newLog); 
                            }
                        }
                        else
                        {
                            var expressionEvaluation = engine.Evaluate(WrapScript(expressionStatement.Expression.ToString())).ToObject();
                            var newLog = new ScriptLog( expressionStatement.Location.Start.Line, expressionEvaluation);
                            result.Add(newLog); 
                        }
                    }
                    else
                    {
                        engine.Execute(statement.ToString());
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return result;
    }
}