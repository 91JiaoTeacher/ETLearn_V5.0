using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    
    public class OtherPlayerManagerComponent : Component
    {
        /// <summary>
        /// 其它玩家的账号以及其对应的网络同步组件
        /// </summary>
        private Dictionary<int, OtherPlayerNetSyncComponent> otherPlayerAccountToNetSyncComponent =
            new Dictionary<int, OtherPlayerNetSyncComponent>();

        /// <summary>
        /// 通过账号获取其它玩家的网络同步组件
        /// </summary>
        public OtherPlayerNetSyncComponent GetNetSyncComponentByOtherPlayerAccount(int Account)
        {
            if (otherPlayerAccountToNetSyncComponent.TryGetValue(Account,
                out OtherPlayerNetSyncComponent netSyncComponent))
            {
                return netSyncComponent;
            }
            return null;
        }

        /// <summary>
        /// 添加其它玩家的网络同步组件
        /// </summary>
        public void AddNetSyncComponentByOtherPlayerAccount(int Account, OtherPlayerNetSyncComponent netSyncComponent)
        {
            if (!otherPlayerAccountToNetSyncComponent.ContainsKey(Account))
            {
                otherPlayerAccountToNetSyncComponent.Add(Account, netSyncComponent);
            }
            else
            {
                Log.Info("其它玩家已经存在：" + Account);
            }
        }

    }
}


