using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [MessageHandler]
    public class G2C_OtherPlayerPositionHandler : AMHandler<G2C_OtherPlayerPosition>
    {
        private OtherCubeManagerComponent otherCubeManagerComponent = null;

        private long serverTime = 0;
        protected override async ETTask Run(ETModel.Session session, G2C_OtherPlayerPosition message)
        {
            if (otherCubeManagerComponent == null)
            {
                otherCubeManagerComponent = Game.Scene.GetComponent<OtherCubeManagerComponent>();
            }

            if (message.ServerTime > serverTime)
            {
                int[] DirAccount = message.DirAccount.array;
                float[] PositionX = message.PositionX.array;
                float[] PositionY = message.PositionY.array;
                float[] PositionZ = message.PositionZ.array;

                float[] RotationX = message.RotationX.array;
                float[] RotationY = message.RotationY.array;
                float[] RotationZ = message.RotationZ.array;
                float[] RotationW = message.RotationW.array;

                float[] VelocityX = message.VelocityX.array;
                float[] VelocityY = message.VelocityY.array;
                float[] VelocityZ = message.VelocityZ.array;

                for (int i = 0; i < DirAccount.Length; i++)
                {
                    OtherCubeNetSyncComponent otherCubeNetSyncComponent = otherCubeManagerComponent.GetNetSyncComponentByOtherCubeAccount(DirAccount[i]);
                    if (otherCubeNetSyncComponent != null)
                    {
                        otherCubeNetSyncComponent.NetWorkAsyncPosition(new Vector3(PositionX[i], PositionY[i], PositionZ[i]), new Quaternion(RotationX[i], RotationY[i], RotationZ[i], RotationW[i]), new Vector3(VelocityX[i], VelocityY[i], VelocityZ[i]));
                        Log.Info("同步一次位置：" + DirAccount[i]);
                    }
                }
            }
            else
            {
                Debug.LogError("丢包了");
            }

            serverTime = message.ServerTime;

            await ETTask.CompletedTask;
        }
    }
}
