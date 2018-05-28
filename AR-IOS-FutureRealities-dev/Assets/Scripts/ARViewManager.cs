// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FutureRealities;


using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class ARViewManager : MonoBehaviour
{
	public bool created = false;

	public GameObject ARAdd_1;
	public GameObject ARAdd_2;
	public GameObject ARAdd_3;

	public GameObject ARAdd;
	public int ARAddType;

	public static DataCollector Instance;
	private DatabaseReference db;

	string _ARName;
	string _ARText;
	float _ARlocalLatitude;
	float _ARAlocalLongitude;
	Vector3 _ARlocalPosition;

	// Use this for initialization
	void Start()
	{
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ar-futurerealities-dev.firebaseio.com/");
		db = FirebaseDatabase.DefaultInstance.RootReference;
		DontDestroyOnLoad(this.gameObject);
		created = true;
		db.GetValueAsync().ContinueWith(task =>
		{
			if (task.IsFaulted)
			{

			}
			else if (task.IsCompleted)
			{
				DataSnapshot snapshot = task.Result;

				foreach (DataSnapshot _seccion in snapshot.Children)
				{
					foreach (DataSnapshot _ARData in _seccion.Children)
					{
						string _ARDataMach = _ARData.Key.Split('-')[0];
						if (_ARDataMach == "ARData")
						{
							foreach (DataSnapshot _ARDataKey in _ARData.Children)
							{
								if (_ARDataKey.Key == "_NewARAddName")
								{
									_ARName = (string)_ARDataKey.Value;

								}
								if (_ARDataKey.Key == "_NewARAddText")
								{
									_ARText = (string)_ARDataKey.Value;

								}
								if (_ARDataKey.Key == "_NewARAddlocalLatitude")
								{
									_ARlocalLatitude = float.Parse((string)_ARDataKey.Value);

								}
								if (_ARDataKey.Key == "_NewARAddlocalLongitude")
								{
									_ARAlocalLongitude = float.Parse((string)_ARDataKey.Value);

								}
								if (_ARDataKey.Key == "_NewARAddlocalPosition")
								{
									char[] CharTrim = { '(', ')' };
									string value = (string)_ARDataKey.Value;
									value = value.Trim(CharTrim);
									string[] values = value.Split(',');
									_ARlocalPosition = new Vector3(float.Parse(values[0]), float.Parse(values[1]), float.Parse(values[2]));
								}
							}
							if (_ARName == ARAdd_1.name)
							{
								GameObject instance = Instantiate(ARAdd_1);
								instance.transform.position = _ARlocalPosition;
							}
							else if (_ARName == ARAdd_2.name)
							{
								GameObject instance = Instantiate(ARAdd_2);
								foreach (Transform child in instance.transform)
								{
									foreach (Transform _child in child.transform)
									{
										if (_child.name == "Canvas")
										{
											foreach (Transform __child in _child.transform)
											{
												foreach (Transform ___child in __child)
												{
													Text childText = ___child.GetComponent<Text>();
													childText.text = _ARText;
												}
											}
										}
									}
								}
								instance.transform.position = _ARlocalPosition;
							}
							else if (_ARName == ARAdd_3.name)
							{
								GameObject instance = Instantiate(ARAdd_3);
								instance.transform.position = _ARlocalPosition;
							}
						}
					}
				}
			}
		});
	}

	// Update is called once per frame
	void Update()
	{

	}
}
