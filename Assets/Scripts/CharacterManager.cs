﻿using FlatBuffers;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Upzp.GameStatus;

public class CharacterManager : MonoBehaviour
{
    public PCController PCC;
    public GameObject PCPrefab;
    public GameObject NPCPrefab;
    public GameObject CLPrefab;
    public AbstractMap map;
    public uint id;
    bool initialized = false;
    public Dictionary<uint,Transform> targets;

    private ulong sequence = 2;

    public void Update()
    {
        if (GameStartController.GSC.gameStats.isUpdated)
        {
            GameStartController.GSC.gameStats.isUpdated = false;
            if (!initialized)
            {
                Initialize(GameStartController.GSC.gameStats);
                PCC.isLoaded = true;
            }
            else {
                UpdateChrachters(GameStartController.GSC.gameStats);
            }
        }
    }

    public void createCL(Collectable cl)
    { 
    
    }
    
    Vector3 start_position;
    
    public void createPC(PlayerData PCdata)
    {
        var pos = PCdata.position;
        start_position = Conversions.GeoToWorldPosition(pos.x, pos.y, map.CenterMercator, map.WorldRelativeScale).ToVector3xz();
        GameObject PC = Instantiate(PCPrefab, start_position, Quaternion.identity);
        Transform tatget = PC.transform.Find("Target").transform;
        targets.Add(PCdata.id, tatget);
        PCC.target = tatget;
        PCC.character = PC.transform.GetChild(0);
        PCC.dest = PCC.character.position;
    }
    
    public void createNPC(PlayerData NPCdata)
    {
        var pos = NPCdata.position;
        start_position = Conversions.GeoToWorldPosition(pos.x, pos.y, map.CenterMercator, map.WorldRelativeScale).ToVector3xz();
        GameObject NPC = Instantiate(NPCPrefab, start_position, Quaternion.identity);
        Transform tatget = NPC.transform.Find("Target").transform;
        targets.Add(NPCdata.id, tatget);

    }

    internal void UpdateChrachters(GameStats gameStats)
    {
        foreach (Dictionary<uint, PlayerData> team in gameStats.teams)
        {
            foreach (uint id in team.Keys)
            {   
                var pos = team[id].position;
                if (targets.ContainsKey(id))
                {
                    targets[id].position = Conversions.GeoToWorldPosition(pos.x, pos.y, map.CenterMercator, map.WorldRelativeScale).ToVector3xz();
                }
                else {
                    createNPC(team[id]);
                }
            }
        }
    }

    internal void Send(float movementAngle, bool move = true)
    {
        FlatBufferBuilder biuld = new FlatBufferBuilder(200);
        var offset = Upzp.PlayerInput.Input.CreateInput(biuld, sequence, id, false, movementAngle, move);
        Upzp.PlayerInput.Input.FinishInputBuffer(biuld, offset);
        var mess = biuld.SizedByteArray();
        Communication.SendToGame(new Message(mess, 101));
        sequence++;
    }

    internal void Initialize(GameStats gameStats)
    {
        initialized = true;

        targets = new Dictionary<uint, Transform>();

        foreach (Dictionary<uint, PlayerData> team in gameStats.teams)
        {
            foreach (uint id in team.Keys)
            {
                if (id != gameStats.PCid)
                {
                    createNPC(team[id]);
                }

                else 
                {
                    createPC(team[id]);
                }

            }
        }

    }
}
