using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [MessageHandler]
    public class G2C_OtherPlayerPositionHandler : AMHandler<G2C_OtherPlayerPosition>
    {
        private OtherCubeManagerComponent otherCubeManagerComponent = null;
        protected override async ETTask Run(ETModel.Session session, G2C_OtherPlayerPosition message)
        {
            if (otherCubeManagerComponent == null)
            {
                otherCubeManagerComponent = Game.Scene.GetComponent<OtherCubeManagerComponent>();
            }
            int[] DirAccount = message.DirAccount.array;
            float[] PositionX = message.PositionX.array;
            float[] PositionY = message.PositionY.array;
            float[] PositionZ = message.PositionZ.array;

            for (int i = 0; i < DirAccount.Length; i++)
            {
                OtherCubeNetSyncComponent otherCubeNetSyncComponent = otherCubeManagerComponent.GetNetSyncComponentByOtherCubeAccount(DirAccount[i]);
                if (otherCubeNetSyncComponent != null)
                {
                    otherCubeNetSyncComponent.NetWorkAsyncPosition(new Vector3(PositionX[i], PositionY[i], PositionZ[i]));
                    //Log.Info("同步一次位置：" + DirAccount[i]);
                }
            }

            await ETTask.CompletedTask;
        }
    }
}
