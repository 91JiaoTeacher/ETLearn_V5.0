using System;
using ETModel;
using libx;
using UnityEngine;

namespace ETHotfix
{
    public static class OtherCubeFactory
    {
        public static ETTask<OtherCube> Create(int account, Vector3 InitPosition)
        {
            ETTaskCompletionSource<OtherCube> tcs = new ETTaskCompletionSource<OtherCube>();

            CreateOtherCube(account, InitPosition, tcs).Coroutine();


            return tcs.Task;
        }

        private static async ETVoid CreateOtherCube(int account, Vector3 InitPosition, ETTaskCompletionSource<OtherCube> tcs)
        {
            try
            {
                GameObject resObj = await ETModel.Game.Scene.GetComponent<ResourcesAsyncComponent>().LoadAssetAsync<GameObject>(Assets.LoadAssetAsync("Assets/Bundles/Prefab/OtherCube.prefab", typeof(GameObject)));
                ReferenceCollector rc = resObj.GetComponent<ReferenceCollector>();
                GameObject otherCubeObj = GameObject.Instantiate<GameObject>(rc.Get<GameObject>("OtherCube"));

                OtherCube otherCube = ComponentFactory.Create<OtherCube, int, GameObject>(account, otherCubeObj, false);

                ////添加网络同步组件
                //OtherPlayerNetSyncComponent otherPlayerNetSyncComponent = otherPlayer.AddComponent<OtherPlayerNetSyncComponent, int, Vector3>(account, InitPosition);

                tcs.SetResult(otherCube);
            }
            catch (Exception e)
            {
                Log.Error(e);
                tcs.SetResult(null);
            }
        }
    }
}