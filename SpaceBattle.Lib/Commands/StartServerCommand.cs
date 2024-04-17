using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace SpaceBattle.Lib
{
    // Server.StartServer
    public class StartServerCommand : ICommand  
    {
        private readonly int numberOfThreads;

        public StartServerCommand(int numberOfThreads) => this.numberOfThreads = numberOfThreads;

        public void Execute()
        {
            for (int i = 0; i < this.numberOfThreads; i++)
            {
                IoC.Resolve<ICommand>("Server.Thread.CreateAndStartThread", i).Execute();
            }
        }
    }
}
