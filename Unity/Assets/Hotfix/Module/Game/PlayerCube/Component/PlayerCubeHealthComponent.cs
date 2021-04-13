using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class PlayerCubeHealthComponentAwakeSystem : AwakeSystem<PlayerCubeHealthComponent>
    {
        public override void Awake(PlayerCubeHealthComponent self)
        {
            self.Awake();
        }
    }

    [ObjectSystem]
    public class PlayerCubeHealthComponentStartSystem : StartSystem<PlayerCubeHealthComponent>
    {
        public override void Start(PlayerCubeHealthComponent self)
        {
            self.Start();
        }
    }

    public class PlayerCubeHealthComponent : Component
    {
        /// <summary>
        /// 玩家生命值信息UI
        /// </summary>
        private UI playerInfoUI;

        /// <summary>
        /// 玩家生命值信息UI组件
        /// </summary>
        private UIPlayerInfoComponent playerInfoUIComponent;

        public void Awake()
        {
            playerInfoUI = UIPlayerInfoFactory.Create();
            Game.Scene.GetComponent<UIComponent>().Add(playerInfoUI);
        }

        public void Start()
        {
            //查找引用
            playerInfoUIComponent = playerInfoUI.GetComponent<UIPlayerInfoComponent>();

        }

        /// <summary>
        /// 设置生命值UI的显示
        /// </summary>
        public void SetPlayerCubeHealth(int health)
        {
            playerInfoUIComponent.Health.fillAmount = (health / 100.0f);
        }

    }
}