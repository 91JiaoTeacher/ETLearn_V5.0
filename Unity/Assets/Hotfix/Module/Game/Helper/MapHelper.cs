using System;
using ETModel;
using libx;
using UnityEngine;

namespace ETHotfix
{
    public static class MapHelper
    {
        public static async ETVoid EnterMapAsync()
        {
            try
            {
                Session hotfixSession = Game.Scene.GetComponent<SessionComponent>().Session;
                ResourcesAsyncComponent resourcesAsync = ETModel.Game.Scene.GetComponent<ResourcesAsyncComponent>();
                PlayerInfoComponent playerInfo = Game.Scene.GetComponent<PlayerInfoComponent>();

                if (hotfixSession == null)
                {
                    Log.Error("获取hotfixSession失败");
                }

                G2C_RequestEnterMap g2CRequestEnterMap = (G2C_RequestEnterMap)await hotfixSession.Call(new C2G_RequestEnterMap() { Account = playerInfo.account });

                // 加载场景资源
                SceneAssetRequest sceneAssetAsyncRequest = Assets.LoadSceneAsync("Arena.unity3d");
                await resourcesAsync.LoadSceneAsync(sceneAssetAsyncRequest);

                // 切换到map场景
                using (SceneChangeComponent sceneChangeComponent = ETModel.Game.Scene.AddComponent<SceneChangeComponent>())
                {
                    await sceneChangeComponent.ChangeSceneAsync(SceneType.Arena);
                }


                PlayerCube playerCube = await PlayerCubeFactory.Create(new Vector3(g2CRequestEnterMap.PositionX, g2CRequestEnterMap.PositionY, g2CRequestEnterMap.PositionZ));

                //PlayerRole playerRole = await PlayerRoleFactory.Create(playerInfo.account, new Vector3(g2CRequestEnterMap.PositionX, g2CRequestEnterMap.PositionY, g2CRequestEnterMap.PositionZ));

                Game.EventSystem.Run(EventIdType.EnterMapFinish);

                //hotfixSession.Send(new C2G_GetOtherPlayer() {Account = playerInfo.account});

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}