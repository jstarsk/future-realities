// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.using System.Collections;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GPSLocalitation : MonoBehaviour
{
	public static GPSLocalitation Instance { set; get; }
    
	public float Latitude = 99.99999f;
	public float Longitude = 99.99999f;

	// Use this for initialization
	private void Start()
	{
		Instance = this;
		DontDestroyOnLoad(this.gameObject);
		StartCoroutine(StartGPSLocalitation());
	}
    
	IEnumerator StartGPSLocalitation()
	{
		// First, check if user has location service enabled
		if (!Input.location.isEnabledByUser)
			yield break;

		// Start service before querying location
		Input.location.Start();

		// Wait until service initializes
		int maxWait = 20;
		while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
		{
			yield return new WaitForSeconds(1);
			maxWait--;
		}

		// Service didn't initialize in 20 seconds
		if (maxWait < 1)
		{
			print("Timed out");
			yield break;
		}

		// Connection has failed
		if (Input.location.status == LocationServiceStatus.Failed)
		{
			print("Unable to determine device location");
			yield break;
		}
		else
		{
			// Access granted and location value could be retrieved
			Latitude = Input.location.lastData.latitude;
			Longitude = Input.location.lastData.longitude;
			//print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
		}

		// Stop service if there is no need to query location updates continuously
		Input.location.Stop();
	}
}