// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace Upzp.GameStatus
{

using global::System;
using global::System.Collections.Generic;
using global::FlatBuffers;

/// Team
public struct Team : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_1_12_0(); }
  public static Team GetRootAsTeam(ByteBuffer _bb) { return GetRootAsTeam(_bb, new Team()); }
  public static Team GetRootAsTeam(ByteBuffer _bb, Team obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Team __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Points { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public Upzp.GameStatus.Player? Players(int j) { int o = __p.__offset(6); return o != 0 ? (Upzp.GameStatus.Player?)(new Upzp.GameStatus.Player()).__assign(__p.__indirect(__p.__vector(o) + j * 4), __p.bb) : null; }
  public int PlayersLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }

  public static Offset<Upzp.GameStatus.Team> CreateTeam(FlatBufferBuilder builder,
      int points = 0,
      VectorOffset playersOffset = default(VectorOffset)) {
    builder.StartTable(2);
    Team.AddPlayers(builder, playersOffset);
    Team.AddPoints(builder, points);
    return Team.EndTeam(builder);
  }

  public static void StartTeam(FlatBufferBuilder builder) { builder.StartTable(2); }
  public static void AddPoints(FlatBufferBuilder builder, int points) { builder.AddInt(0, points, 0); }
  public static void AddPlayers(FlatBufferBuilder builder, VectorOffset playersOffset) { builder.AddOffset(1, playersOffset.Value, 0); }
  public static VectorOffset CreatePlayersVector(FlatBufferBuilder builder, Offset<Upzp.GameStatus.Player>[] data) { builder.StartVector(4, data.Length, 4); for (int i = data.Length - 1; i >= 0; i--) builder.AddOffset(data[i].Value); return builder.EndVector(); }
  public static VectorOffset CreatePlayersVectorBlock(FlatBufferBuilder builder, Offset<Upzp.GameStatus.Player>[] data) { builder.StartVector(4, data.Length, 4); builder.Add(data); return builder.EndVector(); }
  public static void StartPlayersVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(4, numElems, 4); }
  public static Offset<Upzp.GameStatus.Team> EndTeam(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    builder.Required(o, 6);  // players
    return new Offset<Upzp.GameStatus.Team>(o);
  }
};


}
