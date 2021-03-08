using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [MessageHandler]
    public class G2C_OtherPlayerPositionHandler : AMHandler<G2C_OtherPlayerPosition>
    {
        private OtherPlayerManagerComponent otherPlayerManagerComponent = null;
        protected override async ETTask Run(ETModel.Session session, G2C_OtherPlayerPosition message)
        {
            if (otherPlayerManagerComponent == null)
            {
                otherPlayerManagerComponent = Game.Scene.GetComponent<OtherPlayerManagerComponent>();
            }
            int[] DirAccount = message.DirAccount.array;
            float[] PositionX = message.PositionX.array;
            float[] PositionY = message.PositionY.array;
            float[] PositionZ = message.PositionZ.array;

            for (int i = 0; i < DirAccount.Length; i++)
            {
                OtherPlayerNetSyncComponent otherPlayerNetSyncComponent = otherPlayerManagerComponent.GetNetSyncComponentByOtherPlayerAccount(DirAccount[i]);
                if (otherPlayerNetSyncComponent != null)
                {
                    otherPlayerNetSyncComponent.NetWorkAsyncPosition(new Vector3(PositionX[i], PositionY[i], PositionZ[i]));
                    //Log.Info("同步一次位置：" + DirAccount[i]);
                }
            }

            await ETTask.CompletedTask;
        }
    }
}
