using System;
using ETModel;
using libx;
using UnityEngine;

namespace ETHotfix
{
    public static class OtherPlayerRoleFactory
    {
        public static ETTask<OtherPlayer> Create(int account, Vector3 InitPosition)
        {
            ETTaskCompletionSource<OtherPlayer> tcs = new ETTaskCompletionSource<OtherPlayer>();

            CreateOtherPlayer(account, InitPosition, tcs).Coroutine();


            return tcs.Task;
        }

        private static async ETVoid CreateOtherPlayer(int account, Vector3 InitPosition, ETTaskCompletionSource<OtherPlayer> tcs)
        {
            try
            {
                GameObject resObj = await ETModel.Game.Scene.GetComponent<ResourcesAsyncComponent>().LoadAssetAsync<GameObject>(Assets.LoadAssetAsync("Assets/Bundles/Prefab/OtherPlayer.prefab", typeof(GameObject)));
                ReferenceCollector rc = resObj.GetComponent<ReferenceCollector>();
                GameObject otherPlayerObj = GameObject.Instantiate<GameObject>(rc.Get<GameObject>("OtherPlayer"));

                OtherPlayer otherPlayer = ComponentFactory.Create<OtherPlayer, int, GameObject>(account, otherPlayerObj, false);
                //添加网络同步组件
                OtherPlayerNetSyncComponent otherPlayerNetSyncComponent = otherPlayer.AddComponent<OtherPlayerNetSyncComponent, int, Vector3>(account, InitPosition);

                tcs.SetResult(otherPlayer);
            }
            catch (Exception e)
            {
                Log.Error(e);
                tcs.SetResult(null);
            }
        }
    }
}