// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UVAnimation : MonoBehaviour
{

    public bool State;
    public int UVy = 22;
    public int UVx = 22;
    public int ftps = 25;
    private int index;
    Vector2 size;
    Vector2 Offset;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        index = (int)(Time.time * ftps);
        index = index % (UVy * UVx);
        size = new Vector2(1.0f / UVy, 1.0f / UVx);

        UVAnimationRunning(State);
    }

    void UVAnimationRunning(bool state)
    {
        var Uindex = index % UVy;
        var Vindex = index / UVx;
        if (state)
        {
            if (Uindex == 0 && Vindex == 0)
            {
                Uindex = 1;
                Vindex = 0;
            }
        }

        Offset = new Vector2(Uindex * size.x, 1.0f * size.y - Vindex * size.y);
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", Offset);
        GetComponent<Renderer>().material.SetTextureScale("_MainTex", size);
    }
}