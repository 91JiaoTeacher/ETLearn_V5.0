using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [MessageHandler]
    public class G2C_OtherPlayerPositionHandler : AMHandler<G2C_OtherPlayerPosition>
    {
        private OtherCubeManagerComponent otherCubeManagerComponent = null;

        //本地时间标记
        private long serverTime;

        protected override async ETTask Run(ETModel.Session session, G2C_OtherPlayerPosition message)
        {
            if (otherCubeManagerComponent == null)
            {
                otherCubeManagerComponent = Game.Scene.GetComponent<OtherCubeManagerComponent>();
            }

            if (message.ServerTime >= serverTime)
            {
                serverTime = message.ServerTime;

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

                bool[] Fire = message.Fire.array;

                for (int i = 0; i < DirAccount.Length; i++)
                {
                    OtherCubeNetSyncComponent otherCubeNetSyncComponent = otherCubeManagerComponent.GetNetSyncComponentByOtherCubeAccount(DirAccount[i]);
                    if (otherCubeNetSyncComponent != null)
                    {
                        otherCubeNetSyncComponent.NetWorkAsyncPosition(new Vector3(PositionX[i], PositionY[i], PositionZ[i]), new Quaternion(RotationX[i], RotationY[i], RotationZ[i], RotationW[i]), new Vector3(VelocityX[i], VelocityY[i], VelocityZ[i]));
                        //Log.Info("同步一次位置：" + DirAccount[i]);

                        otherCubeNetSyncComponent.NetWorkAsyncFire(Fire[i]);
                    }
                }

                PlayerInfoComponent playerInfoComponent = Game.Scene.GetComponent<PlayerInfoComponent>();

                //同步子弹数量
                BulletInfo[] bulletInfos = message.Bullets.array;
                for (int i = 0; i < bulletInfos.Length; i++)
                {
                    BulletInfo bulletInfo = bulletInfos[i];

                    //不是自己的子弹才需要创建同步
                    if (bulletInfo.Account != playerInfoComponent.account)
                    {
                        CubeBullet cubeBullet = CubeBulletFactory.CreateCubeBullet();
                        cubeBullet.SyncBullet(new Vector3(bulletInfo.PositionX, bulletInfo.PositionY, bulletInfo.PositionZ),
                            new Quaternion(bulletInfo.RotationX, bulletInfo.RotationY, bulletInfo.RotationZ, bulletInfo.RotationW),
                            new Vector3(bulletInfo.VelocityX, bulletInfo.VelocityY, bulletInfo.VelocityZ));
                    }
                }

            }
            else
            {
                Debug.LogError("丢包了: " + message.ServerTime + " || " + serverTime);
            }

            await ETTask.CompletedTask;
        }
    }
}
