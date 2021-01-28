using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using UnityEngine;


	public class InitializeMapWithLocationProvider : MonoBehaviour
	{
		[SerializeField]
		AbstractMap _map;

		ILocationProvider _locationProvider;
    
		private void Awake()
		{
		_map.InitializeOnStart = false;
			// Prevent double initialization of the map. 
			
		}
	public void Start()
	{
		
	}
	/*
			protected virtual IEnumerator Start()
			{
				yield return null;
				_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
				_locationProvider.OnLocationUpdated += LocationProvider_OnLocationUpdated; ;
			}

			void LocationProvider_OnLocationUpdated(Unity.Location.Location location)
			{
				_locationProvider.OnLocationUpdated -= LocationProvider_OnLocationUpdated;
				_map.Initialize(location.LatitudeLongitude, _map.AbsoluteZoom);
			}
			*/
}

