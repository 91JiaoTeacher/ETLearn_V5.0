using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    public class OtherCubeManagerComponent : Component
    {
        /// <summary>
        /// 其它cube玩家的账号以及其对应的网络同步组件
        /// </summary>
        private Dictionary<int, OtherCubeNetSyncComponent> otherCubeAccountToNetSyncComponent =
            new Dictionary<int, OtherCubeNetSyncComponent>();

        /// <summary>
        /// 通过账号获取其它cube玩家的网络同步组件
        /// </summary>
        public OtherCubeNetSyncComponent GetNetSyncComponentByOtherCubeAccount(int Account)
        {
            if (otherCubeAccountToNetSyncComponent.TryGetValue(Account,
                out OtherCubeNetSyncComponent netSyncComponent))
            {
                return netSyncComponent;
            }
            return null;
        }

        /// <summary>
        /// 添加其它cube玩家的网络同步组件
        /// </summary>
        public void AddNetSyncComponentByOtherCubeAccount(int Account, OtherCubeNetSyncComponent netSyncComponent)
        {
            if (!otherCubeAccountToNetSyncComponent.ContainsKey(Account))
            {
                otherCubeAccountToNetSyncComponent.Add(Account, netSyncComponent);
            }
            else
            {
                Log.Info("其它玩家已经存在：" + Account);
            }
        }

    }
}