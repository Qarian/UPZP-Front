// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace mainServer.schemas.FError
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct FError : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static FError GetRootAsFError(ByteBuffer _bb) { return GetRootAsFError(_bb, new FError()); }
  public static FError GetRootAsFError(ByteBuffer _bb, FError obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public FError __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public string Message { get { int o = __p.__offset(4); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetMessageBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetMessageBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetMessageArray() { return __p.__vector_as_array<byte>(4); }

  public static Offset<mainServer.schemas.FError.FError> CreateFError(FlatBufferBuilder builder,
      StringOffset messageOffset = default(StringOffset)) {
    builder.StartTable(1);
    FError.AddMessage(builder, messageOffset);
    return FError.EndFError(builder);
  }

  public static void StartFError(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddMessage(FlatBufferBuilder builder, StringOffset messageOffset) { builder.AddOffset(0, messageOffset.Value, 0); }
  public static Offset<mainServer.schemas.FError.FError> EndFError(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<mainServer.schemas.FError.FError>(o);
  }
  public static void FinishFErrorBuffer(FlatBufferBuilder builder, Offset<mainServer.schemas.FError.FError> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedFErrorBuffer(FlatBufferBuilder builder, Offset<mainServer.schemas.FError.FError> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
