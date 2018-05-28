// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FutureRealities;


public class GoogleMapsManager : MonoBehaviour
{
	public RawImage img;

    string url;

    public float lat;
    public float lon;

    LocationInfo li;

    public int zoom = 14;
    public int mapWidth = 640;
    public int mapHeight = 640;

    public enum mapType { roadmap, satellite, hybrid, terrain }
    public mapType mapSelected;
    public int scale;

	private bool _GetHomeSceneGameObjects;
    private GameObject _GPSLocalitation;
    private GPSLocalitation _GPSLocalitation_;

    IEnumerator Map()
    {
        url = "https://maps.googleapis.com/maps/api/staticmap?center=" + lat + "," + lon +
            "&zoom=" + zoom + "&size=" + mapWidth + "x" + mapHeight + "&scale=" + scale +
            "&maptype=" + mapSelected +
            "&markers=color:blue%7Clabel:S%7C40.702147,-74.015794&markers=color:green%7Clabel:G%7C40.711614,-74.012318&markers=color:red%7Clabel:C%7C40.718217,-73.998284&key=" +
			ID.GoogleMapsApi;
        WWW www = new WWW(url);
        yield return www;
        img.texture = www.texture;
        img.SetNativeSize();
    }
    // Use this for initialization
    void Start()
    {
		GPSLocalitationTManager();
        img = gameObject.GetComponent<RawImage>();
        StartCoroutine(Map());
    }

    // Update is called once per frame
    void Update()
    {
    }

	private void GPSLocalitationTManager()
    {
        if ((SceneManager.GetActiveScene().name == ID.SceneNames[(int)ID.Scenes.Home]) && !_GetHomeSceneGameObjects)
        {
            _GPSLocalitation = GameObject.FindWithTag("_GPSLocalitation");
            _GPSLocalitation_ = _GPSLocalitation.GetComponent<GPSLocalitation>();
            _GetHomeSceneGameObjects = true;

        }
        else
        {
            _GetHomeSceneGameObjects = false;
        }

        if ((SceneManager.GetActiveScene().name == ID.SceneNames[(int)ID.Scenes.Home]))
        {
			lat = _GPSLocalitation_.Latitude;
			lon = _GPSLocalitation_.Longitude;
			Debug.Log(lat);
			Debug.Log(lon);
        }
    }
}