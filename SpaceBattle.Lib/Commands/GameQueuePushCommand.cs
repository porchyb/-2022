using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace SpaceBattle.Lib
{
    public class GameQueuePushCommand : Hwdtech.ICommand
    {
        Queue<Hwdtech.ICommand> commandQueue;
        Hwdtech.ICommand command;
        public GameQueuePushCommand(Queue<Hwdtech.ICommand> commandQueue, Hwdtech.ICommand command)
        {
            this.commandQueue = commandQueue;
            this.command = command;
        }
        public void Execute()
        {
            commandQueue.Enqueue(command);
        }
    }
}