// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoCommunication : MonoBehaviour {
    //OSX
    //SerialPort stream = new SerialPort("/dev/cu.usbmodem1411", 9600);
    //WIN
    SerialPort stream = new SerialPort("COM3", 9600);

    public string DataToArduino;

	// Use this for initialization
	void Start () {
        stream.Open();
        stream.ReadTimeout = 1;
	}

    // Update is called once per frame
    void Update()
    {
        ArduinoCommunicationManager();
    }

    void ArduinoCommunicationManager()
    {
        if (DataToArduino == "H")
        {
            stream.Write(DataToArduino);
            Debug.Log(DataToArduino);
            stream.BaseStream.Flush();
        }
    }
}
