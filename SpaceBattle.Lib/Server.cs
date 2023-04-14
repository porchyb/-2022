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
                var cmd = receiver.Receive();
                try{
                    if(!(receiver.IsEmpty())){
                        cmd.Execute();
                    }
                    else{
                        Stop();
                    }
                }
                catch(Exception e){
                    ExceptionHandler.Handle(e, cmd);
                }
            };
            Thread thread = new Thread(()=>{
                while(!stop){
                    strategy();
                }
            });
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
    }
}
