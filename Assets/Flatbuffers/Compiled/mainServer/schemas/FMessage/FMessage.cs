// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace mainServer.schemas.FMessage
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct FMessage : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static FMessage GetRootAsFMessage(ByteBuffer _bb) { return GetRootAsFMessage(_bb, new FMessage()); }
  public static FMessage GetRootAsFMessage(ByteBuffer _bb, FMessage obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public FMessage __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public mainServer.schemas.FMessage.FMessageType MessageType { get { int o = __p.__offset(4); return o != 0 ? (mainServer.schemas.FMessage.FMessageType)__p.bb.GetSbyte(o + __p.bb_pos) : mainServer.schemas.FMessage.FMessageType.StartGame; } }

  public static Offset<mainServer.schemas.FMessage.FMessage> CreateFMessage(FlatBufferBuilder builder,
      mainServer.schemas.FMessage.FMessageType messageType = mainServer.schemas.FMessage.FMessageType.StartGame) {
    builder.StartTable(1);
    FMessage.AddMessageType(builder, messageType);
    return FMessage.EndFMessage(builder);
  }

  public static void StartFMessage(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddMessageType(FlatBufferBuilder builder, mainServer.schemas.FMessage.FMessageType messageType) { builder.AddSbyte(0, (sbyte)messageType, 0); }
  public static Offset<mainServer.schemas.FMessage.FMessage> EndFMessage(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<mainServer.schemas.FMessage.FMessage>(o);
  }
  public static void FinishFMessageBuffer(FlatBufferBuilder builder, Offset<mainServer.schemas.FMessage.FMessage> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedFMessageBuffer(FlatBufferBuilder builder, Offset<mainServer.schemas.FMessage.FMessage> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
