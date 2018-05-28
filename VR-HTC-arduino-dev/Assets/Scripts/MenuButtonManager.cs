// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonManager : MonoBehaviour {

    private GameObject _VRroom;
    private Transform _NewLocVRroom;
    private ArduinoCommunication _ArduinoCommunication;

    public bool Trigger;


    public GameObject NewLocVRroom;
    public bool IsTriggerExit;

    // Use this for initialization
    void Start () {
        _VRroom = GameObject.FindWithTag("VRroom");
        _NewLocVRroom = NewLocVRroom.GetComponent<Transform>();
        _ArduinoCommunication = GetComponent<ArduinoCommunication>();

    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);

        if (!IsTriggerExit)
        {
            _VRroom.transform.position = _NewLocVRroom.transform.position;
            _ArduinoCommunication.DataToArduino = "H";

        }
        else if (IsTriggerExit)
        {
            Trigger = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (IsTriggerExit)
        {
            Trigger = false;
        }
    }
}
