using ETModel;
using System;

namespace ETHotfix
{
    [ActorMessageHandler(AppType.Map)]
    public class Actor_PlayerToUnitSubHealthRequestHandler : AMActorRpcHandler<Unit, Actor_PlayerToUnitSubHealthRequest, Actor_PlayerToUnitSubHealthResponse>
    {
        protected override async ETTask Run(Unit unit, Actor_PlayerToUnitSubHealthRequest request, Actor_PlayerToUnitSubHealthResponse response, Action reply)
        {
            int newHealth = unit.SubHealth(request.SubHealth);

            response.UnitHealth = newHealth;
            response.Die = false;

            reply();
            await ETTask.CompletedTask;
        }
    }
}
