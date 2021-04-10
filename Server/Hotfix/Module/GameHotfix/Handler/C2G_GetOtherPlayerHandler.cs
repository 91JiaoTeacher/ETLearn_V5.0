using System.Collections.Generic;
using ETModel;

namespace ETHotfix
{
    [MessageHandler(AppType.Gate)]
    public class C2G_GetOtherPlayerHandler : AMHandler<C2G_GetOtherPlayer>
    {
        protected override async ETTask Run(Session session, C2G_GetOtherPlayer message)
        {
            PlayerComponent playerComponent = Game.Scene.GetComponent<PlayerComponent>();

            //发送其它玩家的信息给客户端
            List<Player> players = playerComponent.getOtherPlayerIgnoreAccount(message.Account);
            if (players != null)
            {
                //获取角色出生位置
                ActorMessageSenderComponent actorSenderComponent = Game.Scene.GetComponent<ActorMessageSenderComponent>();

                for (int i = 0; i < players.Count; i++)
                {
                    //需要保证玩家进入地图才发送
                    if (players[i].MapInstanceId != 0)
                    {
                        ActorMessageSender actorMessageSender = actorSenderComponent.Get(players[i].MapInstanceId);
                        Actor_PlayerInitPositionResponse actor_PlayerInitPositionResponse = (Actor_PlayerInitPositionResponse)await actorMessageSender.Call(new Actor_PlayerInitPositionRequest());
                        session.Send(new G2C_OtherPlayerEnterMap()
                        {
                            Account = players[i].Account,
                            PositionX = actor_PlayerInitPositionResponse.PositionX,
                            PositionY = actor_PlayerInitPositionResponse.PositionY,
                            PositionZ = actor_PlayerInitPositionResponse.PositionZ
                        });
                    }
                }
            }

            await ETTask.CompletedTask;
        }
    }
}
