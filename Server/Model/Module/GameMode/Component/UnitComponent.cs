using System.Collections.Generic;
using System.Linq;

namespace ETModel
{

    [ObjectSystem]
    public class UnitComponentAwakeSystem : AwakeSystem<UnitComponent>
    {
        public override void Awake(UnitComponent self)
        {
            self.Awake();
        }
    }
    public class UnitComponent : Component
    {
        private Dictionary<int, Unit> AccountToUnit = new Dictionary<int, Unit>();

        public void Awake()
        {
            Log.Info("单位管理组件初始化");
        }

        /// <summary>
        /// 添加玩家实体到字典管理
        /// </summary>
        public void addUnitToDict(int account, Unit player)
        {
            if (!AccountToUnit.ContainsKey(account))
            {
                AccountToUnit.Add(account, player);
            }
            else
            {
                Log.Error("Unit账号重复添加：" + account);
            }

        }

        /// <summary>
        /// 通过账号来获取Unit
        /// </summary>
        public Unit getUnitByAccount(int account)
        {
            if (AccountToUnit.TryGetValue(account, out Unit unit))
            {
                return unit;
            }
            else
            {
                Log.Error("错误，没有获取到unit：" + account);
                return null;
            }
        }

        /// <summary>
        /// 得到不少于多少个Unit
        /// </summary>
        public List<Unit> getCountUnits(int minCount)
        {
            if (AccountToUnit.Count > 1)
            {
                return AccountToUnit.Values.ToList<Unit>();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Unit已经被创建过了
        /// </summary>
        public bool UnitHaveBeCreated(int account)
        {
            return AccountToUnit.ContainsKey(account);
        }

    }
}
