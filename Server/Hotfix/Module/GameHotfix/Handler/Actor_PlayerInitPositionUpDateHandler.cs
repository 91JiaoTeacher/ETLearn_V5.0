using ETModel;
using System;

namespace ETHotfix
{
    [ActorMessageHandler(AppType.Map)]
    public class Actor_PlayerInitPositionUpDateHandler : AMActorHandler<Unit, Actor_PlayerInitPositionUpDate>
    {
        protected override async ETTask Run(Unit entity, Actor_PlayerInitPositionUpDate message)
        {
            entity.InitPositionX = message.PositionX;
            entity.InitPositionY = message.PositionY;
            entity.InitPositionZ = message.PositionZ;

            //Log.Info("单位[" + entity.Id + "]位置更新：" + message.PositionX + " | " + message.PositionY + " | " + message.PositionZ);

            await ETTask.CompletedTask;
        }
    }
}
