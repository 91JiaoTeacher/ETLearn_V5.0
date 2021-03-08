using System;
using System.Collections.Generic;
using ETModel;

namespace ETHotfix
{
    [MessageHandler(AppType.Gate)]
    public class C2R_LoginHandler : AMRpcHandler<C2G_Login, G2C_Login>
    {
        protected override async ETTask Run(Session session, C2G_Login request, G2C_Login response, Action reply)
        {
            Log.Info("玩家登录：" + request.Account + "玩家输入密码：" + request.Password);

            Log.Info("玩家上线，查询数据库");
            DBProxyComponent dBProxy = Game.Scene.GetComponent<DBProxyComponent>();

            List<ComponentWithId> count = await dBProxy.Query<PlayerInfoDB>(PlayerInfoDB => PlayerInfoDB.account == request.Account);
            if (count.Count > 0)
            {
                if (count.Count == 1)
                {
                    //取得该条数据
                    PlayerInfoDB info = await dBProxy.Query<PlayerInfoDB>(count[0].Id);
                    //验证密码
                    if (info.pwd == request.Password)
                    {
                        Log.Info("密码正确，允许登录");

                        response.Address = "密码正确, 允许登录";
                        response.Key = 11;
                    }
                    else
                    {
                        Log.Info("密码错误");

                        response.Address = "密码错误";
                        response.Key = 1;
                    }
                }
                else
                {
                    Log.Error("账号重复了: " + count.Count);
                    response.Address = "账号重复错误，请联系管理员";
                    response.Key = 2;
                }
            }
            else
            {
                //如果运行到这里说明是注册的新账号
                PlayerInfoDB playerData = ComponentFactory.Create<PlayerInfoDB>();
                playerData.account = request.Account;
                playerData.pwd = request.Password;
                await dBProxy.Save(playerData);

                response.Address = "注册新账号成功";
                response.Key = 12;

                Log.Info("注册新账号成功");
            }


            PlayerComponent playerComponent = Game.Scene.GetComponent<PlayerComponent>();

            //查看玩家是否已经登录创建过
            Player loginPlayer;
            if (playerComponent.AccountHaveBeCreated(request.Account))
            {
                //获取之前已经创建好的Player实体
                loginPlayer = playerComponent.getPlayerByAccount(request.Account);
            }
            else
            {
                //创建登录玩家的实体
                loginPlayer = PlayerFactory.Create(request.Account);
                //向玩家管理组件里添加玩家的信息
                playerComponent.addPlayerToDict(request.Account, loginPlayer);
            }
            //对玩家的session进行记录
            loginPlayer.session = session;
            session.AddComponent<SessionPlayerComponent>().Player = loginPlayer;

            reply();
            await ETTask.CompletedTask;
        }
    }
}