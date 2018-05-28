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

public class GPSTxt : MonoBehaviour {
	
	private bool _GetHomeSceneGameObjects;
    private GameObject _GPSLocalitation;
	private GPSLocalitation _GPSLocalitation_;
	private Text _GPSLocalitationTxT;

	// Use this for initialization
	void Start () {
		_GPSLocalitationTxT = GetComponent<Text>();
	}
	
	//Update is called once per frame
    void Update()
    {
        GPSLocalitationTxTManager();
    }

    private void GPSLocalitationTxTManager()
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
			_GPSLocalitationTxT.text = string.Format("Latitude: {0} - Longitude: {1}", _GPSLocalitation_.Latitude.ToString(), _GPSLocalitation_.Longitude.ToString());
        }
    }
}
