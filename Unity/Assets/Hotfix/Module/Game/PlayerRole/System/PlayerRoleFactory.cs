using System;
using ETModel;
using libx;
using UnityEngine;

namespace ETHotfix
{
    public static class PlayerRoleFactory
    {
        public static ETTask<PlayerRole> Create(int account, Vector3 InitPos)
        {
            ETTaskCompletionSource<PlayerRole> tcs = new ETTaskCompletionSource<PlayerRole>();

            CreatePlayerRole(account, InitPos, tcs).Coroutine();


            return tcs.Task;
        }

        private static async ETVoid CreatePlayerRole(int account, Vector3 InitPos, ETTaskCompletionSource<PlayerRole> tcs)
        {
            try
            {
                //创建一个角色的3D物体
                GameObject resObj = await ETModel.Game.Scene.GetComponent<ResourcesAsyncComponent>().LoadAssetAsync<GameObject>(Assets.LoadAssetAsync("Assets/Bundles/Prefab/Player.prefab", typeof(GameObject)));
                ReferenceCollector rc = resObj.GetComponent<ReferenceCollector>();
                GameObject playerObj = GameObject.Instantiate<GameObject>(rc.Get<GameObject>("Player"));
                playerObj.transform.position = InitPos;

                //创建玩家角色实体
                PlayerRole playerRole = ComponentFactory.Create<PlayerRole, int, GameObject>(account, playerObj, false);
                //添加控制组件
                PlayerControllerComponent playerControllerComponent = playerRole.AddComponent<PlayerControllerComponent>();
                //添加网络同步组件
                PlayerPositionNetComponent playerPositionNetComponent = playerRole.AddComponent<PlayerPositionNetComponent, int>(account);

                tcs.SetResult(playerRole);
            }
            catch (Exception e)
            {
                Log.Error(e);
                tcs.SetResult(null);
            }
        }
    }
}
