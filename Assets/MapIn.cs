using Mapbox.Unity.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIn : MonoBehaviour
{
	[SerializeField]
	AbstractMap _map;



	private void Awake()
	{
		_map.InitializeOnStart = false;
		// Prevent double initialization of the map. 

	}
	public void Start()
	{
		_map.Initialize(GameStartController.GSC.gameStats.mapCenter, _map.AbsoluteZoom);
	}
}
