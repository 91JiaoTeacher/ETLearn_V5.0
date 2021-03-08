using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class PlayerPositionNetComponentAwakeSystem : AwakeSystem<PlayerPositionNetComponent, int>
    {
        public override void Awake(PlayerPositionNetComponent self, int Account)
        {
            self.Awake(Account);
        }
    }

    [ObjectSystem]
    public class PlayerPositionNetComponentStartSystem : StartSystem<PlayerPositionNetComponent>
    {
        public override void Start(PlayerPositionNetComponent self)
        {
            self.Start();
        }
    }

    [ObjectSystem]
    public class PlayerPositionNetComponentUpDateSystem : UpdateSystem<PlayerPositionNetComponent>
    {
        public override void Update(PlayerPositionNetComponent self)
        {
            self.UpDate();
        }
    }

    public class PlayerPositionNetComponent : Component
    {
        /// <summary>
        /// 当前玩家账号
        /// </summary>
        private int playerAccount;

        /// <summary>
        /// 角色的Transform组件
        /// </summary>
        private Transform role_Transform = null;

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
            role_Transform = this.GetParent<PlayerRole>().role_GameObject.GetComponent<Transform>();
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
            NetPackge.PositionX = role_Transform.position.x;
            NetPackge.PositionY = role_Transform.position.y;
            NetPackge.PositionZ = role_Transform.position.z;

            hotfixSession.Send(NetPackge);
        }

    }
}