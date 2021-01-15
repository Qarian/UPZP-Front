using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public PCController PCC;
    public GameObject PCPrefab;
    public GameObject NPCPrefab;

    public List<Transform> targets = new List<Transform>();
    public void UpdateCharachterPositions(List<Vector3> new_positions) {
        for (int i = 0;i<new_positions.Count ; i++)
        {
            targets[i].position = new_positions[i];
        }
    }


    public void createPC(Vector3 start_position)
    {
        GameObject PC = Instantiate(PCPrefab, start_position, Quaternion.identity);
        Transform tatget = PC.transform.Find("Target").transform;
        targets.Add(tatget);
        PCC.target = tatget;
        PCC.character = PC;
    }
    public void createNPC(Vector3 start_position)
    {
        GameObject NPC = Instantiate(NPCPrefab, start_position, Quaternion.identity);
        Transform tatget = NPC.transform.Find("Target").transform;
        targets.Add(tatget);

    }


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
