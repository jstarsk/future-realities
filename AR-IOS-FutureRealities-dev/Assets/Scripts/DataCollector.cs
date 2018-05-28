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

using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class DataCollector : MonoBehaviour {

	public bool created = false;
	public bool triggerDataCollector;
	private bool _GetLoginSceneGameObjects;
	private bool _GetARAddSceneGameObjects;

	System.Guid _GUID;
	private int _counter;
	private GameObject _Name;
	private Text _NameText;
	private GameObject _Age;
	private Text _AgeText;
	private GameObject _Gender;
	private Text _GenderText;
	private GameObject _Local;
	private bool _LocalBool;

	private GameObject _NewARAdd;
	private GameObject _NewARAdd_;
	private ARAddManager _ARAddManager;
	private GameObject _ARAdd;
	private Text _NewARAdd_Text;
	private GameObject _NewARAddAll;

	public static DataCollector Instance;
    private DatabaseReference db;

	public float Latitude = 99.99999f;
    public float Longitude = 99.99999f;
	private bool _GetHomeSceneGameObjects;
    private GameObject _GPSLocalitation;
    private GPSLocalitation _GPSLocalitation_;
    

	void Awake()
    {
        if (!created)
        {
			FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(ID.GoogleFirebaseApi);
			db = FirebaseDatabase.DefaultInstance.RootReference;
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		DataCollectorManager();
	}

	private void DataCollectorManager(){
		if ((SceneManager.GetActiveScene().name == ID.SceneNames[(int)ID.Scenes.Login]) && !_GetLoginSceneGameObjects)
		{
			_Name = GameObject.FindWithTag("_Name");
			_NameText = _Name.GetComponent<Text>();
			_Age = GameObject.FindWithTag("_Age");
			_AgeText = _Age.GetComponent<Text>();
			_Gender = GameObject.FindWithTag("_Gender");
			_GenderText = _Gender.GetComponent<Text>();
			_Local = GameObject.FindWithTag("_Local");
			_LocalBool = _Local.GetComponent<Toggle>();

			_GetLoginSceneGameObjects = true;
		}
		else
		{
			_GetLoginSceneGameObjects = false;
		}
		if ((SceneManager.GetActiveScene().name == ID.SceneNames[(int)ID.Scenes.ARAdd]) && !_GetARAddSceneGameObjects)
		{
			_NewARAdd = GameObject.FindWithTag("_NewARAdd");
			_ARAddManager = _NewARAdd.GetComponent<ARAddManager>();

			_GetARAddSceneGameObjects = true;
		}
		else
		{
			_GetARAddSceneGameObjects = false;
		}

		// DATA
		if (triggerDataCollector && (SceneManager.GetActiveScene().name == ID.SceneNames[(int)ID.Scenes.Login]))
		{
			_GUID = System.Guid.NewGuid();
			_counter = 0;
			writeNewUser(_GUID.ToString(), _NameText.text, _AgeText.text, _GenderText.text, _LocalBool.ToString());
			triggerDataCollector = false;
		}
		else if (triggerDataCollector && (SceneManager.GetActiveScene().name == ID.SceneNames[(int)ID.Scenes.ARAdd]))
        {
			_ARAdd = _ARAddManager.ARAdd;
			_GPSLocalitation = GameObject.FindWithTag("_GPSLocalitation");
            _GPSLocalitation_ = _GPSLocalitation.GetComponent<GPSLocalitation>();
			if(_ARAdd.tag == "_ARAdd_DataText")
			{
				_NewARAdd_ = GameObject.FindWithTag("_ARAddText");
				_NewARAdd_Text = _NewARAdd_.GetComponent<Text>();
				writeNewARAddData(_GUID.ToString(), _ARAdd.name, _ARAdd.transform.position.ToString(), _GPSLocalitation_.Latitude.ToString(), _GPSLocalitation_.Longitude.ToString(), _NewARAdd_Text.text);
			}
			else if (_ARAdd.tag == "_ARAddTarget")
            {
				//Score
            }
			else if ((_ARAdd.tag != "_ARAdd_DataText") && (_ARAdd.tag != "_ARAddTarget"))
			{
				writeNewARAddData(_GUID.ToString(), _ARAdd.name, _ARAdd.transform.position.ToString(), _GPSLocalitation_.Latitude.ToString(), _GPSLocalitation_.Longitude.ToString());
			}
			triggerDataCollector = false;
        }
	}

	private void writeNewUser(string _userId, string _name, string _age, string _gender, string _local)
	{
		db.Child(_userId).Child("_name").SetValueAsync(_name);
		db.Child(_userId).Child("_age").SetValueAsync(_age);
		db.Child(_userId).Child("_gender").SetValueAsync(_gender);
		db.Child(_userId).Child("_local").SetValueAsync(_local);

	}

	private void writeNewARAddData(string _userId, string _NewARAddName, string _NewARAddlocalPosition, string _Latitude, string _Longitude, string _Text)
    {
		db.Child(_userId).Child(string.Format("ARData-{0}-{1}", _userId, _counter)).Child("_NewARAddName").SetValueAsync(_NewARAddName);
        db.Child(_userId).Child(string.Format("ARData-{0}-{1}", _userId, _counter)).Child("_NewARAddlocalPosition").SetValueAsync(_NewARAddlocalPosition);
        db.Child(_userId).Child(string.Format("ARData-{0}-{1}", _userId, _counter)).Child("_NewARAddlocalLatitude").SetValueAsync(_Latitude);
        db.Child(_userId).Child(string.Format("ARData-{0}-{1}", _userId, _counter)).Child("_NewARAddlocalLongitude").SetValueAsync(_Longitude);
        db.Child(_userId).Child(string.Format("ARData-{0}-{1}", _userId, _counter)).Child("_NewARAddText").SetValueAsync(_Text);
        _counter++;

    }

	private void writeNewARAddData(string _userId, string _NewARAddName, string _NewARAddlocalPosition, string _Latitude, string _Longitude)
    {
        db.Child(_userId).Child(string.Format("ARData-{0}-{1}", _userId, _counter)).Child("_NewARAddName").SetValueAsync(_NewARAddName);
        db.Child(_userId).Child(string.Format("ARData-{0}-{1}", _userId, _counter)).Child("_NewARAddlocalPosition").SetValueAsync(_NewARAddlocalPosition);
        db.Child(_userId).Child(string.Format("ARData-{0}-{1}", _userId, _counter)).Child("_NewARAddlocalLatitude").SetValueAsync(_Latitude);
        db.Child(_userId).Child(string.Format("ARData-{0}-{1}", _userId, _counter)).Child("_NewARAddlocalLongitude").SetValueAsync(_Longitude);
        _counter++;

    }
}
