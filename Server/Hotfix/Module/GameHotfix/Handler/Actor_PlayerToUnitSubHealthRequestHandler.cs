using ETModel;
using System;

namespace ETHotfix
{
    [ActorMessageHandler(AppType.Map)]
    public class Actor_PlayerToUnitSubHealthRequestHandler : AMActorRpcHandler<Unit, Actor_PlayerToUnitSubHealthRequest, Actor_PlayerToUnitSubHealthResponse>
    {
        protected override async ETTask Run(Unit unit, Actor_PlayerToUnitSubHealthRequest request, Actor_PlayerToUnitSubHealthResponse response, Action reply)
        {
            //是否攻击了已经死亡的玩家
            response.AttackDiePlayer = false;

            if (unit.Die)
            {
                response.AttackDiePlayer = true;
            }
            else
            {
                int newHealth = unit.SubHealth(request.SubHealth);

                response.UnitHealth = newHealth;
                response.Die = unit.Die;
            }
            

            reply();
            await ETTask.CompletedTask;
        }
    }
}
