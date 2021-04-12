using System;
using System.Net;

namespace ETModel
{
    [MessageHandler(AppType.Map)]
    public class G2M_RemoveUnitByMapHandler : AMHandler<G2M_RemoveUnitByMap>
    {
        protected override async ETTask Run(Session session, G2M_RemoveUnitByMap message)
        {
            //需要从map服中一处一个Unit
            UnitComponent unitComponent = Game.Scene.GetComponent<UnitComponent>();

            unitComponent.removeOneUnit(message.Account);

            await ETTask.CompletedTask;
        }

    }
}
