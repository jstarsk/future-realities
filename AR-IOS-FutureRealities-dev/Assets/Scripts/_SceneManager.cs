// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour {

	private void Awake()
	{
		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_SceneManager_();
	}

	private void _SceneManager_(){
		if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            
        }
		else if (SceneManager.GetActiveScene().buildIndex == 1)
        {

        }
		else if (SceneManager.GetActiveScene().buildIndex == 2)
        {

        }
		else if (SceneManager.GetActiveScene().buildIndex == 3)
        {

        }
		else if (SceneManager.GetActiveScene().buildIndex == 4)
        {

        }
	}
}
