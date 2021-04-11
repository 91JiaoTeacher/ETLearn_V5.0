using ETModel;

namespace ETHotfix
{
    [MessageHandler(AppType.Gate)]
    public class C2G_PlayerRoleNetworkHandler : AMHandler<C2G_PlayerRoleNetwork>
    {
        protected override async ETTask Run(Session session, C2G_PlayerRoleNetwork message)
        {
            //Log.Info("玩家[" + message.Account + "]传来坐标信息：" + message.RotationX + " | " + message.RotationY + " | " + message.RotationZ + " | " + message.RotationW);

            //获取玩家
            Player player = Game.Scene.GetComponent<PlayerComponent>().getPlayerByAccount(message.Account);
            //Actor发送组件
            ActorMessageSenderComponent actorSenderComponent = Game.Scene.GetComponent<ActorMessageSenderComponent>();
            ActorMessageSender actorMessageSender = actorSenderComponent.Get(player.MapInstanceId);

            actorMessageSender.Send(new Actor_PlayerInitPositionUpDate()
            {
                PositionX = message.PositionX, 
                PositionY = message.PositionY, 
                PositionZ = message.PositionZ,
                RotationX = message.RotationX,
                RotationY = message.RotationY,
                RotationZ = message.RotationZ,
                RotationW = message.RotationW,
                VelocityX = message.VelocityX,
                VelocityY = message.VelocityY,
                VelocityZ = message.VelocityZ,
            });

            await ETTask.CompletedTask;
        }
    }
}
