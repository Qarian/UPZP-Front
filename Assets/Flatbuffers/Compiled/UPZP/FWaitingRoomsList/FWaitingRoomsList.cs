// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace UPZP.FWaitingRoomsList
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct FWaitingRoomsList : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static FWaitingRoomsList GetRootAsFWaitingRoomsList(ByteBuffer _bb) { return GetRootAsFWaitingRoomsList(_bb, new FWaitingRoomsList()); }
  public static FWaitingRoomsList GetRootAsFWaitingRoomsList(ByteBuffer _bb, FWaitingRoomsList obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public FWaitingRoomsList __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public UPZP.FWaitingRoomsList.FWaitingRoom? WaitingRoom(int j) { int o = __p.__offset(4); return o != 0 ? (UPZP.FWaitingRoomsList.FWaitingRoom?)(new UPZP.FWaitingRoomsList.FWaitingRoom()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int WaitingRoomLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<UPZP.FWaitingRoomsList.FWaitingRoomsList> CreateFWaitingRoomsList(FlatBufferBuilder builder,
      VectorOffset waitingRoomOffset = default(VectorOffset)) {
    builder.StartTable(1);
    FWaitingRoomsList.AddWaitingRoom(builder, waitingRoomOffset);
    return FWaitingRoomsList.EndFWaitingRoomsList(builder);
  }

  public static void StartFWaitingRoomsList(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddWaitingRoom(FlatBufferBuilder builder, VectorOffset waitingRoomOffset) { builder.AddOffset(0, waitingRoomOffset.Value, 0); }
  public static VectorOffset CreateWaitingRoomVector(FlatBufferBuilder builder, Offset<UPZP.FWaitingRoomsList.FWaitingRoom>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateWaitingRoomVectorBlock(FlatBufferBuilder builder, Offset<UPZP.FWaitingRoomsList.FWaitingRoom>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartWaitingRoomVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<UPZP.FWaitingRoomsList.FWaitingRoomsList> EndFWaitingRoomsList(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<UPZP.FWaitingRoomsList.FWaitingRoomsList>(o);
  }
  public static void FinishFWaitingRoomsListBuffer(FlatBufferBuilder builder, Offset<UPZP.FWaitingRoomsList.FWaitingRoomsList> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedFWaitingRoomsListBuffer(FlatBufferBuilder builder, Offset<UPZP.FWaitingRoomsList.FWaitingRoomsList> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
