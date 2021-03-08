using ETModel;
namespace ETHotfix
{
	[Message(HotfixOpcode.C2G_Login)]
	public partial class C2G_Login : IRequest {}

	[Message(HotfixOpcode.G2C_Login)]
	public partial class G2C_Login : IResponse {}

	[Message(HotfixOpcode.C2G_RequestEnterMap)]
	public partial class C2G_RequestEnterMap : IRequest {}

	[Message(HotfixOpcode.G2C_RequestEnterMap)]
	public partial class G2C_RequestEnterMap : IResponse {}

	[Message(HotfixOpcode.C2M_PlayerPosition)]
	public partial class C2M_PlayerPosition : IRequest {}

	[Message(HotfixOpcode.M2C_PlayerPosition)]
	public partial class M2C_PlayerPosition : IResponse {}

	[Message(HotfixOpcode.C2G_PlayerRoleNetwork)]
	public partial class C2G_PlayerRoleNetwork : IMessage {}

	[Message(HotfixOpcode.C2G_GetOtherPlayer)]
	public partial class C2G_GetOtherPlayer : IMessage {}

	[Message(HotfixOpcode.G2C_OtherPlayerEnterMap)]
	public partial class G2C_OtherPlayerEnterMap : IMessage {}

	[Message(HotfixOpcode.G2C_OtherPlayerPosition)]
	public partial class G2C_OtherPlayerPosition : IMessage {}

}
namespace ETHotfix
{
	public static partial class HotfixOpcode
	{
		 public const ushort C2G_Login = 10001;
		 public const ushort G2C_Login = 10002;
		 public const ushort C2G_RequestEnterMap = 10003;
		 public const ushort G2C_RequestEnterMap = 10004;
		 public const ushort C2M_PlayerPosition = 10005;
		 public const ushort M2C_PlayerPosition = 10006;
		 public const ushort C2G_PlayerRoleNetwork = 10007;
		 public const ushort C2G_GetOtherPlayer = 10008;
		 public const ushort G2C_OtherPlayerEnterMap = 10009;
		 public const ushort G2C_OtherPlayerPosition = 10010;
	}
}
