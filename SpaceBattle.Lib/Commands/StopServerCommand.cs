using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace SpaceBattle.Lib
{
    // Server.StopServer
    public class StopServerCommand : ICommand
    {
        public void Execute()
        {
            Dictionary<string, string> myThreads = IoC.Resolve<Dictionary<string, string>>("Thread.GetDictionary");
            foreach (string threadId in myThreads.Keys)
            {
                IoC.Resolve<ICommand>("Thread.SoftStopTheThreads", threadId).Execute();
            }
        }
    }
}
