using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mock : MonoBehaviour
{public CharacterManager CM;
    public AbstractMap map;
    void Start()
    {
        CM.createNPC(Vector3.one);
        CM.createPC(Vector3.zero);
        Init(Vector2d.one);
    }


    public void Send(float direction)
    {
        Debug.Log(direction);
    }

    public void Init(Vector2d map_center)
    {
        map.Initialize(map_center, map.AbsoluteZoom);

    }
    public void Get(List<Vector2> new_positions)
    { List<Vector3> unityPositions = new List<Vector3>();
        foreach( Vector2 pos in new_positions)
            {
            unityPositions.Add(Conversions.GeoToWorldPosition(pos.x, pos.y, map.CenterMercator, map.WorldRelativeScale).ToVector3xz());
        }
        CM.UpdateCharachterPositions(unityPositions);
    }
}
