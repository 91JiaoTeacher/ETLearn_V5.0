using System;
using System.Collections.Generic;
using ETModel;
using libx;
using UnityEngine;

namespace ETHotfix
{
    public static class CubeBulletFactory
    {
        private static AssetRequest assetRequest;
        private static ReferenceCollector rc;

        /// <summary>
        /// 子弹实体的池
        /// </summary>
        private static Queue<CubeBullet> cubeBulletPool = new Queue<CubeBullet>();

        public static CubeBullet CreateCubeBullet()
        {
            if (rc == null)
            {
                assetRequest = Assets.LoadAsset("Assets/Bundles/Prefab/BulletFX.prefab", typeof(GameObject));
                rc = (assetRequest.asset as GameObject).GetComponent<ReferenceCollector>();
            }

            if (cubeBulletPool.Count > 0)
            {
                return cubeBulletPool.Dequeue();
            }
            else
            {
                Bullets bullets = new Bullets(GameObject.Instantiate(rc.Get<GameObject>("gunFire")),
                    GameObject.Instantiate(rc.Get<GameObject>("bullet")),
                    GameObject.Instantiate(rc.Get<GameObject>("hitEffect")));

                CubeBullet cubeBullet = ComponentFactory.Create<CubeBullet, Bullets>(bullets, false);


                return cubeBullet;
            }
            
        }

        public static void EnCubeBulletPool(CubeBullet cubeBullet)
        {
            cubeBullet.bullets.ReSetObj();
            cubeBulletPool.Enqueue(cubeBullet);
        }

    }
}


