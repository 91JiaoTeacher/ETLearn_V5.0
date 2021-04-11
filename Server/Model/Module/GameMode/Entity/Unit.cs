namespace ETModel
{
    [ObjectSystem]
    public class UnitAwakeSystem : AwakeSystem<Unit, int>
    {
        public override void Awake(Unit self, int account)
        {
            self.Awake(account);
        }
    }

    public sealed class Unit : Entity
    {
        public int Account { get; private set; }

        public MailBoxComponent mailBoxComponent;

        public long GateInstanceId;

        public float InitPositionX = 0.0f;
        public float InitPositionY = 0.0f;
        public float InitPositionZ = 0.0f;

        public float RotationX = 0;
        public float RotationY = 0;
        public float RotationZ = 0;
        public float RotationW = 1;

        public float VelocityX;
        public float VelocityY;
        public float VelocityZ;

        /// <summary>
        /// 是否在开火
        /// </summary>
        public bool Fire = false;

        public void Awake(int account)
        {
            this.Account = account;
            //添加MailBoxComponent组件
            mailBoxComponent = this.AddComponent<MailBoxComponent>();

            //mailBoxComponent = this.AddComponent<MailBoxComponent, string>(MailboxType.GateSession);

        }

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }

            base.Dispose();
        }
    }
}
