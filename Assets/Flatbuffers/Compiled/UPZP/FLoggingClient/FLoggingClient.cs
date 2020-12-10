// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace UPZP.FLoggingClient
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct FLoggingClient : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static FLoggingClient GetRootAsFLoggingClient(ByteBuffer _bb) { return GetRootAsFLoggingClient(_bb, new FLoggingClient()); }
  public static FLoggingClient GetRootAsFLoggingClient(ByteBuffer _bb, FLoggingClient obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public FLoggingClient __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Name { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetNameBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetNameBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetNameArray() { return __p.__vector_as_array<byte>(4); }
  public string Password { get { int o = __p.__offset(6); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetPasswordBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetPasswordBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetPasswordArray() { return __p.__vector_as_array<byte>(6); }

  public static Offset<UPZP.FLoggingClient.FLoggingClient> CreateFLoggingClient(FlatBufferBuilder builder,
      StringOffset nameOffset = default(StringOffset),
      StringOffset passwordOffset = default(StringOffset)) {
    builder.StartTable(2);
    FLoggingClient.AddPassword(builder, passwordOffset);
    FLoggingClient.AddName(builder, nameOffset);
    return FLoggingClient.EndFLoggingClient(builder);
  }

  public static void StartFLoggingClient(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset) { builder.AddOffset(0, nameOffset.Value, 0); }
  public static void AddPassword(FlatBufferBuilder builder, StringOffset passwordOffset) { builder.AddOffset(1, passwordOffset.Value, 0); }
  public static Offset<UPZP.FLoggingClient.FLoggingClient> EndFLoggingClient(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<UPZP.FLoggingClient.FLoggingClient>(o);
  }
  public static void FinishFLoggingClientBuffer(FlatBufferBuilder builder, Offset<UPZP.FLoggingClient.FLoggingClient> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedFLoggingClientBuffer(FlatBufferBuilder builder, Offset<UPZP.FLoggingClient.FLoggingClient> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
