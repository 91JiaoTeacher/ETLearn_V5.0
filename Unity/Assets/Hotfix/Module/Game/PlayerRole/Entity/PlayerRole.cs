using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class PlayerRoleAwakeSystem : AwakeSystem<PlayerRole, int, GameObject>
    {
        public override void Awake(PlayerRole self, int account, GameObject gameObject)
        {
            self.Awake(account, gameObject);
        }
    }

	public sealed class PlayerRole : Entity
    {
        /// <summary>
        /// 这个角色是哪个账号的
        /// </summary>
        public int account;

        /// <summary>
        /// 角色的Gameobject
        /// </summary>
        public GameObject role_GameObject;

        public void Awake(int account, GameObject gameObject)
        {
            this.account = account;
            this.role_GameObject = gameObject;

        }

    }
}
