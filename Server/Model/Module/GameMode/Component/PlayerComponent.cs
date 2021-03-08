using System.Collections.Generic;

namespace ETModel
{
    [ObjectSystem]
    public class PlayerComponentAwakeSystem : AwakeSystem<PlayerComponent>
    {
        public override void Awake(PlayerComponent self)
        {
            self.Awake();
        }
    }

    public class PlayerComponent: Component
    {

        private Dictionary<int, Player> AccountToPlayer = new Dictionary<int, Player>();

        public void Awake()
        {
            Log.Info("玩家管理组件初始化");
        }

        /// <summary>
        /// 添加玩家实体到字典管理
        /// </summary>
        public void addPlayerToDict(int account, Player player)
        {
            if (!AccountToPlayer.ContainsKey(account))
            {
                AccountToPlayer.Add(account, player);
            }
            else
            {
                Log.Error("相同账号重复添加：" + account);
            }

        }

        /// <summary>
        /// 通过账号来获取玩家
        /// </summary>
        public Player getPlayerByAccount(int account)
        {
            if (AccountToPlayer.TryGetValue(account, out Player player))
            {
                return player;
            }
            else
            {
                Log.Error("错误，没有获取到玩家：" + account);
                return null;
            }
        }

        /// <summary>
        /// 忽略自己的account获取到其它玩家的account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public List<Player> getOtherPlayerIgnoreAccount(int account)
        {
            if (AccountToPlayer.Count > 1)
            {
                List<Player> data = new List<Player>();
                foreach (int otherAccount in AccountToPlayer.Keys)
                {
                    if (account != otherAccount)
                    {
                        data.Add(AccountToPlayer[otherAccount]);
                    }
                }
                return data;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 账号已经被创建过了
        /// </summary>
        public bool AccountHaveBeCreated(int account)
        {
            return AccountToPlayer.ContainsKey(account);
        }
    }
}

