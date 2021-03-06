// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace TestData
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

public struct Tester : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static Tester GetRootAsTester(ByteBuffer _bb) { return GetRootAsTester(_bb, new Tester()); }
  public static Tester GetRootAsTester(ByteBuffer _bb, Tester obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Tester __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public TestData.Vec3? Pos { get { int o = __p.__offset(4); return o != 0 ? (TestData.Vec3?)(new TestData.Vec3()).__assign(o + __p.bb_pos, __p.bb) : null; } }
  public int SomeInteger { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)123; } }
  public string SomeString { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetSomeStringBytes() { return __p.__vector_as_span<byte>(8, 1); }
#else
  public ArraySegment<byte>? GetSomeStringBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetSomeStringArray() { return __p.__vector_as_array<byte>(8); }

  public static void StartTester(FlatBufferBuilder builder) { builder.StartTable(3); }
  public static void AddPos(FlatBufferBuilder builder, Offset<TestData.Vec3> posOffset) { builder.AddStruct(0, posOffset.Value, 0); }
  public static void AddSomeInteger(FlatBufferBuilder builder, int someInteger) { builder.AddInt(1, someInteger, 123); }
  public static void AddSomeString(FlatBufferBuilder builder, StringOffset someStringOffset) { builder.AddOffset(2, someStringOffset.Value, 0); }
  public static Offset<TestData.Tester> EndTester(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<TestData.Tester>(o);
  }
  public static void FinishTesterBuffer(FlatBufferBuilder builder, Offset<TestData.Tester> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedTesterBuffer(FlatBufferBuilder builder, Offset<TestData.Tester> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
