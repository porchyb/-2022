using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace SpaceBattle.Lib
{
    // Server.StartServer
    public class StartServerCommand : Hwdtech.ICommand
    {
        private readonly int numberOfThreads;

        public StartServerCommand(int numberOfThreads) => this.numberOfThreads = numberOfThreads;

        public void Execute()
        {
            for (int i = 0; i < this.numberOfThreads; i++)
            {
                Hwdtech.IoC.Resolve<Hwdtech.ICommand>("Server.Thread.CreateAndStartThread", i).Execute();
            }
        }
    }
}
