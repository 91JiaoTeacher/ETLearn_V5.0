using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class PlayerCubeNetComponentAwakeSystem : AwakeSystem<PlayerCubeNetComponent, int>
    {
        public override void Awake(PlayerCubeNetComponent self, int Account)
        {
            self.Awake(Account);
        }
    }

    [ObjectSystem]
    public class PlayerCubeNetComponentStartSystem : StartSystem<PlayerCubeNetComponent>
    {
        public override void Start(PlayerCubeNetComponent self)
        {
            self.Start();
        }
    }

    [ObjectSystem]
    public class PlayerCubeNetComponentUpDateSystem : UpdateSystem<PlayerCubeNetComponent>
    {
        public override void Update(PlayerCubeNetComponent self)
        {
            self.UpDate();
        }
    }

    public class PlayerCubeNetComponent : Component
    {
        /// <summary>
        /// 当前玩家账号
        /// </summary>
        private int playerAccount;

        /// <summary>
        /// 角色cube的Transform组件
        /// </summary>
        private Transform cube_Transform = null;

        /// <summary>
        /// 每秒发包次数，但是不会超过帧数
        /// </summary>
        private float ttk = 1.0f / 24.0f;

        /// <summary>
        /// 计时器
        /// </summary>
        private float timer = 0.0f;

        /// <summary>
        /// 数据包发送器
        /// </summary>
        private Session hotfixSession = null;

        /// <summary>
        /// 发送的数据包
        /// </summary>
        private C2G_PlayerRoleNetwork NetPackge = null;

        public void Awake(int Account)
        {
            playerAccount = Account;
        }

        public void Start()
        {
            cube_Transform = this.GetParent<PlayerCube>().cube_GameObject.GetComponent<Transform>();
            hotfixSession = Game.Scene.GetComponent<SessionComponent>().Session;
            NetPackge = new C2G_PlayerRoleNetwork();
            NetPackge.Account = playerAccount;
        }

        public void UpDate()
        {
            timer += Time.deltaTime;
            if (timer >= ttk)
            {
                timer = 0;
                sendNetPostion();
            }
        }

        /// <summary>
        /// 发送一次网络包
        /// </summary>
        public void sendNetPostion()
        {
            NetPackge.PositionX = cube_Transform.position.x;
            NetPackge.PositionY = cube_Transform.position.y;
            NetPackge.PositionZ = cube_Transform.position.z;

            hotfixSession.Send(NetPackge);
        }

    }
}