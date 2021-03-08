using ETModel;
using UnityEngine;

namespace ETHotfix
{
    [ObjectSystem]
    public class PlayerControllerComponentAwakeSystem : AwakeSystem<PlayerControllerComponent>
    {
        public override void Awake(PlayerControllerComponent self)
        {
            self.Awake();
        }
    }

    [ObjectSystem]
    public class PlayerControllerComponentStartSystem : StartSystem<PlayerControllerComponent>
    {
        public override void Start(PlayerControllerComponent self)
        {
            self.Start();
        }
    }

    [ObjectSystem]
    public class PlayerControllerComponentUpDateSystem : UpdateSystem<PlayerControllerComponent>
    {
        public override void Update(PlayerControllerComponent self)
        {
            self.UpDate();
        }
    }

    public class PlayerControllerComponent : Component
    {
        /// <summary>
        /// 角色的Gameobject
        /// </summary>
        public Transform player_Transform = null;

        /// <summary>
        /// 角色的PlayerUnit
        /// </summary>
        public Transform playerUnit_Transform = null;

        /// <summary>
        /// 所有摄像机的父物体
        /// </summary>
        public Transform PlayerCameraBaseTransform = null;

        /// <summary>
        /// 角色的CharacterController组件
        /// </summary>
        private CharacterController Controller = null;

        /// <summary>
        /// 鼠标灵敏度
        /// </summary>
        public float mouseSensitivity = 15.0f;

        /// <summary>
        /// 上下视角
        /// </summary>
        public float xRotation = 0.0f;

        /// <summary>
        /// 移动速度
        /// </summary>
        private float speed = 10.0f;

        /// <summary>
        /// 重力加速度
        /// </summary>
        private float gravity = -9.81f * 2.0f;

        /// <summary>
        /// 速率
        /// </summary>
        private Vector3 velocity = Vector3.zero;

        /// <summary>
        /// 地面检测点
        /// </summary>
        private Transform groundCheck = null;

        /// <summary>
        /// 检测地面距离
        /// </summary>
        public float groundDistance = 0.5f;

        /// <summary>
        /// 是否在地面
        /// </summary>
        private bool isGrounded = true;

        /// <summary>
        /// 跳跃高度
        /// </summary>
        private float jumpHeight = 1.5f;

        public void Awake()
        {
            //查找相关引用
            player_Transform = this.GetParent<PlayerRole>().role_GameObject.GetComponent<Transform>();
            playerUnit_Transform = player_Transform.Find("PlayerUnit").GetComponent<Transform>();

            PlayerCameraBaseTransform = playerUnit_Transform.Find("PlayerCameraBase");
            groundCheck = playerUnit_Transform.Find("GroundCheck");
            Controller = player_Transform.GetComponent<CharacterController>();
        }

        public void Start()
        {
            Log.Info("角色创建完成");
            Cursor.visible = false;//隐藏鼠标
            Cursor.lockState = CursorLockMode.Locked;   //锁定鼠标在正中间
        }


        public void UpDate()
        {

            //检测角色是否在地面
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, 14336);

            MouseMove();

            PlayerMove();

        }

        public void MouseMove()
        {

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

            PlayerCameraBaseTransform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
            playerUnit_Transform.Rotate(Vector3.up * mouseX);


        }

        public void PlayerMove()
        {
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = playerUnit_Transform.right * x + playerUnit_Transform.forward * z;

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            Controller.Move(move * Time.deltaTime * speed + velocity * Time.deltaTime);
            
        }

    }
}


