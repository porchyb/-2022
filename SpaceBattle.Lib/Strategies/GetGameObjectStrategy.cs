﻿using Hwdtech;
namespace SpaceBattle.Lib
{
    public class GetGameObjectStrategy : IStrategy
    {
        public object UseStrategy(params object[] param)
        {
            string gameItemId = (string)param[1];
            Dictionary<string, object> objects = (Dictionary<string, object>)param[0];
            return objects[gameItemId];
        }
    }
}
