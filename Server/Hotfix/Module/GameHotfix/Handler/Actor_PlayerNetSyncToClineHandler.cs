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
            entity.session.Send(packge);

            await ETTask.CompletedTask;
        }
    }
}
