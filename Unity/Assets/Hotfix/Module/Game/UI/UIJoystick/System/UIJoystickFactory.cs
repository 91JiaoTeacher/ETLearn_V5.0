using System;
using libx;
using UnityEngine;

namespace ETHotfix
{
    public static class UIJoystickFactory
    {
        public static UI Create()
        {
            try
            {
                AssetRequest assetRequest = Assets.LoadAsset("Assets/Bundles/UI/" + UIType.UIJoystick + ".prefab", typeof(GameObject));
                GameObject bundleGameObject = assetRequest.asset as GameObject;
                GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject);

                UI ui = ComponentFactory.Create<UI, string, GameObject, AssetRequest>(UIType.UIJoystick, gameObject, assetRequest, false);

                ui.AddComponent<VariableJoystickComponent>();
                return ui;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return null;
            }
		}


    }
}

