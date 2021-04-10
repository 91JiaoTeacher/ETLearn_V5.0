using System;
using ETModel;

namespace ETHotfix
{
    public static class LoginHelper
    {
        public static bool initSession = false;

        public static async ETVoid OnLoginAsync(int account, string Password)
        {
            try
            {
                if (!initSession)
                {
                    initSession = true;

                    Log.Info("登录的服务器地址：" + GlobalConfigComponent.Instance.GlobalProto.Address);

                    // 创建一个ETModel层的Session
                    ETModel.Session session = ETModel.Game.Scene.GetComponent<NetOuterComponent>().Create(GlobalConfigComponent.Instance.GlobalProto.Address);
                    ETModel.Game.Scene.AddComponent<ETModel.SessionComponent>().Session = session;

                    // 创建一个ETHotfix层的Session, ETHotfix的Session会通过ETModel层的Session发送消息
                    Session hotfixSession = ComponentFactory.Create<Session, ETModel.Session>(session);
                    Game.Scene.AddComponent<SessionComponent>().Session = hotfixSession;
                }

                Session Session = Game.Scene.GetComponent<SessionComponent>().Session;
                //发送请求登录的包
                G2C_Login r2CLogin = (G2C_Login)await Session.Call(new C2G_Login() { Account = account, Password = Password });

                if (r2CLogin.Key > 10)
                {
                    //添加玩家信息管理组件
                    Game.Scene.AddComponent<PlayerInfoComponent, int>(account);

                    //添加其它cube玩家的管理组件
                    Game.Scene.AddComponent<OtherCubeManagerComponent>();

                    Log.Info(r2CLogin.Address);

                    Game.EventSystem.Run(EventIdType.LoginFinish);
                }
                else
                {
                    Log.Error(r2CLogin.Address);
                }
                
                //testAll();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public static void testAll()
        {
            test1();
        }

        public static async ETVoid test1()
        {
            Log.Error("发送第一个包");
            M2C_PlayerPosition g2CPlayerPosition = (M2C_PlayerPosition)await SessionComponent.Instance.Session.Call(new C2M_PlayerPosition()
            {
                PositionX = 10,
                PositionY = 20,
                PositionZ = 30
            });

            Log.Error("玩家位置回包[" + g2CPlayerPosition.PositionX + "] | [" + g2CPlayerPosition.PositionY + "] | [" + g2CPlayerPosition.PositionZ + "]");
        }

    }
}