﻿using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class PlayerCubeAwakeSystem : AwakeSystem<PlayerCube, GameObject>
    {
        public override void Awake(PlayerCube self, GameObject gameObject)
        {
            self.Awake(gameObject);
        }
    }


    public sealed class PlayerCube : Entity
    {

        /// <summary>
        /// 角色cube的Gameobject
        /// </summary>
        public GameObject cube_GameObject;

        public void Awake(GameObject gameObject)
        {
            this.cube_GameObject = gameObject;

        }

    }
}

