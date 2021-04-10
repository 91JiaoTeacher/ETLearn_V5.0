using System;
using System.Collections.Generic;
using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class OtherCubeNetSyncComponentAwakeSystem : AwakeSystem<OtherCubeNetSyncComponent, int, Vector3>
    {
        public override void Awake(OtherCubeNetSyncComponent self, int Account, Vector3 InitPostion)
        {
            self.Awake(Account, InitPostion);
        }
    }

    [ObjectSystem]
    public class OtherCubeNetSyncComponentStartSystem : StartSystem<OtherCubeNetSyncComponent>
    {
        public override void Start(OtherCubeNetSyncComponent self)
        {
            self.Start();
        }
    }
    public class OtherCubeNetSyncComponent : Component
    {
        /// <summary>
        /// 其它cube玩家的账号
        /// </summary>
        private int Account;

        /// <summary>
        /// 其它cube玩家的初始位置
        /// </summary>
        private Vector3 InitPosition;

        /// <summary>
        /// 其它cube玩家的Transform组件
        /// </summary>
        private Transform OtherCube_Transform;

        public void Awake(int Account, Vector3 InitPostion)
        {
            Log.Info("其它玩家初始位置：" + InitPostion.ToString());

            this.Account = Account;
            this.InitPosition = InitPostion;
        }

        public void Start()
        {
            //获取Transform
            OtherCube_Transform = this.GetParent<OtherCube>().otherCube_GameObject.GetComponent<Transform>();
            OtherCube_Transform.position = InitPosition;

            //添加网络组件到集中管理
            Game.Scene.GetComponent<OtherCubeManagerComponent>()
                .AddNetSyncComponentByOtherCubeAccount(Account, this);

        }

        /// <summary>
        /// 同步位置
        /// </summary>
        public void NetWorkAsyncPosition(Vector3 Position)
        {
            OtherCube_Transform.position = Position;

        }
    }
}