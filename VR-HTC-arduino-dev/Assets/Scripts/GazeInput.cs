// By Starsky Lara
// starsk@noumena.io
// Future Realities Seminar - IAAC - Institute for Advanced Architecture of Catalonia
// under a Creative Commons Attribution-ShareAlike 3.0 Unported License.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeInput : MonoBehaviour
{

    public bool Enabled = true;
    public bool parentRecursive = true;
    CrossHair crossHair;

    // Use this for initialization
    void Start()
    {
        crossHair = GetComponentInChildren<CrossHair>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enabled)
        {
            RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward);

            foreach (var hit in hits)
            {
                GazeReceiver receiver = hit.collider.gameObject.GetComponent<GazeReceiver>();
                if (parentRecursive)
                {
                    receiver = hit.collider.gameObject.GetComponentInParent<GazeReceiver>();
                }
                else
                {
                    receiver = hit.collider.gameObject.GetComponent<GazeReceiver>();
                }
                if (receiver)
                {
                    if (receiver.receive)
                    {
                        receiver.OnGazeFrame();
                    }
                }
            }
        }

        //crossHair.Enabled = Enabled;
    }

    void OnDrawGizmos()
    {
        if (Enabled)
        {
            Color c = Gizmos.color;
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * 100);
            Gizmos.color = c;
        }
    }
}
