using System;
using System.Net;
using ETModel;
using UnityEngine;
using UnityEngine.UI;

namespace ETHotfix
{
	[ObjectSystem]
	public class UiLoginComponentSystem : AwakeSystem<UILoginComponent>
	{
		public override void Awake(UILoginComponent self)
		{
			self.Awake();
		}
	}
	
	public class UILoginComponent: Component
	{
		private GameObject account;
        private GameObject password;
		private GameObject loginBtn;

		public void Awake()
		{
			ReferenceCollector rc = this.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
			
			//注册输入框
			this.account = rc.Get<GameObject>("Account");
            this.password = rc.Get<GameObject>("Password");

			//注册登录按钮
            loginBtn = rc.Get<GameObject>("LoginBtn");
            loginBtn.GetComponent<Button>().onClick.Add(OnLogin);
		}

		public void OnLogin()
		{
			//获取账号
            if (!int.TryParse(this.account.GetComponent<InputField>().text, out int Account))
            {
                Log.Error("错误，账号不是数字");
                return;
			}

            string Password = this.password.GetComponent<InputField>().text;

			LoginHelper.OnLoginAsync(Account, Password).Coroutine();
		}
	}
}
