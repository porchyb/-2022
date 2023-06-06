using System;
using System.Collections.Concurrent;

namespace SpaceBattle.Lib
{
    public class MyThread{
        Thread? thread;
        bool stop = false;
        Action strategy;
        IReceiver receiver;
        public ISender sender;
        public MyThread(IReceiver _receiver, ISender _sender){
            receiver = _receiver;
            sender = _sender;
            strategy = () => {
                
                if(!(receiver.IsEmpty())){
                    var cmd = receiver.Receive();
                    try
                    {
                        cmd.Execute();
                    }
                    catch (Exception e)
                    {
                        ExceptionHandler.Handle(e, cmd);
                    }
                }
                else{
                    Stop();
                }
                
            };
            thread = new Thread(()=>{
                while(!stop){
                    strategy();
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
        public void UpdateBehaviour(Action _newBehaviour){
            strategy = _newBehaviour;
        }
        public void Start(){
            stop = false;
        }
        public void Stop(){
            stop = true;
        }
        public bool IsWork(){
            return !stop;
        }
    }
}
