using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class OtherPlayerNetSyncComponentAwakeSystem : AwakeSystem<OtherPlayerNetSyncComponent,int, Vector3>
    {
        public override void Awake(OtherPlayerNetSyncComponent self, int Account, Vector3 InitPostion)
        {
            self.Awake(Account, InitPostion);
        }
    }

    [ObjectSystem]
    public class OtherPlayerNetSyncComponentStartSystem : StartSystem<OtherPlayerNetSyncComponent>
    {
        public override void Start(OtherPlayerNetSyncComponent self)
        {
            self.Start();
        }
    }

    public class OtherPlayerNetSyncComponent : Component
    {
        /// <summary>
        /// 其它玩家账号
        /// </summary>
        private int Account;

        /// <summary>
        /// 其它玩家的位置
        /// </summary>
        private Vector3 Position;

        private Transform OtherPlayer_Transform;

        public void Awake(int Account, Vector3 InitPostion)
        {
            Log.Info("其它玩家初始位置：" + InitPostion.ToString());

            this.Account = Account;
            Position = InitPostion;
        }

        public void Start()
        {
            //获取Transform
            OtherPlayer_Transform = this.GetParent<OtherPlayer>().otherPlayer_GameObject.GetComponent<Transform>();
            OtherPlayer_Transform.position = Position;

            //添加网络组件到集中管理
            Game.Scene.GetComponent<OtherPlayerManagerComponent>()
                .AddNetSyncComponentByOtherPlayerAccount(Account, this);

        }

        /// <summary>
        /// 同步位置
        /// </summary>
        public void NetWorkAsyncPosition(Vector3 Position)
        {
            this.Position = Position;
            OtherPlayer_Transform.position = Position;

        }
    }
}