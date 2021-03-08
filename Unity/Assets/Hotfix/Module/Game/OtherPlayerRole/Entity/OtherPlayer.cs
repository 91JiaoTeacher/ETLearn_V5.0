using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class OtherPlayerAwakeSystem : AwakeSystem<OtherPlayer, int, GameObject>
    {
        public override void Awake(OtherPlayer self, int account, GameObject gameObject)
        {
            self.Awake(account, gameObject);
        }
    }

    public sealed class OtherPlayer : Entity
    {
        /// <summary>
        /// 这个角色是哪个账号的
        /// </summary>
        public int account;

        /// <summary>
        /// 其它角色的Gameobject
        /// </summary>
        public GameObject otherPlayer_GameObject;

        public void Awake(int account, GameObject gameObject)
        {
            this.account = account;
            this.otherPlayer_GameObject = gameObject;

        }
    }
}