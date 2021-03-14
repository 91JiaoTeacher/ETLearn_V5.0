using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class CubeBulletAwakeSystem : AwakeSystem<CubeBullet, Bullets>
    {
        public override void Awake(CubeBullet self, Bullets bullets)
        {
            self.Awake(bullets);
        }
    }

    public class CubeBullet : Entity
    {
        public Bullets bullets;

        public void Awake(Bullets bullets)
        {
            this.bullets = bullets;


        }




    }

    /// <summary>
    /// 一个子弹特效所包含的三个部分
    /// </summary>
    public struct Bullets
    {
        public GameObject gunFire;
        public GameObject bullet;
        public GameObject hitEffect;

        public Bullets(GameObject gunFire, GameObject bullet, GameObject hitEffect)
        {
            this.gunFire = gunFire;
            this.bullet = bullet;
            this.hitEffect = hitEffect;

            ReSetObj();
        }

        /// <summary>
        /// 重置物体
        /// </summary>
        public void ReSetObj()
        {
            gunFire.SetActive(false);
            bullet.SetActive(false);
            hitEffect.SetActive(false);
        }
    }
}