using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [MessageHandler]
    public class G2C_OtherPlayerEnterMapHandler : AMHandler<G2C_OtherPlayerEnterMap>
    {
        protected override async ETTask Run(ETModel.Session session, G2C_OtherPlayerEnterMap message)
        {
            Log.Info("其它玩家进入Map: " + message.Account);
            OtherPlayerNetSyncComponent NetSyncComponent = Game.Scene.GetComponent<OtherPlayerManagerComponent>()
                .GetNetSyncComponentByOtherPlayerAccount(message.Account);

            if (NetSyncComponent != null)
            {
                NetSyncComponent.NetWorkAsyncPosition(
                    new Vector3(message.PositionX, message.PositionY, message.PositionZ));
            }
            else
            {
                OtherPlayer otherPlayer = await OtherPlayerRoleFactory.Create(message.Account,
                    new Vector3(message.PositionX, message.PositionY, message.PositionZ));
            }

            await ETTask.CompletedTask;
        }
    }
}