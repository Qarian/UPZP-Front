using FlatBuffers;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Networking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Upzp.GameStatus;
using Upzp.PlayerInput;
public class CharacterManager : MonoBehaviour
{
    public PCController PCC;
    public GameObject PCPrefab;
    public GameObject NPCPrefab;
    public GameObject CLPrefab;
    public AbstractMap map;
    public uint id;
    public Dictionary<uint,Transform> targets;

    private void Start()
    {
        if (!GameObject.FindObjectOfType<ControllersManager>())
        {

        }
    }

    Vector3 start_position;
    public void createCL(List<Collectable> CLdata)
    {

        GameObject tempGameObject = null;
        List<GameObject> currentCLs = GameObject.FindGameObjectsWithTag("CLPrefab").ToList();
        int currentIndex = 0, countDifference = CLdata.Count - currentCLs.Count;


        // extract new positions of all collectables
        Vector3[] CLpositions = new Vector3[CLdata.Count];
        for (int i = 0; i < CLdata.Count; i++)
        {
            CLpositions[i] = Conversions.GeoToWorldPosition(CLdata[i].position.x, CLdata[i].position.y, map.CenterMercator, map.WorldRelativeScale).ToVector3xz();
        }

        // instantiate new collectables if needed
        if (countDifference > 0)
        {
            for (int i = 0; i < countDifference; i++)
            {
                currentCLs.Add(Instantiate(CLPrefab, CLpositions[i], Quaternion.identity));
                currentIndex++;
            }
        }
        // destroy unnecessary collectables
        else if (countDifference < 0)
        {
            for (int i = (-countDifference); i > 0; i--)
            {
                tempGameObject = currentCLs[i - 1];
                currentCLs.RemoveAt(i - 1);
                tempGameObject.Destroy();
            }
        }

        // update positions for the remaining collectables
        for (int i = 0; i < (currentCLs.Count - currentIndex); i++)
        {
            currentCLs[i].transform.position = CLpositions[currentIndex + i];
        }
    }
    
    public void createPC(PlayerData PCdata)
    {
        var pos = PCdata.position;
        start_position = Conversions.GeoToWorldPosition(pos.x, pos.y, map.CenterMercator, map.WorldRelativeScale).ToVector3xz();
        GameObject PC = Instantiate(PCPrefab, start_position, Quaternion.identity);
        Transform tatget = PC.transform.Find("Target").transform;
        targets.Add(PCdata.id, tatget);
        PCC.target = tatget;
        PCC.character = PC.transform.Find("Body");
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

        createCL(gameStats.cls);

        foreach (Dictionary<uint, PlayerData> team in gameStats.teams)
        {
            foreach (uint id in team.Keys)
            {
                var pos = team[id].position;
                targets[id].position = Conversions.GeoToWorldPosition(pos.x, pos.y, map.CenterMercator, map.WorldRelativeScale).ToVector3xz();

            }
        }
    }

    internal void Send(float movementAngle)
    {
        FlatBufferBuilder biuld = new FlatBufferBuilder(200);
        var offset = Upzp.PlayerInput.Input.CreateInput(biuld, 0, id, false, movementAngle, true);
        Upzp.PlayerInput.Input.FinishInputBuffer(biuld, offset);
        var mess = biuld.SizedByteArray();
        Communication.SendToServer(new Message(mess, 101));
    }

    internal void Initialize(GameStats gameStats)

    {

        createCL(gameStats.cls);

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
