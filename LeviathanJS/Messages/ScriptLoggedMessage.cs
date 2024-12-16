using System.Collections.Generic;
using CommunityToolkit.Mvvm.Messaging.Messages;
using LeviathanJS.Models;

namespace LeviathanJS.Services;

public class ScriptLoggedMessage : ValueChangedMessage<List<ScriptLog>>
{
   public ScriptLoggedMessage(List<ScriptLog> value) : base(value)
   {
   } 
}