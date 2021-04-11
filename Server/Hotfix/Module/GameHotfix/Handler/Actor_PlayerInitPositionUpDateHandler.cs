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

            entity.RotationX = message.RotationX;
            entity.RotationY = message.RotationY;
            entity.RotationZ = message.RotationZ;
            entity.RotationW = message.RotationW;

            entity.VelocityX = message.VelocityX;
            entity.VelocityY = message.VelocityY;
            entity.VelocityZ = message.VelocityZ;

            //Log.Info("单位[" + entity.Id + "]位置更新：" + message.RotationX + " | " + message.RotationY + " | " + message.RotationZ + " | " + message.RotationW);

            await ETTask.CompletedTask;
        }
    }
}
