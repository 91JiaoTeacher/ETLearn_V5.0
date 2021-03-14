using ETModel;
using UnityEngine;

namespace ETHotfix
{

    [ObjectSystem]
    public class PlayerCubeAttackComponentAwakeSystem : AwakeSystem<PlayerCubeAttackComponent>
    {
        public override void Awake(PlayerCubeAttackComponent self)
        {
            self.Awake();
        }
    }

    [ObjectSystem]
    public class PlayerCubeAttackComponentStartSystem : StartSystem<PlayerCubeAttackComponent>
    {
        public override void Start(PlayerCubeAttackComponent self)
        {
            self.Start();
        }
    }

    [ObjectSystem]
    public class PlayerCubeAttackComponentUpDateSystem : UpdateSystem<PlayerCubeAttackComponent>
    {
        public override void Update(PlayerCubeAttackComponent self)
        {
            self.UpDate();
        }
    }

    public class PlayerCubeAttackComponent : Component
    {
        /// <summary>
        /// cube角色的Transform
        /// </summary>
        public Transform cubePlayer_Transform = null;

        /// <summary>
        /// 武器点
        /// </summary>
        public Transform cubeGun_Transform = null;

        /// <summary>
        /// 射速
        /// </summary>
        private float shootSpeedTime = 1000.0f / 10.0f;

        /// <summary>
        /// 准星的Object
        /// </summary>
        private GameObject attackObject = null;

        public void Awake()
        {
            //查找相关引用
            cubePlayer_Transform = this.GetParent<PlayerCube>().cube_GameObject.GetComponent<Transform>();
            cubeGun_Transform = cubePlayer_Transform.Find("Gun");
            attackObject = this.GetParent<PlayerCube>().GetComponent<PlayerCubeControllerComponent>().targetArrow.targetArrow_GameObject;

        }

        public void Start()
        {
           
        }

        public void UpDate()
        {
            if (attackObject != null)
            {
                if (attackObject.activeSelf)
                {
                    Debug.LogError("需要攻击");
                }
            }
        }
    }
}