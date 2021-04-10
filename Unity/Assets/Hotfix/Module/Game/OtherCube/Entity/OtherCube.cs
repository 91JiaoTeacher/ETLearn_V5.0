using ETModel;
using UnityEngine;

namespace ETHotfix
{

    [ObjectSystem]
    public class OtherCubeAwakeSystem : AwakeSystem<OtherCube, int, GameObject>
    {
        public override void Awake(OtherCube self, int account, GameObject gameObject)
        {
            self.Awake(account, gameObject);
        }
    }

    public sealed class OtherCube : Entity
    {
        /// <summary>
        /// 这个cube角色是哪个账号的
        /// </summary>
        public int account;

        /// <summary>
        /// cube角色的Gameobject
        /// </summary>
        public GameObject otherCube_GameObject;

        public void Awake(int account, GameObject gameObject)
        {
            this.account = account;
            this.otherCube_GameObject = gameObject;

        }
    }
}