// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FutureRealities;

public class LoadVRGameObjects : MonoBehaviour {

    public bool created = false;
    public List<GameObject> VRGameObjects = new List<GameObject>();
    private bool VRGameObjectsActive = false;


    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

    // Use this for initialization
    void Start () {
        foreach (GameObject VRGameObject in VRGameObjects)
        {
            VRGameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if ((SceneManager.GetActiveScene().name == ID.SceneNames[(int)ID.Scenes.VR_A]) && !VRGameObjectsActive)
        {
            foreach (GameObject VRGameObject in VRGameObjects)
            {
                VRGameObject.SetActive(true);
            }
            VRGameObjectsActive = true;
        }
        else if ((SceneManager.GetActiveScene().name != ID.SceneNames[(int)ID.Scenes.VR_A]) && VRGameObjectsActive)
        {
            foreach (GameObject VRGameObject in VRGameObjects)
            {
                VRGameObject.SetActive(false);
            }
            VRGameObjectsActive = false;

        }
    }
}
