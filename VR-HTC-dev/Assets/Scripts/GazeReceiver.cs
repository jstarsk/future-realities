// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeReceiver : MonoBehaviour
{
    private bool isGazeFrame = false;
    private bool isGazeFrameOld = false;

    public bool receive = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGazeFrameOld ^ isGazeFrame)
        {
            if (isGazeFrame)
            {
                gameObject.SendMessage("OnGazeBegin", SendMessageOptions.DontRequireReceiver);
            }
            else
            {
                gameObject.SendMessage("OnGazeEnd", SendMessageOptions.DontRequireReceiver);
            }
        }
        if (isGazeFrame)
        {
            gameObject.SendMessage("OnGazing", SendMessageOptions.DontRequireReceiver);
        }

        isGazeFrameOld = isGazeFrame;
        isGazeFrame = false;
    }

    public void OnGazeFrame()
    {
        isGazeFrame = true;
    }
}