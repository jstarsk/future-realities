// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FutureRealities;


public class ButtonManager : MonoBehaviour {

	private GameObject _DataCollectorGameObject;
	private DataCollector _DataCollector;
	private bool _GetLoginSceneGameObjects;
	private GameObject _Shooter;
	private ShooterManager _ShooterManager;
	private GameObject _NewARAdd;
	private ARAddManager _ARAddManager;
	private int _ARAddAmount;
	private int _ARAddCounter;

	// Use this for initialization
	void Start () {
		_ARAddAmount = 6;
	}
	
	// Update is called once per frame
	void Update () {
		if ((SceneManager.GetActiveScene().name == ID.SceneNames[(int)ID.Scenes.ARAdd]) && !_GetLoginSceneGameObjects)
        {
			_Shooter = GameObject.FindWithTag("MainCamera");
			_ShooterManager = _Shooter.GetComponent<ShooterManager>();
			_NewARAdd = GameObject.FindWithTag("_NewARAdd");
			_ARAddManager = _NewARAdd.GetComponent<ARAddManager>();
			_GetLoginSceneGameObjects = true;
			Debug.Log(_ARAddManager.ARAddType);
        }
	}

	public void OnClickLogin(){
		_DataCollectorGameObject = GameObject.FindWithTag("_DataCollector");
		_DataCollector = _DataCollectorGameObject.GetComponent<DataCollector>();

		_DataCollector.triggerDataCollector = true;

		SceneManager.LoadScene((int)ID.Scenes.Home);
	}

	public void OnClickHome()
    {
		SceneManager.LoadScene((int)ID.Scenes.Home);
    }

	public void OnClickARAdd()
    {
		SceneManager.LoadScene((int)ID.Scenes.ARAdd);
    }

	public void OnClickARAView()
    {
		SceneManager.LoadScene((int)ID.Scenes.ARView);
    }

	public void OnClickARAddNew()
    
    {
        _DataCollectorGameObject = GameObject.FindWithTag("_DataCollector");
        _DataCollector = _DataCollectorGameObject.GetComponent<DataCollector>();
		if(_ARAddManager.ARAddType == 1){
			_ShooterManager.TriggerShoot = true;
		}
        _DataCollector.triggerDataCollector = true;
    }

	public void OnClickARAddNext(){
		if((_ARAddCounter >= 0)&& (_ARAddCounter <= _ARAddAmount)){
			_ARAddCounter++;
		}
	}

	public void OnClickARAddPrevious(){
		if ((_ARAddCounter >= 0) && (_ARAddCounter <= _ARAddAmount))
        {
            _ARAddCounter--;
        }
    } 
    
}
