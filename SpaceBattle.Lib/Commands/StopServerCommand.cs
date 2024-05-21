using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace SpaceBattle.Lib
{
    // Server.StopServer
    public class StopServerCommand : Hwdtech.ICommand
    {
        public void Execute()
        {
            Dictionary<string, string> myThreads = Hwdtech.IoC.Resolve<Dictionary<string, string>>("Thread.GetDictionary");
            foreach (string threadId in myThreads.Keys)
            {
                Hwdtech.IoC.Resolve<Hwdtech.ICommand>("Thread.SoftStopTheThreads", threadId).Execute();
            }
        }
    }
}
