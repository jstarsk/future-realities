// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{

    public bool Enabled = true;
    Renderer renderer;

    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = Enabled;
    }

    // Update is called once per frame
    void Update()
    {
        renderer.enabled = Enabled;
    }
}
