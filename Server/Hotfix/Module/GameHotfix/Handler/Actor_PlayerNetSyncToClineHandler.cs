using System;
using ETModel;
using Google.Protobuf.Collections;

namespace ETHotfix
{
    [ActorMessageHandler(AppType.Gate)]
    public class Actor_PlayerNetSyncToClineHandler : AMActorHandler<Player, Actor_PlayerNetSyncToCline>
    {
        protected override async ETTask Run(Player entity, Actor_PlayerNetSyncToCline message)
        {

            G2C_OtherPlayerPosition packge = new G2C_OtherPlayerPosition();
            packge.DirAccount.Add(message.DirAccount);
            packge.PositionX.Add(message.PositionX);
            packge.PositionY.Add(message.PositionY);
            packge.PositionZ.Add(message.PositionZ);

            packge.RotationX.Add(message.RotationX);
            packge.RotationY.Add(message.RotationY);
            packge.RotationZ.Add(message.RotationZ);
            packge.RotationW.Add(message.RotationW);

            packge.VelocityX.Add(message.VelocityX);
            packge.VelocityY.Add(message.VelocityY);
            packge.VelocityZ.Add(message.VelocityZ);

            //Log.Info("时间： " + TimeHelper.ClientNow());
            packge.ServerTime = TimeHelper.ClientNow();

            packge.Fire.Add(message.Fire);

            packge.Bullets.Add(message.Bullets);

            //Log.Error("场景子弹数量: " + message.Bullets.Count);

            entity.session.Send(packge);

            await ETTask.CompletedTask;
        }
    }
}
