// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FutureRealities;


public class BackgroundAudioManager : MonoBehaviour {

    private Scene _CurrentScene;
    private AudioSource _AudioSource;
    private ID.Scenes _ScenceAudioSourceStop;
    private string[] _SceneNames = ID.SceneNames;

    private bool created;


    // Use this for initialization
    void Start () {
        _ScenceAudioSourceStop = ID.Scenes.opening;
        _AudioSource = GetComponent<AudioSource>();
        _AudioSource.Play();
}

// Update is called once per frame
void Update () {
        _CurrentScene = SceneManager.GetActiveScene();

        if (_SceneNames[(int)ID.Scenes.opening] == _CurrentScene.name)
        {
            DestroyObject(this.gameObject);
            created = false;
        }
        else if ((_SceneNames[(int)ID.Scenes.VR_A] == _CurrentScene.name) && !created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }
}
