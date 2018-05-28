using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClickLogin(){
		SceneManager.LoadScene(2);
	}

	public void OnClickHome()
    {
		SceneManager.LoadScene(2);
    }

	public void OnClickBocadilloAdd()
    {
		SceneManager.LoadScene(3);
    }

	public void OnClickEmojiAdd()
    {
		SceneManager.LoadScene(4);
    }

	public void OnClickARCameraAdd()
    {
		//SceneManager.LoadScene();
		Debug.Log("TO DO");
    }
}
