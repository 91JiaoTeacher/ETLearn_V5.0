using System;
using ETModel;

namespace ETHotfix
{
    public static class LoginHelper
    {
        public static void OnLoginAsync(int account)
        {
            //添加玩家信息管理组件
            Game.Scene.AddComponent<PlayerInfoComponent, int>(account);

            //添加其它cube玩家的管理组件
            Game.Scene.AddComponent<OtherCubeManagerComponent>();

            Game.EventSystem.Run(EventIdType.LoginFinish);
        }

    }
}