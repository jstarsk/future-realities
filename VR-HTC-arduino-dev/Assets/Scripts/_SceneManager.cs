// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FutureRealities;

public class _SceneManager : MonoBehaviour
{
    public ID.Scenes scene;

    public GameObject GameObjectTrigger;

    private OpeningManager _OpeningManager;
    private MenuButtonManager _MenuButtonManager;
    private GameObject _LoadingScreen;
    private bool _TriggerLoadGameObjects;
    private Slider _slider;
    private float _FadeOutTime;
    private float _FadeInTime;
    private string _SceneName;
    private string[] _SceneNames = ID.SceneNames;

    // Use this for initialization
    void Start()
    {
        switch (scene)
        {
            case ID.Scenes.startExperience:
                {
                    _LoadingScreen = GameObjectTrigger;
                    _slider = GameObjectTrigger.GetComponentInChildren<Slider>();
                    _LoadingScreen.SetActive(false);
                    break;
                }
            case ID.Scenes.LoadVRGameObjects:
                {
                    _TriggerLoadGameObjects = true;
                    break;
                }
            case ID.Scenes.opening:
                {
                    _OpeningManager = GameObjectTrigger.GetComponent<OpeningManager>();
                    break;
                }
            case ID.Scenes.VR_A:
                {
                    _MenuButtonManager = GameObjectTrigger.GetComponent<MenuButtonManager>();
                    break;
                }
            // ADDING  MORE SCENES AS YOU NEED. REMENBER TO EDIT THE LoadSceneController
            //case ID.Scenes.VR_n:
            //    {

            //        break;
            //    }
            case ID.Scenes.ending:
                {
                    _OpeningManager = GameObjectTrigger.GetComponent<OpeningManager>();
                    break;
                }
        }
        _FadeOutTime = 0.5f;
        _FadeInTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        LoadSceneController();
    }

    public void LoadSceneController()
    {
        switch (scene)
        {
            case ID.Scenes.LoadVRGameObjects:
                {
                    if (_TriggerLoadGameObjects)
                    {
                        LoadManager(ID.Scenes.opening);
                    }
                    break;
                }
            case ID.Scenes.opening:
                {
                    if (_OpeningManager.Trigger)
                    {
                        LoadManager(ID.Scenes.VR_A);
                    }
                    break;
                }
            case ID.Scenes.VR_A:
                {
                    if (_MenuButtonManager.Trigger)
                    {
                        LoadManager(ID.Scenes.ending);
                    }
                    break;
                }
            case ID.Scenes.ending:
                {
                    if (_OpeningManager.Trigger)
                    {
                        LoadManager(ID.Scenes.opening);
                    }
                    break;
                }
        }
    }

    public void LoadExpericence(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        _LoadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            _slider.value = progress;
            yield return null;
        }
    }

    private void LoadManager(ID.Scenes _sceneNameToLoad)
    {
        _SceneName = _SceneNames[(int)_sceneNameToLoad];
        SteamVR_LoadLevel.Begin(_SceneName, false, _FadeOutTime, _FadeInTime, 0, 0, 0, 1);
    }
}