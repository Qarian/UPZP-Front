// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Upzp.GameStatus
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

/// Point box that is collected by the players
public struct PointBox : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static PointBox GetRootAsPointBox(ByteBuffer _bb) { return GetRootAsPointBox(_bb, new PointBox()); }
  public static PointBox GetRootAsPointBox(ByteBuffer _bb, PointBox obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public PointBox __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public Upzp.GameStatus.Position? Position { get { int o = __p.__offset(4); return o != 0 ? (Upzp.GameStatus.Position?)(new Upzp.GameStatus.Position()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public int Value { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static void StartPointBox(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddPosition(FlatBufferBuilder builder, Offset<Upzp.GameStatus.Position> positionOffset) { builder.AddStruct(0, positionOffset.Value, 0); }
  public static void AddValue(FlatBufferBuilder builder, int value) { builder.AddInt(1, value, 0); }
  public static Offset<Upzp.GameStatus.PointBox> EndPointBox(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    builder.Required(o, 4);  // position
    return new Offset<Upzp.GameStatus.PointBox>(o);
  }
};


}
