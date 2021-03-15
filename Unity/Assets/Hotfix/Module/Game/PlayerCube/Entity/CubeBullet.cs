using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class CubeBulletAwakeSystem : AwakeSystem<CubeBullet, GameObject[]>
    {
        public override void Awake(CubeBullet self, GameObject[] bulletObj)
        {
            self.Awake(bulletObj);
        }
    }

    public class CubeBullet : Entity
    {
        /// <summary>
        /// 子弹的三部分
        /// </summary>
        public GameObject[] bulletObj;

        /// <summary>
        /// 子弹速度
        /// </summary>
        private float bulletSpeed = 40.0f;

        public void Awake(GameObject[] bulletObj)
        {
            this.bulletObj = bulletObj;
            //初始化全部隐藏
            ReSet();

        }

        /// <summary>
        /// 子弹被用于攻击
        /// </summary>
        public void Attack(GameObject gunParent, GameObject dirObj, Vector3 baseVelocity)
        {
            bulletObj[1].SetActive(true);
            bulletObj[1].transform.position = gunParent.transform.position;
            bulletObj[1].transform.LookAt(dirObj.transform.position);
            bulletObj[1].GetComponent<Rigidbody>().velocity = bulletObj[1].transform.forward * bulletSpeed + baseVelocity;
        }


        /// <summary>
        /// 重置
        /// </summary>
        public void ReSet()
        {
            for (int i = 0; i < bulletObj.Length; i++)
            {
                bulletObj[i].SetActive(false);
            }
        }

    }

}