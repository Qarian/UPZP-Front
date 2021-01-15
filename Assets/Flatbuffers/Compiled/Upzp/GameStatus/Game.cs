// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Upzp.GameStatus
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

/// Game includes all information about current game status.
public struct Game : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static Game GetRootAsGame(ByteBuffer _bb) { return GetRootAsGame(_bb, new Game()); }
  public static Game GetRootAsGame(ByteBuffer _bb, Game obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Game __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public ulong Sequence { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetUlong(o + __p.bb_pos) : (ulong)0; } }
  public Upzp.GameStatus.Team? Teams(int j) { int o = __p.__offset(6); return o != 0 ? (Upzp.GameStatus.Team?)(new Upzp.GameStatus.Team()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int TeamsLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }
  public Upzp.GameStatus.PointBox? Boxes(int j) { int o = __p.__offset(8); return o != 0 ? (Upzp.GameStatus.PointBox?)(new Upzp.GameStatus.PointBox()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int BoxesLength { get { int o = __p.__offset(8); return o != 0 ? __p.__vector_len(o) : 0; } }
  public bool Finished { get { int o = __p.__offset(10); return o != 0 ? 0!=__p.bb.Get(o + __p.bb_pos) : (bool)false; } }

  public static Offset<Upzp.GameStatus.Game> CreateGame(FlatBufferBuilder builder,
      ulong sequence = 0,
      VectorOffset teamsOffset = default(VectorOffset),
      VectorOffset boxesOffset = default(VectorOffset),
      bool finished = false) {
    builder.StartTable(4);
    Game.AddSequence(builder, sequence);
    Game.AddBoxes(builder, boxesOffset);
    Game.AddTeams(builder, teamsOffset);
    Game.AddFinished(builder, finished);
    return Game.EndGame(builder);
  }

  public static void StartGame(FlatBufferBuilder builder) { builder.StartTable(4); }
  public static void AddSequence(FlatBufferBuilder builder, ulong sequence) { builder.AddUlong(0, sequence, 0); }
  public static void AddTeams(FlatBufferBuilder builder, VectorOffset teamsOffset) { builder.AddOffset(1, teamsOffset.Value, 0); }
  public static VectorOffset CreateTeamsVector(FlatBufferBuilder builder, Offset<Upzp.GameStatus.Team>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateTeamsVectorBlock(FlatBufferBuilder builder, Offset<Upzp.GameStatus.Team>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartTeamsVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddBoxes(FlatBufferBuilder builder, VectorOffset boxesOffset) { builder.AddOffset(2, boxesOffset.Value, 0); }
  public static VectorOffset CreateBoxesVector(FlatBufferBuilder builder, Offset<Upzp.GameStatus.PointBox>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreateBoxesVectorBlock(FlatBufferBuilder builder, Offset<Upzp.GameStatus.PointBox>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartBoxesVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static void AddFinished(FlatBufferBuilder builder, bool finished) { builder.AddBool(3, finished, false); }
  public static Offset<Upzp.GameStatus.Game> EndGame(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    builder.Required(o, 6);  // teams
    return new Offset<Upzp.GameStatus.Game>(o);
  }
  public static void FinishGameBuffer(FlatBufferBuilder builder, Offset<Upzp.GameStatus.Game> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedGameBuffer(FlatBufferBuilder builder, Offset<Upzp.GameStatus.Game> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}