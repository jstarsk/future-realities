using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoCommunication : MonoBehaviour {

    SerialPort stream = new SerialPort("/dev/cu.usbmodem1411", 9600);


	// Use this for initialization
	void Start () {
        stream.Open();
        stream.ReadTimeout = 1;
	}

    // Update is called once per frame
    void Update()
    {
        //string value = stream.ReadLine();
        //Debug.Log(value);
        //stream.Write("H");
        //stream.BaseStream.Flush();
        //string value = stream.ReadLine();
        //Debug.Log(value);
        //stream.BaseStream.Flush();

        if (Input.GetKeyDown(KeyCode.N))
        {
            stream.Write("N");
            Debug.Log("N");
            stream.BaseStream.Flush();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            stream.Write("E");
            Debug.Log("E");
            stream.BaseStream.Flush();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            stream.Write("W");
            Debug.Log("W");
            stream.BaseStream.Flush();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            stream.Write("X");
            Debug.Log("X");
            stream.BaseStream.Flush();
        }
    }
}
