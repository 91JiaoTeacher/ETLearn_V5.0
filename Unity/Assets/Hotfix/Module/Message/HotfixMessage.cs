// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: HotfixMessage.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using scg = global::System.Collections.Generic;
namespace ETHotfix {

  #region Messages
  public partial class C2G_Login : pb::IMessage {
    private static readonly pb::MessageParser<C2G_Login> _parser = new pb::MessageParser<C2G_Login>(() => (C2G_Login)MessagePool.Instance.Fetch(typeof(C2G_Login)));
    public static pb::MessageParser<C2G_Login> Parser { get { return _parser; } }

    private int rpcId_;
    public int RpcId {
      get { return rpcId_; }
      set {
        rpcId_ = value;
      }
    }

    private int account_;
    /// <summary>
    /// 帐号
    /// </summary>
    public int Account {
      get { return account_; }
      set {
        account_ = value;
      }
    }

    private string password_ = "";
    /// <summary>
    /// 密码
    /// </summary>
    public string Password {
      get { return password_; }
      set {
        password_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    public void WriteTo(pb::CodedOutputStream output) {
      if (Account != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Account);
      }
      if (Password.Length != 0) {
        output.WriteRawTag(18);
        output.WriteString(Password);
      }
      if (RpcId != 0) {
        output.WriteRawTag(208, 5);
        output.WriteInt32(RpcId);
      }
    }

    public int CalculateSize() {
      int size = 0;
      if (RpcId != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(RpcId);
      }
      if (Account != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Account);
      }
      if (Password.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Password);
      }
      return size;
    }

    public void MergeFrom(pb::CodedInputStream input) {
      account_ = 0;
      password_ = "";
      rpcId_ = 0;
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            Account = input.ReadInt32();
            break;
          }
          case 18: {
            Password = input.ReadString();
            break;
          }
          case 720: {
            RpcId = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public partial class G2C_Login : pb::IMessage {
    private static readonly pb::MessageParser<G2C_Login> _parser = new pb::MessageParser<G2C_Login>(() => (G2C_Login)MessagePool.Instance.Fetch(typeof(G2C_Login)));
    public static pb::MessageParser<G2C_Login> Parser { get { return _parser; } }

    private int rpcId_;
    public int RpcId {
      get { return rpcId_; }
      set {
        rpcId_ = value;
      }
    }

    private int error_;
    public int Error {
      get { return error_; }
      set {
        error_ = value;
      }
    }

    private string message_ = "";
    public string Message {
      get { return message_; }
      set {
        message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    private string address_ = "";
    public string Address {
      get { return address_; }
      set {
        address_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    private int key_;
    public int Key {
      get { return key_; }
      set {
        key_ = value;
      }
    }

    public void WriteTo(pb::CodedOutputStream output) {
      if (Address.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Address);
      }
      if (Key != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(Key);
      }
      if (RpcId != 0) {
        output.WriteRawTag(208, 5);
        output.WriteInt32(RpcId);
      }
      if (Error != 0) {
        output.WriteRawTag(216, 5);
        output.WriteInt32(Error);
      }
      if (Message.Length != 0) {
        output.WriteRawTag(226, 5);
        output.WriteString(Message);
      }
    }

    public int CalculateSize() {
      int size = 0;
      if (RpcId != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(RpcId);
      }
      if (Error != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(Error);
      }
      if (Message.Length != 0) {
        size += 2 + pb::CodedOutputStream.ComputeStringSize(Message);
      }
      if (Address.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Address);
      }
      if (Key != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Key);
      }
      return size;
    }

    public void MergeFrom(pb::CodedInputStream input) {
      address_ = "";
      key_ = 0;
      rpcId_ = 0;
      error_ = 0;
      message_ = "";
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10: {
            Address = input.ReadString();
            break;
          }
          case 16: {
            Key = input.ReadInt32();
            break;
          }
          case 720: {
            RpcId = input.ReadInt32();
            break;
          }
          case 728: {
            Error = input.ReadInt32();
            break;
          }
          case 738: {
            Message = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public partial class C2G_RequestEnterMap : pb::IMessage {
    private static readonly pb::MessageParser<C2G_RequestEnterMap> _parser = new pb::MessageParser<C2G_RequestEnterMap>(() => (C2G_RequestEnterMap)MessagePool.Instance.Fetch(typeof(C2G_RequestEnterMap)));
    public static pb::MessageParser<C2G_RequestEnterMap> Parser { get { return _parser; } }

    private int rpcId_;
    public int RpcId {
      get { return rpcId_; }
      set {
        rpcId_ = value;
      }
    }

    private int account_;
    /// <summary>
    /// 帐号
    /// </summary>
    public int Account {
      get { return account_; }
      set {
        account_ = value;
      }
    }

    public void WriteTo(pb::CodedOutputStream output) {
      if (Account != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Account);
      }
      if (RpcId != 0) {
        output.WriteRawTag(208, 5);
        output.WriteInt32(RpcId);
      }
    }

    public int CalculateSize() {
      int size = 0;
      if (RpcId != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(RpcId);
      }
      if (Account != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Account);
      }
      return size;
    }

    public void MergeFrom(pb::CodedInputStream input) {
      account_ = 0;
      rpcId_ = 0;
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            Account = input.ReadInt32();
            break;
          }
          case 720: {
            RpcId = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public partial class G2C_RequestEnterMap : pb::IMessage {
    private static readonly pb::MessageParser<G2C_RequestEnterMap> _parser = new pb::MessageParser<G2C_RequestEnterMap>(() => (G2C_RequestEnterMap)MessagePool.Instance.Fetch(typeof(G2C_RequestEnterMap)));
    public static pb::MessageParser<G2C_RequestEnterMap> Parser { get { return _parser; } }

    private int rpcId_;
    public int RpcId {
      get { return rpcId_; }
      set {
        rpcId_ = value;
      }
    }

    private int error_;
    public int Error {
      get { return error_; }
      set {
        error_ = value;
      }
    }

    private string message_ = "";
    public string Message {
      get { return message_; }
      set {
        message_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    private float positionX_;
    public float PositionX {
      get { return positionX_; }
      set {
        positionX_ = value;
      }
    }

    private float positionY_;
    public float PositionY {
      get { return positionY_; }
      set {
        positionY_ = value;
      }
    }

    private float positionZ_;
    public float PositionZ {
      get { return positionZ_; }
      set {
        positionZ_ = value;
      }
    }

    public void WriteTo(pb::CodedOutputStream output) {
      if (PositionX != 0F) {
        output.WriteRawTag(13);
        output.WriteFloat(PositionX);
      }
      if (PositionY != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(PositionY);
      }
      if (PositionZ != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(PositionZ);
      }
      if (RpcId != 0) {
        output.WriteRawTag(208, 5);
        output.WriteInt32(RpcId);
      }
      if (Error != 0) {
        output.WriteRawTag(216, 5);
        output.WriteInt32(Error);
      }
      if (Message.Length != 0) {
        output.WriteRawTag(226, 5);
        output.WriteString(Message);
      }
    }

    public int CalculateSize() {
      int size = 0;
      if (RpcId != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(RpcId);
      }
      if (Error != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(Error);
      }
      if (Message.Length != 0) {
        size += 2 + pb::CodedOutputStream.ComputeStringSize(Message);
      }
      if (PositionX != 0F) {
        size += 1 + 4;
      }
      if (PositionY != 0F) {
        size += 1 + 4;
      }
      if (PositionZ != 0F) {
        size += 1 + 4;
      }
      return size;
    }

    public void MergeFrom(pb::CodedInputStream input) {
      positionX_ = 0f;
      positionY_ = 0f;
      positionZ_ = 0f;
      rpcId_ = 0;
      error_ = 0;
      message_ = "";
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 13: {
            PositionX = input.ReadFloat();
            break;
          }
          case 21: {
            PositionY = input.ReadFloat();
            break;
          }
          case 29: {
            PositionZ = input.ReadFloat();
            break;
          }
          case 720: {
            RpcId = input.ReadInt32();
            break;
          }
          case 728: {
            Error = input.ReadInt32();
            break;
          }
          case 738: {
            Message = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public partial class C2G_PlayerRoleNetwork : pb::IMessage {
    private static readonly pb::MessageParser<C2G_PlayerRoleNetwork> _parser = new pb::MessageParser<C2G_PlayerRoleNetwork>(() => (C2G_PlayerRoleNetwork)MessagePool.Instance.Fetch(typeof(C2G_PlayerRoleNetwork)));
    public static pb::MessageParser<C2G_PlayerRoleNetwork> Parser { get { return _parser; } }

    private int account_;
    public int Account {
      get { return account_; }
      set {
        account_ = value;
      }
    }

    private float positionX_;
    public float PositionX {
      get { return positionX_; }
      set {
        positionX_ = value;
      }
    }

    private float positionY_;
    public float PositionY {
      get { return positionY_; }
      set {
        positionY_ = value;
      }
    }

    private float positionZ_;
    public float PositionZ {
      get { return positionZ_; }
      set {
        positionZ_ = value;
      }
    }

    private float rotationX_;
    public float RotationX {
      get { return rotationX_; }
      set {
        rotationX_ = value;
      }
    }

    private float rotationY_;
    public float RotationY {
      get { return rotationY_; }
      set {
        rotationY_ = value;
      }
    }

    private float rotationZ_;
    public float RotationZ {
      get { return rotationZ_; }
      set {
        rotationZ_ = value;
      }
    }

    private float rotationW_;
    public float RotationW {
      get { return rotationW_; }
      set {
        rotationW_ = value;
      }
    }

    private float velocityX_;
    public float VelocityX {
      get { return velocityX_; }
      set {
        velocityX_ = value;
      }
    }

    private float velocityY_;
    public float VelocityY {
      get { return velocityY_; }
      set {
        velocityY_ = value;
      }
    }

    private float velocityZ_;
    public float VelocityZ {
      get { return velocityZ_; }
      set {
        velocityZ_ = value;
      }
    }

    public void WriteTo(pb::CodedOutputStream output) {
      if (Account != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Account);
      }
      if (PositionX != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(PositionX);
      }
      if (PositionY != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(PositionY);
      }
      if (PositionZ != 0F) {
        output.WriteRawTag(37);
        output.WriteFloat(PositionZ);
      }
      if (RotationX != 0F) {
        output.WriteRawTag(45);
        output.WriteFloat(RotationX);
      }
      if (RotationY != 0F) {
        output.WriteRawTag(53);
        output.WriteFloat(RotationY);
      }
      if (RotationZ != 0F) {
        output.WriteRawTag(61);
        output.WriteFloat(RotationZ);
      }
      if (RotationW != 0F) {
        output.WriteRawTag(69);
        output.WriteFloat(RotationW);
      }
      if (VelocityX != 0F) {
        output.WriteRawTag(77);
        output.WriteFloat(VelocityX);
      }
      if (VelocityY != 0F) {
        output.WriteRawTag(85);
        output.WriteFloat(VelocityY);
      }
      if (VelocityZ != 0F) {
        output.WriteRawTag(93);
        output.WriteFloat(VelocityZ);
      }
    }

    public int CalculateSize() {
      int size = 0;
      if (Account != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Account);
      }
      if (PositionX != 0F) {
        size += 1 + 4;
      }
      if (PositionY != 0F) {
        size += 1 + 4;
      }
      if (PositionZ != 0F) {
        size += 1 + 4;
      }
      if (RotationX != 0F) {
        size += 1 + 4;
      }
      if (RotationY != 0F) {
        size += 1 + 4;
      }
      if (RotationZ != 0F) {
        size += 1 + 4;
      }
      if (RotationW != 0F) {
        size += 1 + 4;
      }
      if (VelocityX != 0F) {
        size += 1 + 4;
      }
      if (VelocityY != 0F) {
        size += 1 + 4;
      }
      if (VelocityZ != 0F) {
        size += 1 + 4;
      }
      return size;
    }

    public void MergeFrom(pb::CodedInputStream input) {
      account_ = 0;
      positionX_ = 0f;
      positionY_ = 0f;
      positionZ_ = 0f;
      rotationX_ = 0f;
      rotationY_ = 0f;
      rotationZ_ = 0f;
      rotationW_ = 0f;
      velocityX_ = 0f;
      velocityY_ = 0f;
      velocityZ_ = 0f;
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            Account = input.ReadInt32();
            break;
          }
          case 21: {
            PositionX = input.ReadFloat();
            break;
          }
          case 29: {
            PositionY = input.ReadFloat();
            break;
          }
          case 37: {
            PositionZ = input.ReadFloat();
            break;
          }
          case 45: {
            RotationX = input.ReadFloat();
            break;
          }
          case 53: {
            RotationY = input.ReadFloat();
            break;
          }
          case 61: {
            RotationZ = input.ReadFloat();
            break;
          }
          case 69: {
            RotationW = input.ReadFloat();
            break;
          }
          case 77: {
            VelocityX = input.ReadFloat();
            break;
          }
          case 85: {
            VelocityY = input.ReadFloat();
            break;
          }
          case 93: {
            VelocityZ = input.ReadFloat();
            break;
          }
        }
      }
    }

  }

  public partial class C2G_GetOtherPlayer : pb::IMessage {
    private static readonly pb::MessageParser<C2G_GetOtherPlayer> _parser = new pb::MessageParser<C2G_GetOtherPlayer>(() => (C2G_GetOtherPlayer)MessagePool.Instance.Fetch(typeof(C2G_GetOtherPlayer)));
    public static pb::MessageParser<C2G_GetOtherPlayer> Parser { get { return _parser; } }

    private int rpcId_;
    public int RpcId {
      get { return rpcId_; }
      set {
        rpcId_ = value;
      }
    }

    private int account_;
    public int Account {
      get { return account_; }
      set {
        account_ = value;
      }
    }

    public void WriteTo(pb::CodedOutputStream output) {
      if (Account != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Account);
      }
      if (RpcId != 0) {
        output.WriteRawTag(208, 5);
        output.WriteInt32(RpcId);
      }
    }

    public int CalculateSize() {
      int size = 0;
      if (RpcId != 0) {
        size += 2 + pb::CodedOutputStream.ComputeInt32Size(RpcId);
      }
      if (Account != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Account);
      }
      return size;
    }

    public void MergeFrom(pb::CodedInputStream input) {
      account_ = 0;
      rpcId_ = 0;
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            Account = input.ReadInt32();
            break;
          }
          case 720: {
            RpcId = input.ReadInt32();
            break;
          }
        }
      }
    }

  }

  public partial class G2C_OtherPlayerEnterMap : pb::IMessage {
    private static readonly pb::MessageParser<G2C_OtherPlayerEnterMap> _parser = new pb::MessageParser<G2C_OtherPlayerEnterMap>(() => (G2C_OtherPlayerEnterMap)MessagePool.Instance.Fetch(typeof(G2C_OtherPlayerEnterMap)));
    public static pb::MessageParser<G2C_OtherPlayerEnterMap> Parser { get { return _parser; } }

    private int account_;
    public int Account {
      get { return account_; }
      set {
        account_ = value;
      }
    }

    private float positionX_;
    public float PositionX {
      get { return positionX_; }
      set {
        positionX_ = value;
      }
    }

    private float positionY_;
    public float PositionY {
      get { return positionY_; }
      set {
        positionY_ = value;
      }
    }

    private float positionZ_;
    public float PositionZ {
      get { return positionZ_; }
      set {
        positionZ_ = value;
      }
    }

    public void WriteTo(pb::CodedOutputStream output) {
      if (Account != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(Account);
      }
      if (PositionX != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(PositionX);
      }
      if (PositionY != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(PositionY);
      }
      if (PositionZ != 0F) {
        output.WriteRawTag(37);
        output.WriteFloat(PositionZ);
      }
    }

    public int CalculateSize() {
      int size = 0;
      if (Account != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Account);
      }
      if (PositionX != 0F) {
        size += 1 + 4;
      }
      if (PositionY != 0F) {
        size += 1 + 4;
      }
      if (PositionZ != 0F) {
        size += 1 + 4;
      }
      return size;
    }

    public void MergeFrom(pb::CodedInputStream input) {
      account_ = 0;
      positionX_ = 0f;
      positionY_ = 0f;
      positionZ_ = 0f;
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            Account = input.ReadInt32();
            break;
          }
          case 21: {
            PositionX = input.ReadFloat();
            break;
          }
          case 29: {
            PositionY = input.ReadFloat();
            break;
          }
          case 37: {
            PositionZ = input.ReadFloat();
            break;
          }
        }
      }
    }

  }

  public partial class G2C_OtherPlayerPosition : pb::IMessage {
    private static readonly pb::MessageParser<G2C_OtherPlayerPosition> _parser = new pb::MessageParser<G2C_OtherPlayerPosition>(() => (G2C_OtherPlayerPosition)MessagePool.Instance.Fetch(typeof(G2C_OtherPlayerPosition)));
    public static pb::MessageParser<G2C_OtherPlayerPosition> Parser { get { return _parser; } }

    private static readonly pb::FieldCodec<int> _repeated_dirAccount_codec
        = pb::FieldCodec.ForInt32(10);
    private pbc::RepeatedField<int> dirAccount_ = new pbc::RepeatedField<int>();
    public pbc::RepeatedField<int> DirAccount {
      get { return dirAccount_; }
      set { dirAccount_ = value; }
    }

    private static readonly pb::FieldCodec<float> _repeated_positionX_codec
        = pb::FieldCodec.ForFloat(18);
    private pbc::RepeatedField<float> positionX_ = new pbc::RepeatedField<float>();
    public pbc::RepeatedField<float> PositionX {
      get { return positionX_; }
      set { positionX_ = value; }
    }

    private static readonly pb::FieldCodec<float> _repeated_positionY_codec
        = pb::FieldCodec.ForFloat(26);
    private pbc::RepeatedField<float> positionY_ = new pbc::RepeatedField<float>();
    public pbc::RepeatedField<float> PositionY {
      get { return positionY_; }
      set { positionY_ = value; }
    }

    private static readonly pb::FieldCodec<float> _repeated_positionZ_codec
        = pb::FieldCodec.ForFloat(34);
    private pbc::RepeatedField<float> positionZ_ = new pbc::RepeatedField<float>();
    public pbc::RepeatedField<float> PositionZ {
      get { return positionZ_; }
      set { positionZ_ = value; }
    }

    private static readonly pb::FieldCodec<float> _repeated_rotationX_codec
        = pb::FieldCodec.ForFloat(42);
    private pbc::RepeatedField<float> rotationX_ = new pbc::RepeatedField<float>();
    public pbc::RepeatedField<float> RotationX {
      get { return rotationX_; }
      set { rotationX_ = value; }
    }

    private static readonly pb::FieldCodec<float> _repeated_rotationY_codec
        = pb::FieldCodec.ForFloat(50);
    private pbc::RepeatedField<float> rotationY_ = new pbc::RepeatedField<float>();
    public pbc::RepeatedField<float> RotationY {
      get { return rotationY_; }
      set { rotationY_ = value; }
    }

    private static readonly pb::FieldCodec<float> _repeated_rotationZ_codec
        = pb::FieldCodec.ForFloat(58);
    private pbc::RepeatedField<float> rotationZ_ = new pbc::RepeatedField<float>();
    public pbc::RepeatedField<float> RotationZ {
      get { return rotationZ_; }
      set { rotationZ_ = value; }
    }

    private static readonly pb::FieldCodec<float> _repeated_rotationW_codec
        = pb::FieldCodec.ForFloat(66);
    private pbc::RepeatedField<float> rotationW_ = new pbc::RepeatedField<float>();
    public pbc::RepeatedField<float> RotationW {
      get { return rotationW_; }
      set { rotationW_ = value; }
    }

    private static readonly pb::FieldCodec<float> _repeated_velocityX_codec
        = pb::FieldCodec.ForFloat(74);
    private pbc::RepeatedField<float> velocityX_ = new pbc::RepeatedField<float>();
    public pbc::RepeatedField<float> VelocityX {
      get { return velocityX_; }
      set { velocityX_ = value; }
    }

    private static readonly pb::FieldCodec<float> _repeated_velocityY_codec
        = pb::FieldCodec.ForFloat(82);
    private pbc::RepeatedField<float> velocityY_ = new pbc::RepeatedField<float>();
    public pbc::RepeatedField<float> VelocityY {
      get { return velocityY_; }
      set { velocityY_ = value; }
    }

    private static readonly pb::FieldCodec<float> _repeated_velocityZ_codec
        = pb::FieldCodec.ForFloat(90);
    private pbc::RepeatedField<float> velocityZ_ = new pbc::RepeatedField<float>();
    public pbc::RepeatedField<float> VelocityZ {
      get { return velocityZ_; }
      set { velocityZ_ = value; }
    }

    private long serverTime_;
    public long ServerTime {
      get { return serverTime_; }
      set {
        serverTime_ = value;
      }
    }

    public void WriteTo(pb::CodedOutputStream output) {
      dirAccount_.WriteTo(output, _repeated_dirAccount_codec);
      positionX_.WriteTo(output, _repeated_positionX_codec);
      positionY_.WriteTo(output, _repeated_positionY_codec);
      positionZ_.WriteTo(output, _repeated_positionZ_codec);
      rotationX_.WriteTo(output, _repeated_rotationX_codec);
      rotationY_.WriteTo(output, _repeated_rotationY_codec);
      rotationZ_.WriteTo(output, _repeated_rotationZ_codec);
      rotationW_.WriteTo(output, _repeated_rotationW_codec);
      velocityX_.WriteTo(output, _repeated_velocityX_codec);
      velocityY_.WriteTo(output, _repeated_velocityY_codec);
      velocityZ_.WriteTo(output, _repeated_velocityZ_codec);
      if (ServerTime != 0L) {
        output.WriteRawTag(96);
        output.WriteInt64(ServerTime);
      }
    }

    public int CalculateSize() {
      int size = 0;
      size += dirAccount_.CalculateSize(_repeated_dirAccount_codec);
      size += positionX_.CalculateSize(_repeated_positionX_codec);
      size += positionY_.CalculateSize(_repeated_positionY_codec);
      size += positionZ_.CalculateSize(_repeated_positionZ_codec);
      size += rotationX_.CalculateSize(_repeated_rotationX_codec);
      size += rotationY_.CalculateSize(_repeated_rotationY_codec);
      size += rotationZ_.CalculateSize(_repeated_rotationZ_codec);
      size += rotationW_.CalculateSize(_repeated_rotationW_codec);
      size += velocityX_.CalculateSize(_repeated_velocityX_codec);
      size += velocityY_.CalculateSize(_repeated_velocityY_codec);
      size += velocityZ_.CalculateSize(_repeated_velocityZ_codec);
      if (ServerTime != 0L) {
        size += 1 + pb::CodedOutputStream.ComputeInt64Size(ServerTime);
      }
      return size;
    }

    public void MergeFrom(pb::CodedInputStream input) {
      dirAccount_.Clear();
      positionX_.Clear();
      positionY_.Clear();
      positionZ_.Clear();
      rotationX_.Clear();
      rotationY_.Clear();
      rotationZ_.Clear();
      rotationW_.Clear();
      velocityX_.Clear();
      velocityY_.Clear();
      velocityZ_.Clear();
      serverTime_ = 0;
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 10:
          case 8: {
            dirAccount_.AddEntriesFrom(input, _repeated_dirAccount_codec);
            break;
          }
          case 18:
          case 21: {
            positionX_.AddEntriesFrom(input, _repeated_positionX_codec);
            break;
          }
          case 26:
          case 29: {
            positionY_.AddEntriesFrom(input, _repeated_positionY_codec);
            break;
          }
          case 34:
          case 37: {
            positionZ_.AddEntriesFrom(input, _repeated_positionZ_codec);
            break;
          }
          case 42:
          case 45: {
            rotationX_.AddEntriesFrom(input, _repeated_rotationX_codec);
            break;
          }
          case 50:
          case 53: {
            rotationY_.AddEntriesFrom(input, _repeated_rotationY_codec);
            break;
          }
          case 58:
          case 61: {
            rotationZ_.AddEntriesFrom(input, _repeated_rotationZ_codec);
            break;
          }
          case 66:
          case 69: {
            rotationW_.AddEntriesFrom(input, _repeated_rotationW_codec);
            break;
          }
          case 74:
          case 77: {
            velocityX_.AddEntriesFrom(input, _repeated_velocityX_codec);
            break;
          }
          case 82:
          case 85: {
            velocityY_.AddEntriesFrom(input, _repeated_velocityY_codec);
            break;
          }
          case 90:
          case 93: {
            velocityZ_.AddEntriesFrom(input, _repeated_velocityZ_codec);
            break;
          }
          case 96: {
            ServerTime = input.ReadInt64();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
