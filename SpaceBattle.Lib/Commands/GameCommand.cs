using System.Collections.Generic;
using System.Diagnostics;

namespace SpaceBattle.Lib.Commands
{
    public class GameCommand : ICommand
    {
        int gameId;
        public GameCommand(int _gameId)
        {
            gameId = _gameId;
        }
        public void Execute()
        {
            var scopes = IoC.Resolve<Dictionary<int, Dictionary<string, IStrategy>>>("IoC.GameScopes");
            var gameScope = scopes[gameId];
            IoC.Resolve<ICommand>("IoC.SetScopeCommand", gameScope).Execute();

            int timeOnGame = IoC.Resolve<int>("Game.TimeQuantum");
            var commandQueue = IoC.Resolve<Queue<ICommand>>("Game.Queue");

            var sw = new Stopwatch();
            sw.Start();

            while (sw.Elapsed.Milliseconds < timeOnGame)
            {
                ICommand? cmd;
                commandQueue.TryDequeue(out cmd);
                if (cmd != null)
                {
                    try
                    {
                        cmd.Execute();
                    }
                    catch(Exception e)
                    {
                        ExceptionHandler.Handle(e, cmd);
                    }
                }
                else
                {
                    break;
                }
            }
            sw.Stop();
            IoC.Resolve<ICommand>("IoC.DeleteScopeCommand", new List<string>(gameScope.Keys)).Execute();
        }
    }
}
