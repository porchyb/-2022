using System;
using System.Collections.Concurrent;

namespace SpaceBattle.Lib
{
    public class MyThread{
        Thread? thread;
        bool stop = false;
        Action strategy;
        public IReceiver queue;
        public MyThread(IReceiver _receiver){
            queue = _receiver;
            strategy = () => {
                var cmd = queue.Receive();
                try{
                    if(queue.IsEmpty()){
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
        internal void UpdateBehaviour(Action _newBehaviour){
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
