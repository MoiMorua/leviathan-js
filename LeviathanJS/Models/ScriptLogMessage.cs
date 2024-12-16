using System.Collections.Generic;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace LeviathanJS.Models;

public class ScriptLogMessage : ValueChangedMessage<List<ScriptLog>>
{
   public ScriptLogMessage(List<ScriptLog> value) : base(value) { } 
}